using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Pages.Student.Create;
using SealingSchoolWPF.PDF;
using SealingSchoolWPF.ViewModel.BusinessUnit;
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

namespace SealingSchoolWPF.ViewModel.Course
{
    public class CreateTAViewModel : ViewModel<SealingSchoolWPF.Model.TrainingActivity>
    {
        #region ctor
        public CreateTAViewModel(SealingSchoolWPF.Model.TrainingActivity model)
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
                        instance = new CreateTAViewModel(new SealingSchoolWPF.Model.TrainingActivity());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        private IList<SealingSchoolWPF.Model.CoursePlaning> GetCourseTypNames()
        {
            CourseTypNames = new List<SealingSchoolWPF.Model.CoursePlaning>();
            if (this.StartDate != null && this.EndDate != null)
            {
                foreach (SealingSchoolWPF.Model.CoursePlaning course in coursePlaningMgr.GetAll(CourseStatus.PLANUNG, this.StartDate, this.EndDate))
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

        private IList<SealingSchoolWPF.Model.CoursePlaning> CourseTypNames;

        private IEnumerable<SealingSchoolWPF.Model.CoursePlaning> _courseValues;
        public IEnumerable<SealingSchoolWPF.Model.CoursePlaning> CourseValues
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

        private SealingSchoolWPF.Model.CoursePlaning _courseTyp;
        public SealingSchoolWPF.Model.CoursePlaning CourseTyp
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

        private ObservableCollection<SealingSchoolWPF.ViewModel.Course.CourseViewModel> _courses;
        public ObservableCollection<SealingSchoolWPF.ViewModel.Course.CourseViewModel> Courses
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

        private SealingSchoolWPF.Model.Course _course;
        public SealingSchoolWPF.Model.Course Course
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

        private IList<SealingSchoolWPF.Model.Student> GetStudentTypNames()
        {
            StudentTypNames = new List<SealingSchoolWPF.Model.Student>();
            foreach (Model.Student quali in studentMgr.GetAll())
            {
                StudentTypNames.Add(quali);
            }
            return StudentTypNames;
        }

        private IList<SealingSchoolWPF.Model.Student> StudentTypNames;

        public IEnumerable<SealingSchoolWPF.Model.Student> StudentValues
        {
            get
            {
                return GetStudentTypNames();
            }
        }

        private SealingSchoolWPF.Model.Student _studentTyp;
        public SealingSchoolWPF.Model.Student StudentTyp
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

        private ObservableCollection<SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> _students;

        public ObservableCollection<SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> Students
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

            SealingSchoolWPF.Model.Course course = courseMgr.GetById(this.CourseTyp.Course.CourseId);
            int maxStudents = course.Capacity;

            SealingSchoolWPF.Model.Student origStud = this.StudentTyp;
            SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel stud =
                new SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel(origStud);

            if (this.Students == null)
            {
                this.Students = new ObservableCollection<SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel>();
            }

            foreach (SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel q in dummy)
            {
                if (q.Id == stud.Id)
                    return;
            }

            //prüfen, ob die notwendigen Qualification vorhanden sind
            //zuerst die  notwendenigen Qualifikationen aus dem Kurs holen
            IList<SealingSchoolWPF.Model.Qualification> courseQualies = this.qualiMgr.GetQualifications("Course", this.CourseTyp.Course.CourseId);

            //dann die Qualifikationen des Kursleiter
            IList<SealingSchoolWPF.Model.Qualification> studentQualies = this.qualiMgr.GetQualifications("Student", this.StudentTyp.StudentId);

            //jetzt vergleichen
            List<SealingSchoolWPF.Model.Qualification> results = new List<SealingSchoolWPF.Model.Qualification>();

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

        public void ExecuteDeleteCommand(SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel stud)
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

        private List<SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> dummy =
            new List<SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel>();

        private IList<SealingSchoolWPF.Model.Student> prepareStudents(IList<SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> list)
        {
            IList<SealingSchoolWPF.Model.Student> studList = new List<SealingSchoolWPF.Model.Student>();

            foreach (SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel q in list)
            {
                SealingSchoolWPF.Model.Student stud = new Model.Student();
                stud.StudentId = Convert.ToInt32(q.Id);
                studList.Add(stud);
            }

            return studList;
        }

        private void SaveModelToDatabase()
        {

            foreach (SealingSchoolWPF.Model.Student stud in prepareStudents(dummy))
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
            Students = new ObservableCollection<SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel>(dummy);
            this.ErrorLabel = String.Empty;
        }

        private ObservableCollection<SealingSchoolWPF.Model.TrainingActivity> GetTrainingActivities()
        {
            IList<SealingSchoolWPF.Model.TrainingActivity> tas = trainingActivityMgr.GetAll();
            trainingActivities = new ObservableCollection<TrainingActivity>(tas);
            return trainingActivities;
        }

        public IList<CoursePlaning> coursesList = new List<CoursePlaning>();
        #endregion



    }
}