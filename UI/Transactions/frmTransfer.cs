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
using Business;
using BusinessLayer;
using Common;
using DataAccesLayer;
using Guna.UI2.WinForms;
using UI;

namespace BankPresentationLayer
{
    public partial class frmTransfer : Form
    {
        public frmTransfer()
        {
            InitializeComponent();
        }

        ClientsBusiness ClientFromObject;
        ClientsBusiness ClientToObject;

        Countries_CurenciesBusiness Country_CurrencyFrom;
        Countries_CurenciesBusiness Country_CurrencyTo;


        private bool ValidateAccountNumber(Guna2TextBox TextBox)
        {
            bool IsValid = true;

            //Account Number Validation
            string accountNumber = TextBox.Text;
            string pattern = @"^[A-Za-z]\d{1,4}$"; // 1 letter + 1 to 4 digits

            if (!Regex.IsMatch(accountNumber, pattern))
            {
                errorProvider1.SetError(TextBox, "Account number must start with a letter followed by 1 to 4 digits. Example: A1 or B1234");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(TextBox, "");
            }

            return IsValid;
        }

        private void ClearForm()
        {
            
            EnableDisableTransfareToInfo(false);
            txtAmount.Text = string.Empty;
            txtNotes.Text = string.Empty;
            txtTransferFrom.Text = string.Empty;
            txtTransferTo.Text = string.Empty;

            lblFirstNameFrom.Text = "N/A";
            lblLastNameFrom.Text = "N/A";
            lblAccountNumberFrom.Text = "N/A";
            lblBalanceFrom.Text = "N/A";
            lblCurrencyNameFrom.Text = "N/A";

            lblFirstNameTo.Text = "N/A";
            lblLastNameTo.Text = "N/A";
            lblAccountNumberTo.Text = "N/A";
            lblBalanceTo.Text = "N/A";
            lblCurrencyNameTo.Text = "N/A";

            
            

            cbTransferCurrency.SelectedIndex = -1;
        }

        private void btnFindCleintFrom_Click(object sender, EventArgs e)
        {
            if (!ValidateAccountNumber(txtTransferFrom))
                return;

            string ClientFromAccountNumber = txtTransferFrom.Text.Trim();
            ClientFromObject = ClientsBusiness.FindClient(ClientFromAccountNumber);

            if (ClientFromObject == null)
            {
                ClearForm();
                MessageBox.Show($"Client with account number [{ClientFromAccountNumber}] is not exsit, try another one.");
            }
            else
            {

                txtTransferTo.Enabled = true;
                btnFindClientTo.Enabled = true;
                gbTransferToInfo.Enabled = true;
                lblTransferTo.Enabled = true;

                lblFirstNameFrom.Text = ClientFromObject.FirstName;
                lblLastNameFrom.Text = ClientFromObject.LastName;
                lblAccountNumberFrom.Text = ClientFromObject.AccountNumber;
                lblBalanceFrom.Text = ClientFromObject.Balance.ToString("N2");

                Country_CurrencyFrom = Countries_CurenciesBusiness.Find(ClientFromObject.CountryId);

                lblCurrencyNameFrom.Text = Country_CurrencyFrom.CurrencyName;

                LoadTransferCurrenciestocombobox();

                //Get Country Flag
                string FlagPathRelative = CountriesDataAccess.GetCountryFlag(ClientFromObject.CountryId);
                string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
                pbCountryFlagFrom.Image = Image.FromFile(FlagPathFull);
            }

        }

       

        private void btnFindClientTo_Click(object sender, EventArgs e)
        {
            if (!ValidateAccountNumber(txtTransferTo))
                return;

            string ClientToAccountNumber = txtTransferTo.Text.Trim();
            ClientToObject = ClientsBusiness.FindClient(ClientToAccountNumber);

            if (ClientToObject == null)
            {
                MessageBox.Show($"Client with account number [{ClientToAccountNumber}] is not exsit, try another one.");
            }
            else
            {
                EnableDisableTransfareToInfo(true);


                lblFirstNameTo.Text = ClientToObject.FirstName;
                lblLastNameTo.Text = ClientToObject.LastName;
                lblAccountNumberTo.Text = ClientToObject.AccountNumber;
                lblBalanceTo.Text = ClientToObject.Balance.ToString("N2");

                Country_CurrencyTo = Countries_CurenciesBusiness.Find(ClientToObject.CountryId);

                lblCurrencyNameTo.Text = Country_CurrencyTo.CurrencyName;

                //Get Country Flag
                string FlagPathRelative = CountriesDataAccess.GetCountryFlag(ClientToObject.CountryId);
                string FlagPathFull = Path.Combine(Utility.GetRootPath(), FlagPathRelative);
                pbCountryFlagTo.Image = Image.FromFile(FlagPathFull);
            }
        }

