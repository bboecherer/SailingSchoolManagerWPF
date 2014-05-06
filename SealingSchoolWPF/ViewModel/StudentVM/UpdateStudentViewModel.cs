using SealingSchoolWPF.Data;
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
    public class UpdateStudentViewModel : ViewModel<Student>
    {
        public Student StudentDummy { get; set; }

        public UpdateStudentViewModel(Student model)
            : base(model)
        {
            instance = this;
            this.StudentDummy = model;
        }

        static UpdateStudentViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateStudentViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateStudentViewModel(new SealingSchoolWPF.Model.Student());
                    }
                    return instance;
                }
            }
        }

        StudentMgr studMgr = new StudentMgr();

        public string FirstName
        {
            get
            {
                return StudentDummy.FirstName;
            }
            set
            {
                StudentDummy.FirstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return StudentDummy.LastName;
            }
            set
            {
                StudentDummy.LastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        public string Street
        {
            get
            {
                return StudentDummy.Adress.Street;
            }
            set
            {
                StudentDummy.Adress.Street = value;
                this.OnPropertyChanged("Street");
            }
        }

        public string Postal
        {
            get
            {
                return StudentDummy.Adress.ZipCode;
            }
            set
            {
                StudentDummy.Adress.ZipCode = value;
                this.OnPropertyChanged("Postal");
            }
        }

        public string City
        {
            get
            {
                return StudentDummy.Adress.City;
            }
            set
            {
                StudentDummy.Adress.City = value;
                this.OnPropertyChanged("City");
            }
        }

        public string AccountNo
        {
            get
            {
                return StudentDummy.Bank.AccountNo;
            }
            set
            {
                StudentDummy.Bank.AccountNo = value;
                this.OnPropertyChanged("AccountNo");
            }
        }

        public string BankNo
        {
            get
            {
                return StudentDummy.Bank.BankNo;
            }
            set
            {
                StudentDummy.Bank.BankNo = value;
                this.OnPropertyChanged("BankNo");
            }
        }

        public string BankName
        {
            get
            {
                return StudentDummy.Bank.BankName;
            }
            set
            {
                StudentDummy.Bank.BankName = value;
                this.OnPropertyChanged("BankName");
            }
        }

        public string Iban
        {
            get
            {
                return StudentDummy.Bank.Iban;
            }
            set
            {
                StudentDummy.Bank.Iban = value;
                this.OnPropertyChanged("Iban");
            }
        }

        public bool Sepa
        {
            get
            {
                return StudentDummy.Bank.Sepa;
            }
            set
            {
                StudentDummy.Bank.Sepa = value;
                this.OnPropertyChanged("Sepa");
            }
        }

        public string Bic
        {
            get
            {
                return StudentDummy.Bank.Bic;
            }
            set
            {
                StudentDummy.Bank.Bic = value;
                this.OnPropertyChanged("Bic");
            }
        }

        public string Notes
        {
            get
            {
                return StudentDummy.AdditionalInfo;
            }
            set
            {
                StudentDummy.AdditionalInfo = value;
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
            Model.ModifiedOn = DateTime.Now;
            studMgr.Update(Model);
        }
    }
}