using De.SealingSchool.ViewModelBase;
using De.SealingSchoolManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.SealingSchool.ViewModel
{
    public class CourseViewModel : ViewModel<Course>
    {
        public CourseViewModel(Course model)
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

        public string Title
        {
            get
            {
                return Model.Title;
            }
            set
            {
                if (Title != value)
                {
                    Model.Title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        public string Description
        {
            get
            {
                return Model.Description;
            }
            set
            {
                if (Description != value)
                {
                    Model.Description = value;
                    this.OnPropertyChanged("Description");
                }
            }
        }

        public int Capacity
        {
            get
            {
                return Model.Capacity;
            }
            set
            {
                if (Capacity != value)
                {
                    Model.Capacity = value;
                    this.OnPropertyChanged("Capacity");
                }
            }
        }

        public int Duration
        {
            get
            {
                return Model.Duration;
            }
            set
            {
                if (Duration != value)
                {
                    Model.Duration = value;
                    this.OnPropertyChanged("Duration");
                }
            }
        }

        public DateTime StartDate
        {
            get
            {
                return Model.StartDate;
            }
            set
            {
                if (StartDate != value)
                {
                    Model.StartDate = value;
                    this.OnPropertyChanged("StartDate");
                }
            }
        }

        public DateTime EndDate
        {
            get
            {
                return Model.EndDate;
            }
            set
            {
                if (EndDate != value)
                {
                    Model.EndDate = value;
                    this.OnPropertyChanged("EndDate");
                }
            }
        }

    }
}
