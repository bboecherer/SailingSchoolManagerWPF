using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.ViewModel.Student
{
    class StudentViewModel : ViewModel<SealingSchoolWPF.Model.Student>
    {
        public StudentViewModel(SealingSchoolWPF.Model.Student model)
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


    }
}