        private void EnableDisableTransfareToInfo(bool EnableOrDisable)
        {
                gbTransferToInfo.Enabled = EnableOrDisable;
                txtTransferTo.Enabled = EnableOrDisable;
                lblTransferTo.Enabled = EnableOrDisable;
                txtTransferTo.Enabled = EnableOrDisable;
                btnFindClientTo.Enabled = EnableOrDisable;
                lblAmount.Enabled = EnableOrDisable;
                txtAmount.Enabled = EnableOrDisable;
                btnTransfer.Enabled = EnableOrDisable;
                btnExchange.Enabled = EnableOrDisable;
                txtAmount.Enabled= EnableOrDisable;
                txtNotes.Enabled = EnableOrDisable;
                cbTransferCurrency.Enabled = EnableOrDisable;
        }

        private static Decimal GetFees(Decimal Amount)
        {

            if (Amount <= 50000)
            {
                return 0.002M;

            }
            else
            {
                return 0.004M;
            }
        }
       
        private bool RecordTransferLog(int ClientIdFrom, int ClientIdTo, int UserId, Decimal Amount, Decimal Fees,
                                        Decimal SourceBalance, string SourceCurrencyName, Decimal DestinationBalance,
                                        string DestinationCurrencyName, DateTime TransferDate, string Notes , int PersonId)
        {
            bool IsSaved = false;

            Transfer_LogBusiness Transfer_Log = new Transfer_LogBusiness();

            Transfer_Log.ClientIdFrom = ClientIdFrom;
            Transfer_Log.ClientIdTo = ClientIdTo;
            Transfer_Log.UserId = UserId;
            Transfer_Log.SourceBalance = SourceBalance;
            Transfer_Log.SourceCurrencyName = SourceCurrencyName;
            Transfer_Log.DestinationBalance = DestinationBalance;
            Transfer_Log.DestinationCurrencyName = DestinationCurrencyName;
            Transfer_Log.Amount = Amount;
            Transfer_Log.Fees = Fees;
            Transfer_Log.TransferDate = TransferDate;
            Transfer_Log.Notes = Notes;
            Transfer_Log.PersonId = PersonId;

            if(Transfer_Log.Save())
            {
                IsSaved = true;
            }
            else
            {
                IsSaved = false;
            }

            return IsSaved;
        }

