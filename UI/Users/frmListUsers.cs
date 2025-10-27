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
    public partial class frmListUsers : Form
    {
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void SetDataGridViewsProperties()
        {
            // Rows Colors
            dgvUsersList.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F0F3F4");
            dgvUsersList.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D6E4E5");

            // Font Inside Cells
            dgvUsersList.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            dgvUsersList.DefaultCellStyle.ForeColor = Color.Black;

            // Font And Width of Cell Headers
            dgvUsersList.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#34495E");
            dgvUsersList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsersList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            // Desable Visual Styles to allow Control Colors
            dgvUsersList.EnableHeadersVisualStyles = false;


            // Background color
            dgvUsersList.BackgroundColor = Color.FromArgb(222, 229, 196);
        }

        private int OffsetValue = 0, FetchValue = 23;
        private void LoadOriginalData()
        {
            OffsetValue = 0;
            DataTable originalData = UserBusiness.GetNextOrPrevRows(OffsetValue, FetchValue);
            dgvUsersList.DataSource = originalData;
        }

        private void txtKeyWord_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtKeyWord.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadOriginalData();
                return;
            }

            DataTable DtUsers = new DataTable();

            switch (cbSearchMethod.SelectedIndex)
            {
                case 0:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue, FetchValue
                        , "Persons.FirstName + ' ' + Persons.LastName", txtKeyWord.Text.Trim());
                    break;
                case 1:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue, FetchValue
                        , "Persons.CountryId", Convert.ToInt32(txtKeyWord.Text));
                    break;
                case 2:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue, FetchValue
                       , "Users.UserName", txtKeyWord.Text.Trim());
                    break;
                case 3:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue, FetchValue
                      , "Users.UserId", Convert.ToInt32(txtKeyWord.Text));
                    break;
                case 4:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue, FetchValue
                     , "Persons.ID", Convert.ToInt32(txtKeyWord.Text));
                    break;
                case 5:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue, FetchValue
                    , "Email", (txtKeyWord.Text));
                    break;
            }


            if (DtUsers.Rows.Count != 0)
            {
                dgvUsersList.DataSource = DtUsers;
            }
            else
            {
                dgvUsersList.DataSource = null;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (OffsetValue == 0)
            {
                MessageBox.Show("This is the first page", "Alert");
                return;
            }

            DataTable DtUsers = new DataTable();

            switch (cbSearchMethod.SelectedIndex)
            {
                case 0:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                        , "Persons.FirstName + ' ' + Persons.LastName", txtKeyWord.Text.Trim());
                    break;
                case 1:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                        , "Persons.CountryId", Convert.ToInt32(txtKeyWord.Text));
                    break;
                case 2:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                       , "Users.UserName", txtKeyWord.Text.Trim());
                    break;
                case 3:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                      , "Users.UserId", Convert.ToInt32(txtKeyWord.Text));
                    break;
                case 4:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                     , "Persons.ID", Convert.ToInt32(txtKeyWord.Text));
                    break;
                case 5:
                    DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue - FetchValue, FetchValue
                    , "Email", (txtKeyWord.Text));
                    break;
            }

            if (OffsetValue == 0)
            {
                MessageBox.Show("This is the first page", "Alert");
                return;
            }
            else
            {

                dgvUsersList.DataSource = DtUsers;

                OffsetValue -= FetchValue;

                if (OffsetValue < 0) OffsetValue = 0;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DataTable DtUsers = new DataTable();

            if (string.IsNullOrEmpty(txtKeyWord.Text))
            {
                DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue);
            }
            else
            {

                switch (cbSearchMethod.SelectedIndex)
                {
                    case 0:
                        DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                            , "Persons.FirstName + ' ' + Persons.LastName", txtKeyWord.Text.Trim());
                        break;
                    case 1:
                        DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                            , "Persons.CountryId", Convert.ToInt32(txtKeyWord.Text));
                        break;
                    case 2:
                        DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                           , "Users.UserName", txtKeyWord.Text.Trim());
                        break;
                    case 3:
                        DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                          , "Users.UserId", Convert.ToInt32(txtKeyWord.Text));
                        break;
                    case 4:
                        DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                         , "Persons.ID", Convert.ToInt32(txtKeyWord.Text));
                        break;
                    case 5:
                        DtUsers = UserBusiness.GetNextOrPrevRows(OffsetValue + FetchValue, FetchValue
                        , "Email", (txtKeyWord.Text));
                        break;
                }

            }

            if (DtUsers.Rows.Count == 0)
            {
                MessageBox.Show("This is the last page", "Alert");
            }
            else
            {

                dgvUsersList.DataSource = DtUsers;

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

        private void frmListUsere_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            DataTable Dt = UserBusiness.GetNextOrPrevRows(OffsetValue, FetchValue);
            dgvUsersList.DataSource = Dt;

            if (dgvUsersList.Rows.Count == 0)
            {
                lblNoUsersExist.Visible = true;
            }

            SetDataGridViewsProperties();
            LoadOriginalData();

            cbSearchMethod.SelectedIndex = 0;
        }
    }
}
