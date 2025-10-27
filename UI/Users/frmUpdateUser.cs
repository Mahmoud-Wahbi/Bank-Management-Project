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
using BankProjectUi;
using BusinessLayer;
using Common;
using DataAccesLayer;
using UI.Properties;
using static BusinessLayer.UserBusiness;
namespace BankPresentationLayer
{
    public partial class frmUpdateUser : Form
    {
        public frmUpdateUser()
        {
            InitializeComponent();
        }


        UserBusiness UserObject;
        PhoneBusiness PhoneObject;


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

            pbPersonalImage.ImageLocation = null;
            pbPersonalImage.Image = Resources.no_image_white;

            cbGender.SelectedIndex = -1;
            cbCountry.SelectedIndex = -1;

            cbPhones.Items.Clear();
            cbPhones.SelectedIndex = -1;

            foreach (Control Control in gbPermissions.Controls)
            {
                if (Control is CheckBox chk)
                {
                    chk.Checked = false;
                }
            }

            llRemove.Visible = false;
            llAdd.Visible = true;

            //Birthdate date time picker  settings
            dtpBirthDate.Value = DateTime.Today.AddYears(-18);
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-120);
        }

        private bool TrySaveUserInDataBase()
        {

            UserObject.FirstName = txtFirstName.Text;
            UserObject.LastName = txtLastName.Text;
            UserObject.Email = txtEmail.Text;
            UserObject.Address = txtAddress.Text;
            UserObject.BirthDate = dtpBirthDate.Value;
            UserObject.Gender = Convert.ToChar(cbGender.SelectedItem);
            UserObject.CountryId = CountryBusiness.GetCountryIdByCountryName(cbCountry.SelectedItem.ToString());
            UserObject.UserName = txtUserName.Text;
            UserObject.Password = Utility.PasswordEncryption(txtPassword.Text.Trim(), 4);

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


        private void FillPhonesCombobox()
        {

            DataTable dtPhones = PhoneBusiness.FindPhones(UserObject.PersonId);

            if (dtPhones != null && dtPhones.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPhones.Rows)
                {
                    cbPhones.Items.Add(dr[2].ToString());
                }
            }
        }

        private void FillUserInfo()
        {
            txtFirstName.Text = UserObject.FirstName;
            txtLastName.Text = UserObject.LastName;
            txtEmail.Text = UserObject.Email;
            txtAddress.Text = UserObject.Address;
            dtpBirthDate.Value = UserObject.BirthDate;
            cbGender.SelectedIndex = cbGender.FindString(UserObject.Gender.ToString());
            cbCountry.SelectedIndex = cbCountry.FindString(CountryBusiness.Find(UserObject.CountryId).CountryName);
            txtUserName.Text = UserObject.UserName;
            txtPassword.Text = Utility.PasswordDecryption(UserObject.Password,4);

            if (string.IsNullOrEmpty(UserObject.ImageUrl))
            {
                pbPersonalImage.ImageLocation = null;
            }
            else
            {
                pbPersonalImage.ImageLocation = Path.Combine(Utility.GetRootPath(), UserObject.ImageUrl);
                llRemove.Visible = true;
            }

            FillPhonesCombobox();
        }

        private void FillPermissionsCheckBoxes()
        {

            if (UserObject.HasPermission((int)enPermissions.All))
            {
                chkAllPermissions.Checked = true;
                return;
            }

            if (UserObject.HasPermission((int)enPermissions.ListClients))
            {
               chkListClients.Checked = true;
            }
            

            if (UserObject.HasPermission((int)enPermissions.UpdateClient))
            {
                chkUpdateClient.Checked = true;
            }
           

            if (UserObject.HasPermission((int)enPermissions.AddNewClient))
            {
                chkAddNewClient.Checked = true;
            }
            

            if (UserObject.HasPermission((int)enPermissions.FindClient))
            {
                chkFindClient.Checked = true;
            }
            

            if (UserObject.HasPermission((int)enPermissions.DeleteClient))
            {
                chkDeleteClient.Checked = true;
            }
            

            if (UserObject.HasPermission((int)enPermissions.Transactions))
            {
                chkTransactions.Checked = true;
            }
            

            if (UserObject.HasPermission((int)enPermissions.ManageUsers))
            {
                chkManageUesrs.Checked = true;
            }

           
            
        }

        private bool ValidateSearchBox()
        {
            bool IsValid = true;

            // Validate Search TextBox
            if (string.IsNullOrWhiteSpace(txtFind.Text) ||
                !Regex.IsMatch(txtFind.Text, @"^[A-Za-z0-9!@#\$%\^&\*\(\)_\-\+=\.\?]{2,20}$"))
            {
                errorProvider1.SetError(txtFind,
                    "Username must be 2-20 characters (letters, numbers, and symbols allowed, no spaces).");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtFind, "");
            }
            return IsValid;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            if (!ValidateSearchBox())
                return;

            UserObject = UserBusiness.FindUser(txtFind.Text);


            ClearForm();

            if (UserObject == null)
            {
                MessageBox.Show($"User with username [{txtFind.Text}] is not found");
                return;
            }
            else
            {
                if (UserObject.UserName == "admin" || UserObject.UserName == "Admin")
                {
                    gbPermissions.Enabled = false;
                    txtUserName.Enabled = false;
                    txtPassword.Enabled = false ;
                }
                else
                {
                    gbPermissions.Enabled = true;
                    txtUserName.Enabled = true;
                    txtPassword.Enabled = true;
                }


                FillUserInfo();
                FillPermissionsCheckBoxes();

                // This resets the error provider if any error is active.
                ValidateControls();
            }

        }

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

        private void frmUpdateUser_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            FillGenderCombobox();
            _FillCountriesComboBox();

            //Birthdate date time picker  settings
            dtpBirthDate.Value = DateTime.Today.AddYears(-18);
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-120);
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

        private bool ValidateControls()
        {
            bool IsValid = true;

            // Validate Username
            if (UserObject != null && txtUserName.Text.Trim() != UserObject.UserName)
            {
                if (UserBusiness.IsUserExist(txtUserName.Text.Trim()))
                {
                    MessageBox.Show($"User account number is already exist. {txtUserName.Text.Trim()}");
                    IsValid = false;
                }
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
            if (UserObject != null && txtEmail.Text.Trim() != UserObject.Email)
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

        private void btnAddPhoneToList_Click(object sender, EventArgs e)
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

        private void btnRemovePhoneFromList_Click(object sender, EventArgs e)
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


        private bool _HandlePersonImage()
        {
            
            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            string OldImagePath = Path.Combine(Utility.GetRootPath(), UserObject.ImageUrl);

            if (OldImagePath != pbPersonalImage.ImageLocation)
            {
                if (UserObject.ImageUrl != "")
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

            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UserObject == null)
            {
                MessageBox.Show("Search for a user first");
                return;
            }

            if (!ValidateControls())
                return;

            if (!_HandlePersonImage())
                return;

            if (UserObject == null)
            {
                MessageBox.Show("Please search for a user first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to update user info?","Update Confirmation",MessageBoxButtons.YesNo , 
                MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (TrySaveUserInDataBase())
                {
                    MessageBox.Show("User information updated successfuly.");
                    SavePhones();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Couldn't save user in database.");
                }
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonalImage.ImageLocation = null;
            pbPersonalImage.Image = Resources.no_image_white;

            llRemove.Visible = false;
            llAdd.Visible = true;
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

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCountry.SelectedItem == null)
                return;

            string FlagPathRelative = CountriesDataAccess.GetCountryFlag(cbCountry.SelectedItem.ToString().Trim());
            string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
            pbCountryFlag.Image = Image.FromFile(FlagPathFull);
        }

        private void ucHideShowPassword1_ToggleStateChanged(object sender, EventArgs e)
        {
            if (UserObject == null)
                return;

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
                txtPassword.Text = Utility.PasswordDecryption(UserObject.Password, 4);
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
