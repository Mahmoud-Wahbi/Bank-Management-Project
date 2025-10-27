using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Transfer_LogBusiness
    {

        public int TranfareId { get; set; }
        public int ClientIdFrom { get; set; }
        public int ClientIdTo { get; set; }
        public int UserId { get; set; }
        public Decimal SourceBalance { get; set; }
        public string SourceCurrencyName { get; set; }
        public Decimal DestinationBalance { get; set; }
        public string DestinationCurrencyName { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Fees { get; set; }
        public DateTime TransferDate { get; set; }
        public string Notes { get; set; }
        public int PersonId { get; set; }

        private enum _enMode { AddNew, Update };
        _enMode Mode = _enMode.Update;

        public Transfer_LogBusiness()
        {
            TranfareId = 0;
            ClientIdFrom = 0;
            ClientIdTo = 0;
            UserId = 0;
            Amount = new Decimal(0);
            Fees = new Decimal(0);
            SourceBalance = new Decimal(0);
            SourceCurrencyName = string.Empty;
            DestinationBalance = new Decimal(0);
            DestinationCurrencyName = string.Empty;
            TransferDate = DateTime.MinValue;
            Notes = string.Empty;
            PersonId = 0;

            Mode = _enMode.AddNew;

        }

        private Transfer_LogBusiness(int TransfareId, int ClientIdFrom, int ClientIdTo, int UserId
             , Decimal Amount, Decimal Fees, Decimal SourceBalance, string SourceCurrencyName, Decimal DestinationBalance,
            string DestinationCurrencyName, DateTime TransferDate,
            string Notes, int PersonId)
        {
            this.TranfareId = TransfareId;
            this.ClientIdFrom = ClientIdFrom;
            this.ClientIdTo = ClientIdTo;
            this.UserId = UserId;
            this.Amount = Amount;
            this.Fees = Fees;
            this.SourceBalance = SourceBalance;
            this.SourceCurrencyName = SourceCurrencyName;
            this.DestinationBalance = DestinationBalance;
            this.DestinationCurrencyName = DestinationCurrencyName;
            this.TransferDate = TransferDate;
            this.Notes = Notes;
            this.PersonId = PersonId;


            Mode = _enMode.Update;
        }


        public static Transfer_LogBusiness FindTransferLog(int TransferId)
        {
            int ClientIdFrom = 0;
            int ClientIdTo = 0;
            int UserId = 0;
            decimal SourceBalance = 0;
            string SourceCurrencyName = string.Empty;
            decimal DestinationBalance = 0;
            string DestinationCurrencyName = string.Empty;
            decimal Amount = 0;
            decimal Fees = 0;
            DateTime TransferDate = DateTime.MinValue;
            string Notes = string.Empty;
            int PersonId = 0;

            if (Transfer_LogDataAccess.GetTransferLogById(TransferId, ref ClientIdFrom, ref ClientIdTo, ref UserId,
                ref SourceBalance, ref SourceCurrencyName, ref DestinationBalance, ref DestinationCurrencyName,
                ref Amount, ref Fees, ref TransferDate, ref Notes, ref PersonId))
            {
                return new Transfer_LogBusiness(TransferId, ClientIdFrom, ClientIdTo, UserId,
                    Amount, Fees, SourceBalance, SourceCurrencyName,
                    DestinationBalance, DestinationCurrencyName, TransferDate, Notes, PersonId);
            }
            else
            {
                return null;
            }
        }


        private bool _AddNewTransferLog()
        {
            this.TranfareId = Transfer_LogDataAccess.AddNewTransferRecord(ClientIdFrom, ClientIdTo, UserId,
                Amount, Fees, SourceBalance, SourceCurrencyName, DestinationBalance, DestinationCurrencyName, TransferDate, Notes, PersonId);


            return (this.TranfareId != -1);
        }

        private bool _UpdateTransferLog()
        {
            return Transfer_LogDataAccess.UpdateTransferLog(this.TranfareId, this.ClientIdFrom, this.ClientIdTo, this.UserId,
                this.SourceBalance, this.SourceCurrencyName, this.DestinationBalance, this.DestinationCurrencyName, this.Amount,
                this.Fees, this.TransferDate, this.Notes, this.PersonId);
        }

        public static DataTable GetTransferLogs()
        {
            return Transfer_LogDataAccess.GetTransferLogs();
        }

        public static bool DeleteLog(int LogId)
        {
            return Transfer_LogDataAccess.DeleteTransferLogById(LogId);
        }

        public static bool DeleteLogByClientId(int ClientId)
        {
            return Transfer_LogDataAccess.DeleteTransferLogByClientId(ClientId);
        }

        public static bool DeleteLogByUserId(int UserId)
        {
            return Transfer_LogDataAccess.DeleteTransferLogByUserId(UserId);
        }

        public static bool DeleteLogByPersonId(int PersonId)
        {
            return Transfer_LogDataAccess.DeleteTransferLogByPersonId(PersonId);
        }

        public static bool IsTransferLogExistByClientId(int ClientId)
        {
            return Transfer_LogDataAccess.IsTransferLogExistByClientId(ClientId);
        }

        public static bool IsTransferLogExistByUserId(int UserId)
        {
            return Transfer_LogDataAccess.IsTransferLogExistByUserId(UserId);
        }

        public static bool IsTransferLogExistByPersonId(int PersonId)
        {
            return Transfer_LogDataAccess.IsTransferLogExistByPersonId(PersonId);
        }
         

        public static DataTable GetNextOrPrevRows(int OffsetRows, int FetchRows , string AccountNumber = null)
        {

            DataTable DataTable = Transfer_LogDataAccess.GetNextOrPrevRows(OffsetRows, FetchRows , AccountNumber);

            return DataTable;

        }

        public bool Save()
        {

            switch (Mode)
            {
                case _enMode.AddNew:
                    Mode = _enMode.Update;
                    return _AddNewTransferLog();

                case _enMode.Update:
                    return _UpdateTransferLog();

            }

            return false;
        }

       


    }
}
