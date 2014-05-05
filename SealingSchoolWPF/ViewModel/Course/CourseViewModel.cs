﻿using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.ViewModel.Course
{
    public class CourseViewModel : ViewModel<SealingSchoolWPF.Model.Course>
    {
        public CourseViewModel(SealingSchoolWPF.Model.Course model)
            : base(model)
        {
        }

        public int Id
        {
            get
            {
                return Model.Id;
            }
            set
            {
                if (Id != value)
                {
                    Model.Id = value;
                    this.OnPropertyChanged("Id");
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

        public DateTime StartDate
        {
            get
            {
                return Model.StartDate;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return Model.EndDate;
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
    }
}
