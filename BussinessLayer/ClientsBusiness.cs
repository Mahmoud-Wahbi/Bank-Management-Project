using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLayer
{
    public class ClientsBusiness : PersonBusiness
    {


        public int ClientId { get; set; }
        public int PersonId_FK_Clients { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string PinCode { get; set; }

        private enum _enMode { AddNew = 0, Update = 1, AddOnlyClient = 2 };

        _enMode Mode = _enMode.Update;


        public ClientsBusiness()
        {
            this.ClientId = 0;
            this.PersonId_FK_Clients = 0;
            this.AccountNumber = string.Empty;
            this.Balance = 0;
            this.PinCode = string.Empty;

            Mode = _enMode.AddNew;
        }

        public ClientsBusiness(bool AddOnlyClient)
        {
            this.ClientId = 0;
            this.PersonId_FK_Clients = 0;
            this.AccountNumber = string.Empty;
            this.Balance = 0;
            this.PinCode = string.Empty;

            Mode = _enMode.AddOnlyClient;
        }


        private ClientsBusiness(int ClinetId, int PersonId, string AccountNumber, decimal Balance, string PinCode, int baseId, int countryId
            , string firstName, string lastName, string email, string address, char gender, DateTime birthDate, string imageUrl
            ) : base(baseId, countryId, firstName, lastName, email, address, gender, birthDate, imageUrl)
        {

            this.ClientId = ClinetId;
            this.PersonId = PersonId;
            this.AccountNumber = AccountNumber;
            this.Balance = Balance;
            this.PinCode = PinCode;

            Mode = _enMode.Update;
        }

        ClientsBusiness(int ClientId, int PersonId, string AccountNumber, Decimal Balance, string PinCode)
        {

            this.ClientId = ClientId;
            this.PersonId = PersonId;
            this.AccountNumber = AccountNumber;
            this.Balance = Balance;
            this.PinCode = PinCode;

            Mode = _enMode.Update;
        }

        private bool _AddNewClient()
        {

            //Adding PersonId Automaticlly to the Client.
            //this.personid = this.PersonId_FK_Clients ..... is because we need to store the person id in the created object
            this.PersonId = this.PersonId_FK_Clients = PersonDataAccess.AddNewPerson(this.CountryId, this.FirstName, this.LastName
                , this.Email, this.Address, this.Gender, this.BirthDate, this.ImageUrl);

            // Subbmiting that person is Added and saved before Saving Client
            if (PersonId_FK_Clients != -1)
                this.ClientId = ClientDataAccess.AddNewClient(this.PersonId_FK_Clients, this.AccountNumber, this.Balance, this.PinCode);
            else
                this.ClientId = -1;


            return (this.PersonId_FK_Clients != -1 && this.ClientId != -1);
        }

        private bool _AddOnlyClient()
        {
            this.ClientId = ClientDataAccess.AddNewClient(this.PersonId, this.AccountNumber, this.Balance, this.PinCode);

            return this.ClientId != -1;
        }

        public static ClientsBusiness FindClient(int ClientId)
        {

            int PersonId_FK_Clients = 0;
            string AccountNumber = string.Empty, PinCode = string.Empty;
            Decimal Balance = 0;

            if (ClientDataAccess.GetClientById(ClientId, ref PersonId_FK_Clients, ref AccountNumber, ref Balance, ref PinCode))
            {
                var FoundClient = new ClientsBusiness(ClientId, PersonId_FK_Clients, AccountNumber, Balance, PinCode);


                var FoundPerson = PersonBusiness.FindPerson(PersonId_FK_Clients);


                if (FoundClient != null && FoundPerson != null)
                {
                    return new ClientsBusiness(ClientId, PersonId_FK_Clients, AccountNumber, Balance, PinCode,
                        FoundPerson.PersonId, FoundPerson.CountryId, FoundPerson.FirstName, FoundPerson.LastName, FoundPerson.Email, FoundPerson.Address,
                        FoundPerson.Gender, FoundPerson.BirthDate, FoundPerson.ImageUrl);
                }
                else
                {
                    return null;
                }


            }
            else
            {
                return null;
            }
        }


        public static ClientsBusiness FindClient(string AccountNumber)
        {

            int ClientId = 0, PersonId_FK_Clients = 0;
            string PinCode = string.Empty;
            Decimal Balance = 0;

            if (ClientDataAccess.GetClientByAccountNumber(AccountNumber, ref PersonId_FK_Clients, ref ClientId, ref Balance, ref PinCode))
            {
                var FoundClient = new ClientsBusiness(ClientId, PersonId_FK_Clients, AccountNumber, Balance, PinCode);


                var FoundPerson = PersonBusiness.FindPerson(PersonId_FK_Clients);


                if (FoundClient != null && FoundPerson != null)
                {
                    return new ClientsBusiness(ClientId, PersonId_FK_Clients, AccountNumber, Balance, PinCode,
                        FoundPerson.PersonId, FoundPerson.CountryId, FoundPerson.FirstName, FoundPerson.LastName, FoundPerson.Email, FoundPerson.Address,
                        FoundPerson.Gender, FoundPerson.BirthDate, FoundPerson.ImageUrl);
                }
                else
                {
                    return null;
                }


            }
            else
            {
                return null;
            }
        }


        public static ClientsBusiness FindClientByEmail(string Email)
        {
            int ClientId = 0, PersonId_FK_Clients = 0;
            string PinCode = string.Empty, AccountNumber = string.Empty;
            Decimal Balance = 0;

            if (ClientDataAccess.GetClientByEmail(Email, ref ClientId, ref PersonId_FK_Clients, ref AccountNumber, ref Balance, ref PinCode))
            {
                var FoundClient = new ClientsBusiness(ClientId, PersonId_FK_Clients, AccountNumber, Balance, PinCode);


                var FoundPerson = PersonBusiness.FindPerson(PersonId_FK_Clients);


                if (FoundClient != null && FoundPerson != null)
                {
                    return new ClientsBusiness(ClientId, PersonId_FK_Clients, AccountNumber, Balance, PinCode,
                        FoundPerson.PersonId, FoundPerson.CountryId, FoundPerson.FirstName, FoundPerson.LastName, FoundPerson.Email, FoundPerson.Address,
                        FoundPerson.Gender, FoundPerson.BirthDate, FoundPerson.ImageUrl);
                }
                else
                {
                    return null;
                }


            }
            else
            {
                return null;
            }

        }

        public static ClientsBusiness FindClientByPersonId(int PersonId_FK_Clients)
        {
            int ClientId = 0;
            string PinCode = string.Empty, AccountNumber = string.Empty;
            Decimal Balance = 0;

            if (ClientDataAccess.GetClientByPersonId(PersonId_FK_Clients, ref ClientId, ref AccountNumber, ref Balance, ref PinCode))
            {
                var FoundClient = new ClientsBusiness(ClientId, PersonId_FK_Clients, AccountNumber, Balance, PinCode);


                var FoundPerson = PersonBusiness.FindPerson(PersonId_FK_Clients);


                if (FoundClient != null && FoundPerson != null)
                {
                    return new ClientsBusiness(ClientId, PersonId_FK_Clients, AccountNumber, Balance, PinCode,
                        FoundPerson.PersonId, FoundPerson.CountryId, FoundPerson.FirstName, FoundPerson.LastName, FoundPerson.Email, FoundPerson.Address,
                        FoundPerson.Gender, FoundPerson.BirthDate, FoundPerson.ImageUrl);
                }
                else
                {
                    return null;
                }


            }
            else
            {
                return null;
            }

        }




        private bool _UpdateClient()
        {
            return (ClientDataAccess.UpdateClient(this.ClientId, this.AccountNumber, this.Balance, this.PinCode)
                &&
                PersonDataAccess.UpdatePerson(this.PersonId, this.CountryId, this.FirstName, this.LastName, this.Email, this.Address, this.Gender, this.BirthDate, this.ImageUrl)

                );

        }

        public static bool DeleteClient(int ClientId, ref bool IsUserDeleted , ref bool IsAdmin)
        {
            IsAdmin = false;

            int personId = 0;
            string accountNumber = "", pinCode = "";
            decimal balance = 0;
            bool success = true;

            if (!ClientDataAccess.GetClientById(ClientId, ref personId, ref accountNumber, ref balance, ref pinCode))
                return false;

            if (PhoneBusiness.IsPhoneExist(personId) && !PhoneDataAccess.DeletePhone(personId))
                success = false;

            if (Transfer_LogBusiness.IsTransferLogExistByClientId(ClientId) && !Transfer_LogBusiness.DeleteLogByClientId(ClientId))
                success = false;

            if (Transaction_Log.IsTransactionLogExist(ClientId) && !Transaction_Log.DeleteTransactionLogsByClientId(ClientId))
                success = false;

            if (!ClientDataAccess.DeleteClientById(ClientId))
                success = false;

            // Check if this person is also a User
            UserBusiness UserObject = UserBusiness.FindUserByPersonId(personId);
            if (UserObject != null)
            {
                if (UserObject.IsUserTheAdmin())
                {
                    IsAdmin = true;
                    return false;
                }
            }

            if (UserBusiness.IsUserExistByPersonId(personId))
            {
                if (!UserBusiness.DeleteOnlyUserByPersonId(personId))
                    success = false;
                else
                    IsUserDeleted = true;
            }
            else
            {
                IsUserDeleted = false;
            }

            // Delete person only if no longer a user or client
            if (!UserBusiness.IsUserExistByPersonId(personId) &&
                !ClientsBusiness.IsClientExistByPersonId(personId))
            {
                if (!PersonBusiness.DeletePerson(personId))
                    success = false;
            }

            return success;
        }


        public static bool DeleteOnlyClient(int ClientId)
        {
            bool Success = true;

            if (Transaction_Log.IsTransactionLogExist(ClientId) && !Transaction_Log.DeleteTransactionLogsByClientId(ClientId))
                Success = false;

            if (Transfer_LogBusiness.IsTransferLogExistByClientId(ClientId) && !Transfer_LogBusiness.DeleteLogByClientId(ClientId))
                Success = false;

            if (!ClientDataAccess.DeleteClientById(ClientId))
                Success = false;

            return Success;

        }

        public static bool DeleteOnlyClientByPersonId(int PersonId)
        {

            bool Success = true;

            if (Transaction_Log.IsTransactionExistByPersonId(PersonId) && !Transaction_Log.DeleteTransactionLogsBypersonId(PersonId))
                Success = false;

            if (Transfer_LogBusiness.IsTransferLogExistByPersonId(PersonId) && !Transfer_LogBusiness.DeleteLogByPersonId(PersonId))
                Success = false;

            if (!ClientDataAccess.DeleteClientByPersonId(PersonId))
                Success = false;

            return Success;

        }


        public static bool IsClientExist(int ClientiD)
        {
            return ClientDataAccess.IsClientExist(ClientiD);
        }

        public static bool IsClientExistByPersonId(int PersonId)
        {
            return ClientDataAccess.IsClientExistByPersonId(PersonId);
        }
        public static bool IsClientExistByAccountNumber(string AccountNumber)
        {
            return ClientDataAccess.IsClientExistByAccountNumber(AccountNumber);
        }

        public bool SaveClient()
        {
            switch (Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewClient())
                    {
                        Mode = _enMode.Update;
                        return true;
                    }
                    else
                    {
                        Mode = _enMode.Update;
                        return false;
                    }


                case _enMode.AddOnlyClient:
                    if (_AddOnlyClient())
                    {
                        Mode = _enMode.Update;
                        return true;
                    }
                    else
                    {
                        Mode = _enMode.Update;
                        return false;
                    }

                case _enMode.Update:
                    return _UpdateClient();

            }

            return false;
        }

        public static DataTable GetClientsTable()
        {

            DataTable dtClients = new DataTable();

            dtClients = ClientDataAccess.GetClientsTable();

            return dtClients;
        }

        public static DataTable GetShortClientsTable()
        {

            DataTable dtClients = new DataTable();

            dtClients = ClientDataAccess.GetShortClientsTable();

            return dtClients;
        }


        private bool LogTransaction(ref Transaction_Log TransactionLogObject, ref string MessageError, string TransactionNotes, Transaction_Type TransactionTypeObject)
        {


            TransactionLogObject.UserId = GlobaCurrentlUser.CurrentUser.UserId;
            TransactionLogObject.ClientId = this.ClientId;

            Countries_CurenciesBusiness Country_CurrencyObject = Countries_CurenciesBusiness.Find(this.CountryId);

            if (Country_CurrencyObject != null)
            {
                TransactionLogObject.Currency = Country_CurrencyObject.CurrencyName;

            }
            else
            {
                MessageError = "Currency information not found for this country.";
                return false;
            }

            TransactionLogObject.Amount = this.Balance;
            TransactionLogObject.TransactionDate = DateTime.Now;
            TransactionLogObject.TransactionTypeId = TransactionTypeObject.Transaction_TypeId;
            TransactionLogObject.Notes = TransactionNotes;
            TransactionLogObject.PersonId = this.PersonId;

            if (!TransactionLogObject.Save())
            {
                MessageError = "Could not save log in transaction logs.";
                return false;
            }
            else
            {
                return true;
            }

        }

        Transaction_Type TransactionTypeObject;

        public bool TryUpdateBalance(Decimal Amount, int ClientId, ref string MessageError, bool IsTransaction, string TransactionNotes = "")
        {
            Decimal NewBalance = 0;



            if (Amount < 0)
            {

                // Amount is already sent as negative so adding it to balance will substact it from balance.
                if (this.Balance + Amount >= 0)
                {
                    NewBalance = this.Balance + Amount;
                    TransactionTypeObject = Transaction_Type.FindType("Withdraw");

                }
                else
                {
                    MessageError = "Amount exceeds the balance.";
                    return false;
                }

            }
            else
            {

                NewBalance = this.Balance + Amount;

                TransactionTypeObject = Transaction_Type.FindType("Deposit");
            }


            if (ClientDataAccess.UpdateBalance(NewBalance, ClientId))
            {

                this.Balance = NewBalance;



                Transaction_Log TransactionLogObject = new Transaction_Log();

                if (IsTransaction)
                {
                    return LogTransaction(ref TransactionLogObject, ref MessageError, TransactionNotes, TransactionTypeObject);
                }

                return true;
            }

            else
            {
                MessageError = "Could not save data in database";

                return false;
            }
        }


        public static Decimal GetTotalBalances()
        {
            return ClientDataAccess.GetTotalBalances();
        }


        public static DataTable GetNextOrPrevRows(int OffsetRows, int FetchRows , string SearchColumn = null,object SearchValue = null)
        {

            DataTable DataTable = ClientDataAccess.GetNextOrPrevRows(OffsetRows, FetchRows ,  SearchColumn, SearchValue );

            return DataTable;

        }



        public static DataTable GetTableSeachOf(string Keyword, Common.SearchConstrants.enSearchMethod enSearchMethod)
        {
            DataTable Dt = ClientDataAccess.GetTableSeachOf(Keyword, enSearchMethod);
            return Dt;
        }

        public static string GetRandomNextAccountNumber()
        {
            return ClientDataAccess.GenerateRandomNextAccountNumber();
        }

    }

}
