namespace BankPresentationLayer
{
    partial class frmTransferLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTransferLog = new System.Windows.Forms.DataGridView();
            this.ContextMenuTransferLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbUpdateInfo = new System.Windows.Forms.GroupBox();
            this.cbDestinationCurrencyName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSourceCurrencyName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtDestinationBalance = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFees = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSourceBalance = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lable111 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoTransfers = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnPervious = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnMainMenu = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferLog)).BeginInit();
            this.ContextMenuTransferLog.SuspendLayout();
            this.gbUpdateInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransferLog
            // 
            this.dgvTransferLog.AllowUserToAddRows = false;
            this.dgvTransferLog.AllowUserToDeleteRows = false;
            this.dgvTransferLog.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTransferLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransferLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransferLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferLog.ContextMenuStrip = this.ContextMenuTransferLog;
            this.dgvTransferLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTransferLog.Location = new System.Drawing.Point(0, 0);
            this.dgvTransferLog.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTransferLog.MultiSelect = false;
            this.dgvTransferLog.Name = "dgvTransferLog";
            this.dgvTransferLog.ReadOnly = true;
            this.dgvTransferLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferLog.Size = new System.Drawing.Size(1090, 265);
            this.dgvTransferLog.TabIndex = 0;
            this.dgvTransferLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // ContextMenuTransferLog
            // 
            this.ContextMenuTransferLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.ContextMenuTransferLog.Name = "ContextMenuTransferLog";
            this.ContextMenuTransferLog.Size = new System.Drawing.Size(113, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // gbUpdateInfo
            // 
            this.gbUpdateInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbUpdateInfo.Controls.Add(this.cbDestinationCurrencyName);
            this.gbUpdateInfo.Controls.Add(this.cbSourceCurrencyName);
            this.gbUpdateInfo.Controls.Add(this.txtDestinationBalance);
            this.gbUpdateInfo.Controls.Add(this.txtNotes);
            this.gbUpdateInfo.Controls.Add(this.txtFees);
            this.gbUpdateInfo.Controls.Add(this.txtAmount);
            this.gbUpdateInfo.Controls.Add(this.txtSourceBalance);
            this.gbUpdateInfo.Controls.Add(this.label8);
            this.gbUpdateInfo.Controls.Add(this.dtpDate);
            this.gbUpdateInfo.Controls.Add(this.label7);
            this.gbUpdateInfo.Controls.Add(this.label5);
            this.gbUpdateInfo.Controls.Add(this.label6);
            this.gbUpdateInfo.Controls.Add(this.lable111);
            this.gbUpdateInfo.Controls.Add(this.label4);
            this.gbUpdateInfo.Controls.Add(this.label2);
            this.gbUpdateInfo.Controls.Add(this.label1);
            this.gbUpdateInfo.ForeColor = System.Drawing.Color.White;
            this.gbUpdateInfo.Location = new System.Drawing.Point(13, 371);
            this.gbUpdateInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gbUpdateInfo.Name = "gbUpdateInfo";
            this.gbUpdateInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gbUpdateInfo.Size = new System.Drawing.Size(1064, 291);
            this.gbUpdateInfo.TabIndex = 4;
            this.gbUpdateInfo.TabStop = false;
            this.gbUpdateInfo.Text = "Update Info";
            // 
            // cbDestinationCurrencyName
            // 
            this.cbDestinationCurrencyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDestinationCurrencyName.BackColor = System.Drawing.Color.Transparent;
            this.cbDestinationCurrencyName.BorderRadius = 5;
            this.cbDestinationCurrencyName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDestinationCurrencyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationCurrencyName.FocusedColor = System.Drawing.Color.Empty;
            this.cbDestinationCurrencyName.FocusedState.Parent = this.cbDestinationCurrencyName;
            this.cbDestinationCurrencyName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDestinationCurrencyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbDestinationCurrencyName.FormattingEnabled = true;
            this.cbDestinationCurrencyName.HoverState.Parent = this.cbDestinationCurrencyName;
            this.cbDestinationCurrencyName.IntegralHeight = false;
            this.cbDestinationCurrencyName.ItemHeight = 30;
            this.cbDestinationCurrencyName.ItemsAppearance.Parent = this.cbDestinationCurrencyName;
            this.cbDestinationCurrencyName.Location = new System.Drawing.Point(216, 169);
            this.cbDestinationCurrencyName.Margin = new System.Windows.Forms.Padding(4);
            this.cbDestinationCurrencyName.MaxDropDownItems = 13;
            this.cbDestinationCurrencyName.Name = "cbDestinationCurrencyName";
            this.cbDestinationCurrencyName.ShadowDecoration.Parent = this.cbDestinationCurrencyName;
            this.cbDestinationCurrencyName.Size = new System.Drawing.Size(200, 36);
            this.cbDestinationCurrencyName.Sorted = true;
            this.cbDestinationCurrencyName.TabIndex = 61;
            // 
            // cbSourceCurrencyName
            // 
            this.cbSourceCurrencyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSourceCurrencyName.BackColor = System.Drawing.Color.Transparent;
            this.cbSourceCurrencyName.BorderRadius = 5;
            this.cbSourceCurrencyName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSourceCurrencyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceCurrencyName.FocusedColor = System.Drawing.Color.Empty;
            this.cbSourceCurrencyName.FocusedState.Parent = this.cbSourceCurrencyName;
            this.cbSourceCurrencyName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSourceCurrencyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSourceCurrencyName.FormattingEnabled = true;
            this.cbSourceCurrencyName.HoverState.Parent = this.cbSourceCurrencyName;
            this.cbSourceCurrencyName.IntegralHeight = false;
            this.cbSourceCurrencyName.ItemHeight = 30;
            this.cbSourceCurrencyName.ItemsAppearance.Parent = this.cbSourceCurrencyName;
            this.cbSourceCurrencyName.Location = new System.Drawing.Point(216, 107);
            this.cbSourceCurrencyName.Margin = new System.Windows.Forms.Padding(4);
            this.cbSourceCurrencyName.MaxDropDownItems = 13;
            this.cbSourceCurrencyName.Name = "cbSourceCurrencyName";
            this.cbSourceCurrencyName.ShadowDecoration.Parent = this.cbSourceCurrencyName;
            this.cbSourceCurrencyName.Size = new System.Drawing.Size(200, 36);
            this.cbSourceCurrencyName.Sorted = true;
            this.cbSourceCurrencyName.TabIndex = 60;
            // 
            // txtDestinationBalance
            // 
            this.txtDestinationBalance.BorderRadius = 6;
            this.txtDestinationBalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDestinationBalance.DefaultText = "";
            this.txtDestinationBalance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDestinationBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDestinationBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDestinationBalance.DisabledState.Parent = this.txtDestinationBalance;
            this.txtDestinationBalance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDestinationBalance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDestinationBalance.FocusedState.Parent = this.txtDestinationBalance;
            this.txtDestinationBalance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDestinationBalance.HoverState.Parent = this.txtDestinationBalance;
            this.txtDestinationBalance.Location = new System.Drawing.Point(216, 233);
            this.txtDestinationBalance.Margin = new System.Windows.Forms.Padding(5);
            this.txtDestinationBalance.Name = "txtDestinationBalance";
            this.txtDestinationBalance.PasswordChar = '\0';
            this.txtDestinationBalance.PlaceholderText = "";
            this.txtDestinationBalance.SelectedText = "";
            this.txtDestinationBalance.ShadowDecoration.Parent = this.txtDestinationBalance;
            this.txtDestinationBalance.Size = new System.Drawing.Size(200, 36);
            this.txtDestinationBalance.TabIndex = 22;
            // 
            // txtNotes
            // 
            this.txtNotes.AcceptsReturn = true;
            this.txtNotes.BorderRadius = 6;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.Parent = this.txtNotes;
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.FocusedState.Parent = this.txtNotes;
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.HoverState.Parent = this.txtNotes;
            this.txtNotes.Location = new System.Drawing.Point(777, 214);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(5);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = '\0';
            this.txtNotes.PlaceholderText = "";
            this.txtNotes.SelectedText = "";
            this.txtNotes.ShadowDecoration.Parent = this.txtNotes;
            this.txtNotes.Size = new System.Drawing.Size(200, 66);
            this.txtNotes.TabIndex = 21;
            // 
            // txtFees
            // 
            this.txtFees.BorderRadius = 6;
            this.txtFees.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFees.DefaultText = "";
            this.txtFees.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFees.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFees.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFees.DisabledState.Parent = this.txtFees;
            this.txtFees.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFees.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFees.FocusedState.Parent = this.txtFees;
            this.txtFees.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFees.HoverState.Parent = this.txtFees;
            this.txtFees.Location = new System.Drawing.Point(777, 94);
            this.txtFees.Margin = new System.Windows.Forms.Padding(5);
            this.txtFees.Name = "txtFees";
            this.txtFees.PasswordChar = '\0';
            this.txtFees.PlaceholderText = "";
            this.txtFees.SelectedText = "";
            this.txtFees.ShadowDecoration.Parent = this.txtFees;
            this.txtFees.Size = new System.Drawing.Size(200, 36);
            this.txtFees.TabIndex = 20;
            // 
            // txtAmount
            // 
            this.txtAmount.BorderRadius = 6;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DefaultText = "";
            this.txtAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmount.DisabledState.Parent = this.txtAmount;
            this.txtAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.FocusedState.Parent = this.txtAmount;
            this.txtAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.HoverState.Parent = this.txtAmount;
            this.txtAmount.Location = new System.Drawing.Point(777, 27);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(5);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.PlaceholderText = "";
            this.txtAmount.SelectedText = "";
            this.txtAmount.ShadowDecoration.Parent = this.txtAmount;
            this.txtAmount.Size = new System.Drawing.Size(200, 36);
            this.txtAmount.TabIndex = 19;
            // 
            // txtSourceBalance
            // 
            this.txtSourceBalance.BorderRadius = 6;
            this.txtSourceBalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSourceBalance.DefaultText = "";
            this.txtSourceBalance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSourceBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSourceBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSourceBalance.DisabledState.Parent = this.txtSourceBalance;
            this.txtSourceBalance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSourceBalance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSourceBalance.FocusedState.Parent = this.txtSourceBalance;
            this.txtSourceBalance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSourceBalance.HoverState.Parent = this.txtSourceBalance;
            this.txtSourceBalance.Location = new System.Drawing.Point(216, 30);
            this.txtSourceBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtSourceBalance.Name = "txtSourceBalance";
            this.txtSourceBalance.PasswordChar = '\0';
            this.txtSourceBalance.PlaceholderText = "";
            this.txtSourceBalance.SelectedText = "";
            this.txtSourceBalance.ShadowDecoration.Parent = this.txtSourceBalance;
            this.txtSourceBalance.Size = new System.Drawing.Size(200, 36);
            this.txtSourceBalance.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(708, 175);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(777, 169);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 25);
            this.dtpDate.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(708, 241);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Notes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(708, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fees";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(686, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Amount";
            // 
            // lable111
            // 
            this.lable111.AutoSize = true;
            this.lable111.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable111.ForeColor = System.Drawing.Color.White;
            this.lable111.Location = new System.Drawing.Point(8, 178);
            this.lable111.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable111.Name = "lable111";
            this.lable111.Size = new System.Drawing.Size(175, 17);
            this.lable111.TabIndex = 6;
            this.lable111.Text = "Destination Currency Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(56, 238);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Destination Balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "SourceCurrencyName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(84, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Balance";
            // 
            // lblNoTransfers
            // 
            this.lblNoTransfers.AutoSize = true;
            this.lblNoTransfers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(229)))), ((int)(((byte)(196)))));
            this.lblNoTransfers.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTransfers.ForeColor = System.Drawing.Color.Black;
            this.lblNoTransfers.Location = new System.Drawing.Point(352, 115);
            this.lblNoTransfers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoTransfers.Name = "lblNoTransfers";
            this.lblNoTransfers.Size = new System.Drawing.Size(294, 17);
            this.lblNoTransfers.TabIndex = 5;
            this.lblNoTransfers.Text = "There is no transfers in the system at this time.";
            this.lblNoTransfers.Visible = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BorderRadius = 6;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.CustomImages.Parent = this.btnDelete;
            this.btnDelete.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Location = new System.Drawing.Point(289, 694);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(180, 45);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BorderRadius = 6;
            this.btnUpdate.CheckedState.Parent = this.btnUpdate;
            this.btnUpdate.CustomImages.Parent = this.btnUpdate;
            this.btnUpdate.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.Parent = this.btnUpdate;
            this.btnUpdate.Location = new System.Drawing.Point(610, 694);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShadowDecoration.Parent = this.btnUpdate;
            this.btnUpdate.Size = new System.Drawing.Size(180, 45);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BorderRadius = 6;
            this.btnNext.CheckedState.Parent = this.btnNext;
            this.btnNext.CustomImages.Parent = this.btnNext;
            this.btnNext.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnNext.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.HoverState.Parent = this.btnNext;
            this.btnNext.Location = new System.Drawing.Point(897, 285);
            this.btnNext.Name = "btnNext";
            this.btnNext.ShadowDecoration.Parent = this.btnNext;
            this.btnNext.Size = new System.Drawing.Size(180, 45);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPervious
            // 
            this.btnPervious.BackColor = System.Drawing.Color.Transparent;
            this.btnPervious.BorderRadius = 6;
            this.btnPervious.CheckedState.Parent = this.btnPervious;
            this.btnPervious.CustomImages.Parent = this.btnPervious;
            this.btnPervious.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnPervious.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnPervious.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPervious.ForeColor = System.Drawing.Color.White;
            this.btnPervious.HoverState.Parent = this.btnPervious;
            this.btnPervious.Location = new System.Drawing.Point(16, 285);
            this.btnPervious.Name = "btnPervious";
            this.btnPervious.ShadowDecoration.Parent = this.btnPervious;
            this.btnPervious.Size = new System.Drawing.Size(180, 45);
            this.btnPervious.TabIndex = 8;
            this.btnPervious.Text = "Previous";
            this.btnPervious.Click += new System.EventHandler(this.btnPervious_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(434, 273);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search by Account Number";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderRadius = 6;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconLeft = global::UI.Properties.Resources.SearchLogo;
            this.txtSearch.Location = new System.Drawing.Point(423, 294);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(200, 36);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMainMenu.BorderRadius = 6;
            this.btnMainMenu.CheckedState.Parent = this.btnMainMenu;
            this.btnMainMenu.CustomImages.Parent = this.btnMainMenu;
            this.btnMainMenu.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnMainMenu.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnMainMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnMainMenu.HoverState.Parent = this.btnMainMenu;
            this.btnMainMenu.Location = new System.Drawing.Point(13, 694);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.ShadowDecoration.Parent = this.btnMainMenu;
            this.btnMainMenu.Size = new System.Drawing.Size(180, 45);
            this.btnMainMenu.TabIndex = 19;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // frmTransferLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Properties.Resources.Forms_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1090, 742);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPervious);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblNoTransfers);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gbUpdateInfo);
            this.Controls.Add(this.dgvTransferLog);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTransferLog";
            this.Text = "frmTransferLog";
            this.Load += new System.EventHandler(this.frmTransferLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferLog)).EndInit();
            this.ContextMenuTransferLog.ResumeLayout(false);
            this.gbUpdateInfo.ResumeLayout(false);
            this.gbUpdateInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransferLog;
        private System.Windows.Forms.ContextMenuStrip ContextMenuTransferLog;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbUpdateInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lable111;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNoTransfers;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox txtDestinationBalance;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2TextBox txtFees;
        private Guna.UI2.WinForms.Guna2TextBox txtAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtSourceBalance;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdate;
        private Guna.UI2.WinForms.Guna2GradientButton btnDelete;
        private Guna.UI2.WinForms.Guna2GradientButton btnNext;
        private Guna.UI2.WinForms.Guna2GradientButton btnPervious;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2ComboBox cbDestinationCurrencyName;
        private Guna.UI2.WinForms.Guna2ComboBox cbSourceCurrencyName;
        private Guna.UI2.WinForms.Guna2GradientButton btnMainMenu;
    }
}