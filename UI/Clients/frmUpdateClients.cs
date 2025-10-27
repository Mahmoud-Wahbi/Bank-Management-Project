using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankProjectUi;
using Business;
using BusinessLayer;
using Common;
using DataAccesLayer;
using UI;
using UI.Properties;

namespace BankPresentationLayer
{
    public partial class frmUpdateClients : Form
    {
        public frmUpdateClients()
        {
            InitializeComponent();
        }


        ClientsBusiness ClientObject;
        PhoneBusiness PhoneObject;

        private void ClearPhonesCombobox()
        {

            cbPhoneNumbers.Items.Clear();
            cbPhoneNumbers.SelectedIndex = -1;
        }

        private void ClearTextBoxes()
        {
            txtSearch.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtAccountNumber.Text = string.Empty;
            txtBalance.Text = string.Empty;
            txtPinCode.Text = string.Empty;
        }

        
        private void ClearForm()
        {
            ClearPhonesCombobox();
            ClearTextBoxes();


            cbCountry.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;

            dtpBirthDate.Value = DateTime.Now.AddYears(-18);
            txtBalance.IconLeft = null;
            pbPersonalPicture.Image = Resources.no_image_white;

            ClientObject = null;

            llAddPicture.Visible = false;
            llRemivePicture.Visible = false;
        }

        private bool ValidateSearchbox()
        {

            bool IsValid = true;

            // Search box validatoin
            string Searchbox = txtSearch.Text;
            string SearchBoxpattern = @"^[A-Za-z]\d{1,4}$"; // 1 letter + 1 to 4 digits

            if (!Regex.IsMatch(Searchbox, SearchBoxpattern))
            {
                errorProvider1.SetError(txtSearch, "Account number must start with a letter followed by 1 to 4 digits. Example: A1 or B1234");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtSearch, "");
            }
            return IsValid;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!ValidateSearchbox())
                return;

            ClearPhonesCombobox();

            ClientObject = ClientsBusiness.FindClient(txtSearch.Text);

