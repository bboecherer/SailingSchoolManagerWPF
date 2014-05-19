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

namespace SealingSchoolWPF.ViewModel.CourseViewModel
{
    public class UpdateCourseViewModel : ViewModel<Model.Course>
    {
        public Model.Course CourseDummy { get; set; }

        public UpdateCourseViewModel(Model.Course model)
            : base(model)
        {
            instance = this;
            this.CourseDummy = model;
        }

        static UpdateCourseViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateCourseViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateCourseViewModel(new SealingSchoolWPF.Model.Course());
                    }
                    return instance;
                }
            }
        }

        CourseMgr courseMgr = new CourseMgr();

        public string Label
        {
            get
            {
                return CourseDummy.Label;
            }
            set
            {
                CourseDummy.Label = value;
                this.OnPropertyChanged("Label");
            }
        }

        public DateTime StartDate
        {
            get
            {
                return CourseDummy.StartDate;
            }
            set
            {
                CourseDummy.StartDate = value;
                this.OnPropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return CourseDummy.EndDate;
            }
            set
            {
                CourseDummy.EndDate = value;
                this.OnPropertyChanged("EndDate");
            }
        }

        public int Duration
        {
            get
            {
                return CourseDummy.Duration;
            }
            set
            {
                CourseDummy.Duration = value;
                this.OnPropertyChanged("Duration");
            }
        }

        public int Capacity
        {
            get
            {
                return CourseDummy.Capacity;
            }
            set
            {
                CourseDummy.Capacity = value;
                this.OnPropertyChanged("Capacity");
            }
        }

        public Decimal NetPrice
        {
            get
            {
                return CourseDummy.NetPrice;
            }
            set
            {
                CourseDummy.NetPrice = value;
                this.CalculatePrice(value);
                this.OnPropertyChanged("NetPrice");
            }
        }

        public Decimal GrossPrice
        {
            get
            {
                return CourseDummy.GrossPrice;
            }
            set
            {
                CourseDummy.GrossPrice = value;
                this.OnPropertyChanged("GrossPrice");
            }
        }

        public Decimal NetAmount
        {
            get
            {
                return CourseDummy.NetAmount;
            }
            set
            {
                CourseDummy.NetAmount = value;
                this.OnPropertyChanged("NetAmount");
            }
        }

        public string Notes
        {
            get
            {
                return CourseDummy.AdditionalInfo;
            }
            set
            {
                CourseDummy.AdditionalInfo = value;
                this.OnPropertyChanged("Notes");
            }
        }

        public string Description
        {
            get
            {
                return CourseDummy.Description;
            }
            set
            {
                CourseDummy.Description = value;
                this.OnPropertyChanged("Description");
            }
        }

        public IEnumerable<Currency> CurrencyTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(Currency))
                    .Cast<Currency>();
            }
        }

        public Currency Currency
        {
            get
            {
                return CourseDummy.Currency;
            }
            set
            {
                CourseDummy.Currency = value;
                this.OnPropertyChanged("Currency");
            }
        }

        InstructorMgr instructorMgr = new InstructorMgr();

        private IList<SealingSchoolWPF.Model.Instructor> GetInstructorNames()
        {
            InstructorNames = new List<SealingSchoolWPF.Model.Instructor>();
            foreach (Model.Instructor inst in instructorMgr.GetAll())
            {
                InstructorNames.Add(inst);
            }
            return InstructorNames;
        }

        private IList<SealingSchoolWPF.Model.Instructor> InstructorNames;

        private Model.Instructor _instructor;
        public Model.Instructor Instructor
        {
            get
            {
                return CourseDummy.Instructor;
            }
            set
            {
                _instructor = value;
                this.OnPropertyChanged("Instructor");
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
            courseMgr.Update(Model);
        }

        private void CalculatePrice(decimal p)
        {
            decimal netPrice = p;
            decimal grossPrice = decimal.MinValue;
            decimal vat = 19;

            grossPrice = netPrice + (netPrice * vat / 100);
            this.NetAmount = (netPrice * vat / 100);
            this.GrossPrice = grossPrice;
        }

    }
}