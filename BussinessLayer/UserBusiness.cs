using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using System.Data;
using Common;

namespace BusinessLayer
{
    public class UserBusiness : PersonBusiness
    {


        public int UserId { get; set; }
        public int PersonId_Fk_User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }

        enum _enMode { AddNew = 0, Update = 1, AddOnlyUser = 2 };

        _enMode Mode = _enMode.Update;

        public UserBusiness()
        {
            this.UserId = 0;
            this.PersonId = 0;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Permissions = 0;

            Mode = _enMode.AddNew;

        }

        public UserBusiness(bool AddUserOnly)
        {
            this.UserId = 0;
            this.PersonId = 0;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Permissions = 0;

            Mode = _enMode.AddOnlyUser;

        }

        private UserBusiness(int UserId, int PersonId, string userName, string password, int permissions,
            int BaseId, int CountryId, string FirstName, string LastName, string Email, string Address, char Gender, DateTime BirthDate, string ImageUrl)
            : base(BaseId, CountryId, FirstName, LastName, Email, Address, Gender, BirthDate, ImageUrl)
        {

            this.UserId = UserId;
            this.PersonId = PersonId;
            this.UserName = userName;
            this.Password = password;
            this.Permissions = permissions;


            Mode = _enMode.Update;
        }

        private UserBusiness(int UserId, int PersonId, string Usename, string Password, int Permissions)
        {

            this.UserId = UserId;
            this.PersonId = PersonId;
            this.UserName = Usename;
            this.Password = Password;
            this.Permissions = Permissions;

            Mode = _enMode.Update;

        }

        private bool _AddNewUser()
        {

            //Adding PersonId Automaticlly to the User.
            //this.personid =  this.PersonId_Fk_User ..... is because we need to store the person id in the created object
            this.PersonId = this.PersonId_Fk_User = PersonDataAccess.AddNewPerson(this.CountryId, this.FirstName, this.LastName
                , this.Email, this.Address, this.Gender, this.BirthDate, this.ImageUrl);

            // Subbmiting that person is Added and saved before Saving User
            if (PersonId_Fk_User != -1)
                this.UserId = UserDataAccess.AddNewUser(this.PersonId_Fk_User, this.UserName, this.Password, this.Permissions);
            else
                this.UserId = -1;


            return (this.PersonId_Fk_User != -1 && this.UserId != -1);
        }

        private bool _AddOnlyUser()
        {
            this.UserId = UserDataAccess.AddNewUser(this.PersonId, this.UserName, this.Password, this.Permissions);

            return this.UserId != -1;

        }


