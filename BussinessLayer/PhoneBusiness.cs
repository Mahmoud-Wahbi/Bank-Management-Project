using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PhoneBusiness
    {

        public int PhoneId { get; set; }

        public int PersonId { get; set; }

        public string PhoneNumber { get; set; }

        enum _enMode { AddNew = 0, Update = 1 };

        _enMode Mode = _enMode.Update;

        public PhoneBusiness()
        {
            PhoneId = 0;
            PersonId = 0;
            PhoneNumber = string.Empty;

            Mode = _enMode.AddNew;

        }

        private PhoneBusiness(int PhoneId, int PersonId, string PhoneNumber)
        {

            Mode = _enMode.Update;

        }

        private bool _AddNewPhone()
        {

            this.PhoneId = PhoneDataAccess.AddNewPhone(this.PersonId, this.PhoneNumber);

            return (this.PhoneId != -1);

        }

        public static bool DeletePhone(int PersonId)
        {
            return PhoneDataAccess.DeletePhone(PersonId);
        }

        public static DataTable GetAllPhones(int PersonId)
        {
            return PhoneDataAccess.GetAllPhones(PersonId);
        }
        public bool Save()
        {

            switch (Mode)
            {

                case _enMode.AddNew:
                    Mode = _enMode.Update;
                    return _AddNewPhone();


            }

            return false;

        }

        public static bool IsPhoneExist(string PhoneNumber)
        {
            return PhoneDataAccess.IsPhoneExist(PhoneNumber);
        }

        public static bool IsPhoneExist(int PersonId_Fk_Person)
        {
            return PhoneDataAccess.IsPhoneExist(PersonId_Fk_Person);
        }

        public static DataTable FindPhones(int PersonId)
        {
            return PhoneDataAccess.GetPhone(PersonId);
        }

    }
}
