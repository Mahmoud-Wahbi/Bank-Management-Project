using BankProjectUi;
using BusinessLayer;
using Common;
using DataAccesLayer;
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
using UI;
using UI.Properties;

namespace BankPresentationLayer
{
    public partial class frmWithdraw : Form
    {
        public frmWithdraw()
        {
            InitializeComponent();
        }


        ClientsBusiness ClientObject;
        Countries_CurenciesBusiness Country_Currency;

        private void SetCountryFlags()
        {
            string FlagPathRelative = CountriesDataAccess.GetCountryFlag(ClientObject.CountryId);
            string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
            txtWithdrawAmount.IconLeft = Image.FromFile(FlagPathFull);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!ValidateAccountNumber())
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
              
                btnWithdraw.Enabled = true;      
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
                    string PersonalImageFullPath =Path.Combine(RootPath, ClientObject.ImageUrl);
                    pbPersonalPicture.ImageLocation = PersonalImageFullPath;
                }
                SetCountryFlags();
            }
        }


        private void ClearForm()
        {
            
            btnWithdraw.Enabled = false;
            btnExchange.Enabled= false;

            pbPersonalPicture.ImageLocation = null;
            pbPersonalPicture.Image = Resources.no_image_white;

            lblFirstName.Text = lblLastName.Text = lblEmail.Text = lblPinCode.Text = lblAccountNumber.Text = lblBalance.Text = lblCurrency.Text = "N/A";

            cbPhones.Items.Clear();
            cbPhones.SelectedIndex = -1;

            lblNoPhones.Visible = false;

            txtAccountNumber.Text = string.Empty;

            txtWithdrawAmount.Text = string.Empty;

            txtNotes.Text = string.Empty;

            txtWithdrawAmount.IconLeft = null;
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

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (!ValidateAmountAndNotes())
                return;

                Decimal WithdrawAmount = Convert.ToDecimal(txtWithdrawAmount.Text);
                string ErrorMessage = string.Empty;

                if (WithdrawAmount >= 0)
                {

                    if (MessageBox.Show("Please Confirm Withdrawing balance", "Withdrawing Balance confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question
                                , MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {

                        if (ClientObject.TryUpdateBalance(WithdrawAmount * -1, ClientObject.ClientId, ref ErrorMessage ,true, txtNotes.Text))
                        {

                            MessageBox.Show($"Balance Updated Successfully new balanse is [{ClientObject.Balance.ToString()}]");
                            lblBalance.Text = ClientObject.Balance.ToString("N2");
                            txtWithdrawAmount.Text = string.Empty;

                    }
                    else
                        {
                            MessageBox.Show($"Error : {ErrorMessage}");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Error : Withdraw Amount Must Be Positive.");
                }



            errorProvider1.SetError(txtWithdrawAmount,"");
            lblUSDAmount.Text = "N/A";
            lblUSDAmount.ForeColor = Color.Green;
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
            if (!decimal.TryParse(txtWithdrawAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal balance) || balance <= 0)
            {
                errorProvider1.SetError(txtWithdrawAmount, "Amount must be a positive number (decimals allowed).");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtWithdrawAmount, "");
            }

            // Validate Notes length + letters and numbers only
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

        private void frmWithdraw_Load(object sender, EventArgs e)
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

        private void btnExchange_Click(object sender, EventArgs e)
        {
            frmExchange frmExchange = new frmExchange(ClientObject.CountryId);
            frmExchange.ShowDialog();
        }

        private bool ValidateWithdrawAmount()
        {
            bool IsValid = true;

            //Validate Amount
            if (!decimal.TryParse(txtWithdrawAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal balance) || balance <= 0)
            {
                errorProvider1.SetError(txtWithdrawAmount, "Amount must be a positive number (decimals allowed).");
                lblUSDAmount.Text = "Invalid Pattern";
                lblUSDAmount.ForeColor = Color.Red;
                return false;
            }
            else
            {
                errorProvider1.SetError(txtWithdrawAmount, "");
            }

            if (ClientObject == null)
            {
                errorProvider1.SetError(txtWithdrawAmount, "Search for a client first.");
                lblUSDAmount.Text = "N/A";
                lblUSDAmount.ForeColor = Color.Red;
                return false;
            }
            else
            {
                errorProvider1.SetError(txtWithdrawAmount, "");
            }


            return IsValid;
        }

        private void txtWithdrawAmount_TextChanged(object sender, EventArgs e)
        {
            if (!ValidateWithdrawAmount())
                return;

            Countries_CurenciesBusiness CountryCurrencyObject = Countries_CurenciesBusiness.Find(ClientObject.CountryId);
            lblUSDAmount.Text = CountryCurrencyObject.ConvertToUSD(Convert.ToDecimal(txtWithdrawAmount.Text)).ToString("N2");
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
