using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.Pages.Student.Create;
using SailingSchoolWPF.ViewModel.BusinessUnit;
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

namespace SailingSchoolWPF.ViewModel.Invoicing
{
    /// <summary>
    /// ViewModel for multiple invoice creation
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CreateMultipleInvoiceViewModel : ViewModel<SailingSchoolWPF.Model.Invoice>
    {
        #region ctor
        public CreateMultipleInvoiceViewModel(SailingSchoolWPF.Model.Invoice model)
            : base(model)
        {
            GetCourseTypNames();
        }

        static CreateMultipleInvoiceViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateMultipleInvoiceViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateMultipleInvoiceViewModel(new SailingSchoolWPF.Model.Invoice());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties

        private IList<SailingSchoolWPF.Model.CoursePlaning> GetCourseTypNames()
        {
            CourseTypNames = new List<SailingSchoolWPF.Model.CoursePlaning>();

            foreach (SailingSchoolWPF.Model.CoursePlaning course in coursePlaningMgr.GetByStatus(CourseStatus.BEENDET))
            {
                CourseTypNames.Add(course);
                coursesList.Add(course);
            }

            CourseValues = coursesList;

            return CourseTypNames;
        }

        private IList<SailingSchoolWPF.Model.CoursePlaning> CourseTypNames;

        private IEnumerable<SailingSchoolWPF.Model.CoursePlaning> _courseValues;
        public IEnumerable<SailingSchoolWPF.Model.CoursePlaning> CourseValues
        {
            get
            {
                return coursesList;
            }
            set
            {
                _courseValues = value;
                this.OnPropertyChanged("CourseValues");
            }
        }

        private SailingSchoolWPF.Model.CoursePlaning _courseTyp;
        public SailingSchoolWPF.Model.CoursePlaning CourseTyp
        {
            get
            {
                return _courseTyp;
            }
            set
            {
                _courseTyp = value;
                this.OnPropertyChanged("CourseTyp");
            }
        }

        private ObservableCollection<SailingSchoolWPF.ViewModel.Course.CourseViewModel> _courses;
        public ObservableCollection<SailingSchoolWPF.ViewModel.Course.CourseViewModel> Courses
        {
            get
            {
                return _courses;
            }
            set
            {
                if (_courses != value)
                {
                    _courses = value;
                    this.OnPropertyChanged("Courses");
                }
            }
        }

        private SailingSchoolWPF.Model.Course _course;
        public SailingSchoolWPF.Model.Course Course
        {
            get
            {
                return _course;
            }
            set
            {
                _course = value;
                this.OnPropertyChanged("Course");
            }
        }

        private string _errorLabel;
        public string ErrorLabel
        {
            get
            {
                return _errorLabel;
            }
            set
            {
                _errorLabel = value;
                this.OnPropertyChanged("ErrorLabel");
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

        private string _imageSourceNext = "/Resources/Images/arrow_Next_16xLG.png";
        public string ImageSourceNext
        {
            get
            {
                return _imageSourceNext;
            }
            set
            {
                _imageSourceNext = value;
                this.OnPropertyChanged("ImageSourceNext");
            }
        }

        private string _imageSourceClear = "/Resources/Images/Undo_16x.png";
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

        private ObservableCollection<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> _students;
        public ObservableCollection<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> Students
        {
            get
            {
                return GetStudents();
            }
            set
            {
                if (_students != value)
                {
                    _students = value;
                    this.OnPropertyChanged("Students");
                }
            }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    this.OnPropertyChanged("IsChecked");
                }
            }
        }


        private ObservableCollection<StudentViewModel.StudentViewModel> GetStudents()
        {
            var studentList = this.studentMgr.GetByCoursePlaning(this._courseTyp);
            if (_students != null)
                _students.Clear();

            foreach (Student s in studentList)
            {
                StudentViewModel.StudentViewModel stud = new StudentViewModel.StudentViewModel(s);
                if (_students == null)
                    _students = new ObservableCollection<StudentViewModel.StudentViewModel>();
                _students.Add(stud);
            }

            return _students;
        }
        #endregion

        #region commands
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

        private ICommand addAndNextCommand;
        public ICommand AddAndNextCommand
        {
            get
            {
                if (addAndNextCommand == null)
                {
                    addAndNextCommand = new RelayCommand(p => ExecuteAddAndNextCommand());
                }
                return addAndNextCommand;
            }
        }

        private void ExecuteAddAndNextCommand()
        {
            SaveModelToDatabase();
            this.ExecuteClearCommand();
            this.Close();
        }

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(p => ExecuteClearCommand());
                }
                return clearCommand;
            }
        }

        private void ExecuteClearCommand()
        {
            this.ErrorLabel = string.Empty;
            //TODO: Felder leeren
        }

        private void ExecuteAddCommand()
        {
            SaveModelToDatabase();
            Application.Current.Windows[1].Close();
        }

        #endregion

        #region helpers
        public void Close()
        {
            instance = null;
        }

        private void SaveModelToDatabase()
        {

            InvoiceItem item = new InvoiceItem();
            item.GrossPrice = this.CourseTyp.Course.GrossPrice;
            item.NetPrice = this.CourseTyp.Course.NetPrice;
            item.VatAmount = this.CourseTyp.Course.NetAmount;
            item.Amount = 1;
            item.ServiceLocation = "Italien";
            item.ServiceEndDate = DateTime.Now;
            item.ServiceStartDate = DateTime.Now;
            Model.InvoiceItems = new List<InvoiceItem>();
            Model.InvoiceItems.Add(item);

            Model.CreatedOn = DateTime.Now;
            Model.Printed = false;
            Model.GrossPrice = this.CourseTyp.Course.GrossPrice;
            Model.NetPrice = this.CourseTyp.Course.NetPrice;
            Model.VatAmount = this.CourseTyp.Course.NetAmount;
            Model.PaymentStatus = PaymentStatus.NICHT_GEZAHLT;
            Model.InvoiceStatus = InvoiceStatus.RECHNUNG;
            Model.PaymentTargetDate = DateTime.Now.Add(new TimeSpan(14, 0, 0, 0));
            Model.PaidDate = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;

            this.invoiceMgr.Create(Model);
        }

        public IList<CoursePlaning> coursesList = new List<CoursePlaning>();

        public IList<StudentViewModel.StudentViewModel> CheckedStudentList = new List<StudentViewModel.StudentViewModel>();
        #endregion
    }
}