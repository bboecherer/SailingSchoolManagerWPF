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

        private string _duration;
        public string Duration
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

        private string _capacity;
        public string Capacity
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

        private string _netPrice;
        public string NetPrice
        {
            get
            {
                return _netPrice;
            }
            set
            {
                _netPrice = value;
                this.OnPropertyChanged("NetPrice");
            }
        }

        private string _grossPrice;
        public string GrossPrice
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

        private string _netAmount;
        public string NetAmount
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
            //   Model.Duration = this.Duration;
            // Model.Capacity = this.Capacity;
            Model.AdditionalInfo = this.Notes;
            // Model.NetPrice = this.NetPrice;
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;
            Model.StartDate = DateTime.Now;
            Model.EndDate = DateTime.Now;

            using (var ctx = new SchoolDataContext())
            {
                ctx.Courses.Add(Model);
                ctx.SaveChanges();
            }
        }
    }
}