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

namespace BankPresentationLayer
{
    public partial class frmListClients : Form
    {
        public frmListClients()
        {
            InitializeComponent();
        }

        private static DataTable GetClientsTable()
        {
            DataTable dtClients = new DataTable();
            dtClients = ClientsBusiness.GetClientsTable();
            return dtClients;

        }

        private int OffsetValue = 0, FetchValue = 23;

        private void btnNext_Click(object sender, EventArgs e)
        {
            DataTable DtClients = new DataTable();

            if (string.IsNullOrEmpty(txtKeyWord.Text))
            {
                DtClients =  ClientsBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue);
            }
            else
            {
               
                switch (cbSearchMethod.SelectedIndex)
                {
                    case 0:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue 
                            , "Persons.FirstName + ' ' + Persons.LastName", txtKeyWord.Text.Trim());
                        break;
                    case 1:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                            ,"Persons.CountryId", Convert.ToInt32(txtKeyWord.Text));
                        break;
                    case 2:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                           , "Clients.AccountNumber", txtKeyWord.Text.Trim());
                        break;
                    case 3:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                          , "Clients.ClientId", Convert.ToInt32(txtKeyWord.Text));
                        break;
                    case 4:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                         , "Persons.ID", Convert.ToInt32(txtKeyWord.Text));
                        break;
                    case 5:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                        , "Email", (txtKeyWord.Text));
                        break;
                }

            }

                if (DtClients.Rows.Count == 0)
                {
                    MessageBox.Show("This is the last page", "Alert");
                }
                else
                {

                    dgvListClients.DataSource = DtClients;

                    OffsetValue += FetchValue;

                }
            
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

            if (OffsetValue == 0)
            {
                MessageBox.Show("This is the first page", "Alert");
                return;
            }

            DataTable DtClients = new DataTable();

            if (string.IsNullOrEmpty(txtKeyWord.Text))
            {
                DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue);
            }
            else
            {

                switch (cbSearchMethod.SelectedIndex)
                {
                    case 0:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                            , "Persons.FirstName + ' ' + Persons.LastName", txtKeyWord.Text.Trim());
                        break;
                    case 1:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                            , "Persons.CountryId", Convert.ToInt32(txtKeyWord.Text));
                        break;
                    case 2:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                           , "Clients.AccountNumber", txtKeyWord.Text.Trim());
                        break;
                    case 3:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                          , "Clients.ClientId", Convert.ToInt32(txtKeyWord.Text));
                        break;
                    case 4:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                         , "Persons.ID", Convert.ToInt32(txtKeyWord.Text));
                        break;
                    case 5:
                        DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                        , "Email", (txtKeyWord.Text));
                        break;
                }

            }

            if (OffsetValue == 0)
            {
                MessageBox.Show("This is the first page", "Alert");
                return;
            }
            else
            {

                dgvListClients.DataSource = DtClients;

                OffsetValue -= FetchValue;

                if (OffsetValue < 0) OffsetValue = 0;
            }


        }

        private void LoadOriginalData()
        {

            OffsetValue = 0; 
            DataTable originalData = ClientsBusiness.GetNextOrPrevRows(OffsetValue, FetchValue);
            dgvListClients.DataSource = originalData;
        }

        private void txtKeyWord_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtKeyWord.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadOriginalData(); 
                return;
            }

            DataTable DtClients = new DataTable();

             switch (cbSearchMethod.SelectedIndex)
             {
                case 0:
                    DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue , FetchValue
                        , "Persons.FirstName + ' ' + Persons.LastName", txtKeyWord.Text.Trim());
                    break;
                case 1:
                    DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue , FetchValue
                        , "Persons.CountryId", Convert.ToInt32(txtKeyWord.Text));
                    break;
                case 2:
                    DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue , FetchValue
                       , "Clients.AccountNumber", txtKeyWord.Text.Trim());
                    break;
                case 3:
                    DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue , FetchValue
                      , "Clients.ClientId", Convert.ToInt32(txtKeyWord.Text));
                    break;
                case 4:
                    DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue , FetchValue
                     , "Persons.ID", Convert.ToInt32(txtKeyWord.Text));
                    break;
                case 5:
                    DtClients = ClientsBusiness.GetNextOrPrevRows(OffsetValue, FetchValue
                    , "Email",(txtKeyWord.Text));
                    break;
             }
        

            if (DtClients.Rows.Count != 0)
            {
                dgvListClients.DataSource = DtClients;
            }
            else
            {
                dgvListClients.DataSource = null;
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

      
        private void SetDataGridViewsProperties()
        {
            // Rows Colors
            dgvListClients.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F0F3F4");
            dgvListClients.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D6E4E5");

            // Font Inside Cells
            dgvListClients.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            dgvListClients.DefaultCellStyle.ForeColor = Color.Black;

            // Font And Width of Cell Headers
            dgvListClients.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#34495E");
            dgvListClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListClients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            // Desable Visual Styles to allow Control Colors
            dgvListClients.EnableHeadersVisualStyles = false;


            // Background color
            dgvListClients.BackgroundColor = Color.FromArgb(222, 229, 196);
        }

        
        private void frmListClients_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            DataTable Dt = ClientsBusiness.GetNextOrPrevRows(OffsetValue, FetchValue);
            dgvListClients.DataSource = Dt;

            if (dgvListClients.Rows.Count == 0)
            {
                lblNoClients.Visible = true;
            }
            else
            {
                dgvListClients.Columns["Balance"].DefaultCellStyle.Format = "N2";
            }

            cbSearchMethod.SelectedIndex = 0;

            SetDataGridViewsProperties();
        }



    }
}
