using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.ViewModel.Course
{
    /// <summary>
    /// ViewModel for course
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CourseViewModel : ViewModel<SailingSchoolWPF.Model.Course>
    {
        #region ctor
        public CourseViewModel(SailingSchoolWPF.Model.Course model)
            : base(model)
        {
        }
        #endregion

        #region properties
        public int Id
        {
            get
            {
                return Model.CourseId;
            }
            set
            {
                if (Id != value)
                {
                    Model.CourseId = value;
                    this.OnPropertyChanged("Id");
                }
            }
        }

        public double RatingValue
        {
            get
            {
                return Model.RatingValue;
            }
            set
            {
                if (RatingValue != value)
                {
                    Model.RatingValue = value;
                    this.OnPropertyChanged("RatingValue");
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

        public string AdditionalInfo
        {
            get
            {
                return Model.AdditionalInfo;
            }
            set
            {
                if (AdditionalInfo != value)
                {
                    Model.AdditionalInfo = value;
                    this.OnPropertyChanged("AdditionalInfo");
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

        public Decimal NetPrice
        {
            get
            {
                return Model.NetPrice;
            }
            set
            {
                if (NetPrice != value)
                {
                    Model.NetPrice = value;
                    this.OnPropertyChanged("NetPrice");
                }
            }
        }

        public Decimal GrossPrice
        {
            get
            {
                return Model.GrossPrice;
            }
            set
            {
                if (GrossPrice != value)
                {
                    Model.GrossPrice = value;
                    this.OnPropertyChanged("GrossPrice");
                }
            }
        }

        public Decimal NetAmount
        {
            get
            {
                return Model.NetAmount;
            }
            set
            {
                if (NetAmount != value)
                {
                    Model.NetAmount = value;
                    this.OnPropertyChanged("NetAmount");
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

        public int NeededInstructors
        {
            get
            {
                return Model.NeededInstructors;
            }
            set
            {
                if (NeededInstructors != value)
                {
                    Model.NeededInstructors = value;
                    this.OnPropertyChanged("NeededInstructors");
                }
            }
        }

        public BoatTyp BoatTyp
        {
            get
            {
                return Model.BoatTyp;
            }
            set
            {
                if (BoatTyp != value)
                {
                    Model.BoatTyp = value;
                    this.OnPropertyChanged("BoatTyp");
                }
            }
        }

        public ICollection<Qualification> Qualifications
        {
            get
            {
                return Model.Qualifications;
            }
            set
            {
                if (Qualifications != value)
                {
                    Model.Qualifications = value;
                    this.OnPropertyChanged("Qualifications");
                }
            }
        }

        public ICollection<CourseMaterialTyp> CourseMaterialTyps
        {
            get
            {
                return Model.CourseMaterialTyps;
            }
            set
            {
                if (CourseMaterialTyps != value)
                {
                    Model.CourseMaterialTyps = value;
                    this.OnPropertyChanged("CourseMaterialTyps");
                }
            }
        }
        #endregion
    }
}
