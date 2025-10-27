using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
namespace BusinessLayer
{

    public class Countries_CurenciesBusiness
    {

        public int Country_CurrencyId { get; set; }
        public int CountryId { get; set; }
        public int CurrencyId { get; set; }
        public Decimal Rate_On_1_Dollar { get; set; }
        public string CurrencyName { get; set; }

        private enum _enMode { AddNew, Update };

        _enMode Mode = _enMode.Update;

        public Countries_CurenciesBusiness()
        {
            this.Country_CurrencyId = 0;
            this.CountryId = 0;
            this.CurrencyId = 0;
            this.Rate_On_1_Dollar = 0;
            this.CurrencyName = string.Empty;

            Mode = _enMode.AddNew;
        }

        private Countries_CurenciesBusiness(int country_CurrencyId, int countryId, int currencyId, decimal rate_On_1_Dollar, string CurrencyName)
        {
            this.Country_CurrencyId = country_CurrencyId;
            this.CountryId = countryId;
            this.CurrencyId = currencyId;
            this.Rate_On_1_Dollar = rate_On_1_Dollar;
            this.CurrencyName = CurrencyName;

            Mode = _enMode.Update;
        }

        public static Countries_CurenciesBusiness Find(int CountryId)
        {
            int CurrencyId = 0, Country_Currency_Id = 0;
            Decimal Rate_On_1_Dollar = 0;
            string CurrencyName = string.Empty;

            if (Countries_CurrenciesDataAccess.GetCurrencyByCountryId(CountryId, ref CurrencyId, ref Rate_On_1_Dollar,
                ref Country_Currency_Id, ref CurrencyName))
            {
                return new Countries_CurenciesBusiness(Country_Currency_Id, CountryId, CurrencyId, Rate_On_1_Dollar, CurrencyName);
            }
            else
            {
                return null;
            }
        }

        public static Countries_CurenciesBusiness Find(string CurrencyName)
        {
            int CountryId = 0, CurrencyId = 0, Country_Currency_Id = 0;
            Decimal Rate_On_1_Dollar = 0;

            if (Countries_CurrenciesDataAccess.GetCurrencyByCurrencyName(CurrencyName, ref CountryId, ref CurrencyId, ref Rate_On_1_Dollar,
                ref Country_Currency_Id))
            {
                return new Countries_CurenciesBusiness(Country_Currency_Id, CountryId, CurrencyId, Rate_On_1_Dollar, CurrencyName);
            }
            else
            {
                return null;
            }
        }

        public static Decimal GetExchangeRate(int CountryId)
        {

            Decimal ExchangeRate = 0;

            if (Countries_CurrenciesDataAccess.GetExchangeRateByCountry(CountryId, ref ExchangeRate))
            {
                return ExchangeRate;
            }
            else
            {
                return -1;
            }


        }

        public Decimal ConvertToUSD(Decimal Amount)
        {
            return Amount / this.Rate_On_1_Dollar;
        }

        public Decimal ConvertToOtherCurrency(Decimal Amount, Countries_CurenciesBusiness OtherCurrency)
        {

            Decimal AmountInDollar = ConvertToUSD(Amount);

            //If Other Currency Is Dollar
            if (OtherCurrency.CurrencyId == 2)
            {
                return AmountInDollar;
            }

            return (AmountInDollar * OtherCurrency.Rate_On_1_Dollar);

        }

       

    }
}
