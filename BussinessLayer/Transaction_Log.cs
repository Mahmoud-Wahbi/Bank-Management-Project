using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class Transaction_Log
    {

        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public string Currency { get; set; }
        public Decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionTypeId { get; set; }
        public string Notes { get; set; }

        public int PersonId { get; set; }

        private enum _enMode { AddNew, Update };

        _enMode Mode = _enMode.Update;


        public Transaction_Log()
        {
            this.TransactionId = 0;
            this.UserId = 0;
            this.ClientId = 0;
            this.Currency = string.Empty;
            this.Amount = 0;
            this.TransactionDate = DateTime.MinValue;
            this.TransactionTypeId = 0;
            this.Notes = string.Empty;
            this.PersonId = 0;

            Mode = _enMode.AddNew;

        }

        private Transaction_Log(int TransactionId, int UserId, int ClientId, string Currency, Decimal Amount, DateTime TransactionDate, int TransactionTypeId, string Notes, int PersonId)
        {

            this.TransactionId = TransactionId;
            this.UserId = UserId;
            this.ClientId = ClientId;
            this.Currency = Currency;
            this.Amount = Amount;
            this.TransactionDate = TransactionDate;
            this.TransactionTypeId = TransactionTypeId;
            this.Notes = Notes;
            this.PersonId = PersonId;

            Mode = _enMode.Update;
        }

        private bool _AddTransactionLog()
        {

            this.TransactionId = TransactionLogDataAccess.AddTransactionLog(this.UserId, this.ClientId, this.Currency, this.Amount
                , this.TransactionDate, this.TransactionTypeId, this.Notes, this.PersonId);

            return (this.TransactionId != -1);
        }



        public static bool IsTransactionLogExist(int ClientId)
        {
            return TransactionLogDataAccess.IsTransactionLogExistByClientId(ClientId);
        }

        public static bool IsTransactionLogExistByUserId(int UserId)
        {
            return TransactionLogDataAccess.IsTransactionLogExistByUserId(UserId);
        }

        public static bool IsTransactionExistByPersonId(int PersonId)
        {
            return TransactionLogDataAccess.IsTransactionLogExistByPersonId(PersonId);
        }

        public static bool DeleteTransactionLogsByClientId(int ClientId)
        {
            return TransactionLogDataAccess.DeleteTransactionLogsByClientId(ClientId);
        }

        public static bool DeleteTransactionLogsByUserId(int UserId)
        {
            return TransactionLogDataAccess.DeleteTransactionLogsByUserId(UserId);
        }

        public static bool DeleteTransactionLogsBypersonId(int PersonId)
        {
            return TransactionLogDataAccess.DeleteTransactionLogsByPersonId(PersonId);
        }




        public bool Save()
        {
            switch (Mode)
            {

                case (_enMode.AddNew):

                    if (_AddTransactionLog())
                    {
                        Mode = _enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }

            return false;

        }


    }
}
