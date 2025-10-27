using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankProjectUi;
using BusinessLayer;
using Common;
using DataAccesLayer;
using UI;
using UI.Properties;

namespace BankPresentationLayer
{
    public partial class frmDeposit : Form
    {
        public frmDeposit()
        {
            InitializeComponent();
        }


        ClientsBusiness ClientObject;
        Countries_CurenciesBusiness Country_Currency;

        private void SetCountryFlags()
        {
            string FlagPathRelative = CountriesDataAccess.GetCountryFlag(ClientObject.CountryId);
            string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
            txtDepositAmount.IconLeft = Image.FromFile(FlagPathFull);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(!ValidateAccountNumber())
                return;

            string AccountNumber = txtAccountNumber.Text;

            ClientObject = ClientsBusiness.FindClient(AccountNumber);

            if (ClientObject == null)
            {
                MessageBox.Show($"No Clients exist with account number [{AccountNumber}].");
                ClearForm();
            }
            else
            {
                ClearForm();

                btnDeposit.Enabled = true;
                btnExchange.Enabled = true;

                lblFirstName.Text = ClientObject.FirstName;
                lblLastName.Text = ClientObject.LastName;
                lblEmail.Text = ClientObject.Email;

                //Make sure the pin is hidden
                string originalPinCode = ClientObject.PinCode;
                lblPinCode.Text = new string('*', originalPinCode.Length);

                lblAccountNumber.Text = ClientObject.AccountNumber;
                lblBalance.Text = ClientObject.Balance.ToString("N2");

                Country_Currency = Countries_CurenciesBusiness.Find(ClientObject.CountryId);
                lblCurrency.Text = Country_Currency.CurrencyName;


                if (!GetPhones())
                {
                    lblNoPhones.Visible = true;
                }

                if (string.IsNullOrEmpty(ClientObject.ImageUrl))
                {
                    pbPersonalPicture.ImageLocation = null;
                    pbPersonalPicture.Image = Resources.no_image_white;
                }
                else
                {
                    string RootPath = Utility.GetRootPath();
                    string PersonalImageFullPath = Path.Combine(RootPath, ClientObject.ImageUrl);
                    pbPersonalPicture.ImageLocation = PersonalImageFullPath;
                }

                SetCountryFlags();
            }

        }


        private bool GetPhones()
        {

            bool HasPhone = false;

            DataTable dtPhones = new DataTable();

            dtPhones = PhoneBusiness.FindPhones(ClientObject.PersonId);

            if (dtPhones != null && dtPhones.Rows.Count > 0)
            {
                HasPhone = true;

                foreach (DataRow row in dtPhones.Rows)
                {
                    cbPhones.Items.Add(row["Phone"]);
                }

                cbPhones.Text = dtPhones.Rows[0][2].ToString();
            }
            else
            {
                HasPhone = false;
            }

            return HasPhone;

        }


        private void ClearForm()
        {
            btnDeposit.Enabled = false;
            btnExchange.Enabled = false;

            pbPersonalPicture.ImageLocation = null;
            pbPersonalPicture.Image = Resources.no_image_white;

            lblFirstName.Text = lblLastName.Text = lblEmail.Text = lblPinCode.Text = lblAccountNumber.Text = lblBalance.Text = lblCurrency.Text = "N/A";

            cbPhones.Items.Clear();
            cbPhones.SelectedIndex = -1;

            lblNoPhones.Visible = false;

            txtAccountNumber.Text = string.Empty;

            txtDepositAmount.Text = string.Empty;

            txtNotes.Text = string.Empty;

            txtDepositAmount.IconLeft = null;
        }

        
        private void btnDeposit_Click(object sender, EventArgs e)
        {
          
            if (!ValidateAmountAndNotes())
                return;

            Decimal DepositAmount = Convert.ToDecimal(txtDepositAmount.Text);
            string ErrorMessage = string.Empty;

            if (DepositAmount >= 0 )
            {

                if (MessageBox.Show("Please Confirm adding balance", "Adding Balance confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question
                            , MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    
                    if(ClientObject.TryUpdateBalance(DepositAmount,ClientObject.ClientId , ref ErrorMessage , true, txtNotes.Text ))
                    {

                        MessageBox.Show($"Balance Updated Successfully new balanse is [{ClientObject.Balance.ToString()}]");
                        lblBalance.Text = ClientObject.Balance.ToString("N2");
                        txtDepositAmount.Text = string.Empty;

                    }
                    else
                    {
                        MessageBox.Show($"Error : {ErrorMessage}");
                    }

                }
            }
            else
            {
                MessageBox.Show("Error : Deposit Amount Must Be Positive.");
            }


            errorProvider1.SetError(txtDepositAmount, "");
            lblUSDAmount.Text = "N/A";
            lblUSDAmount.ForeColor = Color.Green;
        }

        private void frmDeposit_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private bool ValidateAccountNumber()
        {
            bool IsValid = true;

            //Account Number Validation
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

        private bool ValidateAmountAndNotes()
        {
            bool IsValid = true;

            //Validate Amount
            if (!decimal.TryParse(txtDepositAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal balance) || balance <= 0)
            {
                errorProvider1.SetError(txtDepositAmount, "Amount must be a positive number (decimals allowed).");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtDepositAmount, "");
            }

            // Validate Notes length
            if (txtNotes.Text.Length > 100)
            {
                errorProvider1.SetError(txtNotes, "Notes should be max of 100 characters.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtNotes, "");
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
            frmExchange frmExchange = new frmExchange(ClientObject.CountryId);
            frmExchange.ShowDialog();
        }

        private bool ValidateDepositAmount()
        {
            bool IsValid = true;

            //Validate Amount
            if (!decimal.TryParse(txtDepositAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal balance) || balance <= 0)
            {
                errorProvider1.SetError(txtDepositAmount, "Amount must be a positive number (decimals allowed).");
                lblUSDAmount.Text = "Invalid Pattern";
                lblUSDAmount.ForeColor = Color.Red;
                return false;
            }
            else
            {
                errorProvider1.SetError(txtDepositAmount, "");
            }

            if (ClientObject == null)
            {
                errorProvider1.SetError(txtDepositAmount, "Search for a client first.");
                lblUSDAmount.Text = "N/A";
                lblUSDAmount.ForeColor = Color.Red;
                return false;
            }
            else
            {
                errorProvider1.SetError(txtDepositAmount, "");
            }


            return IsValid;
        }

        private void txtDepositAmount_TextChanged(object sender, EventArgs e)
        {

            if (!ValidateDepositAmount())
                return;

            Countries_CurenciesBusiness CountryCurrencyObject = Countries_CurenciesBusiness.Find(ClientObject.CountryId);
            lblUSDAmount.Text = CountryCurrencyObject.ConvertToUSD(Convert.ToDecimal(txtDepositAmount.Text)).ToString("N2");
            lblUSDAmount.ForeColor = Color.Green;

        }

        private void ucHideShowPassword_ToggleStateChanged(object sender, EventArgs e)
        {
            if (ClientObject == null)
                return;

            // Make sure you have the original PinCode available (e.g., from Client object)
            string originalPinCode = ClientObject.PinCode;

            if (ucHideShowPassword.IsPasswordHidden)
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
