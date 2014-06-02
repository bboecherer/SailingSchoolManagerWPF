using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Pages.Student.Create;
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

namespace SealingSchoolWPF.ViewModel.CourseViewModel
{
    public class CreateCoursePlaningViewModel : ViewModel<SealingSchoolWPF.Model.CoursePlaning>
    {
        #region ctor
        public CreateCoursePlaningViewModel(SealingSchoolWPF.Model.CoursePlaning model)
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
                        instance = new CreateCoursePlaningViewModel(new SealingSchoolWPF.Model.CoursePlaning());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        public IEnumerable<SealingSchoolWPF.Model.Course> CourseTypeValues
        {
            get
            {
                return GetCourseNames();
            }
        }

        private IList<SealingSchoolWPF.Model.Course> GetCourseNames()
        {
            CourseNames = new List<SealingSchoolWPF.Model.Course>();
            foreach (Model.Course inst in courseMgr.GetAll())
            {
                CourseNames.Add(inst);
            }
            return CourseNames;
        }

        private IList<SealingSchoolWPF.Model.Course> CourseNames;

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

        private IList<SealingSchoolWPF.Model.Instructor> GetInstructorTypNames()
        {
            InstructorTypNames = new List<SealingSchoolWPF.Model.Instructor>();
            foreach (Model.Instructor quali in instructorMgr.GetAll())
            {
                InstructorTypNames.Add(quali);
            }
            return InstructorTypNames;
        }

        private IList<SealingSchoolWPF.Model.Instructor> InstructorTypNames;

        public IEnumerable<SealingSchoolWPF.Model.Instructor> InstructorValues
        {
            get
            {
                return GetInstructorTypNames();
            }
        }

        private SealingSchoolWPF.Model.Instructor _instructorTyp;
        public SealingSchoolWPF.Model.Instructor InstructorTyp
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

        private ObservableCollection<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel> _instructors;
        public ObservableCollection<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel> Instructors
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
            SaveModelToDatabase();
            Application.Current.Windows[1].Close();
        }

        public void ExecuteDeleteCommand(SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel instr)
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

            if (this.InstructorTyp == null)
                return;

            SealingSchoolWPF.Model.Course course = courseMgr.GetById(this.Course.CourseId);
            int maxInstructors = course.NeededInstructors;

            SealingSchoolWPF.Model.Instructor origQauli = this.InstructorTyp;
            SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel quali = new SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel(origQauli);
            if (this.Instructors == null)
            {
                this.Instructors = new ObservableCollection<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel>();
            }

            foreach (SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel q in dummy)
            {
                if (q.Id == quali.Id)
                    return;
            }

            if (this.dummy.Count == maxInstructors)
            {
                this.ErrorLabel = string.Format("Der Kurs hat nur max. {0} Kursleiter", maxInstructors);
                return;
            }

            this.dummy.Add(quali);
            this.ReBindDataGrid();
        }

        #endregion

        #region helpers
        public void Close()
        {
            instance = null;
        }

        private List<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel> dummy = new List<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel>();

        private IList<SealingSchoolWPF.Model.Instructor> prepareInstructors(IList<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel> list)
        {
            IList<SealingSchoolWPF.Model.Instructor> instrList = new List<SealingSchoolWPF.Model.Instructor>();

            foreach (SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel q in list)
            {
                SealingSchoolWPF.Model.Instructor instr = new Model.Instructor();
                instr.InstructorId = Convert.ToInt32(q.Id);
                instrList.Add(instr);
            }

            return instrList;
        }

        private void SaveModelToDatabase()
        {
            Model.StartDate = this.StartDate;
            Model.EndDate = this.EndDate;
            Model.CourseStatus = this.CourseStatus;

            if (Model.Instructors == null)
            {
                Model.Instructors = new List<SealingSchoolWPF.Model.Instructor>();
            }
            foreach (SealingSchoolWPF.Model.Instructor instr in prepareInstructors(dummy))
            {
                Model.Instructors.Add(instr);
            }

            Model.Course = this.Course;

            coursePlaningMgr.Create(Model);
        }

        private void ReBindDataGrid()
        {
            this.Instructors.Clear();
            Instructors = new ObservableCollection<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel>(dummy);
        }
        #endregion
    }
}