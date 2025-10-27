using BusinessLayer;
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
using UI.Properties;
using System.Text.RegularExpressions;
using Guna.UI2.WinForms.Suite;
using System.IO;

namespace UI
{
    public partial class frmExchange : Form
    {

        public frmExchange()
        {
            InitializeComponent();

        }

        private int? _countryIdFrom;
        private int? _countryIdTo;

        public frmExchange(int CountryIdTo )
        {
            InitializeComponent();
            _countryIdFrom = 2;
            _countryIdTo = CountryIdTo;
        }


        private bool _isFilling = false;

        public void FillCountriesComboboxes()
        {
            _isFilling = true; 

            DataTable dtCountries = CountryBusiness.GetAllCurrenciesNames();

            if (dtCountries.Rows.Count > 0)
            {
                foreach (DataRow row in dtCountries.Rows)
                {
                    cbCurrenciesfrom.Items.Add(row[0].ToString());
                    cbCurrenciesTo.Items.Add(row[0].ToString());
                }
            }

            if (cbCurrenciesfrom.Items.Count > 1)
            {
                cbCurrenciesfrom.SelectedIndex = 1;
                cbCurrenciesTo.SelectedIndex = 1;
            }
            else if (cbCurrenciesfrom.Items.Count > 0)
            {
                cbCurrenciesfrom.SelectedIndex = 0;
                cbCurrenciesTo.SelectedIndex = 0;
            }

            _isFilling = false; 
        }




        private void frmExchange_Load(object sender, EventArgs e)
        {
            
            FillCountriesComboboxes();
 
            txtFromCurrenct.Text = "500";          

            if (_countryIdTo.HasValue)
            {
                FindCurrencyByCountryId(_countryIdTo.Value , _countryIdFrom.Value);
            }
        }


        private void cbCurrenciesfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFilling) return; // Ignore calling the event while loading the form and filling the comboboxes
        }

        private void cbCurrenciesTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFilling) return;// Ignore calling the event while loading the form and filling the comboboxes
        }

        Countries_CurenciesBusiness CurrencyFromObject = new Countries_CurenciesBusiness();
        Countries_CurenciesBusiness CurrencyToObject = new Countries_CurenciesBusiness();

        private void FindCurrencyByCountryId(int CountryIdTo , int CountryIdFrom)
        {
            CurrencyFromObject = Countries_CurenciesBusiness.Find(CountryIdFrom);
            CurrencyToObject = Countries_CurenciesBusiness.Find(CountryIdTo);
            int indexFrom = cbCurrenciesTo.FindStringExact(CurrencyFromObject.CurrencyName);
            if (indexFrom != -1)
                cbCurrenciesfrom.SelectedIndex = indexFrom;

            int indexTo = cbCurrenciesTo.FindStringExact(CurrencyToObject.CurrencyName);
            if (indexTo != -1)
                cbCurrenciesTo.SelectedIndex = indexTo;
        }
        private void FindCurrencyByCurrencyName()
        {
            if (cbCurrenciesfrom.SelectedItem == null || cbCurrenciesTo.SelectedItem == null)
                return;

            CurrencyFromObject = Countries_CurenciesBusiness.Find(cbCurrenciesfrom.SelectedItem.ToString());
            CurrencyToObject = Countries_CurenciesBusiness.Find(cbCurrenciesTo.SelectedItem.ToString());
        }


        // Validate Amounts
        private bool ValidateAmounts()
        {
            bool isValid = true;

            // Validate From
            if (!decimal.TryParse(txtFromCurrenct.Text, out decimal amountFrom))
            {
                errorProvider1.SetError(txtFromCurrenct, "Invalid decimal value.");
                isValid = false;
            }
            else if (amountFrom > decimal.MaxValue)
            {
                errorProvider1.SetError(txtFromCurrenct, $"Value must be less than {decimal.MaxValue}");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtFromCurrenct, "");
            }


            return isValid;
        }
        private void btnExchange_Click(object sender, EventArgs e)
        {

            if (!ValidateAmounts())
                return; 

            FindCurrencyByCurrencyName();

            txtToCurrency.Text = CurrencyFromObject
                .ConvertToOtherCurrency(Convert.ToDecimal(txtFromCurrenct.Text), CurrencyToObject)
                .ToString("N2");
        }
    }
}
