using De.SealingSchool.ViewModelBase;
using De.SealingSchoolManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.SealingSchool.ViewModel
{
    public class InstructorViewModel : ViewModel<Instructor>
    {
        public InstructorViewModel(Instructor model)
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

        public string AddressLine1
        {
            get
            {
                return Model.PrimaryAddress != null ? Model.PrimaryAddress.AddressLine1 : "--";
            }
            set
            {
                if (AddressLine1 != value)
                {
                    Model.PrimaryAddress.AddressLine1 = value;
                    this.OnPropertyChanged("AddressLine1");
                }
            }
        }

        public string ZipCode
        {
            get
            {
                return Model.PrimaryAddress != null ? Model.PrimaryAddress.ZipCode : "--";
            }
            set
            {
                if (ZipCode != value)
                {
                    Model.PrimaryAddress.ZipCode = value;
                    this.OnPropertyChanged("ZipCode");
                }
            }
        }

        public string City
        {
            get
            {
                return Model.PrimaryAddress != null ? Model.PrimaryAddress.City : "--";
            }
            set
            {
                if (City != value)
                {
                    Model.PrimaryAddress.City = value;
                    this.OnPropertyChanged("City");
                }
            }
        }

    }
}
