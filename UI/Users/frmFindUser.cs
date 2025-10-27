using BankProjectUi;
using Business;
using BusinessLayer;
using Common;
using DataAccesLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Properties;
using static BusinessLayer.UserBusiness;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BankPresentationLayer
{
    public partial class frmFindUser : Form
    {
        public frmFindUser()
        {
            InitializeComponent();
        }

        UserBusiness UserObject;

        private void frmFindUser_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            cbSearchMethod.SelectedIndex = 0;
        }

        private void FillPhonesCombobox()
        {
            cbPhoneNumbers.Items.Clear();
            cbPhoneNumbers.SelectedIndex = -1;
            DataTable dtPhones = PhoneBusiness.FindPhones(UserObject.PersonId);

            if(dtPhones != null && dtPhones.Rows.Count > 0)
            {

                foreach(DataRow dr in dtPhones.Rows)
                {
                    cbPhoneNumbers.Items.Add(dr[2]);
                }

            }
            else
            {
                lblNoPhonesShowLabel.Visible = true;
                return;
            }
        }

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

        private void FillFormWithUserInfo()
        {
            lblFirstName.Text = UserObject.FirstName;
            lblLastName.Text = UserObject.LastName;
            lblEmail.Text = UserObject.Email;
            lblAddress.Text = UserObject.Address;
            lblGender.Text = Convert.ToString(UserObject.Gender);
            lblBirthDate.Text = UserObject.BirthDate.ToString("MM/dd/yyyy");
            lblCountry.Text = CountryBusiness.Find(UserObject.CountryId).CountryName;

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

            if (string.IsNullOrEmpty(UserObject.ImageUrl))
            {
                pbPirsonalPicture.ImageLocation = string.Empty;
            }
            else
            {
                pbPirsonalPicture.ImageLocation = Path.Combine(Utility.GetRootPath() , UserObject.ImageUrl);
            }

            FillPermissionsLabels();
            FillPhonesCombobox();

            //Get Country Flag
            string FlagPathRelative = CountriesDataAccess.GetCountryFlag(UserObject.CountryId);
            string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
            pbCountryFlag.Image = Image.FromFile(FlagPathFull);

        }

        private void SearchBySelectedMethod()
        {
            switch (cbSearchMethod.SelectedItem.ToString())
            {

                case "User Name":
                    UserObject = UserBusiness.FindUser(txtSearchBy.Text);
                    if (UserObject == null)
                    {
                        MessageBox.Show($"User with username [{txtSearchBy.Text}] is not found.");
                    }
                    else
                    {
                        FillFormWithUserInfo();
                    }
                    break;

                case "User Id":
                    UserObject = UserBusiness.FindUser(Convert.ToInt32(txtSearchBy.Text));
                    if (UserObject == null)
                    {
                        MessageBox.Show($"User with User Id [{txtSearchBy.Text}] is not found.");
                    }
                    else
                    {
                        FillFormWithUserInfo();
                    }
                    break;

                case "Email":
                    UserObject = UserBusiness.FindUserByEmail(txtSearchBy.Text);
                    if (UserObject == null)
                    {
                        MessageBox.Show($"User with  Email [{txtSearchBy.Text}] is not found.");
                    }
                    else
                    {
                        FillFormWithUserInfo();
                    }
                    break;

                case "Person Id":
                    UserObject = UserBusiness.FindUserByPersonId(Convert.ToInt32(txtSearchBy.Text));
                    if (UserObject == null)
                    {
                        MessageBox.Show($"User with Person Id [{txtSearchBy.Text}] is not found.");
                    }
                    else
                    {
                        FillFormWithUserInfo();
                    }
                    break;

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
            lblCountry.Text = "N/A";
            lblUserName.Text = "N/A";
            lblPassword.Text = "N/A";

            pbPirsonalPicture.ImageLocation = null;
            pbPirsonalPicture.Image = Resources.no_image_white;

            cbPhoneNumbers.Items.Clear();
            cbPhoneNumbers.SelectedIndex = -1;

            lblListClients.Text = "N/A";
            lblUpdateClient.Text = "N/A";
            lblAddClient.Text = "N/A";
            lblFindClient.Text = "N/A";
            lblDeleteClient.Text = "N/A";
            lblTransactions.Text = "N/A";
            lblManageUsers.Text = "N/A";

            pbCountryFlag.Image = Resources.no_image_white;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ClearForm();
            SearchBySelectedMethod();
        }

        private void cbSearchMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSeachMethod.Text = cbSearchMethod.SelectedItem.ToString();
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
