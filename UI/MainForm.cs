using BankPresentationLayer;
using BusinessLayer;
using Common;
using Guna.UI2.WinForms;
using Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;
using UI.Properties;
using static BusinessLayer.UserBusiness;


namespace BankProjectUi
{
    public partial class MainForm : frmBase
    {
        public MainForm()
        {
            InitializeComponent();
        }


        public static string AccessDeniedMessage = "You don't have access rights to this screen. Please contact your admin.";

        public void ShowFormOnly(Form formToOpen)
        {
            foreach (Form frm in this.MdiChildren)
                frm.Close();

            formToOpen.MdiParent = this;
            formToOpen.Dock = DockStyle.Fill;
            formToOpen.Show();
        }

      
        private void HideMainControls()
        {
            guna2ControlBox1.Visible = false;
            guna2ControlBox2.Visible = false;
            lblDateTime.Visible = false;
            pbLogo.Visible = false;
            btnAIChatBot.Visible = false;
        }

        public void ShowMainControls()
        {
            guna2ControlBox1.Visible = true;
            guna2ControlBox2.Visible = true;
            lblDateTime.Visible = true;
            pbLogo.Visible = true;
            btnAIChatBot.Visible = true;
        }

        private void ActivateButton(Guna2GradientButton clickedButton)
        {
            // set all button to default case.
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Guna2GradientButton btn)
                {
                    btn.Checked = false; // set Default fill color.
                }
            }

            // Activate the clicked button.
            clickedButton.Checked = true;

            clickedButton.CheckedState.FillColor = Color.FromArgb(0, 122, 204);
            clickedButton.CheckedState.FillColor2 = Color.FromArgb(0, 80, 160);
            clickedButton.CheckedState.ForeColor = Color.White;
        }



        private void btnShowListClientsForm_Click(object sender, EventArgs e)
        {
            if (GlobaCurrentlUser.CurrentUser.CheckAccessRights((int)enPermissions.ListClients))
            {
                Form frm = new frmListClients();
                ShowFormOnly(frm);
                HideMainControls();
                ActivateButton((Guna2GradientButton) btnShowListClientsForm);
            }

            else
                MessageBox.Show(AccessDeniedMessage);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {

            if (GlobaCurrentlUser.CurrentUser.CheckAccessRights((int)enPermissions.AddNewClient))
            {
                Form frm = new frmAddNewClient();

                ShowFormOnly(frm);
                HideMainControls();
                ActivateButton((Guna2GradientButton) btnShowAddClientForm);
            }
            else MessageBox.Show(AccessDeniedMessage);
        }
       

        private void btnShowDeleteClientForm_Click(object sender, EventArgs e)
        {

            if (GlobaCurrentlUser.CurrentUser.CheckAccessRights((int)enPermissions.DeleteClient))
            {
             
                Form frm = new frmDeleteClient();
                //ShowSmallFormsOnly(frm);
                ShowFormOnly(frm);
                HideMainControls();
                ActivateButton((Guna2GradientButton)btnShowDeleteClientForm);


            }
            else MessageBox.Show(AccessDeniedMessage);

        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (GlobaCurrentlUser.CurrentUser.CheckAccessRights((int)enPermissions.UpdateClient))
            {
                Form frm = new frmUpdateClients();
                ShowFormOnly(frm);
                HideMainControls();
                ActivateButton((Guna2GradientButton)btnUpdateClient);

            }
            else MessageBox.Show(AccessDeniedMessage);
        }

        private void btnFindClient_Click(object sender, EventArgs e)
        {
            if (GlobaCurrentlUser.CurrentUser.CheckAccessRights((int)enPermissions.FindClient))
            {
                Form frm = new frmFindClient();

                ShowFormOnly(frm);
                HideMainControls();
                ActivateButton((Guna2GradientButton)btnFindClient);

            }
            else MessageBox.Show(AccessDeniedMessage);
        }



        private void btnTransactions_Click(object sender, EventArgs e)
        {
            if (GlobaCurrentlUser.CurrentUser.CheckAccessRights((int)enPermissions.Transactions))
            {
                bool ToggleState = !btnDeposit.Visible;

                btnDeposit.Visible = ToggleState;
                btnWithdraw.Visible = ToggleState;
                btnTotalBalances.Visible = ToggleState;
                btnTransfer.Visible = ToggleState;
                btnTransferLog.Visible = ToggleState;
            }

            else MessageBox.Show(AccessDeniedMessage);

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmDeposit());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnDeposit);

        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmWithdraw());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnWithdraw);
        }

        private void btnTotalBalances_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmTotalBalances());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnTotalBalances);

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmTransfer());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnTransfer);
        }

        private void btnTransferLog_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmTransferLog());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnTransferLog);

        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {

            if (GlobaCurrentlUser.CurrentUser.CheckAccessRights((int)enPermissions.ManageUsers))
            {
                bool ToggleState = !btnListUsers.Visible;

                btnListUsers.Visible = ToggleState;
                btnAddUser.Visible = ToggleState;
                btnDeleteUser.Visible = ToggleState;
                btnUpdateUser.Visible = ToggleState;
                btnFindUser.Visible = ToggleState;
            }
            else MessageBox.Show(AccessDeniedMessage);
        }

        private void btnListUsers_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmListUsers());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnListUsers);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmAddUser());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnAddUser);
        }
        private void btnFindUser_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmFindUser());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnFindUser);
        }
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmUpdateUser());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnUpdateUser);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmDeleteUser());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnDeleteUser);
        }

        private void CenterLogo()
        {
            int remainingWidth = this.ClientSize.Width - flowLayoutPanel1.Width;
            pbLogo.Left = flowLayoutPanel1.Width + (remainingWidth - pbLogo.Width) / 2;
            pbLogo.Top = (this.ClientSize.Height - pbLogo.Height) / 2;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient client)
                {
                    client.BackColor = Color.FromArgb(0, 46, 71);
                    break;
                }
            }

            CenterLogo();

        }

        private void btnAIChatBot_Click(object sender, EventArgs e)
        {
            ShowFormOnly(new frmAIChatBot());
            HideMainControls();
            ActivateButton((Guna2GradientButton)btnAIChatBot);
        }

       
    }
}
