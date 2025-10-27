using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Transaction_Type
    {

        public int Transaction_TypeId { get; set; }
        public string Transaction_Name { get; set; }

        public Transaction_Type()
        {
            Transaction_TypeId = 0;
            Transaction_Name = string.Empty;
        }


        private Transaction_Type(int TransactionId, string TransactionName)
        {
            this.Transaction_TypeId = TransactionId;
            this.Transaction_Name = TransactionName;
        }

        public static Transaction_Type FindType(string Name)
        {

            int TransactionId = 0;

            if (Transaction_TypeDataAccess.GetTransactionIdByName(Name, ref TransactionId))
            {
                return new Transaction_Type(TransactionId, Name);
            }
            else
            {
                return null;
            }

        }



    }
}
