﻿using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SealingSchoolWPF.ViewModel.StudentViewModel
{
    public class CreateStudentViewModel : ViewModel<Student>
    {

        public CreateStudentViewModel(Student model)
            : base(model)
        {
        }

        static CreateStudentViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateStudentViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateStudentViewModel(new SealingSchoolWPF.Model.Student());
                    }
                    return instance;
                }
            }
        }

        StudentMgr studMgr = new StudentMgr();

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        private string _adress;
        public string Adress
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = value;
                this.OnPropertyChanged("Adress");
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
                this.OnPropertyChanged("Street");
            }
        }

        private string _postal;
        public string Postal
        {
            get
            {
                return _postal;
            }
            set
            {
                _postal = value;
                this.OnPropertyChanged("Postal");
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                this.OnPropertyChanged("City");
            }
        }

        private string _accountNo;
        public string AccountNo
        {
            get
            {
                return _accountNo;
            }
            set
            {
                _accountNo = value;
                this.OnPropertyChanged("AccountNo");
            }
        }

        private string _bankNo;
        public string BankNo
        {
            get
            {
                return _bankNo;
            }
            set
            {
                _bankNo = value;
                this.OnPropertyChanged("BankNo");
            }
        }

        private string _bankName;
        public string BankName
        {
            get
            {
                return _bankName;
            }
            set
            {
                _bankName = value;
                this.OnPropertyChanged("BankName");
            }
        }

        private string _iban;
        public string Iban
        {
            get
            {
                return _iban;
            }
            set
            {
                _iban = value;
                this.OnPropertyChanged("Iban");
            }
        }

        private bool _sepa;
        public bool Sepa
        {
            get
            {
                return _sepa;
            }
            set
            {
                _sepa = value;
                this.OnPropertyChanged("Sepa");
            }
        }

        private string _bic;
        public string Bic
        {
            get
            {
                return _bic;
            }
            set
            {
                _bic = value;
                this.OnPropertyChanged("Bic");
            }
        }

        private string _notes;
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                this.OnPropertyChanged("Notes");
            }
        }

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(p => ExecuteAddCommand());
                }
                return addCommand;
            }
        }

        public void Close()
        {
            instance = null;

        }

        private void ExecuteAddCommand()
        {
            Model.FirstName = this.FirstName;
            Model.LastName = this.LastName;
            Model.AddressLine1 = this.Adress;
            Model.ZipCode = this.Postal;
            Model.City = this.City;
            Model.AccountNo = this.AccountNo;
            Model.BankName = this.BankName;
            Model.BankNo = this.BankNo;
            Model.Bic = this.Bic;
            Model.Iban = this.Iban;
            Model.AdditionalInfo = this.Notes;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;

            studMgr.Create(Model);
        }
    }
}