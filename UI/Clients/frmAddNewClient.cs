using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankProjectUi;
using BusinessLayer;
using Guna.UI2.WinForms;
using UI;
using UI.Properties;
using System.Text.RegularExpressions;
using System.Net.Mail;
using DataAccesLayer;
using System.IO;
using Common;



namespace BankPresentationLayer
{


    public partial class frmAddNewClient : Form
    {

        ClientsBusiness ClientObject;

        PhoneBusiness PhoneObject;


        public frmAddNewClient()
        {
            InitializeComponent();
        }


        private bool _HandlePersonImage()
        {

             
                if (pbPersonalPicture.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonalPicture.ImageLocation.ToString();

                    if (Utility.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonalPicture.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            
            return true;
        }


        private bool SaveClient()
        {
            bool IsSaved = false;

            ClientObject = new ClientsBusiness();

            ClientObject.FirstName = txtFirstName.Text.Trim();
            ClientObject.LastName = txtLastName.Text.Trim();
            ClientObject.Email = txtEmail.Text.Trim();
            ClientObject.Address = txtAddress.Text.Trim();
            ClientObject.Gender = Convert.ToChar(cbGender.SelectedItem);
            ClientObject.AccountNumber = txtAccountNumber.Text.Trim();
            ClientObject.Balance = Convert.ToDecimal(txtBalance.Text.Trim());

            ClientObject.PinCode = Utility.PasswordEncryption(txtPinCode.Text.Trim(),4);

            ClientObject.CountryId = CountryBusiness.GetCountryIdByCountryName(cbCountry.SelectedItem.ToString());
            ClientObject.BirthDate = dtpBirthDate.Value;

            if (string.IsNullOrEmpty(pbPersonalPicture.ImageLocation))
            {
                ClientObject.ImageUrl = string.Empty;
            }
            else
            {
                ClientObject.ImageUrl = pbPersonalPicture.ImageLocation.ToString();
                llRemovePersonalPicture.Visible = true;
            }

            IsSaved = ClientObject.SaveClient();


            return IsSaved;
        }

        private void ClearForm()
        {
            //Clear Form Data Afte Adding
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtAddPhoneToPhonesCombobox.Text = string.Empty;
            cbPhoneNumbers.Items.Clear();
            txtAccountNumber.Text = string.Empty;
            txtBalance.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            pbPersonalPicture.ImageLocation = null;

            cbCountry.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;

            //Birthdate date time picker  settings
            dtpBirthDate.Value = DateTime.Today.AddYears(-18);
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-120);

            llAddPersonalPicture.Visible = true;
            llRemovePersonalPicture.Visible = false;
            pbPersonalPicture.Image = Resources.no_image_white;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


           if(!ValidateTextBoxes())
            return;

           if(!_HandlePersonImage())
                return;
           

            if (SaveClient())
            {
               
                //Add Client Phone To Phones Table

                foreach (var item in cbPhoneNumbers.Items)
                {
                    PhoneObject = new PhoneBusiness();
                    PhoneObject.PhoneNumber = item.ToString();
                    PhoneObject.PersonId = ClientObject.PersonId;

                    
                        if (!PhoneObject.Save())
                        {
                            MessageBox.Show($"Error : Phone {item.ToString()} couldn't be saved");
                        }
                   
                }


                MessageBox.Show("Client Saved Successfully.");

                ClearForm();
            }
            else
            {
                MessageBox.Show("Client couldn't be saved");

            }
        }

        private void _FillCountriesComboBox()
        {

            DataTable dtCountries = CountryBusiness.GetCountries();

            if (dtCountries.Rows.Count != 0)
            {

                foreach (DataRow dr in dtCountries.Rows)
                {
                    cbCountry.Items.Add(dr[1].ToString());
                }
            }
        }

        private void FillGenderCombobox()
        {
            cbGender.Items.Add("M");
            cbGender.Items.Add("F");
        }

      

        private void frmAddNewClient_Load(object sender, EventArgs e)
        {

            this.DoubleBuffered = true;
            //Fill Gender Combobox
            FillGenderCombobox();

            //Fill Country ComboBox
            _FillCountriesComboBox();

            //Birthdate date time picker  settings
            dtpBirthDate.Value = DateTime.Today.AddYears(-18);
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-120);


            //Suggest a valid unique account number
            txtAccountNumber.Text = ClientsBusiness.GetRandomNextAccountNumber();

        }

        private void llRemovePersonalPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonalPicture.ImageLocation = null;
            pbPersonalPicture.Image = Resources.no_image_white;

            llRemovePersonalPicture.Visible = false;
            llAddPersonalPicture.Visible = true;
        }

        private void btnAddPhoneToCombobox_Click(object sender, EventArgs e)
        {

            //Phone Validation
            bool IsValid = true;
            string phone = txtAddPhoneToPhonesCombobox.Text;
            string pattern = @"^\+?\d{8,15}$"; //Valid Phone

            if (!Regex.IsMatch(phone, pattern))
            {
                errorProvider1.SetError(txtAddPhoneToPhonesCombobox, "Enter a valid phone number (8-15 digits, optional + at start). Example: +1234567890 or 0123456789");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtAddPhoneToPhonesCombobox, "");
            }
            if(!IsValid)
                return;
            //

