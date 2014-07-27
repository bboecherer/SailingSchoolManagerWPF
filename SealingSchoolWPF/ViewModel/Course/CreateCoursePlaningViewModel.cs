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

namespace SailingSchoolWPF.ViewModel.Course
{
    /// <summary>
    /// ViewModel for creating course planning
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CreateCoursePlaningViewModel : ViewModel<SailingSchoolWPF.Model.CoursePlaning>
    {
        #region ctor
        public CreateCoursePlaningViewModel(SailingSchoolWPF.Model.CoursePlaning model)
            : base(model)
        {
        }

        static CreateCoursePlaningViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateCoursePlaningViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateCoursePlaningViewModel(new SailingSchoolWPF.Model.CoursePlaning());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        public IEnumerable<SailingSchoolWPF.Model.Course> CourseTypeValues
        {
            get
            {
                return GetCourseNames();
            }
        }

        private IList<SailingSchoolWPF.Model.Course> GetCourseNames()
        {
            CourseNames = new List<SailingSchoolWPF.Model.Course>();
            foreach (Model.Course inst in courseMgr.GetAll())
            {
                CourseNames.Add(inst);
            }
            return CourseNames;
        }

        private IList<SailingSchoolWPF.Model.Course> CourseNames;

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

        private string _page1ErrorLabel;
        public string Page1ErrorLabel
        {
            get
            {
                return _page1ErrorLabel;
            }
            set
            {
                _page1ErrorLabel = value;
                this.OnPropertyChanged("Page1ErrorLabel");
            }
        }

        private bool _isComboBoxEnabled = true;
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

        private bool _isComboBoxReadOnly = false;
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
                this.OnPropertyChanged("EndDate");
            }
        }

        private IList<SailingSchoolWPF.Model.Instructor> GetInstructorTypNames()
        {
            InstructorTypNames = new List<SailingSchoolWPF.Model.Instructor>();
            foreach (Model.Instructor quali in instructorMgr.GetAll())
            {
                InstructorTypNames.Add(quali);
            }
            return InstructorTypNames;
        }

        private IList<SailingSchoolWPF.Model.Instructor> InstructorTypNames;

        public IEnumerable<SailingSchoolWPF.Model.Instructor> InstructorValues
        {
            get
            {
                return GetInstructorTypNames();
            }
        }

        private SailingSchoolWPF.Model.Instructor _instructorTyp;
        public SailingSchoolWPF.Model.Instructor InstructorTyp
        {
            get
            {
                return _instructorTyp;
            }
            set
            {
                _instructorTyp = value;
                this.OnPropertyChanged("InstructorTyp");
            }
        }

        private ObservableCollection<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel> _instructors;
        public ObservableCollection<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel> Instructors
        {
            get
            {
                return _instructors;
            }
            set
            {
                if (_instructors != value)
                {
                    _instructors = value;
                    this.OnPropertyChanged("Instructors");
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
            this.Instructors.Clear();
            this.dummy.Clear();
            this.ReBindDataGrid();
        }

        private void ExecuteAddCommand()
        {
            if (SaveModelToDatabase())
            {
                Application.Current.Windows[1].Close();
            }
        }

        public void ExecuteDeleteCommand(SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel instr)
        {
            this.ErrorLabel = string.Empty;
            this.dummy.Remove(instr);
            this.ReBindDataGrid();
        }

        private ICommand addInstructorCommand;
        public ICommand AddInstructorCommand
        {
            get
            {
                if (addInstructorCommand == null)
                {
                    addInstructorCommand = new RelayCommand(p => ExecuteAddInstructorCommand());
                }
                return addInstructorCommand;
            }
        }

        private void ExecuteAddInstructorCommand()
        {
            this.ErrorLabel = string.Empty;

            if (this.StartDate == null)
            {
                this.ErrorLabel = "Bitte wählen Sie Start- und Enddatum aus";
                return;
            }

            if (this.EndDate == null)
            {
                this.ErrorLabel = "Bitte wählen Sie Start- und Enddatum aus";
                return;
            }

            if (this.Course == null)
            {
                this.ErrorLabel = "Bitte wählen Sie einen Kurs aus";
                return;
            }

            if (this.InstructorTyp == null)
                return;

            SailingSchoolWPF.Model.Course course = courseMgr.GetById(this.Course.CourseId);
            int maxInstructors = course.NeededInstructors;

            SailingSchoolWPF.Model.Instructor origQauli = this.InstructorTyp;
            SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel quali = new SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel(origQauli);
            if (this.Instructors == null)
            {
                this.Instructors = new ObservableCollection<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel>();
            }

            foreach (SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel q in dummy)
            {
                if (q.Id == quali.Id)
                    return;
            }

            if (this.dummy.Count == maxInstructors)
            {
                this.ErrorLabel = string.Format("Der Kurs hat nur max. {0} Kursleiter", maxInstructors);
                return;
            }

            //prüfen, ob die notwendigen Qualification vorhanden sind
            //zuerst die  notwendenigen Qualifikationen aus dem Kurs holen
            IList<SailingSchoolWPF.Model.Qualification> courseQualies = this.qualiMgr.GetQualifications("Course", this.Course.CourseId);

            //dann die Qualifikationen des Kursleiter
            IList<SailingSchoolWPF.Model.Qualification> instrQualies = this.qualiMgr.GetQualifications("Instructor", this.InstructorTyp.InstructorId);

            //jetzt vergleichen
            List<SailingSchoolWPF.Model.Qualification> results = new List<SailingSchoolWPF.Model.Qualification>();

            foreach (var s1 in courseQualies)
            {
                foreach (var s2 in instrQualies)
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
                this.ErrorLabel = "Der Kursleiter verfügt nicht über die notwendigen Qualifikationen";
                return;
            }

            //prüfen, ob der Instructor zur Verfügung steht
            IList<SailingSchoolWPF.Model.BlockedTimeSpan> instrBlockedTimes = this.blockTimesMgr.GetByInstructor(this.InstructorTyp.InstructorId);

            IList<SailingSchoolWPF.Model.BlockedTimeSpan> timeResult = new List<SailingSchoolWPF.Model.BlockedTimeSpan>();

            // nur notwendig, wenn geblockte Zeiträume vorhanden sind
            if (instrBlockedTimes != null || instrBlockedTimes.Count != 0)
            {
                foreach (SailingSchoolWPF.Model.BlockedTimeSpan blocked in instrBlockedTimes)
                {
                    if (!(blocked.EndDate < this.StartDate))
                    {
                        if (blocked.StartDate < this.StartDate)
                        {
                            if (TimeBetween(this.StartDate, blocked.StartDate, blocked.EndDate))
                                timeResult.Add(blocked);
                        }
                        else
                        {
                            if (TimeBetween(this.EndDate, blocked.StartDate, blocked.EndDate))
                                timeResult.Add(blocked);
                        }
                    }
                }

                if (timeResult.Count > 0)
                {
                    this.ErrorLabel = "Der Kursleiter steht nicht zur Verfügung";
                    return;
                }
            }
            this.dummy.Add(quali);
            this.ReBindDataGrid();
        }
        #endregion

        #region helpers

        public bool TimeBetween(DateTime? datetime, DateTime? start, DateTime? end)
        {
            if (start < end)
            {
                return (start <= datetime && datetime <= end) || (start <= datetime && datetime >= end);
            }
            return !(end < datetime && datetime < start);
        }

        public void Close()
        {
            instance = null;
        }

        private List<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel> dummy = new List<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel>();

        private IList<SailingSchoolWPF.Model.Instructor> prepareInstructors(IList<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel> list)
        {
            IList<SailingSchoolWPF.Model.Instructor> instrList = new List<SailingSchoolWPF.Model.Instructor>();

            foreach (SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel q in list)
            {
                SailingSchoolWPF.Model.Instructor instr = new Model.Instructor();
                instr.InstructorId = Convert.ToInt32(q.Id);
                instrList.Add(instr);
            }

            return instrList;
        }

        private Boolean SaveModelToDatabase()
        {
            Model.StartDate = this.StartDate;
            Model.EndDate = this.EndDate;
            Model.CourseStatus = this.CourseStatus;

            if (Model.Instructors == null)
            {
                Model.Instructors = new List<SailingSchoolWPF.Model.Instructor>();
            }
            foreach (SailingSchoolWPF.Model.Instructor instr in prepareInstructors(dummy))
            {
                Model.Instructors.Add(instr);
            }

            Model.Course = this.Course;

            if (!coursePlaningMgr.CreateWithAnswer(Model))
            {
                this.ErrorLabel = "Es steht nicht genug Material für diesen Kurs zur Verfügung";
                return false;
            }
            return true;
        }

        private void ReBindDataGrid()
        {
            this.Instructors.Clear();
            Instructors = new ObservableCollection<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel>(dummy);
        }

        public void CheckFields()
        {
            //if ( this.StartDate == null )
            //{
            //  this.Page1ErrorLabel = "Bitte Datum auswählen!";
            //  return;
            //}
        }
        #endregion

    }
}