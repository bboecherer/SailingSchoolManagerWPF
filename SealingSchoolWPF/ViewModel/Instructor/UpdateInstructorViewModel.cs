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

namespace SealingSchoolWPF.ViewModel.InstructorViewModel
{
    public class UpdateInstructorViewModel : ViewModel<Model.Instructor>
    {
        public Model.Instructor InstructorDummy { get; set; }

        public UpdateInstructorViewModel(Model.Instructor model)
            : base(model)
        {
            instance = this;
            this.InstructorDummy = model;
        }

        static UpdateInstructorViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateInstructorViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateInstructorViewModel(new SealingSchoolWPF.Model.Instructor());
                    }
                    return instance;
                }
            }
        }

        InstructorMgr instructorMgr = new InstructorMgr();

        public string FirstName
        {
            get
            {
                return InstructorDummy.FirstName;
            }
            set
            {
                InstructorDummy.FirstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return InstructorDummy.LastName;
            }
            set
            {
                InstructorDummy.LastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        public string Street
        {
            get
            {
                return InstructorDummy.Adress.Street;
            }
            set
            {
                InstructorDummy.Adress.Street = value;
                this.OnPropertyChanged("Street");
            }
        }

        public string Postal
        {
            get
            {
                return InstructorDummy.Adress.ZipCode;
            }
            set
            {
                InstructorDummy.Adress.ZipCode = value;
                this.OnPropertyChanged("Postal");
            }
        }

        public string City
        {
            get
            {
                return InstructorDummy.Adress.City;
            }
            set
            {
                InstructorDummy.Adress.City = value;
                this.OnPropertyChanged("City");
            }
        }

        public string AccountNo
        {
            get
            {
                return InstructorDummy.Bank.AccountNo;
            }
            set
            {
                InstructorDummy.Bank.AccountNo = value;
                this.OnPropertyChanged("AccountNo");
            }
        }

        public string BankNo
        {
            get
            {
                return InstructorDummy.Bank.BankNo;
            }
            set
            {
                InstructorDummy.Bank.BankNo = value;
                this.OnPropertyChanged("BankNo");
            }
        }

        public string BankName
        {
            get
            {
                return InstructorDummy.Bank.BankName;
            }
            set
            {
                InstructorDummy.Bank.BankName = value;
                this.OnPropertyChanged("BankName");
            }
        }

        public string Iban
        {
            get
            {
                return InstructorDummy.Bank.Iban;
            }
            set
            {
                InstructorDummy.Bank.Iban = value;
                this.OnPropertyChanged("Iban");
            }
        }

        public bool Sepa
        {
            get
            {
                return InstructorDummy.Bank.Sepa;
            }
            set
            {
                InstructorDummy.Bank.Sepa = value;
                this.OnPropertyChanged("Sepa");
            }
        }

        public string Bic
        {
            get
            {
                return InstructorDummy.Bank.Bic;
            }
            set
            {
                InstructorDummy.Bank.Bic = value;
                this.OnPropertyChanged("Bic");
            }
        }

        public string Notes
        {
            get
            {
                return InstructorDummy.AdditionalInfo;
            }
            set
            {
                InstructorDummy.AdditionalInfo = value;
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
            instructorMgr.Update(Model);
        }
    }
}