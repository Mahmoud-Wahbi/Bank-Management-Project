using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CountryBusiness
    {

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        private enum _enMode { AddNew = 0, Update = 1 };
        _enMode Mode = _enMode.Update;

        public CountryBusiness()
        {
            CountryId = 0;
            CountryName = string.Empty;
            CountryCode = string.Empty;

            Mode = _enMode.AddNew;

        }

        private CountryBusiness(int CountryID, string CountryName, string CountryCode)
        {

            this.CountryId = CountryID;
            this.CountryName = CountryName;
            this.CountryCode = CountryCode;

            Mode = _enMode.Update;

        }

        public static DataTable GetCountries()
        {
            return CountriesDataAccess.GetCountries();
        }

        public static byte GetCountryIdByCountryName(string CountryName)
        {

            return CountriesDataAccess.GetCountryIdByCountryName(CountryName);
        }

        
        public static CountryBusiness Find(int CountryId)
        {

            string CountryName = "", CountryCode = "";

            if (CountriesDataAccess.GetCountryById(CountryId, ref CountryName, ref CountryCode))
            {
                return new CountryBusiness(CountryId, CountryName, CountryCode);
            }
            else
            {
                return null;
            }

        }


        public static DataTable GetAllCurrenciesNames()
        {
            return CountriesDataAccess.GetAllCurrenciesNames();
        }

        public static string GetCountryFlag(int CountryId)
        {
            return CountriesDataAccess.GetCountryFlag(CountryId);
        }

    }
}
