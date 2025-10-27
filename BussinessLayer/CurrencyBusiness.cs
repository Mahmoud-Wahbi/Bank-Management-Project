using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class CurrencyBusiness
    {

        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        decimal RateOnOneDollar { get; set; }

        public CurrencyBusiness()
        {
            CurrencyID = 0;
            CurrencyName = string.Empty;
            RateOnOneDollar = 0;

        }

        private CurrencyBusiness(int CurrencyId, string CurrencyName, decimal RateOnOneDollar)
        {

        }


    }
}
