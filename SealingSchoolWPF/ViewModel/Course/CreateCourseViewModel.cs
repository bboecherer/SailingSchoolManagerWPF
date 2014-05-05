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
    public class CreateCourseViewModel : ViewModel<SealingSchoolWPF.Model.Course>
    {

        public CreateCourseViewModel(SealingSchoolWPF.Model.Course model)
            : base(model)
        {
        }

        InstructorMgr instructorMgr = new InstructorMgr();

        static CreateCourseViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateCourseViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateCourseViewModel(new SealingSchoolWPF.Model.Course());
                    }
                    return instance;
                }
            }
        }

        private string _label;
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                this.OnPropertyChanged("Label");
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                this.OnPropertyChanged("Description");
            }
        }

        private int _duration;
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                this.OnPropertyChanged("Duration");
            }
        }

        private int _capacity;
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                _capacity = value;
                this.OnPropertyChanged("Capacity");
            }
        }

        public IEnumerable<String> InstructorTypeValues
        {
            get
            {
                return GetInstructorNames();
            }
        }

        private IList<String> GetInstructorNames()
        {
            InstructorNames = new List<String>();
            foreach (Model.Instructor inst in instructorMgr.GetAll())
            {
                InstructorNames.Add(inst.Label);
            }
            return InstructorNames;
        }

        private IList<String> InstructorNames;

        private Model.Student _instructor;
        public Model.Student Instructor
        {
            get
            {
                return _instructor;
            }
            set
            {
                _instructor = value;
                this.OnPropertyChanged("Instructor");
            }
        }

        private Decimal _netPrice;
        public Decimal NetPrice
        {
            get
            {
                return _netPrice;
            }
            set
            {
                _netPrice = value;
                this.CalculatePrice(value);
                this.OnPropertyChanged("NetPrice");
            }
        }

        private Decimal _grossPrice;
        public Decimal GrossPrice
        {
            get
            {
                return _grossPrice;
            }
            set
            {
                _grossPrice = value;
                this.OnPropertyChanged("GrossPrice");
            }
        }

        private Decimal _netAmount;
        public Decimal NetAmount
        {
            get
            {
                return _netAmount;
            }
            set
            {
                _netAmount = value;
                this.OnPropertyChanged("NetAmount");
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

        private Currency _currency;
        public Currency Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
                this.OnPropertyChanged("Currency");
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                if (_startDate == null || _startDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _startDate;
                }
            }
            set
            {
                _startDate = value;
                this.OnPropertyChanged("StartDate");
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                if (_endDate == null || _endDate == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return _endDate;
                }
            }
            set
            {
                _endDate = value;
                this.OnPropertyChanged("EndDate");
            }
        }

        private string _notes;
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                this.OnPropertyChanged("Notes");
            }
        }

        private bool _isButtonEnabled = true;
        public bool IsButtonEnabled
        {
            get
            {
                return _isButtonEnabled;
            }
            set
            {
                _isButtonEnabled = value;
                this.OnPropertyChanged("IsButtonEnabled");
            }
        }

        private string _imageSourceSave = "/Resources/Images/save_16xLG.png";
        public string ImageSourceSave
        {
            get
            {
                return _imageSourceSave;
            }
            set
            {
                _imageSourceSave = value;
                this.OnPropertyChanged("ImageSourceSave");
            }
        }

        private string _imageSourceClear = "/Resources/Images/action_Cancel_16xLG.png";
        public string ImageSourceClear
        {
            get
            {
                return _imageSourceClear;
            }
            set
            {
                _imageSourceClear = value;
                this.OnPropertyChanged("ImageSourceClear");
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
            Model.Label = this.Label;
            Model.Description = this.Description;
            Model.Duration = this.Duration;
            Model.Capacity = this.Capacity;
            Model.AdditionalInfo = this.Notes;
            Model.NetPrice = this.NetPrice;
            Model.GrossPrice = this.GrossPrice;
            Model.NetAmount = this.NetAmount;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;
            Model.StartDate = this.StartDate;
            Model.EndDate = this.EndDate;

            using (var ctx = new SchoolDataContext())
            {
                ctx.Courses.Add(Model);
                ctx.SaveChanges();
            }

            this.IsButtonEnabled = false;
            this.ImageSourceSave = "/Resources/Images/StatusAnnotations_Complete_and_ok_32xLG_color.png";
            this.ImageSourceClear = "";
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