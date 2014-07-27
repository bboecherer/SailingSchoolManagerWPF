using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.Pages.Student.Create;
using SailingSchoolWPF.PDF;
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

namespace SailingSchoolWPF.ViewModel.Course
{
    /// <summary>
    /// ViewModel for training activity creation
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CreateTAViewModel : ViewModel<SailingSchoolWPF.Model.TrainingActivity>
    {
        #region ctor
        public CreateTAViewModel(SailingSchoolWPF.Model.TrainingActivity model)
            : base(model)
        {
        }

        static CreateTAViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateTAViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateTAViewModel(new SailingSchoolWPF.Model.TrainingActivity());
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
            if (this.StartDate != null && this.EndDate != null)
            {
                foreach (SailingSchoolWPF.Model.CoursePlaning course in coursePlaningMgr.GetAll(CourseStatus.PLANUNG, this.StartDate, this.EndDate))
                {
                    CourseTypNames.Add(course);
                    coursesList.Add(course);
                }
                CourseValues = coursesList;
            }

            return CourseTypNames;
        }

        private ObservableCollection<TrainingActivity> trainingActivities;
        public ObservableCollection<TrainingActivity> TrainingActivities
        {
            get
            {
                return this.GetTrainingActivities();
            }
            set
            {
                if (trainingActivities != value)
                {
                    trainingActivities = value;
                    this.OnPropertyChanged("TrainingActivities");
                }
            }
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

        private bool _isComboBoxEnabled = false;
        public bool IsComboBoxEnabled
        {
            get
            {
                return _isComboBoxEnabled;
            }
            set
            {
                _isComboBoxEnabled = value;
                this.OnPropertyChanged("IsComboBoxEnabled");
            }
        }

        private bool _isComboBoxReadOnly = true;
        public bool IsComboBoxReadOnly
        {
            get
            {
                return _isComboBoxReadOnly;
            }
            set
            {
                _isComboBoxReadOnly = value;
                this.OnPropertyChanged("IsComboBoxReadOnly");
            }
        }

        private bool CheckComboBox()
        {
            return this.StartDate == null && this.EndDate == null;
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

        public IEnumerable<CourseStatus> CourseStatusTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(CourseStatus))
                    .Cast<CourseStatus>();
            }
        }

        private CourseStatus _courseStatus;
        public CourseStatus CourseStatus
        {
            get
            {
                return _courseStatus;
            }
            set
            {
                _courseStatus = value;
                this.OnPropertyChanged("CourseStatus");
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

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                this.IsComboBoxReadOnly = !CheckComboBox();
                this.IsComboBoxEnabled = CheckComboBox();
                GetCourseTypNames();
                this.OnPropertyChanged("StartDate");
            }
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                this.IsComboBoxReadOnly = CheckComboBox();
                this.IsComboBoxEnabled = !CheckComboBox();
                coursesList.Clear();
                GetCourseTypNames();
                this.OnPropertyChanged("EndDate");
            }
        }

        private IList<SailingSchoolWPF.Model.Student> GetStudentTypNames()
        {
            StudentTypNames = new List<SailingSchoolWPF.Model.Student>();
            foreach (Model.Student quali in studentMgr.GetAll())
            {
                StudentTypNames.Add(quali);
            }
            return StudentTypNames;
        }

        private IList<SailingSchoolWPF.Model.Student> StudentTypNames;

        public IEnumerable<SailingSchoolWPF.Model.Student> StudentValues
        {
            get
            {
                return GetStudentTypNames();
            }
        }

        private SailingSchoolWPF.Model.Student _studentTyp;
        public SailingSchoolWPF.Model.Student StudentTyp
        {
            get
            {
                return _studentTyp;
            }
            set
            {
                _studentTyp = value;
                this.OnPropertyChanged("StudentTyp");
            }
        }

        private ObservableCollection<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> _students;

        public ObservableCollection<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> Students
        {
            get
            {
                return _students;
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
            this.Students.Clear();
            this.dummy.Clear();
            this.ReBindDataGrid();
        }

        private void ExecuteAddCommand()
        {
            SaveModelToDatabase();
            Application.Current.Windows[1].Close();

        }

        private ICommand addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                if (addStudentCommand == null)
                {
                    addStudentCommand = new RelayCommand(p => ExecuteAddStudentCommand());
                }
                return addStudentCommand;
            }
        }

        private void ExecuteAddStudentCommand()
        {
            this.ErrorLabel = string.Empty;

            if (this.StudentTyp == null)
                return;

            SailingSchoolWPF.Model.Course course = courseMgr.GetById(this.CourseTyp.Course.CourseId);
            int maxStudents = course.Capacity;

            SailingSchoolWPF.Model.Student origStud = this.StudentTyp;
            SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel stud =
                new SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel(origStud);

            if (this.Students == null)
            {
                this.Students = new ObservableCollection<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel>();
            }

            foreach (SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel q in dummy)
            {
                if (q.Id == stud.Id)
                    return;
            }

            //prüfen, ob die notwendigen Qualification vorhanden sind
            //zuerst die  notwendenigen Qualifikationen aus dem Kurs holen
            IList<SailingSchoolWPF.Model.Qualification> courseQualies = this.qualiMgr.GetQualifications("Course", this.CourseTyp.Course.CourseId);

            //dann die Qualifikationen des Kursleiter
            IList<SailingSchoolWPF.Model.Qualification> studentQualies = this.qualiMgr.GetQualifications("Student", this.StudentTyp.StudentId);

            //jetzt vergleichen
            List<SailingSchoolWPF.Model.Qualification> results = new List<SailingSchoolWPF.Model.Qualification>();

            foreach (var s1 in courseQualies)
            {
                foreach (var s2 in studentQualies)
                {
                    if (s1.QualificationId == s2.QualificationId)
                    {
                        results.Add(s1);
                        // Aufhören wenn der Wert gefunden wurde
                        break;
                    }
                }
            }

            if (results.Count() != courseQualies.Count())
            {
                this.ErrorLabel = "Der Teilnehmer verfügt nicht über die notwendigen Qualifikationen";
                return;
            }


            if (this.dummy.Count == maxStudents)
            {
                this.ErrorLabel = string.Format("Die max. Anzahl von {0} Teilnehmern wurde erreicht.", maxStudents);
                return;
            }

            this.dummy.Add(stud);
            this.ReBindDataGrid();
        }

        public void ExecuteDeleteCommand(SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel stud)
        {
            this.ErrorLabel = string.Empty;
            this.dummy.Remove(stud);
            this.ReBindDataGrid();
        }
        #endregion

        #region helpers
        public void Close()
        {
            instance = null;
        }

        private List<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> dummy =
            new List<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel>();

        private IList<SailingSchoolWPF.Model.Student> prepareStudents(IList<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> list)
        {
            IList<SailingSchoolWPF.Model.Student> studList = new List<SailingSchoolWPF.Model.Student>();

            foreach (SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel q in list)
            {
                SailingSchoolWPF.Model.Student stud = new Model.Student();
                stud.StudentId = Convert.ToInt32(q.Id);
                studList.Add(stud);
            }

            return studList;
        }

        private void SaveModelToDatabase()
        {

            foreach (SailingSchoolWPF.Model.Student stud in prepareStudents(dummy))
            {
                Model.CancelDateTime = DateTime.Now;
                Model.CreatedOn = DateTime.Now;
                Model.GrossPriceOrg = this.CourseTyp.Course.GrossPrice;
                Model.NetPriceOrg = this.CourseTyp.Course.NetPrice;
                Model.VatAmountOrg = this.CourseTyp.Course.NetAmount;
                Model.StartDateTime = this.CourseTyp.StartDate;
                Model.RegDateTime = DateTime.Now;
                Model.Course = this.CourseTyp.Course;
                Model.TrainingActivityStatus = TrainingActivityStatus.ANGEMELDET;
                Model.Student = stud;
                Model.CoursePlaning = this.CourseTyp;

                try
                {
                    this.trainingActivityMgr.Create(Model);

                    PDFPrinter createTaPDF = new PDFPrinter();
                    string name = DateTime.Now.ToString().Replace(".", "_").Replace(":", string.Empty).Replace(" ", "_");
                    createTaPDF.createTaPDF(name.Trim(), Model, Model.TrainingActivityId);
                }
                catch (Exception)
                {


                }

            }
        }

        private void ReBindDataGrid()
        {
            this.Students.Clear();
            Students = new ObservableCollection<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel>(dummy);
            this.ErrorLabel = String.Empty;
        }

        private ObservableCollection<SailingSchoolWPF.Model.TrainingActivity> GetTrainingActivities()
        {
            IList<SailingSchoolWPF.Model.TrainingActivity> tas = trainingActivityMgr.GetAll();
            trainingActivities = new ObservableCollection<TrainingActivity>(tas);
            return trainingActivities;
        }

        public IList<CoursePlaning> coursesList = new List<CoursePlaning>();
        #endregion



    }
}