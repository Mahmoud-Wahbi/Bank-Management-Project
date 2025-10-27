
using DataAccesLayer;
using System;
using System.Runtime.CompilerServices;

namespace BusinessLayer
{
    public class PersonBusiness
    {

        public int PersonId { get; set; }
        public int CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }

        private enum _enMode { Addnew = 0, Update = 1 };
        _enMode Mode = _enMode.Update;

        public PersonBusiness()
        {
            PersonId = 0;
            CountryId = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            Gender = char.MinValue;
            BirthDate = DateTime.MinValue;
            ImageUrl = string.Empty;

            Mode = _enMode.Addnew;
        }

        protected PersonBusiness(int Id, int CountryId, string FirstName, string LastName,
            string Email, string Address, char Gender, DateTime BirthDate, string ImageUrl)
        {
            this.PersonId = Id;
            this.CountryId = CountryId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Address = Address;
            this.Gender = Gender;
            this.BirthDate = BirthDate;
            this.ImageUrl = ImageUrl;

            Mode = _enMode.Update;
        }

        protected bool _AddNewPerson()
        {
            this.PersonId = PersonDataAccess.AddNewPerson(this.CountryId, this.FirstName, this.LastName, this.Email,
                this.Address, this.Gender, this.BirthDate, this.ImageUrl);
            return (this.PersonId != -1);
        }

        public static PersonBusiness FindPerson(int Id)
        {

            int CountryId = 0;
            string FirstName = string.Empty, LastName = string.Empty, Email = string.Empty, Address = string.Empty, ImageUrl = string.Empty;
            char Gender = Char.MinValue;
            DateTime BirthDate = DateTime.MinValue;


            if (PersonDataAccess.GetPersonById(Id, ref CountryId, ref FirstName, ref LastName, ref Email, ref Address, ref Gender, ref BirthDate, ref ImageUrl))
            {
                return new PersonBusiness(Id, CountryId, FirstName, LastName, Email, Address, Gender, BirthDate, ImageUrl);
            }
            else
            {
                return null;
            }
        }

        public static PersonBusiness FindPersonByEmail(string Email)
        {
            int PersonId = 0;
            int CountryId = 0;
            string FirstName = string.Empty, LastName = string.Empty, Address = string.Empty, ImageUrl = string.Empty;
            char Gender = Char.MinValue;
            DateTime BirthDate = DateTime.MinValue;

            if (PersonDataAccess.GetPersonByEmail(Email, ref PersonId, ref CountryId, ref FirstName, ref LastName, ref Address, ref Gender, ref BirthDate, ref ImageUrl))
            {
                return new PersonBusiness(PersonId, CountryId, FirstName, LastName, Email, Address, Gender, BirthDate, ImageUrl);
            }
            else
            {
                return null;
            }
        }


        protected bool _UpdatePerson()
        {
            return PersonDataAccess.UpdatePerson(this.PersonId, this.CountryId, this.FirstName, this.LastName
                , this.Email, this.Address, this.Gender, this.BirthDate, this.ImageUrl);
        }

        public static bool DeletePerson(int Id)
        {
            return PersonDataAccess.DeletePerson(Id);

        }

        public static bool IsPersonExist(int Id)
        {
            return PersonDataAccess.IsPersonExist(Id);
        }

        public static int GetPersonIdByPersonEmail(string Email)
        {

            return PersonDataAccess.GetPersonIdByEmail(Email);

        }

        public bool SavePerson()
        {
            switch (Mode)
            {
                case _enMode.Addnew:
                    if (_AddNewPerson())
                    {
                        Mode = _enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case _enMode.Update:
                    return _UpdatePerson();

            }

            return false;
        }


    }
}
