using BusinessLayer;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankPresentationLayer
{
    public partial class frmAddOnlyUser : Form
    {
        private int PersonIdToAdd;
        public frmAddOnlyUser(int PersonId)
        {
            InitializeComponent();
            PersonIdToAdd = PersonId;
        }

        UserBusiness UserObject;

        private void AddPermisiionsToUser()
        {
            if (chkAllPermissions.Checked)
            {
                UserObject.Permissions = -1;
                return;
            }

            UserObject.Permissions = 0;

            void AddIfChecked(CheckBox chk)
            {
                if (chk.Checked && int.TryParse(chk.Tag?.ToString(), out int val))
                {
                    UserObject.Permissions += val;
                }
            }

            AddIfChecked(chkListClients);
            AddIfChecked(chkAddNewClient);
            AddIfChecked(chkDeleteClient);
            AddIfChecked(chkFindClient);
            AddIfChecked(chkManageUesrs);
            AddIfChecked(chkUpdateClient);
            AddIfChecked(chkTransactions);
        }



        private bool TryAddUser()
        {
            bool AddUserOnly = true;
            UserObject = new UserBusiness(AddUserOnly);

            UserObject.UserName = txtUserName.Text;
            UserObject.Password = Utility.PasswordEncryption(txtPassword.Text.Trim(), 4);
            UserObject.PersonId = PersonIdToAdd;

            AddPermisiionsToUser();

            if (UserObject.Save())
                return true;
            else
                return false;

        }

        private bool ValidateControls()
        {
            bool IsValid = true;

            // Validate Username
            if (UserBusiness.IsUserExist(txtUserName.Text.Trim()))
            {
                MessageBox.Show($"User account number is already exist. {txtUserName.Text.Trim()}");
                IsValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                !Regex.IsMatch(txtUserName.Text, @"^[A-Za-z0-9!@#\$%\^&\*\(\)_\-\+=\.\?]{2,20}$"))
            {
                errorProvider1.SetError(txtUserName,
                    "Username must be 2-20 characters (letters, numbers, and symbols allowed, no spaces).");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");
            }

            // Validate Password
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password) ||
                password.Length < 4 || password.Length > 20 ||
                !Regex.IsMatch(password, @"[0-9].*[0-9].*[0-9].*[0-9]")) // at least one digit
            {
                errorProvider1.SetError(txtPassword,
                    "Password must be 4-20 characters, include at least 4 numbers.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }

            // Validate Confirmed Password
            string Confirmedpassword = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(Confirmedpassword) ||
                Confirmedpassword.Length < 4 || Confirmedpassword.Length > 20 ||
                !Regex.IsMatch(Confirmedpassword, @"[0-9].*[0-9].*[0-9].*[0-9]")) // at least one digit
            {
                errorProvider1.SetError(txtConfirmPassword,
                    "Password must be 4-20 characters, include at least 4 numbers.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }

            return IsValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!ValidateControls())
                return;

            if(txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Please confirm your password","Passwords Are Not Identical.");
                return;
            }

            if (UserBusiness.IsUserExist(txtUserName.Text))
            {
                MessageBox.Show("This user is already exist.");
            }
            else
            {
                if (TryAddUser())
                {
                    MessageBox.Show("User account added successfuly.");
                    //Close the form after adding user account to prevint adding mutiple accounts.
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Couldn't save user in database");
                }
            }

        }

        private void chkAllPermissions_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control Control in gbPermissions.Controls)
            {

                if (Control is CheckBox chk)
                {
                    if (chkAllPermissions.Checked && chk.Text != "All Permissions")
                        chk.Enabled = false;
                    else
                        chk.Enabled = true;

                }
            }
        }

        private void ucHideShowPassword1_ToggleStateChanged(object sender, EventArgs e)
        {
            //  react AFTER the UserControl has updated its state
            if (ucHideShowPassword1.IsPasswordHidden)
            {
                // If it's now hidden, use the password char
                txtPassword.PasswordChar = '*';
                txtPassword.UseSystemPasswordChar = false;

                txtConfirmPassword.PasswordChar = '*';
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // If it's now shown, clear the password char
                txtPassword.PasswordChar = '\0'; // The null character shows the text
                txtPassword.UseSystemPasswordChar = false;

                txtConfirmPassword.PasswordChar = '\0'; // The null character shows the text
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
