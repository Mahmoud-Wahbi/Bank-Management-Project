using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Guna.UI2.WinForms;
using static Common.SearchConstrants;
using BankProjectUi;

namespace BankPresentationLayer
{
    public partial class frmTransferLog : Form
    {
        public frmTransferLog()
        {
            InitializeComponent();
        }

        private void SetDataGridViewsProperties()
        {

            // Disable adding extra row
            dgvTransferLog.AllowUserToAddRows = false;

            // Rows Colors
            dgvTransferLog.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F0F3F4");
            dgvTransferLog.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D6E4E5");

            // Font Inside Cells
            dgvTransferLog.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            dgvTransferLog.DefaultCellStyle.ForeColor = Color.Black;

            // Font And Width of Cell Headers
            dgvTransferLog.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#34495E");
            dgvTransferLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransferLog.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            // Desable Visual Styles to allow Control Colors
            dgvTransferLog.EnableHeadersVisualStyles = false;


            // Background color
            dgvTransferLog.BackgroundColor = Color.FromArgb(222, 229, 196);
        }


        private void frmTransferLog_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            ClearForm();

            DataTable Dt = Transfer_LogBusiness.GetNextOrPrevRows(OffsetValue, FetchValue);
            dgvTransferLog.DataSource = Dt;
            if(Dt.Rows.Count <= 0)
            {
                lblNoTransfers.Visible = true;
            }
            else
            {
                dgvTransferLog.Columns["SourceBalance"].DefaultCellStyle.Format = "N2";
                dgvTransferLog.Columns["DestinationBalance"].DefaultCellStyle.Format = "N2";
            }
            

            if (dgvTransferLog.Rows.Count == 0)
                dgvTransferLog.Visible = true;

