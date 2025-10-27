using BankProjectUi;
using BusinessLayer;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Properties;
using static BusinessLayer.UserBusiness;

namespace BankPresentationLayer
{
    public partial class frmDeleteUser : Form
    {
        public frmDeleteUser()
        {
            InitializeComponent();
        }

        UserBusiness UserObject;

        private void FillPermissionsLabels()
        {
            if (UserObject.HasPermission((int)enPermissions.ListClients))
            {
                lblListClients.Text = "Allowed.";
            }
            else
            {
                lblListClients.Text = "Not Allowed.";
            }

            if (UserObject.HasPermission((int)enPermissions.UpdateClient))
            {
                lblUpdateClient.Text = "Allowed.";
            }
            else
            {
                lblUpdateClient.Text = "Not Allowed.";
            }

            if (UserObject.HasPermission((int)enPermissions.AddNewClient))
            {
                lblAddClient.Text = "Allowed.";
            }
            else
            {
                lblAddClient.Text = "Not Allowed.";
            }

            if (UserObject.HasPermission((int)enPermissions.FindClient))
            {
                lblFindClient.Text = "Allowed.";
            }
            else
            {
                lblFindClient.Text = "Not Allowed.";
            }

            if (UserObject.HasPermission((int)enPermissions.DeleteClient))
            {
                lblDeleteClient.Text = "Allowed.";
            }
            else
            {
                lblDeleteClient.Text = "Not Allowed.";
            }

            if (UserObject.HasPermission((int)enPermissions.Transactions))
            {
                lblTransactions.Text = "Allowed.";
            }
            else
            {
                lblTransactions.Text = "Not Allowed.";
            }

            if (UserObject.HasPermission((int)enPermissions.ManageUsers))
            {
                lblManageUsers.Text = "Allowed.";
            }
            else
            {
                lblManageUsers.Text = "Not Allowed.";
            }
        }
        private void FillLablesWithUserInfo()
        {

            lblFirstName.Text = UserObject.FirstName;
            lblLastName.Text = UserObject.LastName;
            lblEmail.Text = UserObject.Email;
            lblAddress.Text = UserObject.Address;
            lblGender.Text = UserObject.Gender.ToString();
            lblBirthDate.Text = UserObject.BirthDate.ToString("dd/MM/yyyy");
            lblUserName.Text = UserObject.UserName;
            //Make sure the pin is hidden
            if (UserObject.UserName.ToLower() == "admin")
            {
                ucHideShowPassword1.Enabled = false;
                ucHideShowPassword1.Hide();
            }
            else
            {
                ucHideShowPassword1.Enabled = true;
                ucHideShowPassword1.Show();
            }
            string originalPinCode = UserObject.Password;
            lblPassword.Text = new string('*', originalPinCode.Length);

            if (!string.IsNullOrEmpty(UserObject.ImageUrl))
            {
                pbPersonalPic.ImageLocation = Path.Combine(Utility.GetRootPath() , UserObject.ImageUrl);
            }
            else
            {
                pbPersonalPic.ImageLocation = null;
                pbPersonalPic.Image = Resources.no_image_white;
            }

            FillPermissionsLabels();

        }

        private bool ValidateSearchBox()
        {
            bool IsValid = true;

            // Validate Username
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
            return IsValid;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!ValidateSearchBox())
                return;

            UserObject = UserBusiness.FindUser(txtUserName.Text);

            if (UserObject == null)
            {
                MessageBox.Show($"User with username [{txtUserName.Text}] is not found.");
                txtUserName.Text = string.Empty;
                ClearForm();
            }
            else
            {
                FillLablesWithUserInfo();
            }


        }

        private void ClearForm()
        {

            lblFirstName.Text = "N/A";
            lblLastName.Text = "N/A";
            lblEmail.Text = "N/A";
            lblAddress.Text = "N/A";
            lblGender.Text = "N/A";
            lblBirthDate.Text = "N/A";
            lblUserName.Text = "N/A";
            lblPassword.Text = "N/A";

            lblListClients.Text = "N/A";
            lblUpdateClient.Text = "N/A";
            lblUpdateClient.Text = "N/A";
            lblAddClient.Text = "N/A";
            lblFindClient.Text = "N/A";
            lblDeleteClient.Text = "N/A";
            lblTransactions.Text = "N/A";
            lblManageUsers.Text = "N/A";

            pbPersonalPic.ImageLocation = String.Empty;
            pbPersonalPic.Image = Resources.no_image_white;
            txtUserName.Text = String.Empty;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(UserObject == null)
            {
                MessageBox.Show("Please search for a user first.");
                return;
            }

            if (UserObject.UserName == "Admin" || UserObject.UserName == "admin" )
            {
                MessageBox.Show("Can't delete the Admin user from the system.");
                return;
            }

            if (MessageBox.Show($"If you confirmed this operation the user account {UserObject.UserName}. will be deleted permanently from the database with all of it's recods and accounts in the system : like client account(if exists), transfer logs , phone numbers and etc."
                , "Permanent Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning
                    , MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                bool IsClientAccountDeletedIfExist = false;
                if (UserBusiness.DeleteUser(UserObject.UserId, ref IsClientAccountDeletedIfExist))
                {
                    if (!string.IsNullOrEmpty(UserObject.ImageUrl))
                    {
                        string OldImage = Path.Combine(Utility.GetRootPath(), UserObject.ImageUrl);
                        File.Delete(OldImage);
                    }

                    if (IsClientAccountDeletedIfExist)
                    {
                        MessageBox.Show($"User with username [{txtUserName.Text}] deleted successfuly," +
                            $" notice: this user had a client account and it's also deleted.");
                    }
                    else
                    {
                        MessageBox.Show($"User with username [{txtUserName.Text}] deleted successfuly.");
                    }

                    ClearForm();
                }
                else
                {
                    MessageBox.Show($"couldn't delete user with username [{txtUserName.Text}].");
                }
            }

        }

        private void btnDeleteOnlyUser_Click(object sender, EventArgs e)
        {
            if (UserObject == null)
            {
                MessageBox.Show("Please search for a user first.");
                return;
            }

            if (UserObject.UserName == "Admin" || UserObject.UserName == "admin")
            {
                MessageBox.Show("Can't delete the Admin user from the system.");
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete user With username  {UserObject.UserName}?", "Delete Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning
                   , MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

                if(UserBusiness.DeleteOnlyUser(UserObject.UserId))
                {
                    MessageBox.Show($"User with username [{txtUserName.Text}] deleted successfuly.");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show($"couldn't delete user with username [{txtUserName.Text}].");
                }

            }



        }

        private void frmDeleteUser_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ucHideShowPassword1_ToggleStateChanged(object sender, EventArgs e)
        {
            if (UserObject == null)
                return;

            // Make sure you have the original PinCode available (e.g., from Client object)
            string originalPinCode = UserObject.Password;

            if (ucHideShowPassword1.IsPasswordHidden)
            {
                // If hidden, create a string of asterisks with the same length
                // String constructor: new string(char c, int count)
                lblPassword.Text = new string('*', originalPinCode.Length);
            }
            else
            {
                // If shown, display the original PinCode
                lblPassword.Text = originalPinCode;
                lblPassword.Text = UserObject.Password;
                lblPassword.Text = Utility.PasswordDecryption(UserObject.Password, 4);
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (this.MdiParent is MainForm mainForm)
            {
                mainForm.ShowMainControls();
            }
        }
    }
}
