using BankProjectUi;
using Business;
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

namespace BankPresentationLayer
{
    public partial class frmDeleteClient : Form
    {
        public frmDeleteClient()
        {
            InitializeComponent();
        }


        ClientsBusiness ClientObject;



        private bool ValidateAccountNumberToSearch()
        {

                bool IsValid = true;           
                string accountNumber = txtAccountNumber.Text;
                string pattern = @"^[A-Za-z]\d{1,4}$"; // 1 letter + 1 to 4 digits

                if (!Regex.IsMatch(accountNumber, pattern))
                {
                    errorProvider1.SetError(txtAccountNumber, "Account number must start with a letter followed by 1 to 4 digits. Example: A1 or B1234");
                    IsValid = false;
                }
                else
                {
                    errorProvider1.SetError(txtAccountNumber, "");
                }
            return IsValid;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            if (!ValidateAccountNumberToSearch())
                return;

            string AccountNumber = txtAccountNumber.Text;

            ClientObject = ClientsBusiness.FindClient(AccountNumber);

            if (ClientObject == null)
            {
                MessageBox.Show($"Client With Account Number {AccountNumber} is not exist.");
                ClearForm();
            }
            else
            {           
                lblFirstName.Text = ClientObject.FirstName;
                lblLastName.Text = ClientObject.LastName;
                lblEmail.Text = ClientObject.Email;
                lblAddress.Text = ClientObject.Address;

                if (ClientObject.Gender == 'M')
                {
                    lblGender.Text = "Male";
                }
                else
                {
                    lblGender.Text = "Femaile";
                }

                lblBirthDate.Text = ClientObject.BirthDate.ToString("dd/MM/yyyy");
                lblAccountNumber.Text = ClientObject.AccountNumber;
                //Make sure the pin is hidden
                string originalPinCode = ClientObject.PinCode;
                lblPinCode.Text = new string('*', originalPinCode.Length);


                if (!string.IsNullOrEmpty(ClientObject.ImageUrl))
                {
                    pbPersonalPicture.ImageLocation = Path.Combine(Utility.GetRootPath() , ClientObject.ImageUrl);
                }
                else
                {
                    pbPersonalPicture.Image = Resources.no_image_white;
                }

            }

        }

        private void ClearForm()
        {
            txtAccountNumber.Text = string.Empty;
            lblFirstName.Text = lblLastName.Text = lblEmail.Text = lblAddress.Text = lblGender.Text = lblBirthDate.Text
                   = lblAccountNumber.Text = lblPinCode.Text = "N/A";
            pbPersonalPicture.Image = Resources.no_image_white;
            ClientObject = null;

        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if(ClientObject == null)
            {
                MessageBox.Show("Please search for a client first.");
                return;
            }

            bool IsUserAccountDeletedIfExist = false;

            if (MessageBox.Show($"If you confirmed this operation the client account {ClientObject.AccountNumber}. will be deleted permanently from the database with all of it's recods and accounts in the system : like user account(if exists), transfer logs , phone numbers and etc."
                ,"Permanent Delete Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                bool IsUserTheAdmin = false;

                if (!ClientsBusiness.DeleteClient(ClientObject.ClientId, ref IsUserAccountDeletedIfExist , ref IsUserTheAdmin))
                {
                    if(IsUserTheAdmin == true)
                    {
                        MessageBox.Show("Couldn't Delete The User Account Because It's The [Admin].");
                        ClearForm();
                        return;
                    }

                    MessageBox.Show("Couldn't Delete the client.");
                    ClearForm();

                    return;
                }
                else
                {
                    if (ClientObject.ImageUrl != "")
                    {
                        string OldImage = Path.Combine(Utility.GetRootPath(), ClientObject.ImageUrl);
                        File.Delete(OldImage);
                    }

                    if (IsUserAccountDeletedIfExist)
                    {
                        MessageBox.Show("Client Deleted successfuly , and the client had also a user account it's also deleted.");

                    }
                    else
                    {
                        MessageBox.Show("Client Deleted successfuly");
                    }

                    ClearForm();
                }
            }
        }

        private void btnDeleteOnlyClient_Click(object sender, EventArgs e)
        {
            if (ClientObject == null)
            {
                MessageBox.Show("Please search for a client first.");
                return;
            }
            if (MessageBox.Show($"Are you sure you want to delete Client With Account Number {ClientObject.AccountNumber}? Notice : the client transaction logs and Transfer logs will be deleted. .", "Delete Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
               if (ClientsBusiness.DeleteOnlyClient(ClientObject.ClientId))
                {
    

                    MessageBox.Show("Client account Deleted successfuly");
                   
                    ClearForm();

                }
                else
                {
                    MessageBox.Show("Couldn't Delete the client.");
                    ClearForm();

                }
            }
        }

        private void frmDeleteClient_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

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

        private void ucHideShowPassword1_ToggleStateChanged(object sender, EventArgs e)
        {
            if (ClientObject == null)
                return;

            // Make sure you have the original PinCode available (e.g., from Client object)
            string originalPinCode = ClientObject.PinCode;

            if (ucHideShowPassword1.IsPasswordHidden)
            {
                // If hidden, create a string of asterisks with the same length
                // String constructor: new string(char c, int count)
                lblPinCode.Text = new string('*', originalPinCode.Length);
            }
            else
            {
                // If shown, display the original PinCode
                lblPinCode.Text = originalPinCode;
                lblPinCode.Text = ClientObject.PinCode;
                lblPinCode.Text = Utility.PasswordDecryption(ClientObject.PinCode, 4);
            }
        }
    }
}