        private bool TryTransferBetweenClients(ClientsBusiness ClientFrom, ClientsBusiness ClientTo, ref string ErrorMessage)
        {

            bool IsTransferd = false;

            Decimal InputAmount = Convert.ToDecimal(txtAmount.Text.Trim());

            Decimal SenderAmount = 0 , ReceverAmount = 0;

            string TransferChoice = cbTransferCurrency.SelectedItem.ToString();


            Decimal FeesAmount = 0;

            if (Country_CurrencyFrom.CurrencyName == TransferChoice)
            {
                SenderAmount = InputAmount;

                Decimal FeesRatio = GetFees(Country_CurrencyFrom.ConvertToUSD(SenderAmount));
                FeesAmount = SenderAmount * FeesRatio;
                Decimal AmountAfterFees = SenderAmount + FeesAmount;
                SenderAmount = AmountAfterFees;

                if (AmountAfterFees  > ClientFrom.Balance)
                {
                    ErrorMessage = $"Error : Amount after Fees is [{AmountAfterFees}] ,Exceeds the sender balance.";
                    return false;
                }
                else
                {
                    SenderAmount = AmountAfterFees;
                }

            }
            else
            {
                //Convert Between Sender and reciever currencies
                Countries_CurenciesBusiness AmountInfo = Countries_CurenciesBusiness.Find(TransferChoice);

                SenderAmount = AmountInfo.ConvertToOtherCurrency(InputAmount, Country_CurrencyFrom);

                Decimal FeesRatio = GetFees(Country_CurrencyFrom.ConvertToUSD(SenderAmount));
                FeesAmount = SenderAmount * FeesRatio;
                Decimal AmountAfterFees = SenderAmount + FeesAmount;
                SenderAmount = AmountAfterFees;

                if (AmountAfterFees > ClientFrom.Balance)
                {
                    ErrorMessage = $"Error : Amount after Fees is [{AmountAfterFees}] ,Exceeds the sender balance.";
                    return false;
                }
                else
                {
                    SenderAmount = AmountAfterFees;
                }

            }

            ReceverAmount = Country_CurrencyFrom.ConvertToOtherCurrency(SenderAmount - FeesAmount, Country_CurrencyTo);
            //

            if (SenderAmount <= 0)
            {
                ErrorMessage = "Amount must be a positive number.";
                return false;
            }


            if (ClientFrom.TryUpdateBalance(-SenderAmount, ClientFrom.ClientId, ref ErrorMessage, false))
            {

                if (ClientTo.TryUpdateBalance(ReceverAmount, ClientTo.ClientId, ref ErrorMessage, false))
                {
                    IsTransferd = true;

                    lblBalanceFrom.Text = ClientFromObject.Balance.ToString("N2").Trim();
                    lblBalanceTo.Text = ClientToObject.Balance.ToString("N2").Trim();

                    if(RecordTransferLog(ClientFromObject.ClientId,ClientToObject.ClientId , GlobaCurrentlUser.CurrentUser.UserId,
                        SenderAmount - FeesAmount , FeesAmount , ClientFromObject.Balance , Country_CurrencyFrom.CurrencyName,
                        ClientToObject.Balance , Country_CurrencyTo.CurrencyName , DateTime.Now , txtNotes.Text.Trim() , ClientFromObject.PersonId))
                    {

                        IsTransferd = true;
                    }
                    else
                    {
                        ErrorMessage = "Couldn't save the transfer operation in database.";
                        IsTransferd =  false;
                    }

                }
                else
                {
                    IsTransferd = false;
                }

            }
            else
            {
                IsTransferd = false;
            }

            return IsTransferd;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (!ValidateAmountAndNotes())
                return;

            string ErrorMessage = string.Empty;


            if (ClientFromObject.AccountNumber == ClientToObject.AccountNumber)
            {
                MessageBox.Show("Can't Transfer To the same client plase pick another client.");
            }
            else
            {
                if (MessageBox.Show("Please Confirm Transfer Operation", "Transfer Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (TryTransferBetweenClients(ClientFromObject, ClientToObject, ref ErrorMessage))
                    {
                        MessageBox.Show("Transfer operation done successfuly.");
                    }
                    else
                    {
                        MessageBox.Show($"Error : {ErrorMessage}");
                    }
                }

            }

        }

        private void LoadTransferCurrenciestocombobox()
        {

            cbTransferCurrency.Items.Clear();

            DataTable dtCurrenciesNames = CountryBusiness.GetAllCurrenciesNames();

            if(dtCurrenciesNames != null && dtCurrenciesNames.Rows.Count > 0)
            {
                foreach(DataRow dr in dtCurrenciesNames.Rows)
                {
                    cbTransferCurrency.Items.Add(dr[0].ToString());
                }
            }

            cbTransferCurrency.SelectedIndex = cbTransferCurrency.FindString(Country_CurrencyFrom.CurrencyName);
            cbTransferCurrency.Text = Country_CurrencyFrom.CurrencyName;
        }

        private void btnExchange_Click(object sender, EventArgs e)
        {

            if(cbTransferCurrency.SelectedIndex != -1)
            {
                Countries_CurenciesBusiness CountryCurrency = Countries_CurenciesBusiness.Find(cbTransferCurrency.SelectedItem.ToString());
                frmExchange frmExchange = new frmExchange(CountryCurrency.CountryId);
                frmExchange.ShowDialog();
            }
            else
            {
                MessageBox.Show("An error occurred while opening exchange screen, Please select a currency." , "Error");
            }
        }


        private bool ValidateAmountAndNotes()
        {
            bool IsValid = true;

            //Validate Amount
            if (!decimal.TryParse(txtAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal balance) || balance <= 0)
            {
                errorProvider1.SetError(txtAmount, "Amount must be a positive number (decimals allowed).");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtAmount, "");
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

        private void frmTransfer_Load(object sender, EventArgs e)
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
        private bool ValidateTransferAmount()
        {
            bool IsValid = true;

            //Validate Amount
            if (!decimal.TryParse(txtAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal balance) || balance <= 0)
            {
                errorProvider1.SetError(txtAmount, "Amount must be a positive number (decimals allowed).");
                lblAmountInUSD.Text = "Invalid Pattern";
                lblAmountInUSD.ForeColor = Color.Red;
                return false;
            }
            else
            {
                errorProvider1.SetError(txtAmount, "");
            }

            return IsValid;
        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (!ValidateTransferAmount())
                return;

            Countries_CurenciesBusiness CountryCurrencyObject = Countries_CurenciesBusiness.Find(cbTransferCurrency.SelectedItem.ToString());
            lblAmountInUSD.Text = CountryCurrencyObject.ConvertToUSD(Convert.ToDecimal(txtAmount.Text)).ToString("N2");
            lblAmountInUSD.ForeColor = Color.White;
        }

        
    }
}
