namespace BankPresentationLayer
{
    partial class frmTotalBalances
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TotalBalanceCard = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTotalBalance = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.AvrageBalanceCard = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblAvrageBalance = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.TopClientBalanceCard = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTopClientBalance = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.TotalClientsCard = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTotalClients = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnMainMenu = new Guna.UI2.WinForms.Guna2GradientButton();
            this.TotalBalanceCard.SuspendLayout();
            this.AvrageBalanceCard.SuspendLayout();
            this.TopClientBalanceCard.SuspendLayout();
            this.TotalClientsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TotalBalanceCard
            // 
            this.TotalBalanceCard.BackColor = System.Drawing.Color.Transparent;
            this.TotalBalanceCard.BorderColor = System.Drawing.Color.Transparent;
            this.TotalBalanceCard.BorderRadius = 6;
            this.TotalBalanceCard.Controls.Add(this.lblTotalBalance);
            this.TotalBalanceCard.Controls.Add(this.guna2HtmlLabel1);
            this.TotalBalanceCard.FillColor = System.Drawing.Color.DodgerBlue;
            this.TotalBalanceCard.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.TotalBalanceCard.Location = new System.Drawing.Point(21, 12);
            this.TotalBalanceCard.Name = "TotalBalanceCard";
            this.TotalBalanceCard.ShadowDecoration.Depth = 100;
            this.TotalBalanceCard.ShadowDecoration.Enabled = true;
            this.TotalBalanceCard.ShadowDecoration.Parent = this.TotalBalanceCard;
            this.TotalBalanceCard.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(20);
            this.TotalBalanceCard.Size = new System.Drawing.Size(200, 150);
            this.TotalBalanceCard.TabIndex = 3;
            // 
            // lblTotalBalance
            // 
            this.lblTotalBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBalance.ForeColor = System.Drawing.Color.White;
            this.lblTotalBalance.Location = new System.Drawing.Point(75, 69);
            this.lblTotalBalance.Name = "lblTotalBalance";
            this.lblTotalBalance.Size = new System.Drawing.Size(34, 23);
            this.lblTotalBalance.TabIndex = 1;
            this.lblTotalBalance.Text = "N/A";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(45, 20);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(106, 23);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Total Balance";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // AvrageBalanceCard
            // 
            this.AvrageBalanceCard.BackColor = System.Drawing.Color.Transparent;
            this.AvrageBalanceCard.BorderColor = System.Drawing.Color.Transparent;
            this.AvrageBalanceCard.BorderRadius = 6;
            this.AvrageBalanceCard.Controls.Add(this.lblAvrageBalance);
            this.AvrageBalanceCard.Controls.Add(this.guna2HtmlLabel4);
            this.AvrageBalanceCard.FillColor = System.Drawing.Color.DodgerBlue;
            this.AvrageBalanceCard.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.AvrageBalanceCard.Location = new System.Drawing.Point(295, 12);
            this.AvrageBalanceCard.Name = "AvrageBalanceCard";
            this.AvrageBalanceCard.ShadowDecoration.Parent = this.AvrageBalanceCard;
            this.AvrageBalanceCard.Size = new System.Drawing.Size(200, 150);
            this.AvrageBalanceCard.TabIndex = 4;
            // 
            // lblAvrageBalance
            // 
            this.lblAvrageBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblAvrageBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvrageBalance.ForeColor = System.Drawing.Color.White;
            this.lblAvrageBalance.Location = new System.Drawing.Point(77, 69);
            this.lblAvrageBalance.Name = "lblAvrageBalance";
            this.lblAvrageBalance.Size = new System.Drawing.Size(34, 23);
            this.lblAvrageBalance.TabIndex = 3;
            this.lblAvrageBalance.Text = "N/A";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(28, 20);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(130, 23);
            this.guna2HtmlLabel4.TabIndex = 2;
            this.guna2HtmlLabel4.Text = "Average Balance";
            // 
            // TopClientBalanceCard
            // 
            this.TopClientBalanceCard.BackColor = System.Drawing.Color.Transparent;
            this.TopClientBalanceCard.BorderColor = System.Drawing.Color.Transparent;
            this.TopClientBalanceCard.BorderRadius = 6;
            this.TopClientBalanceCard.Controls.Add(this.lblTopClientBalance);
            this.TopClientBalanceCard.Controls.Add(this.guna2HtmlLabel8);
            this.TopClientBalanceCard.FillColor = System.Drawing.Color.DodgerBlue;
            this.TopClientBalanceCard.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.TopClientBalanceCard.Location = new System.Drawing.Point(864, 12);
            this.TopClientBalanceCard.Name = "TopClientBalanceCard";
            this.TopClientBalanceCard.ShadowDecoration.Parent = this.TopClientBalanceCard;
            this.TopClientBalanceCard.Size = new System.Drawing.Size(200, 150);
            this.TopClientBalanceCard.TabIndex = 6;
            // 
            // lblTopClientBalance
            // 
            this.lblTopClientBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblTopClientBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopClientBalance.ForeColor = System.Drawing.Color.White;
            this.lblTopClientBalance.Location = new System.Drawing.Point(84, 69);
            this.lblTopClientBalance.Name = "lblTopClientBalance";
            this.lblTopClientBalance.Size = new System.Drawing.Size(34, 23);
            this.lblTopClientBalance.TabIndex = 3;
            this.lblTopClientBalance.Text = "N/A";
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(31, 20);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(145, 23);
            this.guna2HtmlLabel8.TabIndex = 2;
            this.guna2HtmlLabel8.Text = "Top Client Balance";
            // 
            // TotalClientsCard
            // 
            this.TotalClientsCard.BackColor = System.Drawing.Color.Transparent;
            this.TotalClientsCard.BorderColor = System.Drawing.Color.Transparent;
            this.TotalClientsCard.BorderRadius = 6;
            this.TotalClientsCard.Controls.Add(this.lblTotalClients);
            this.TotalClientsCard.Controls.Add(this.guna2HtmlLabel6);
            this.TotalClientsCard.FillColor = System.Drawing.Color.DodgerBlue;
            this.TotalClientsCard.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.TotalClientsCard.Location = new System.Drawing.Point(584, 12);
            this.TotalClientsCard.Name = "TotalClientsCard";
            this.TotalClientsCard.ShadowDecoration.Parent = this.TotalClientsCard;
            this.TotalClientsCard.Size = new System.Drawing.Size(200, 150);
            this.TotalClientsCard.TabIndex = 5;
            // 
            // lblTotalClients
            // 
            this.lblTotalClients.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalClients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClients.ForeColor = System.Drawing.Color.White;
            this.lblTotalClients.Location = new System.Drawing.Point(79, 69);
            this.lblTotalClients.Name = "lblTotalClients";
            this.lblTotalClients.Size = new System.Drawing.Size(34, 23);
            this.lblTotalClients.TabIndex = 3;
            this.lblTotalClients.Text = "N/A";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(47, 20);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(98, 23);
            this.guna2HtmlLabel6.TabIndex = 2;
            this.guna2HtmlLabel6.Text = "Total Clients";
            // 
            // PieChart
            // 
            this.PieChart.BackColor = System.Drawing.Color.Transparent;
            chartArea6.Name = "ChartArea1";
            this.PieChart.ChartAreas.Add(chartArea6);
            legend6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend6.ForeColor = System.Drawing.Color.White;
            legend6.IsTextAutoFit = false;
            legend6.Name = "Legend1";
            this.PieChart.Legends.Add(legend6);
            this.PieChart.Location = new System.Drawing.Point(21, 285);
            this.PieChart.Name = "PieChart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.PieChart.Series.Add(series6);
            this.PieChart.Size = new System.Drawing.Size(400, 400);
            this.PieChart.TabIndex = 7;
            // 
            // BarChart
            // 
            this.BarChart.BackColor = System.Drawing.Color.Transparent;
            chartArea5.Name = "ChartArea1";
            this.BarChart.ChartAreas.Add(chartArea5);
            legend5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend5.ForeColor = System.Drawing.Color.White;
            legend5.IsTextAutoFit = false;
            legend5.Name = "Legend1";
            this.BarChart.Legends.Add(legend5);
            this.BarChart.Location = new System.Drawing.Point(506, 230);
            this.BarChart.Name = "BarChart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.BarChart.Series.Add(series5);
            this.BarChart.Size = new System.Drawing.Size(600, 500);
            this.BarChart.TabIndex = 8;
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
            this.btnMainMenu.Location = new System.Drawing.Point(12, 695);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.ShadowDecoration.Parent = this.btnMainMenu;
            this.btnMainMenu.Size = new System.Drawing.Size(180, 45);
            this.btnMainMenu.TabIndex = 19;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // frmTotalBalances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Properties.Resources.Forms_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1090, 742);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.BarChart);
            this.Controls.Add(this.PieChart);
            this.Controls.Add(this.TopClientBalanceCard);
            this.Controls.Add(this.TotalClientsCard);
            this.Controls.Add(this.AvrageBalanceCard);
            this.Controls.Add(this.TotalBalanceCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTotalBalances";
            this.Text = "frmTotalBalances";
            this.Load += new System.EventHandler(this.frmTotalBalances_Load);
            this.TotalBalanceCard.ResumeLayout(false);
            this.TotalBalanceCard.PerformLayout();
            this.AvrageBalanceCard.ResumeLayout(false);
            this.AvrageBalanceCard.PerformLayout();
            this.TopClientBalanceCard.ResumeLayout(false);
            this.TopClientBalanceCard.PerformLayout();
            this.TotalClientsCard.ResumeLayout(false);
            this.TotalClientsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientPanel TotalBalanceCard;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel AvrageBalanceCard;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalBalance;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2GradientPanel TopClientBalanceCard;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTopClientBalance;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2GradientPanel TotalClientsCard;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalClients;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAvrageBalance;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart PieChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart BarChart;
        private Guna.UI2.WinForms.Guna2GradientButton btnMainMenu;
    }
}