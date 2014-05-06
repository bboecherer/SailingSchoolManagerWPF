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

        private bool _SSS;
        public bool SSS
        {
            get
            {
                return InstructorDummy.SSS;
            }
            set
            {
                InstructorDummy.SSS = value;
                this.OnPropertyChanged("SSS");
            }
        }

        private bool _SKS;
        public bool SKS
        {
            get
            {
                return InstructorDummy.SKS;
            }
            set
            {
                InstructorDummy.SKS = value;
                this.OnPropertyChanged("SKS");
            }
        }

        private bool _SBFSEA;
        public bool SBFSEA
        {
            get
            {
                return InstructorDummy.SBFSEA;
            }
            set
            {
                InstructorDummy.SBFSEA = value;
                this.OnPropertyChanged("SBFSEA");
            }
        }

        private bool _SBFBINNEN;
        public bool SBFBINNEN
        {
            get
            {
                return InstructorDummy.SBFBINNEN;
            }
            set
            {
                InstructorDummy.SBFBINNEN = value;
                this.OnPropertyChanged("SBFBINNEN");
            }
        }

        private bool _SRC;
        public bool SRC
        {
            get
            {
                return InstructorDummy.SRC;
            }
            set
            {
                InstructorDummy.SRC = value;
                this.OnPropertyChanged("SRC");
            }
        }

        private bool _UBI;
        public bool UBI
        {
            get
            {
                return InstructorDummy.UBI;
            }
            set
            {
                InstructorDummy.UBI = value;
                this.OnPropertyChanged("UBI");
            }
        }

        private bool _DSV;
        public bool DSV
        {
            get
            {
                return InstructorDummy.DSV;
            }
            set
            {
                InstructorDummy.DSV = value;
                this.OnPropertyChanged("DSV");
            }
        }

        private bool _SHS;
        public bool SHS
        {
            get
            {
                return InstructorDummy.SHS;
            }
            set
            {
                InstructorDummy.SHS = value;
                this.OnPropertyChanged("SHS");
            }
        }

        private bool _lifeGuard;
        public bool LifeGuard
        {
            get
            {
                return InstructorDummy.LifeGuard;
            }
            set
            {
                InstructorDummy.LifeGuard = value;
                this.OnPropertyChanged("LifeGuard");
            }
        }

        private DateTime _SSSDate;
        public DateTime SSSDate
        {
            get
            {
                return InstructorDummy.SSSDate;
            }
            set
            {
                InstructorDummy.SSSDate = value;
                this.OnPropertyChanged("SSSDate");
            }
        }

        private DateTime _SKSDate;
        public DateTime SKSDate
        {
            get
            {
                return InstructorDummy.SKSDate;
            }
            set
            {
                InstructorDummy.SKSDate = value;
                this.OnPropertyChanged("SKSDate");
            }
        }

        private DateTime _SBFSEADate;
        public DateTime SBFSEADate
        {
            get
            {
                return InstructorDummy.SBFSEADate;
            }
            set
            {
                InstructorDummy.SBFSEADate = value;
                this.OnPropertyChanged("SBFSEADate");
            }
        }

        private DateTime _SBFBINNENDate;
        public DateTime SBFBINNENDate
        {
            get
            {
                return InstructorDummy.SBFBINNENDate;
            }
            set
            {
                InstructorDummy.SBFBINNENDate = value;
                this.OnPropertyChanged("SBFBINNENDate");
            }
        }

        private DateTime _SRCDate;
        public DateTime SRCDate
        {
            get
            {
                return InstructorDummy.SRCDate;
            }
            set
            {
                InstructorDummy.SRCDate = value;
                this.OnPropertyChanged("SRCDate");
            }
        }

        private DateTime _UBIDate;
        public DateTime UBIDate
        {
            get
            {
                return InstructorDummy.UBIDate;
            }
            set
            {
                InstructorDummy.UBIDate = value;
                this.OnPropertyChanged("UBIDate");
            }
        }

        private DateTime _DSVDate;
        public DateTime DSVDate
        {
            get
            {
                return InstructorDummy.DSVDate;
            }
            set
            {
                InstructorDummy.DSVDate = value;
                this.OnPropertyChanged("DSVDate");
            }
        }

        private DateTime _SHSDate;
        public DateTime SHSDate
        {
            get
            {
                return InstructorDummy.SHSDate;
            }
            set
            {
                InstructorDummy.SHSDate = value;
                this.OnPropertyChanged("SHSDate");
            }
        }

        private DateTime _lifeGuardDate;
        public DateTime LifeGuardDate
        {
            get
            {
                return InstructorDummy.LifeGuardDate;
            }
            set
            {
                InstructorDummy.LifeGuardDate = value;
                this.OnPropertyChanged("LifeGuardDate");
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