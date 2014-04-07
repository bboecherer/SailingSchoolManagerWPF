﻿using SealingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.StudentViewModel
{
    public class StudentViewModel : ViewModel<SealingSchoolWPF.Model.Student>
    {
        public StudentViewModel(SealingSchoolWPF.Model.Student model)
            : base(model)
        {
        }

        public string Id
        {
            get
            {
                return Model.Id.ToString();
            }
            set
            {
                if (Id != value)
                {
                    Model.Id = Convert.ToInt32(value);
                    this.OnPropertyChanged("Id");
                }
            }
        }

        public string Firstname
        {
            get
            {
                return Model.FirstName;
            }
            set
            {
                if (Firstname != value)
                {
                    Model.FirstName = value;
                    this.OnPropertyChanged("Firstname");
                }
            }
        }

        public string Lastname
        {
            get
            {
                return Model.LastName;
            }
            set
            {
                if (Lastname != value)
                {
                    Model.LastName = value;
                    this.OnPropertyChanged("Lastname");
                }
            }
        }

        public string ZipCode
        {
            get
            {
                return Model.Adress.ZipCode;
            }
            set
            {
                if (ZipCode != value)
                {
                    Model.Adress.ZipCode = value;
                    this.OnPropertyChanged("ZipCode");
                }
            }
        }

        public string City
        {
            get
            {
                return Model.Adress.City;
            }
            set
            {
                if (City != value)
                {
                    Model.Adress.City = value;
                    this.OnPropertyChanged("City");
                }
            }
        }

        public string AddressLine1
        {
            get
            {
                return Model.Adress.AddressLine1;
            }
            set
            {
                if (AddressLine1 != value)
                {
                    Model.Adress.AddressLine1 = value;
                    this.OnPropertyChanged("AddressLine1");
                }
            }
        }

        public string AddressLine2
        {
            get
            {
                return Model.Adress.AddressLine2;
            }
            set
            {
                if (AddressLine2 != value)
                {
                    Model.Adress.AddressLine2 = value;
                    this.OnPropertyChanged("AddressLine2");
                }
            }
        }

        public string AddressLine3
        {
            get
            {
                return Model.Adress.AddressLine3;
            }
            set
            {
                if (AddressLine3 != value)
                {
                    Model.Adress.AddressLine3 = value;
                    this.OnPropertyChanged("AddressLine3");
                }
            }
        }

        public string Country
        {
            get
            {
                return Model.Adress.Country;
            }
            set
            {
                if (Country != value)
                {
                    Model.Adress.Country = value;
                    this.OnPropertyChanged("Country");
                }
            }
        }

        public string State
        {
            get
            {
                return Model.Adress.State;
            }
            set
            {
                if (State != value)
                {
                    Model.Adress.State = value;
                    this.OnPropertyChanged("State");
                }
            }
        }


        public string AccountNo
        {
            get
            {
                return Model.Bank.AccountNo;
            }
            set
            {
                Model.Bank.AccountNo = value;
                this.OnPropertyChanged("AccountNo");
            }
        }


        public string BankNo
        {
            get
            {
                return Model.Bank.BankNo;
            }
            set
            {
                Model.Bank.BankNo = value;
                this.OnPropertyChanged("BankNo");
            }
        }


        public string BankName
        {
            get
            {
                return Model.Bank.BankName;
            }
            set
            {
                Model.Bank.BankName = value;
                this.OnPropertyChanged("BankName");
            }
        }


        public string Iban
        {
            get
            {
                return Model.Bank.Iban;
            }
            set
            {
                Model.Bank.Iban = value;
                this.OnPropertyChanged("Iban");
            }
        }



        public string Bic
        {
            get
            {
                return Model.Bank.Bic;
            }
            set
            {
                Model.Bank.Bic = value;
                this.OnPropertyChanged("Bic");
            }
        }

        public string Notes
        {
            get
            {
                return Model.AdditionalInfo;
            }
            set
            {
                Model.AdditionalInfo = value;
                this.OnPropertyChanged("Notes");
            }
        }
        public DateTime CreatedOn
        {
            get
            {
                return Model.CreatedOn ?? DateTime.MinValue; ;
            }
            set
            {
                if (CreatedOn != value)
                {
                    Model.CreatedOn = value;
                    this.OnPropertyChanged("CreatedOn");
                }
            }
        }

        public DateTime ModifiedOn
        {
            get
            {
                return Model.ModifiedOn ?? DateTime.MinValue; ;
            }
            set
            {
                if (ModifiedOn != value)
                {
                    Model.ModifiedOn = value;
                    this.OnPropertyChanged("ModifiedOn");
                }
            }
        }
    }
}