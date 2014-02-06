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

        public string FirstName
        {
            get
            {
                return Model.FirstName;
            }
            set
            {
                if (FirstName != value)
                {
                    Model.FirstName = value;
                    this.OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get
            {
                return Model.LastName;
            }
            set
            {
                if (LastName != value)
                {
                    Model.LastName = value;
                    this.OnPropertyChanged("LastName");
                }
            }
        }

        public string ZipCode
        {
            get
            {
                return Model.ZipCode;
            }
            set
            {
                if (ZipCode != value)
                {
                    Model.ZipCode = value;
                    this.OnPropertyChanged("ZipCode");
                }
            }
        }

        public string City
        {
            get
            {
                return Model.City;
            }
            set
            {
                if (City != value)
                {
                    Model.City = value;
                    this.OnPropertyChanged("City");
                }
            }
        }

        public string AddressLine1
        {
            get
            {
                return Model.AddressLine1;
            }
            set
            {
                if (AddressLine1 != value)
                {
                    Model.AddressLine1 = value;
                    this.OnPropertyChanged("AddressLine1");
                }
            }
        }

        public string AddressLine2
        {
            get
            {
                return Model.AddressLine2;
            }
            set
            {
                if (AddressLine2 != value)
                {
                    Model.AddressLine2 = value;
                    this.OnPropertyChanged("AddressLine2");
                }
            }
        }

        public string AddressLine3
        {
            get
            {
                return Model.AddressLine3;
            }
            set
            {
                if (AddressLine3 != value)
                {
                    Model.AddressLine3 = value;
                    this.OnPropertyChanged("AddressLine3");
                }
            }
        }
        public string Country
        {
            get
            {
                return Model.Country;
            }
            set
            {
                if (Country != value)
                {
                    Model.Country = value;
                    this.OnPropertyChanged("Country");
                }
            }
        }

        public string State
        {
            get
            {
                return Model.State;
            }
            set
            {
                if (State != value)
                {
                    Model.State = value;
                    this.OnPropertyChanged("State");
                }
            }
        }
    }
}