            bool IsPhoneInComboBox = false;
            
            //Check phone in database
            if(PhoneBusiness.IsPhoneExist(txtAddPhoneToPhonesCombobox.Text))
            {
                MessageBox.Show("Phone is already exist in database.");
                return;
            }

            string PhoneToAdd = txtAddPhoneToPhonesCombobox.Text.ToString();

            foreach (var Item in cbPhoneNumbers.Items)
            {

                if (PhoneToAdd == Item.ToString())
                    IsPhoneInComboBox = true;

            }

            if (IsPhoneInComboBox != true)
            {
                cbPhoneNumbers.Items.Add(PhoneToAdd);
            }
            else
            {
                MessageBox.Show($"Phone : {PhoneToAdd} Is Alerady in the list.");
            }

        }

        private void btnRemoveSelectedPhone_Click(object sender, EventArgs e)
        {
            cbPhoneNumbers.Items.Remove(cbPhoneNumbers.SelectedItem);

            for (int i = cbPhoneNumbers.Items.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(cbPhoneNumbers.Items[i]?.ToString()))
                {
                    cbPhoneNumbers.Items.RemoveAt(i);
                }
            }
        }

        private void llAddPersonalPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = $"C:\\Users\\Mamhoud\\Desktop\\Images";
            openFileDialog1.Title = "Personal Picture";

            openFileDialog1.DefaultExt = ".PNG";

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonalPicture.Load(openFileDialog1.FileName);
                llRemovePersonalPicture.Visible = true;
                llAddPersonalPicture.Visible = false;
            }


        }

        private void btnAddOnlyClient_Click(object sender, EventArgs e)
        {
            Form frmFindPerson = new frmFindPerson(false);
            frmFindPerson.ShowDialog();
        }

      
        private void btnExchange_Click(object sender, EventArgs e)
        {
            if (cbCountry.SelectedIndex == -1)
            {
                frmExchange frmExchange = new frmExchange();
                frmExchange.ShowDialog();
            }
            else
            {
                string CountryName = cbCountry.Text;
                int CountryId = CountryBusiness.GetCountryIdByCountryName(CountryName);
                frmExchange frmExchange = new frmExchange(CountryId);
                frmExchange.ShowDialog();
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

        private bool ValidateTextBoxes()
        {

            bool IsValid = true;

            // Validate first name length + letters only
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                txtFirstName.Text.Length < 2 ||
                txtFirstName.Text.Length > 50 ||
                !Regex.IsMatch(txtFirstName.Text, @"^[A-Za-z]+$")) // letters only
            {
                errorProvider1.SetError(txtFirstName, "First name must be 2-50 letters only (no numbers or symbols) / (no white spaces).");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtFirstName, "");
            }

            // Validate last name length + letters only
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                txtLastName.Text.Length < 2 ||
                txtLastName.Text.Length > 50 ||
                !Regex.IsMatch(txtLastName.Text, @"^[A-Za-z]+$"))
            {
                errorProvider1.SetError(txtLastName, "Last name must be 2-50 letters only (no numbers or symbols) / (no white spaces).");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtLastName, "");
            }

            // Validate Address length 
            if (string.IsNullOrEmpty(txtAddress.Text) ||
                txtAddress.Text.Length < 2 ||
                txtAddress.Text.Length > 100)
            {
                errorProvider1.SetError(txtAddress, "Address must be 2-100 characters, not null.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");
            }

            // Validate Pin Code length + positive numbers only
            if (string.IsNullOrEmpty(txtPinCode.Text) ||
                txtPinCode.Text.Length < 4 ||
                txtPinCode.Text.Length > 20 ||
                !Regex.IsMatch(txtPinCode.Text, @"^[1-9]\d*$")) // positive numbers only
            {
                errorProvider1.SetError(txtPinCode, "Pin code must be 4-20 digits, positive only (no 0 at start).");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtPinCode, "");
            }

            // BirthDate validation
            DateTime birthDate = dtpBirthDate.Value;
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age)) age--; // Adjust if birthday not reached yet

            if (age < 18)
            {
                errorProvider1.SetError(dtpBirthDate, "Age must be 18 years or older.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(dtpBirthDate, "");
            }

            //Account Number Validation

            if (ClientsBusiness.IsClientExistByAccountNumber(txtAccountNumber.Text.Trim()))
            {
                MessageBox.Show($"Client account number is already exist. {txtAccountNumber.Text.Trim()}");
                IsValid = false;
            }
            

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

            //Gender Validation 
            if(cbGender.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbGender , "Gender must be selected");
                IsValid = false;

            }
            else
            {
                errorProvider1.SetError(cbGender , "");
            }

            //Country Validation 
            if (cbCountry.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbCountry, "Country must be selected");
                IsValid = false;

            }
            else
            {
                errorProvider1.SetError(cbCountry, "");
            }

            // Validate email

            //Check if email is already exist
            if (PersonDataAccess.IsEmailExist(txtEmail.Text.Trim()))
            {
                MessageBox.Show($"Email couldn't be saved because it's already exist , try another one {txtEmail.Text.Trim()}");
                IsValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email cannot be empty.");
                IsValid = false;
            }
            else
            {
                try
                {
                    MailAddress m = new MailAddress(txtEmail.Text);

                    string[] parts = txtEmail.Text.Split('@');
                    string localPart = parts[0]; // before @
                    string domainPart = parts[1]; // after @

                    // Check local part length
                    if (localPart.Length < 2 || localPart.Length > 64)
                    {
                        errorProvider1.SetError(txtEmail, "Email username (before @) must be 2-64 characters.");
                        IsValid = false;
                    }
                    // Check domain length
                    else if (domainPart.Length < 3 || domainPart.Length > 255)
                    {
                        errorProvider1.SetError(txtEmail, "Email domain must be 3-255 characters.");
                        IsValid = false;
                    }
                    else
                    {
                        errorProvider1.SetError(txtEmail, ""); // Email is valid
                    }
                }
                catch (FormatException)
                {
                    errorProvider1.SetError(txtEmail, "Invalid email format. Example: user@example.com");
                    IsValid = false;
                }
            }

            //Validate Balance
            if (!decimal.TryParse(txtBalance.Text, out decimal balance))
            {
                errorProvider1.SetError(txtBalance, "Invalid amount");
                IsValid = false;

                if(ClientObject == null)
                    return false;
            }
            else
            {
                errorProvider1.SetError(txtBalance, "");

            }

            if (cbCountry.SelectedIndex == -1)
            {
                errorProvider1.SetError(txtBalance, "You must pick a country first");
                // get out of the function until the user select a country
                return false;
            }
            else
            {
                errorProvider1.SetError(txtBalance, "");
            }


            if (!decimal.TryParse(txtBalance.Text, out decimal amount))
            {
                errorProvider1.SetError(txtBalance, "Invalid amount");
                IsValid = false;

                if (ClientObject == null)
                    return false;
            }
            else
            {
                int CountryId = CountryBusiness.GetCountryIdByCountryName(cbCountry.Text);
                Countries_CurenciesBusiness Currency = Countries_CurenciesBusiness.Find(CountryId);
                Decimal DepositAmountInUSD = Currency.ConvertToUSD(Convert.ToDecimal(txtBalance.Text));
                if (DepositAmountInUSD < 500 || DepositAmountInUSD > 1000000)
                {
                    errorProvider1.SetError(txtBalance, "Amount must reach at least 500$ and max of 1,000,000$");
                    IsValid = false;
                }
                else
                {
                    errorProvider1.SetError(txtBalance, "");
                }
            }

            return IsValid;
        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            if (cbCountry.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(txtBalance.Text))
            {
                if (decimal.TryParse(txtBalance.Text, out decimal balance))
                {
                    if (balance < 0)
                    {
                        lblCurrentDollarBalance.Text = "Invalid amount";
                        lblCurrentDollarBalance.ForeColor = Color.Red;
                        return;
                    }

                    int CountryId = CountryBusiness.GetCountryIdByCountryName(cbCountry.Text);
                    Countries_CurenciesBusiness Currency = Countries_CurenciesBusiness.Find(CountryId);
                    decimal DepositAmountInUSD = Currency.ConvertToUSD(balance);

                    if (DepositAmountInUSD < 500)
                        lblCurrentDollarBalance.ForeColor = Color.Red;
                    else
                        lblCurrentDollarBalance.ForeColor = Color.Green;

                    lblCurrentDollarBalance.Text = DepositAmountInUSD.ToString("N2");
                }
                else
                {
                    lblCurrentDollarBalance.Text = "Invalid amount";
                    lblCurrentDollarBalance.ForeColor = Color.Red;
                }
            }
            else
            {
                lblCurrentDollarBalance.Text = "0.00";
                lblCurrentDollarBalance.ForeColor = Color.Black;
            }
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCountry.SelectedIndex == -1)
                return;

            string FlagPathRelative = CountriesDataAccess.GetCountryFlag(cbCountry.SelectedItem.ToString().Trim());
            string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
            txtBalance.IconLeft = Image.FromFile(FlagPathFull);
        }

      
        private void ucHideShowPassword_ToggleStateChanged(object sender, EventArgs e)
        {
            //  react AFTER the UserControl has updated its state
            if (ucHideShowPassword.IsPasswordHidden)
            {
                // If it's now hidden, use the password char
                txtPinCode.PasswordChar = '*';
                txtPinCode.UseSystemPasswordChar = false;
            }
            else
            {
                // If it's now shown, clear the password char
                txtPinCode.PasswordChar = '\0'; // The null character shows the text
                txtPinCode.UseSystemPasswordChar = false;
            }
        }
    }
}
