using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.ViewModel.Instructor
{
    public class InstructorViewModel : ViewModel<SealingSchoolWPF.Model.Instructor>
    {
        public InstructorViewModel(SealingSchoolWPF.Model.Instructor model)
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

        public string Label
        {
            get
            {
                return Model.Label;
            }
            set
            {
                if (Label != value)
                {
                    Model.Label = value;
                    this.OnPropertyChanged("Label");
                }
            }
        }

        public string Adress
        {
            get
            {
                return Model.Adress.AddressLine1;
            }
            set
            {
                if (Adress != value)
                {
                    Model.Adress.AddressLine1 = value;
                    this.OnPropertyChanged("Adress");
                }
            }
        }

        public string Street
        {
            get
            {
                return Model.Adress.Street;
            }
            set
            {
                if (Street != value)
                {
                    Model.Adress.Street = value;
                    this.OnPropertyChanged("Street");
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

        public bool SSS
        {
            get
            {
                return Model.SSS;
            }
            set
            {
                Model.SSS = value;
                this.OnPropertyChanged("SSS");
            }
        }

        public bool SKS
        {
            get
            {
                return Model.SKS;
            }
            set
            {
                Model.SKS = value;
                this.OnPropertyChanged("SKS");
            }
        }

        public bool SBFSEA
        {
            get
            {
                return Model.SBFSEA;
            }
            set
            {
                Model.SBFSEA = value;
                this.OnPropertyChanged("SBFSEA");
            }
        }

        public bool SBFBINNEN
        {
            get
            {
                return Model.SBFBINNEN;
            }
            set
            {
                Model.SBFBINNEN = value;
                this.OnPropertyChanged("SBFBINNEN");
            }
        }

        public bool SRC
        {
            get
            {
                return Model.SRC;
            }
            set
            {
                Model.SRC = value;
                this.OnPropertyChanged("SRC");
            }
        }

        public bool UBI
        {
            get
            {
                return Model.UBI;
            }
            set
            {
                Model.UBI = value;
                this.OnPropertyChanged("UBI");
            }
        }

        public bool DSV
        {
            get
            {
                return Model.DSV;
            }
            set
            {
                Model.DSV = value;
                this.OnPropertyChanged("DSV");
            }
        }

        public bool SHS
        {
            get
            {
                return Model.SHS;
            }
            set
            {
                Model.SHS = value;
                this.OnPropertyChanged("SHS");
            }
        }

        public bool LifeGuard
        {
            get
            {
                return Model.LifeGuard;
            }
            set
            {
                Model.LifeGuard = value;
                this.OnPropertyChanged("LifeGuard");
            }
        }

        public DateTime SSSDate
        {
            get
            {
                return Model.SSSDate;
            }
            set
            {
                Model.SSSDate = value;
                this.OnPropertyChanged("SSSDate");
            }
        }

        public DateTime SKSDate
        {
            get
            {
                return Model.SKSDate;
            }
            set
            {
                Model.SKSDate = value;
                this.OnPropertyChanged("SKSDate");
            }
        }

        public DateTime SBFSEADate
        {
            get
            {
                return Model.SBFSEADate;
            }
            set
            {
                Model.SBFSEADate = value;
                this.OnPropertyChanged("SBFSEADate");
            }
        }

        public DateTime SBFBINNENDate
        {
            get
            {
                return Model.SBFBINNENDate;
            }
            set
            {
                Model.SBFBINNENDate = value;
                this.OnPropertyChanged("SBFBINNENDate");
            }
        }

        public DateTime SRCDate
        {
            get
            {
                return Model.SRCDate;
            }
            set
            {
                Model.SRCDate = value;
                this.OnPropertyChanged("SRCDate");
            }
        }

        public DateTime UBIDate
        {
            get
            {
                return Model.UBIDate;
            }
            set
            {
                Model.UBIDate = value;
                this.OnPropertyChanged("UBIDate");
            }
        }

        public DateTime DSVDate
        {
            get
            {
                return Model.DSVDate;
            }
            set
            {
                Model.DSVDate = value;
                this.OnPropertyChanged("DSVDate");
            }
        }

        public DateTime SHSDate
        {
            get
            {
                return Model.SHSDate;
            }
            set
            {
                Model.SHSDate = value;
                this.OnPropertyChanged("SHSDate");
            }
        }

        public DateTime LifeGuardDate
        {
            get
            {
                return Model.LifeGuardDate;
            }
            set
            {
                Model.LifeGuardDate = value;
                this.OnPropertyChanged("LifeGuardDate");
            }
        }
    }
}
