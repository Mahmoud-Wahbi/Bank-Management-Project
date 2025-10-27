using BusinessLayer;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using UI;
using UI.Properties;

namespace BankPresentationLayer
{
    public partial class frmAddOnlyClient : Form
    {

        private int PersonIdToAdd;
        PersonBusiness PersonObject = new PersonBusiness();
        public frmAddOnlyClient(int PersonId)
        {
            InitializeComponent();
             PersonIdToAdd = PersonId;
            PersonObject = PersonBusiness.FindPerson(PersonIdToAdd);
        }

        ClientsBusiness ClientObject;

        private bool TryAddClient()
        {
            bool AddOnlyClient = true;
            ClientObject = new ClientsBusiness(AddOnlyClient);

            ClientObject.AccountNumber = txtAccountNumber.Text;
            ClientObject.PinCode = Utility.PasswordEncryption(txtPinCode.Text.Trim(),4);
            ClientObject.Balance = Convert.ToDecimal(txtBalance.Text);
            ClientObject.PersonId = PersonIdToAdd;
            if (ClientObject.SaveClient())
                return true;
            else
                return false;

        }

        //Validate textboxes

        private bool ValidateTextBoxes()
        {

            bool IsValid = true;

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

            // Validate Pin Code length + positive numbers only

            if (txtPinCode.Text != txtConfirmPinCode.Text)
            {
                MessageBox.Show("Pin Codes are not idintical, please confirm your Pin Code.", "Pin Code Error");
                IsValid = false ;
            }

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

            // Validate Confirm Pin Code length + positive numbers only
            if (string.IsNullOrEmpty(txtConfirmPinCode.Text) ||
                txtConfirmPinCode.Text.Length < 4 ||
                txtConfirmPinCode.Text.Length > 20 ||
                !Regex.IsMatch(txtConfirmPinCode.Text, @"^[1-9]\d*$")) // positive numbers only
            {
                errorProvider1.SetError(txtConfirmPinCode, "Pin code must be 4-20 digits, positive only (no 0 at start).");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPinCode, "");
            }


            // Validate Balance
            Countries_CurenciesBusiness CurrencyFromObject = Countries_CurenciesBusiness.Find(PersonObject.CountryId);
            if (!decimal.TryParse(txtBalance.Text, out decimal amountFrom))
            {
                errorProvider1.SetError(txtBalance, "Invalid amount.");
                IsValid = false;
            }
            else
            {
                decimal ConvertedAmountToUSD = CurrencyFromObject.ConvertToUSD(amountFrom);

                if (ConvertedAmountToUSD < 500 || ConvertedAmountToUSD > 1000000)
                {
                    MessageBox.Show("Amount must be (minimum of 500$ and maximum 1,000,000).");
                    IsValid = false;
                }
               
            }

            return IsValid;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBoxes())
                return;
          
                if(TryAddClient())
                {
                    MessageBox.Show("Client account added successfuly");
                    //Close the form after adding client account to prevint adding mutiple accounts.
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Couldn't add client in database.");
                }
        }

        private void btnExchange_Click(object sender, EventArgs e)
        {
            PersonBusiness PersonObject = PersonBusiness.FindPerson(PersonIdToAdd);

            frmExchange frmExchange = new frmExchange(PersonObject.CountryId);

            frmExchange.ShowDialog();
        }

        private void frmAddOnlyClient_Load(object sender, EventArgs e)
        {
            PersonBusiness PersonObject = PersonBusiness.FindPerson(PersonIdToAdd);
            Countries_CurenciesBusiness Currency = Countries_CurenciesBusiness.Find(PersonObject.CountryId);

            lblCountry.Text = Currency.CurrencyName;

        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            Countries_CurenciesBusiness CurrencyFromObject = Countries_CurenciesBusiness.Find(PersonObject.CountryId);

            if (!decimal.TryParse(txtBalance.Text, out decimal amountFrom))
            {

                lblCurrentUSDBalance.Text = "Invalid Amount";
                lblCurrentUSDBalance.ForeColor = Color.Red;
            }
            else
            {
                Decimal ConvertedToUSDAmount = CurrencyFromObject.ConvertToUSD(amountFrom);

                if(ConvertedToUSDAmount < 0 )
                {
                    lblCurrentUSDBalance.Text = "Invalid Amount";
                    lblCurrentUSDBalance.ForeColor = Color.Red;
                    return;
                }

                if(ConvertedToUSDAmount < 500)
                    lblCurrentUSDBalance.ForeColor= Color.Red;

                lblCurrentUSDBalance.Text = ConvertedToUSDAmount.ToString("N2");
                lblCurrentUSDBalance.ForeColor = Color.Green;
            }



        }

        private void ucHideShowPassword1_ToggleStateChanged(object sender, EventArgs e)
        {
            //  react AFTER the UserControl has updated its state
            if (ucHideShowPassword1.IsPasswordHidden)
            {
                // If it's now hidden, use the password char
                txtPinCode.PasswordChar = '*';
                txtPinCode.UseSystemPasswordChar = false;

                txtConfirmPinCode.PasswordChar = '*';
                txtConfirmPinCode.UseSystemPasswordChar = false;
            }
            else
            {
                // If it's now shown, clear the password char
                txtPinCode.PasswordChar = '\0'; // The null character shows the text
                txtPinCode.UseSystemPasswordChar = false;

                txtConfirmPinCode.PasswordChar = '\0'; // The null character shows the text
                txtConfirmPinCode.UseSystemPasswordChar = false;
            }
        }

    }
}
