using BankProjectUi;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;
using Common;
using DataAccesLayer;


namespace BankPresentationLayer
{
    public partial class frmFindClient : Form
    {
        public frmFindClient()
        {
            InitializeComponent();
        }

        ClientsBusiness Client;

        private void frmFindClient_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if(cbSearchMethod.Items.Count != 0)
            cbSearchMethod.SelectedItem = "Account Number";

            cbSearchMethod.SelectedIndex = 0;


        }

        private void cbSearchMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSearchBy, "");

            txtSearchBy.Text = string.Empty;

            lblSeachMethod.Text = cbSearchMethod.SelectedItem.ToString();
            ClearFindClientForm();

        }

       

        private void FillPhonesComboBox(int PersonId)
        {
            DataTable dtPhones = PhoneBusiness.GetAllPhones(PersonId);

            if (dtPhones != null && dtPhones.Rows.Count > 0)
            {
                lblNoPhonesShowLabel.Visible = false;

                foreach (DataRow dr in dtPhones.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["Phone"].ToString()))
                    {
                        cbPhoneNumbers.Items.Add(dr["Phone"].ToString());
                    }
                }
            }
            else
            {
                lblNoPhonesShowLabel.Visible = true;
            }

        }

        private  void ClearFindClientForm()
        {

            //Clear phones combobox from previous search.
            cbPhoneNumbers.Items.Clear();
            cbPhoneNumbers.SelectedIndex = -1;
            cbPhoneNumbers.Text = string.Empty;

            lblNoPhonesShowLabel.Visible = false;

            lblFirstName.Text = lblLastName.Text = lblEmail.Text = lblAddress.Text = lblGender.Text = lblBirthDate.Text = lblCountry.Text
                = lblAccountNumber.Text = lblBalance.Text = lblPinCode.Text = "N/A";

            pbPirsonalPicture.ImageLocation = null;

            pbPirsonalPicture.ImageLocation = null;
            pbPirsonalPicture.Image = Resources.no_image_white;

            pbCountryFlag.ImageLocation = null;
            pbCountryFlag.Image = Resources.no_image_white;
        }

        private bool ValidateTextBoxes()
        {
            bool IsValid = true;

            //Account Number Validation

            if (cbSearchMethod.SelectedItem.ToString() == "Account Number")
            { 

                string accountNumber = txtSearchBy.Text;
                string pattern = @"^[A-Za-z]\d{1,4}$"; // 1 letter + 1 to 4 digits

                if (!Regex.IsMatch(accountNumber, pattern))
                {
                    errorProvider1.SetError(txtSearchBy, "Account number must start with a letter followed by 1 to 4 digits. Example: A1 or B1234");
                    IsValid = false;
                }
                else
                {
                    errorProvider1.SetError(txtSearchBy, "");
                }

            }

            // Validate ClientId length + positive numbers only
            if (cbSearchMethod.SelectedItem.ToString() == "Client Id")
            {
               
                if (string.IsNullOrEmpty(txtSearchBy.Text) ||
                    txtSearchBy.Text.Length < 1 ||
                    txtSearchBy.Text.Length > 20 ||
                    !Regex.IsMatch(txtSearchBy.Text, @"^[1-9]\d*$")) // positive numbers only
                {
                    errorProvider1.SetError(txtSearchBy, "ClientId be 1-20 digits, positive only (no 0 at start).");
                    IsValid = false;
                }
                else
                {
                    errorProvider1.SetError(txtSearchBy, "");
                }
            }

            // Validate PersonId length + positive numbers only
            if (cbSearchMethod.SelectedItem.ToString() == "Person Id")
            {
               

                if (string.IsNullOrEmpty(txtSearchBy.Text) ||
                    txtSearchBy.Text.Length < 1 ||
                    txtSearchBy.Text.Length > 20 ||
                    !Regex.IsMatch(txtSearchBy.Text, @"^[1-9]\d*$")) // positive numbers only
                {
                    errorProvider1.SetError(txtSearchBy, "Person Id be 1-20 digits, positive only (no 0 at start).");
                    IsValid = false;
                }
                else
                {
                    errorProvider1.SetError(txtSearchBy, "");
                }
            }

            // Validate email
            if (cbSearchMethod.SelectedItem.ToString() == "Email")
            {
                if (string.IsNullOrWhiteSpace(txtSearchBy.Text))
                {
                    errorProvider1.SetError(txtSearchBy, "Email cannot be empty.");
                    IsValid = false;
                }
                else
                {
                    try
                    {
                        MailAddress m = new MailAddress(txtSearchBy.Text);

                        string[] parts = txtSearchBy.Text.Split('@');
                        string localPart = parts[0]; // before @
                        string domainPart = parts[1]; // after @

                        // Check local part length
                        if (localPart.Length < 2 || localPart.Length > 64)
                        {
                            errorProvider1.SetError(txtSearchBy, "Email username (before @) must be 2-64 characters.");
                            IsValid = false;
                        }
                        // Check domain length
                        else if (domainPart.Length < 3 || domainPart.Length > 255)
                        {
                            errorProvider1.SetError(txtSearchBy, "Email domain must be 3-255 characters.");
                            IsValid = false;
                        }
                        else
                        {
                            errorProvider1.SetError(txtSearchBy, ""); // Email is valid
                        }
                    }
                    catch (FormatException)
                    {
                        errorProvider1.SetError(txtSearchBy, "Invalid email format. Example: user@example.com");
                        IsValid = false;
                    }
                }
            }


            return IsValid;
        }


        private void btnFind_Click(object sender, EventArgs e)
        {

            if (!ValidateTextBoxes())
                return;

           
            //Clear phones combobox from previous search.
            cbPhoneNumbers.Items.Clear();
            cbPhoneNumbers.SelectedIndex = -1;
            cbPhoneNumbers.Text = string.Empty;

            switch (cbSearchMethod.SelectedItem)
            {

                case "Account Number":
                    Client = ClientsBusiness.FindClient(txtSearchBy.Text);
                    break;
                case "Client Id":
                    Client = ClientsBusiness.FindClient(Convert.ToInt32(txtSearchBy.Text));
                    break;
                case "Email":
                    Client = ClientsBusiness.FindClientByEmail(txtSearchBy.Text);
                    break;
                case "Person Id":
                    Client = ClientsBusiness.FindClientByPersonId(Convert.ToInt32(txtSearchBy.Text));
                    break;
            }

            if (Client == null)
            {
                MessageBox.Show("No Clients found in this search operation.");

                ClearFindClientForm();

            }
            else
            {

                FillPhonesComboBox(Client.PersonId);


                lblFirstName.Text = Client.FirstName;
                lblLastName.Text = Client.LastName;
                lblEmail.Text = Client.Email;
                lblAddress.Text = Client.Address;
                lblGender.Text = Convert.ToString(Client.Gender);
                lblBirthDate.Text = Client.BirthDate.ToString("dd/MM/yyyy");
                lblCountry.Text = CountryBusiness.Find(Client.CountryId).CountryName;

                if(! string.IsNullOrEmpty(Client.ImageUrl))
                {
                    pbPirsonalPicture.ImageLocation = Path.Combine(Utility.GetRootPath() , Client.ImageUrl);
                }
                else
                {
                    pbPirsonalPicture.ImageLocation = null;
                    pbPirsonalPicture.Image = Resources.no_image_white;
                }

                lblAccountNumber.Text = Client.AccountNumber;
                //Make sure the pin is hidden
                string originalPinCode = Client.PinCode;
                lblPinCode.Text = new string('*', originalPinCode.Length);
                

                //get Currency name
                Countries_CurenciesBusiness CountryCurrencyObject = Countries_CurenciesBusiness.Find(Client.CountryId);
                if(CountryCurrencyObject != null)
                    lblBalance.Text = Client.Balance.ToString("N2") + "   " + CountryCurrencyObject.CurrencyName;       

                //Clear search textbox
                txtSearchBy.Text = string.Empty;

                //Get Country Flag
                string FlagPathRelative = CountriesDataAccess.GetCountryFlag(Client.CountryId);
                string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
                pbCountryFlag.Image = Image.FromFile(FlagPathFull);

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

        private void ucHideShowPassword1_ToggleStateChanged(object sender, EventArgs e)
        {
            if (Client == null)
                return;

            // Make sure you have the original PinCode available (e.g., from Client object)
            string originalPinCode = Client.PinCode;

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
                lblPinCode.Text = Client.PinCode;
                lblPinCode.Text = Utility.PasswordDecryption(Client.PinCode, 4);
            }
        }
    }
}
