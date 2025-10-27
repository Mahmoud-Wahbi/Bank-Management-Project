using BankProjectUi;
using BusinessLayer;
using Common;
using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;
using UI.Properties;

namespace BankPresentationLayer
{
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }


        UserBusiness UserObject;
        PhoneBusiness PhoneObject;
        private void FillGenderCombobox()
        {
            cbGender.Items.Add("M");
            cbGender.Items.Add("F");
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

       
        private void frmAddUser_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            FillGenderCombobox();
            _FillCountriesComboBox();

            //Birthdate date time picker  settings
            dtpBirthDate.Value = DateTime.Today.AddYears(-18);
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-120);

        }

      
        private void btnAddToPhonesList_Click(object sender, EventArgs e)
        {
            //Phone Validation
            bool IsValid = true;
            string phone = txtPhone.Text;
            string pattern = @"^\+?\d{8,15}$"; //Valid Phone

            if (!Regex.IsMatch(phone, pattern))
            {
                errorProvider1.SetError(txtPhone, "Enter a valid phone number (8-15 digits, optional + at start). Example: +1234567890 or 0123456789");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtPhone, "");
            }
            if (!IsValid)
                return;

            bool IsPhoneInComboBox = false;

            //Check phone in database
            if (PhoneBusiness.IsPhoneExist(txtPhone.Text))
            {
                MessageBox.Show("Phone is already exist in database.");
                return;
            }

            string PhoneToAdd = txtPhone.Text.ToString();

            foreach (var Item in cbPhones.Items)
            {

                if (PhoneToAdd == Item.ToString())
                    IsPhoneInComboBox = true;

            }

            if (IsPhoneInComboBox != true)
            {
                cbPhones.Items.Add(PhoneToAdd);
            }
            else
            {
                MessageBox.Show($"Phone : {PhoneToAdd} Is Alerady in the list.");
            }

        }

        public void SavePhones()
        {
            foreach (var item in cbPhones.Items)
            {
                PhoneObject = new PhoneBusiness();
                PhoneObject.PhoneNumber = item.ToString();
                PhoneObject.PersonId = UserObject.PersonId;
               
                    if (!PhoneObject.Save())
                    {
                        MessageBox.Show($"Error : Phone {item.ToString()} couldn't be saved");
                    }
            }
        }

        private int GetSelectedPermissions()
        {

            int permissions = 0;

            if (chkAllPermissions.Checked)
            {
                permissions = Convert.ToInt32(chkAllPermissions.Tag);
                return permissions;
            }

            foreach (Control Control in gbPermissions.Controls)
            {

                if (Control is CheckBox chk && chk.Checked == true)
                {
                    permissions += Convert.ToInt32(chk.Tag);
                }

            }
            return permissions;
        }

        private bool TrySaveUserInDataBase()
        {

            UserObject = new UserBusiness();

            UserObject.FirstName = txtFirstName.Text.Trim();
            UserObject.LastName = txtLastName.Text.Trim();
            UserObject.Email = txtEmail.Text.Trim();
            UserObject.Address = txtAddress.Text.Trim();
            UserObject.BirthDate = dtpBirthDate.Value;
            UserObject.Gender = Convert.ToChar(cbGender.SelectedItem);
            UserObject.CountryId = CountryBusiness.GetCountryIdByCountryName(cbCountry.SelectedItem.ToString());
            UserObject.UserName = txtUserName.Text.Trim();
            UserObject.Password = Utility.PasswordEncryption(txtPassword.Text.Trim(),4);

            if (string.IsNullOrEmpty(pbPersonalImage.ImageLocation))
                UserObject.ImageUrl = string.Empty;
            else
                UserObject.ImageUrl = pbPersonalImage.ImageLocation;

            UserObject.Permissions = GetSelectedPermissions();

            if (UserObject.Save())
                return true;
            else
                return false;

        }

        private void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            cbGender.SelectedIndex = 0;
            cbCountry.SelectedIndex = 0;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPhone.Text = string.Empty;
            pbPersonalImage.ImageLocation = string.Empty;
            pbPersonalImage.Image = Resources.no_image_white;

            

            cbPhones.Items.Clear();
            cbPhones.SelectedIndex = -1;

            foreach (Control Control in gbPermissions.Controls)
            {
                if (Control is CheckBox chk)
                {
                    chk.Checked = false;
                }
            }

            //Birthdate date time picker  settings
            dtpBirthDate.Value = DateTime.Today.AddYears(-18);
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-120);

            pbCountryFlag.ImageLocation = null;
            pbCountryFlag.Image = Resources.no_image_white;
        }

        private bool ValidateControls()
        {
            bool IsValid = true;

            // Validate Username
            if (UserBusiness.IsUserExist(txtUserName.Text.Trim()))
            {
                MessageBox.Show($"Username is already exist. {txtUserName.Text.Trim()}");
               return false;
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

            // Validate email

            //Check if email is already exist
            if (PersonDataAccess.IsEmailExist(txtEmail.Text.Trim()))
            {
                MessageBox.Show($"Email couldn't be saved because it's already exist, try another one {txtEmail.Text.Trim()}");
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



            return IsValid;
        }

        private bool _HandlePersonImage()
        {


            if (pbPersonalImage.ImageLocation != null)
            {
                //then we copy the new image to the image folder after we rename it
                string SourceImageFile = pbPersonalImage.ImageLocation.ToString();

                if (Utility.CopyImageToProjectImagesFolder(ref SourceImageFile))
                {
                    pbPersonalImage.ImageLocation = SourceImageFile;
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



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateControls())
                return;

            if (!_HandlePersonImage())
                return;

            if (TrySaveUserInDataBase())
            {
                MessageBox.Show("User Saved Successfuly.");

                SavePhones();

                ClearForm();
            }
            else
            {
                MessageBox.Show("Couldn't save user in database.");

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

        private void llAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = $"C:\\Users\\Mamhoud\\Desktop\\Images";
            openFileDialog1.Title = "Personal Picture";

            openFileDialog1.DefaultExt = ".PNG";

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonalImage.Load(openFileDialog1.FileName);
                llAdd.Visible = false;
                llRemove.Visible = true;
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonalImage.Image = Resources.no_image_white;
            pbPersonalImage.ImageLocation = string.Empty;


            llRemove.Visible = false;
            llAdd.Visible = true;
        }

        private void btnAddUserAccountOnly_Click(object sender, EventArgs e)
        {
            Form frmFindPerson = new frmFindPerson(true);
            frmFindPerson.ShowDialog();
        }

        private void btnDeleteSelectedPhone_Click(object sender, EventArgs e)
        {
            if (cbPhones.SelectedIndex == -1)
            {
                MessageBox.Show("No selected phones.");
            }
            else
            {
                cbPhones.Items.RemoveAt(cbPhones.SelectedIndex);
            }
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FlagPathRelative = CountriesDataAccess.GetCountryFlag(cbCountry.SelectedItem.ToString().Trim());
            string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
            pbCountryFlag.Image = Image.FromFile(FlagPathFull);
        }

        private void ucHideShowPassword1_ToggleStateChanged(object sender, EventArgs e)
        {
           
            //  react AFTER the UserControl has updated its state
            if (ucHideShowPassword1.IsPasswordHidden)
            {
                // If it's now hidden, use the password char
                txtPassword.PasswordChar = '*';
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // If it's now shown, clear the password char
                txtPassword.PasswordChar = '\0'; // The null character shows the text
                txtPassword.UseSystemPasswordChar = false;
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