            FillCountriesComboboxes();
            SetDataGridViewsProperties();
        }

       
        private bool DeleteTransferRecord(int RecordIdToDelete)
        {

            if (Transfer_LogBusiness.DeleteLog(RecordIdToDelete))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void DeleteTransferLog()
        {
            if (dgvTransferLog.SelectedRows.Count == 0)
            {
                MessageBox.Show("There is no selected record. Please select a record to delete.");
                return;
            }

            int recordId;
            try
            {
                recordId = Convert.ToInt32(dgvTransferLog.SelectedRows[0].Cells["TransferId"].Value);
            }
            catch
            {
                MessageBox.Show("Invalid ID format.");
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete selected log with id [{recordId}]", "Delete Confirmation", MessageBoxButtons.OKCancel
              , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

                if (DeleteTransferRecord(recordId))
                {
                    MessageBox.Show("Record deleted successfully.");
                    LoadOriginalData();
                }
                else
                {
                    MessageBox.Show("Could not delete the record from the database.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTransferLog();
        }

        private void ClearForm()
        {

            txtSearch.Text = string.Empty;
            txtSourceBalance.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtFees.Text = string.Empty;
            txtDestinationBalance.Text = string.Empty;
            txtNotes.Text = string.Empty;

            cbSourceCurrencyName.SelectedIndex = -1;
            cbDestinationCurrencyName.SelectedIndex = -1;

            dtpDate.Value = DateTime.Today;

        }

        private void FillCountriesComboboxes()
        {
            DataTable dtCountries = CountryBusiness.GetAllCurrenciesNames();

            if (dtCountries.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCountries.Rows)
                {
                    cbSourceCurrencyName.Items.Add(dr[0]);
                    cbDestinationCurrencyName.Items.Add(dr[0]);
                }
            }
        }

        private bool ValidateDecimalTextBoxes(Guna2TextBox textBox)
        {
            bool IsValid = true;

            if (!decimal.TryParse(textBox.Text, out decimal balance))
            {
                errorProvider1.SetError(textBox, "Invalid, only decimal values are allowed.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            }

            return IsValid;
        }
        private bool ValidateControls()
        {
            bool IsValid = true;

            // Validate Source currency
            if (cbSourceCurrencyName.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbSourceCurrencyName, "You must select a currency.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(cbSourceCurrencyName, "");
            }

            // Validate Destination currency
            if (cbDestinationCurrencyName.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbDestinationCurrencyName, "You must select a currency.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(cbDestinationCurrencyName, "");
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

            // Validate Transfer Date
            DateTime minDate = new DateTime(2000, 1, 1); 
            if (dtpDate.Value < minDate || dtpDate.Value > DateTime.Today)
            {
                errorProvider1.SetError(dtpDate, "Transfer date must be between " +
                    minDate.ToShortDateString() + " and today.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(dtpDate, "");
            }

            return IsValid;
        }

        private bool TryUpdateTransferLog(Transfer_LogBusiness TransferLog)
        {
            TransferLog.SourceBalance = Convert.ToDecimal(txtSourceBalance.Text.Trim());
            TransferLog.SourceCurrencyName = cbSourceCurrencyName.SelectedItem.ToString();
            TransferLog.DestinationBalance = Convert.ToDecimal(txtDestinationBalance.Text.Trim());
            TransferLog.DestinationCurrencyName = cbDestinationCurrencyName.SelectedItem.ToString();
            TransferLog.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
            TransferLog.Fees = Convert.ToDecimal(txtAmount.Text.Trim());
            TransferLog.TransferDate = dtpDate.Value;
            TransferLog.Notes = txtNotes.Text.Trim();

            if (TransferLog.Save())
                return true;
            else
                return false;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a data row is clicked, not the header
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvTransferLog.Rows[e.RowIndex];

            // Fill TextBoxes
            txtSourceBalance.Text = Convert.ToDecimal(row.Cells["SourceBalance"].Value).ToString("N2");
            txtDestinationBalance.Text = Convert.ToDecimal(row.Cells["DestinationBalance"].Value).ToString("N2");
            txtAmount.Text = Convert.ToDecimal(row.Cells["Amount"].Value).ToString("N2");
            txtFees.Text = Convert.ToDecimal(row.Cells["Fees"].Value).ToString("N2");
            txtNotes.Text = row.Cells["Notes"].Value?.ToString();

            // Fill ComboBoxes using FindStringExact
            string sourceCurrency = row.Cells["SourceCurrencyName"].Value?.ToString().Trim();
            string destCurrency = row.Cells["DestinationCurrencyName"].Value?.ToString().Trim();

            cbSourceCurrencyName.SelectedIndex = cbSourceCurrencyName.FindStringExact(sourceCurrency);
            cbDestinationCurrencyName.SelectedIndex = cbDestinationCurrencyName.FindStringExact(destCurrency);


            // Fill DateTimePicker

            if (row.Cells["Date"].Value != null)
            {
                DateTime selectedDate = Convert.ToDateTime(row.Cells["Date"].Value);

                // Ensure the date is within valid range
                DateTime minDate = new DateTime(2000, 1, 1);
                DateTime maxDate = DateTime.Today;

                if (selectedDate < minDate)
                    selectedDate = minDate;
                else if (selectedDate > maxDate)
                    selectedDate = maxDate;

                dtpDate.Value = selectedDate;
            }
        }


        private void UpdateTransferLog()
        {

            if (dgvTransferLog.SelectedRows.Count == 0)
            {
                MessageBox.Show("There is no selected record. Please select a record to update.");
                return;
            }

            int recordId;
            try
            {
                recordId = Convert.ToInt32(dgvTransferLog.SelectedRows[0].Cells["TransferId"].Value);
            }
            catch
            {
                MessageBox.Show("Invalid ID format.");
                return;
            }

            Transfer_LogBusiness TransferLogObject = Transfer_LogBusiness.FindTransferLog(recordId);

            if (TransferLogObject == null)
            {
                MessageBox.Show($"Error : There's no record with id [{recordId}] in the database.");
            }
            else
            {

                if (MessageBox.Show($"Are you sure you want to update selected log with id [{recordId}]", "Update Confirmation", MessageBoxButtons.OKCancel
            , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {

                    if (TryUpdateTransferLog(TransferLogObject))
                    {
                        MessageBox.Show("Transfer log updated successfully.");
                        LoadOriginalData();
                    }
                    else
                    {
                        MessageBox.Show("Couldn't Update transfer log in database.");
                    }
                }
            }
        }

        private bool TryValidateControls()
        {
            if (!ValidateControls())
            {
                return false;
            }

            if (!ValidateDecimalTextBoxes(txtSourceBalance) || !ValidateDecimalTextBoxes(txtDestinationBalance)
               || !ValidateDecimalTextBoxes(txtAmount) || !ValidateDecimalTextBoxes(txtFees))
            {
                return false;
            }

            return true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (!TryValidateControls())
                return;

            UpdateTransferLog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTransferLog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TryValidateControls())
                return;

            UpdateTransferLog();
        }

       
        private int OffsetValue = 0, FetchValue = 10;

        public static DataTable GetNextOrPrevRows(int OffsetRows, int FetchRows)
        {

            DataTable DataTable = Transfer_LogBusiness.GetNextOrPrevRows(OffsetRows, FetchRows);
            return DataTable;

        }

       
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadOriginalData();
                return;
            }

            DataTable DtTransferLogs = new DataTable();

            
            DtTransferLogs = Transfer_LogBusiness.GetNextOrPrevRows(OffsetValue , FetchValue, txtSearch.Text.Trim());
           

            if (DtTransferLogs.Rows.Count != 0)
            {
                dgvTransferLog.DataSource = DtTransferLogs;
            }
            else
            {
                dgvTransferLog.DataSource = null;
            }

        }

        private void LoadOriginalData()
        {
            OffsetValue = 0;
            DataTable originalData = Transfer_LogBusiness.GetNextOrPrevRows(OffsetValue, FetchValue);
            dgvTransferLog.DataSource = originalData;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DataTable DtTransferLogs = new DataTable();

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                DtTransferLogs = Transfer_LogBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue);
            }
            else
            {
                DtTransferLogs = Transfer_LogBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue , txtSearch.Text.Trim());
            }

            if (DtTransferLogs.Rows.Count == 0)
            {
                MessageBox.Show("This is the last page", "Alert");
            }
            else
            {
                dgvTransferLog.DataSource = DtTransferLogs;

                OffsetValue += FetchValue;
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
        

        private void btnPervious_Click(object sender, EventArgs e)
        {
            if (OffsetValue == 0)
            {
                MessageBox.Show("This is the first page", "Alert");
                return;
            }
            
            DataTable DtTransferLogs = new DataTable();

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                DtTransferLogs = Transfer_LogBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue);
            }
            else
            {
                DtTransferLogs = Transfer_LogBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue, txtSearch.Text.Trim());

            }

            if (OffsetValue == 0)
            {
                MessageBox.Show("This is the first page", "Alert");
                return;
            }
            else
            {

                dgvTransferLog.DataSource = DtTransferLogs;

                OffsetValue -= FetchValue;

                if (OffsetValue < 0) OffsetValue = 0;
            }
        }
    }
}