            if (ClientObject == null)
            {
                MessageBox.Show($"No Client Found With Account Number {txtSearch.Text}");
                pbPersonalPicture.Image = Resources.no_image_white;
            }
            else
            {

                txtFirstName.Text = ClientObject.FirstName;
                txtLastName.Text = ClientObject.LastName;
                txtEmail.Text = ClientObject.Email;
                txtAddress.Text = ClientObject.Address;

                cbGender.SelectedIndex = cbGender.FindString(ClientObject.Gender.ToString());

                dtpBirthDate.Value = ClientObject.BirthDate;

                cbCountry.SelectedIndex = cbCountry.FindString(CountryBusiness.Find(ClientObject.CountryId).CountryName);


                if (string.IsNullOrEmpty(ClientObject.ImageUrl))
                {
                    llAddPicture.Visible = true;
                    llRemivePicture.Visible = false;
                    pbPersonalPicture.ImageLocation = null;
                    pbPersonalPicture.Image = Resources.no_image_white; 
                }
                else
                {
                    llRemivePicture.Visible = true;
                    pbPersonalPicture.ImageLocation = Path.Combine(Utility.GetRootPath() , ClientObject.ImageUrl);
                }

                txtAccountNumber.Text = ClientObject.AccountNumber;
                txtBalance.Text = ClientObject.Balance.ToString("N2");

      
                txtPinCode.Text = Utility.PasswordDecryption(ClientObject.PinCode,4);

                DataTable dtPhoneNumbers = PhoneBusiness.GetAllPhones(ClientObject.PersonId);
                if (dtPhoneNumbers != null)
                {

                    foreach (DataRow dr in dtPhoneNumbers.Rows)
                    {
                        cbPhoneNumbers.Items.Add(dr["Phone"]);
                    }

                }

               
            }
        }

        private void FillCountriesComboBox()
        {

            DataTable dtCountries = CountryBusiness.GetCountries();

            foreach (DataRow dr in dtCountries.Rows)
            {
                cbCountry.Items.Add(dr["CountryName"]);
            }
        }

        private void frmUpdateClients_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            ClearForm();

            cbGender.Items.Add('M');
            cbGender.Items.Add('F');

            FillCountriesComboBox();

        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            string OldImagePath = Path.Combine(Utility.GetRootPath(), ClientObject.ImageUrl);

            if (OldImagePath != pbPersonalPicture.ImageLocation)
            {
                if (ClientObject.ImageUrl != "")
                {
                    //first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(OldImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

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

            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ClientObject == null)
            {
                errorProvider1.SetError(txtSearch, "Search for a client first.");
                return;
            }

            if (!ValidateTextBoxes())
                return;

            if(!_HandlePersonImage())
                return;

            ClientObject.FirstName = txtFirstName.Text;
            ClientObject.LastName = txtLastName.Text;
            ClientObject.Email = txtEmail.Text;
            ClientObject.Address = txtAddress.Text;
            ClientObject.Gender = Convert.ToChar(cbGender.SelectedItem);
            ClientObject.BirthDate = dtpBirthDate.Value;
            ClientObject.CountryId = CountryBusiness.GetCountryIdByCountryName(cbCountry.SelectedItem.ToString());
            ClientObject.AccountNumber = txtAccountNumber.Text;
            if (decimal.TryParse(txtBalance.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal balance))
            {
                ClientObject.Balance = balance;
            }
            else
            {
                errorProvider1.SetError(txtBalance,"Invalid balance format.");
                return;
            }
            ClientObject.PinCode =Utility.PasswordEncryption(txtPinCode.Text,4);


            if (string.IsNullOrEmpty(pbPersonalPicture.ImageLocation))
            {
                ClientObject.ImageUrl = string.Empty;
            }
            else
            {
                ClientObject.ImageUrl = pbPersonalPicture.ImageLocation;
            }


            if (ClientObject.SaveClient())
            {

                foreach (var item in cbPhoneNumbers.Items)
                {
                    PhoneObject = new PhoneBusiness();
                    PhoneObject.PhoneNumber = item.ToString();
                    PhoneObject.PersonId = ClientObject.PersonId;

                    if (!PhoneBusiness.IsPhoneExist(item.ToString()))
                    {
                        if (!PhoneObject.Save())
                        {
                            MessageBox.Show($"Error : Phone {item.ToString()} couldn't be saved");
                        }
                    }
                }

                MessageBox.Show("Client Saved Succssesfuly.");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Couldn't Save The Client");
            }


        }

        private void llRemivePicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonalPicture.ImageLocation = null;
            pbPersonalPicture.Image = Resources.no_image_white;
            llRemivePicture.Visible = false;
            llAddPicture.Visible = true;
        }

        private void llAddPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = $"C:\\Users\\Mamhoud\\Desktop\\Images";
            openFileDialog1.Title = "Personal Picture";

            openFileDialog1.DefaultExt = ".PNG";

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonalPicture.Load(openFileDialog1.FileName);
                llRemivePicture.Visible = true;
                llAddPicture.Visible = false;
            }


        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            //Phone Validation
            bool IsValid = true;
            string phone = txtPhoneNumber.Text;
            string pattern = @"^\+?\d{8,15}$"; //Valid Phone

            if (!Regex.IsMatch(phone, pattern))
            {
                errorProvider1.SetError(txtPhoneNumber, "Enter a valid phone number (8-15 digits, optional + at start). Example: +1234567890 or 0123456789");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, "");
            }
            if (!IsValid)
                return;
            //

            bool IsPhoneExistInCombobox = false;

            string PhoneToAdd = txtPhoneNumber.Text.Trim();

            foreach (var item in cbPhoneNumbers.Items)
            {
                if (item.ToString() == PhoneToAdd)
                {
                    IsPhoneExistInCombobox = true;
                }
            }

            if (!IsPhoneExistInCombobox)
            {
                cbPhoneNumbers.Items.Add(PhoneToAdd);
            }
            else
            {
                MessageBox.Show($"The Phone {PhoneToAdd} is already in the list.");
            }

        }

        private void btnDeletePhone_Click(object sender, EventArgs e)
        {

            if (cbPhoneNumbers.Items.Count != 0)
            {

                if (cbPhoneNumbers.SelectedIndex != -1)
                {
                    int SelectedIndex = cbPhoneNumbers.SelectedIndex;
                    cbPhoneNumbers.Items.RemoveAt(SelectedIndex);
                }
                else
                {
                    MessageBox.Show("No selected phones , please select a phone to delete.");
                }
            }
            else
            {
                MessageBox.Show("Can't delete phone ,phones list is empty.");
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

            // Validate Address length + letters and numbers only
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
            if (ClientObject != null && txtAccountNumber.Text.Trim() != ClientObject.AccountNumber)
            {
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
            }

            //Gender Validation 
            if (cbGender.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbGender, "Gender must be selected");
                IsValid = false;

            }
            else
            {
                errorProvider1.SetError(cbGender, "");
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
            if (ClientObject != null && txtEmail.Text.Trim() != ClientObject.Email)
            {
                if (PersonDataAccess.IsEmailExist(txtEmail.Text.Trim()))
                {
                    MessageBox.Show($"Email  couldn't be saved because it's already exist {txtEmail.Text.Trim()}");
                    IsValid = false;
                }
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
            if (!decimal.TryParse(txtBalance.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal balance) || balance <= 0)
            {
                errorProvider1.SetError(txtBalance, "Amount must be a positive number (decimals allowed).");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtBalance, "");
            }

            return IsValid;
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

        private void btnExchange_Click(object sender, EventArgs e)
        {
            frmExchange frmExchange = new frmExchange();
            frmExchange.ShowDialog();
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCountry.SelectedItem == null)
                return;

            string FlagPathRelative = CountriesDataAccess.GetCountryFlag(cbCountry.SelectedItem.ToString().Trim());
            string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
            txtBalance.IconLeft = Image.FromFile(FlagPathFull);
        }

  
        private void ucHideShowPassword1_ToggleStateChanged_1(object sender, EventArgs e)
        {
            if (ClientObject == null)
                return;

            //  react AFTER the UserControl has updated its state
            if (ucHideShowPassword1.IsPasswordHidden)
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
                txtPinCode.Text = Utility.PasswordDecryption(ClientObject.PinCode, 4);
            }
        }
    }
}