        public static UserBusiness FindUser(int UserId)
        {
            int PersonId = 0;
            string Usename = string.Empty;
            string Password = string.Empty;
            int Permissions = 0;

            if (UserDataAccess.GetUserById(UserId, ref PersonId, ref Usename, ref Password, ref Permissions))
            {
                var FoundUser = new UserBusiness(UserId, PersonId, Usename, Password, Permissions);

                var FoundPerson = PersonBusiness.FindPerson(PersonId);

                if (FoundPerson != null && FoundUser != null)
                {
                    return new UserBusiness(UserId, PersonId, Usename, Password, Permissions,
                        FoundPerson.PersonId, FoundPerson.CountryId, FoundPerson.FirstName, FoundPerson.LastName, FoundPerson.Email,
                        FoundPerson.Address, FoundPerson.Gender, FoundPerson.BirthDate, FoundPerson.ImageUrl);
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

        public static UserBusiness FindUser(string UserName)
        {
            int UserId = 0, PersonId = 0;
            string Password = string.Empty;
            int Permissions = 0;

            if (UserDataAccess.GetUserByUserName(UserName, ref PersonId, ref Password, ref Permissions, ref UserId))
            {
                var FoundUser = new UserBusiness(UserId, PersonId, UserName, Password, Permissions);

                var FoundPerson = PersonBusiness.FindPerson(PersonId);

                if (FoundPerson != null && FoundUser != null)
                {
                    return new UserBusiness(UserId, PersonId, UserName, Password, Permissions,
                        FoundPerson.PersonId, FoundPerson.CountryId, FoundPerson.FirstName, FoundPerson.LastName, FoundPerson.Email,
                        FoundPerson.Address, FoundPerson.Gender, FoundPerson.BirthDate, FoundPerson.ImageUrl);
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

        public static UserBusiness FindUserByEmail(string Email)
        {
            int UserId = 0, PersonId = 0;
            string UserName = string.Empty;
            string Password = string.Empty;
            int Permissions = 0;

            if (UserDataAccess.GetUserByEmail(Email, ref UserId, ref PersonId, ref UserName, ref Password, ref Permissions))
            {
                var FoundUser = new UserBusiness(UserId, PersonId, UserName, Password, Permissions);

                var FoundPerson = PersonBusiness.FindPerson(PersonId);

                if (FoundPerson != null && FoundUser != null)
                {
                    return new UserBusiness(UserId, PersonId, UserName, Password, Permissions,
                        FoundPerson.PersonId, FoundPerson.CountryId, FoundPerson.FirstName, FoundPerson.LastName, FoundPerson.Email,
                        FoundPerson.Address, FoundPerson.Gender, FoundPerson.BirthDate, FoundPerson.ImageUrl);
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


        public static UserBusiness FindUserByPersonId(int PersonId)
        {
            int UserId = 0;
            string UserName = string.Empty;
            string Password = string.Empty;
            int Permissions = 0;

            if (UserDataAccess.GetUserByPersonId(PersonId, ref UserId, ref UserName, ref Password, ref Permissions))
            {
                var FoundUser = new UserBusiness(UserId, PersonId, UserName, Password, Permissions);

                var FoundPerson = PersonBusiness.FindPerson(PersonId);

                if (FoundPerson != null && FoundUser != null)
                {
                    return new UserBusiness(UserId, PersonId, UserName, Password, Permissions,
                        FoundPerson.PersonId, FoundPerson.CountryId, FoundPerson.FirstName, FoundPerson.LastName, FoundPerson.Email,
                        FoundPerson.Address, FoundPerson.Gender, FoundPerson.BirthDate, FoundPerson.ImageUrl);
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




        private bool _UpdateUser()
        {
            return
                UserDataAccess.UpdateUser(this.UserId, this.PersonId, this.UserName, this.Password, this.Permissions)

                &&

                PersonDataAccess.UpdatePerson(this.PersonId, this.CountryId, this.FirstName, this.LastName, this.Email, this.Address,
                this.Gender, this.BirthDate, this.ImageUrl)

                ;


        }

        public static bool DeleteUser(int UserId, ref bool IsClientDeleted)
        {
            int personId = 0;
            string username = "", password = "";
            int permissions = 0;
            bool success = true;

            if (!UserDataAccess.GetUserById(UserId, ref personId, ref username, ref password, ref permissions))
                return false;

            if (PhoneBusiness.IsPhoneExist(personId) && !PhoneDataAccess.DeletePhone(personId))
                success = false;

            if (Transfer_LogBusiness.IsTransferLogExistByUserId(UserId) && !Transfer_LogBusiness.DeleteLogByUserId(UserId))
                success = false;

            if (Transaction_Log.IsTransactionLogExistByUserId(UserId) && !Transaction_Log.DeleteTransactionLogsByUserId(UserId))
                success = false;

            if (ClientsBusiness.IsClientExistByPersonId(personId))
            {
                if (!ClientsBusiness.DeleteOnlyClientByPersonId(personId))
                    success = false;
                else
                    IsClientDeleted = true;
            }
            else
            {
                IsClientDeleted = false;
            }

            if (!UserDataAccess.DeleteOnlyUser(UserId))
                success = false;

            if (!ClientsBusiness.IsClientExistByPersonId(personId))
            {
                if (!PersonBusiness.DeletePerson(personId))
                    success = false;
            }

            return success;
        }

        public static bool DeleteOnlyUser(int UserId)
        {

            bool Success = true;

            if (Transaction_Log.IsTransactionLogExistByUserId(UserId) && !Transaction_Log.DeleteTransactionLogsByUserId(UserId))
                Success = false;

            if (Transfer_LogBusiness.IsTransferLogExistByUserId(UserId) && !Transfer_LogBusiness.DeleteLogByUserId(UserId))
                Success = false;

            if (!UserDataAccess.DeleteOnlyUser(UserId))
                Success = false;

            return Success;

        }

        public static bool DeleteOnlyUserByPersonId(int PersonId)
        {

            bool Success = true;

            if (Transaction_Log.IsTransactionExistByPersonId(PersonId) && !Transaction_Log.DeleteTransactionLogsBypersonId(PersonId))
                Success = false;

            if (Transfer_LogBusiness.IsTransferLogExistByPersonId(PersonId) && !Transfer_LogBusiness.DeleteLogByPersonId(PersonId))
                Success = false;

            if (!UserDataAccess.DeleteOnlyUserByPersonId(PersonId))
                Success = false;

            return Success;

        }



        public static bool IsUserExist(int UserId)
        {
            return UserDataAccess.IsUserExist(UserId);
        }

        public static bool IsUserExist(string UserName)
        {
            return UserDataAccess.IsUserExist(UserName);
        }

        public static bool IsUserExistByPersonId(int PersonId)
        {
            return UserDataAccess.IsUserExistByPersonId(PersonId);
        }

        public bool Login(string UserName, string Password)
        {
            bool IsLoginCurrect = false;

            if (this.UserName != UserName || Utility.PasswordDecryption(this.Password,4) !=  Password)
            {
                IsLoginCurrect = false;
            }
            else
            {
                IsLoginCurrect = true;
            }

            return IsLoginCurrect;
        }

        public static DataTable GetAllUsers()
        {
            return UserDataAccess.GetUsersTable();
        }

        public static DataTable GetUsersShortInfo()
        {
            return UserDataAccess.GetShortUsersTable();
        }

        public enum enPermissions
        {
            All = -1, ListClients = 2, AddNewClient = 4, DeleteClient = 8, UpdateClient = 16,
            FindClient = 32, Transactions = 64, ManageUsers = 128
        }
        public bool CheckAccessRights(int permissions)
        {
            if ((permissions == (int)enPermissions.All))
                return true;

            if (((int)this.Permissions & permissions) == permissions)
                return true;
            else
                return false;
        }

        public bool HasPermission(int permissions)
        {
            return ((int)this.Permissions & permissions) == permissions;
        }

        public bool Save()
        {

            switch (Mode)
            {
                case _enMode.AddNew:

                    if (_AddNewUser())
                    {
                        Mode = _enMode.Update;
                        return true;
                    }
                    else
                    {
                        Mode = _enMode.Update;
                        return false;
                    }

                case _enMode.AddOnlyUser:
                    if (_AddOnlyUser())
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
                    return _UpdateUser();


            }



            return false;
        }

        public static DataTable GetNextOrPrevRows(int OffsetRows, int FetchRows, string SearchColumn = null, object SearchValue = null)
        {

            DataTable DataTable = UserDataAccess.GetNextOrPrevRows(OffsetRows, FetchRows, SearchColumn, SearchValue);

            return DataTable;

        }

        public bool IsUserTheAdmin()
        {
            return this.UserName == "admin" || this.UserName == "Admin";
        }

        public bool _RegesterALogin()
        {
          return  UserDataAccess.RegesterALogin(this.UserId , DateTime.Now , this.UserName , this.Password , this.Permissions);
        }

    }
}
