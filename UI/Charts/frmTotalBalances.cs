using BankProjectUi;
using BusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BankPresentationLayer
{
    public partial class frmTotalBalances : Form
    {
        public frmTotalBalances()
        {
            InitializeComponent();
        }

        
        private void SetPanelsShadowsAndGradients()
        {
            Guna2GradientPanel[] panels = { TotalBalanceCard, AvrageBalanceCard, TopClientBalanceCard, TotalClientsCard };
           

            for (int i = 0; i < panels.Length; i++)
            {
                var panel = panels[i];

                // Shadow
                panel.ShadowDecoration.Enabled = true;
                panel.ShadowDecoration.Color = Color.FromArgb(120, 0, 0, 0);
                panel.ShadowDecoration.Depth = 15;
                panel.ShadowDecoration.Shadow = new Padding(5, 5, 6, 6);
                panel.ShadowDecoration.BorderRadius = 12;

                // Border light white
                panel.BorderColor = Color.FromArgb(200, 255, 255, 255);
                panel.BorderThickness = 1;

                panel.UseTransparentBackground = true;
            }
        }

        private decimal GetTopClientBalance()
        {
            // Get all clients
            DataTable dtClients = ClientsBusiness.GetClientsTable();

            decimal topBalance = 0;

            foreach (DataRow dr in dtClients.Rows)
            {
                // Convert client balance to USD
                Countries_CurenciesBusiness CountryCurrencyObject = Countries_CurenciesBusiness.Find(Convert.ToInt32(dr["CountryId"]));
                decimal clientBalance = CountryCurrencyObject.ConvertToUSD(Convert.ToDecimal(dr["Balance"]));

                // Check if this is the highest balance so far
                if (clientBalance > topBalance)
                {
                    topBalance = clientBalance;
                }
            }

            // Return the top client balance
            return topBalance;
        }

        private int GetTotalClientsCount()
        {
            // Get all clients
            DataTable dtClients = ClientsBusiness.GetClientsTable();

            // Return the number of rows = number of clients
            return dtClients.Rows.Count;
        }


        private decimal GetAvrageBalance()
        {
            // Get all clients
            DataTable dtClients = ClientsBusiness.GetClientsTable();

            decimal totalBalance = 0;
            int clientsCount = 0;

            foreach (DataRow dr in dtClients.Rows)
            {
                // Convert client balance to USD
                Countries_CurenciesBusiness CountryCurrencyObject = Countries_CurenciesBusiness.Find(Convert.ToInt32(dr["CountryId"]));
                decimal clientBalance = CountryCurrencyObject.ConvertToUSD(Convert.ToDecimal(dr["Balance"]));

                totalBalance += clientBalance;
                clientsCount++;
            }

            // Avoid division by zero
            if (clientsCount == 0)
                return 0;

            // Return average balance
            return totalBalance / clientsCount;
        }

        private decimal GetTotalBalances()
        {
            // Get all clients
            DataTable dtClients = ClientsBusiness.GetClientsTable();

            decimal totalBalance = 0;

            foreach (DataRow dr in dtClients.Rows)
            {
                // Convert client balance to USD
                Countries_CurenciesBusiness CountryCurrencyObject = Countries_CurenciesBusiness.Find(Convert.ToInt32(dr["CountryId"]));
                decimal clientBalance = CountryCurrencyObject.ConvertToUSD(Convert.ToDecimal(dr["Balance"]));

                // Add to total
                totalBalance += clientBalance;
            }

            // Return the total balance
            return totalBalance;
        }


        private void FillInfoCards()
        {
            lblTopClientBalance.Text = GetTopClientBalance().ToString("N2");
            lblTotalClients.Text = GetTotalClientsCount().ToString();
            lblAvrageBalance.Text = GetAvrageBalance().ToString("N2");
            lblTotalBalance.Text = GetTotalBalances().ToString("N2");
        }

        private void SetTop5ClientsBarChart()
        {
            // Get clients data
            DataTable dtClients = ClientsBusiness.GetClientsTable();

            // List to store clients names and their balances in USD
            List<KeyValuePair<string, decimal>> clientsBalances = new List<KeyValuePair<string, decimal>>();

            foreach (DataRow dr in dtClients.Rows)
            {
                Countries_CurenciesBusiness CountryCurrencyObject = Countries_CurenciesBusiness.Find(Convert.ToInt32(dr["CountryId"]));
                decimal ClientBalance = CountryCurrencyObject.ConvertToUSD(Convert.ToDecimal(dr["Balance"]));

                string clientName = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                clientsBalances.Add(new KeyValuePair<string, decimal>(clientName, ClientBalance));
            }

            // Sort clients by balance and take top 5
            var top5 = clientsBalances
                .OrderByDescending(c => c.Value)
                .Take(5)
                .ToList();

            // Clear any old data
            BarChart.Series.Clear();

            // Create series
            Series series = new Series("Top5Clients");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;           // Show values above columns
            series.LabelForeColor = Color.White;         // Values color
            series.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            // Add data to series
            foreach (var client in top5)
            {
                series.Points.AddXY(client.Key, client.Value);
            }
            
            series.LabelFormat = "N2";

            BarChart.Series.Add(series);

            // ChartArea formatting
            ChartArea area = BarChart.ChartAreas[0];
            area.BackColor = Color.Transparent;

            // Hide grid lines
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisY.MinorGrid.Enabled = false;

            // Set axis titles
            area.AxisX.Title = "Client Name";
            area.AxisY.Title = "Balance (USD)";

            area.AxisX.TitleFont = new Font("Segoe UI", 8, FontStyle.Bold);
            area.AxisX.TitleForeColor = Color.White;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            area.AxisX.LabelStyle.ForeColor = Color.White;

            area.AxisY.TitleFont = new Font("Segoe UI", 8, FontStyle.Bold);
            area.AxisY.TitleForeColor = Color.White;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            area.AxisY.LabelStyle.ForeColor = Color.White;

            // Chart and Legend formatting
            BarChart.BackColor = Color.Transparent;
            BarChart.Legends[0].BackColor = Color.Transparent;
            BarChart.Legends[0].ForeColor = Color.White;
            BarChart.Legends[0].Font = new Font("Segoe UI", 8, FontStyle.Bold);
            BarChart.Legends[0].Docking = Docking.Top;
        }


        private void SetBlancesClassesPieChar()
        {
            // Counters for each balance class
            int VipBalances = 0, MiddleBalances = 0, LowBalances = 0;

            // Get clients data
            DataTable dtClients = ClientsBusiness.GetClientsTable();

            foreach (DataRow dr in dtClients.Rows)
            {
                // Convert client balance to USD
                Countries_CurenciesBusiness CountryCurrencyObject = Countries_CurenciesBusiness.Find(Convert.ToInt32(dr["CountryId"]));
                decimal ClientBalance = CountryCurrencyObject.ConvertToUSD(Convert.ToDecimal(dr["Balance"]));

                // Classify client by balance range
                if (ClientBalance >= 10000000)
                {
                    VipBalances++;
                }
                else if (ClientBalance >= 1000000)
                {
                    MiddleBalances++;
                }
                else if (ClientBalance >= 100)
                {
                    LowBalances++;
                }
                else
                {
                    LowBalances++;
                }
            }

            // Clear old series before adding new data
            PieChart.Series.Clear();

            // Create a new Pie series
            Series series = new Series("ClientsBalances");
            series.ChartType = SeriesChartType.Pie;

            // Add categories (class name, value)
            series.Points.AddXY("Vip class", VipBalances);
            series.Points.AddXY("Middle class", MiddleBalances);
            series.Points.AddXY("Low class", LowBalances);

            // Add series to chart
            PieChart.Series.Add(series);

            // Show percentage inside Pie slices
            series.Label = "#PERCENT{P0}";

            // Show class names in the legend
            series.LegendText = "#VALX";

            // ChartArea formatting
            PieChart.ChartAreas[0].BackColor = Color.Transparent; // Pie drawing area
            PieChart.BackColor = Color.Transparent;               // Whole chart background

            // Legend formatting
            PieChart.Legends[0].BackColor = Color.Transparent;
            PieChart.Legends[0].Docking = Docking.Top; // Place legend above the chart
        }

        private void CenterLabels()
        {
            lblTopClientBalance.Left = (TopClientBalanceCard.Width - lblTopClientBalance.Width) / 2;
            lblTopClientBalance.Top = (TopClientBalanceCard.Height - lblTopClientBalance.Height) / 2;

            lblTotalClients.Left = (TotalClientsCard.Width - lblTotalClients.Width) / 2;
            lblTotalClients.Top = (TotalClientsCard.Height - lblTotalClients.Height) / 2;

            lblAvrageBalance.Left = (AvrageBalanceCard.Width - lblAvrageBalance.Width) / 2;
            lblAvrageBalance.Top = (AvrageBalanceCard.Height - lblAvrageBalance.Height) / 2;


            lblTotalBalance.Left = (TotalBalanceCard.Width - lblTotalBalance.Width) / 2;
            lblTotalBalance.Top = (TotalBalanceCard.Height - lblTotalBalance.Height) / 2;

        }
        private void frmTotalBalances_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            SetPanelsShadowsAndGradients();
            SetBlancesClassesPieChar();
            SetTop5ClientsBarChart();
            FillInfoCards();
            CenterLabels();
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
    }
}
