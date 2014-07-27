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
    /// ViewModel for update course planning
    /// @Author Benjamin Böcherer
    /// </summary>
    public class UpdateCoursePlaningViewModel : ViewModel<SailingSchoolWPF.Model.CoursePlaning>
    {
        static SailingSchoolWPF.Model.CoursePlaning modelDummy = new SailingSchoolWPF.Model.CoursePlaning();

        #region ctor
        public UpdateCoursePlaningViewModel(SailingSchoolWPF.Model.CoursePlaning model)
            : base(model)
        {
            modelDummy.CoursePlaningId = model.CoursePlaningId;
            modelDummy.StartDate = model.StartDate;
            modelDummy.EndDate = model.EndDate;
            modelDummy.Course = model.Course;
            modelDummy.CourseStatus = model.CourseStatus;
            modelDummy.Instructors = model.Instructors;

            foreach (SailingSchoolWPF.Model.Instructor inst in model.Instructors)
            {
                instrList.Add(inst);
            }
        }

        static UpdateCoursePlaningViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateCoursePlaningViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateCoursePlaningViewModel(modelDummy);
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties

        private bool isInsructorChanged = false;
        public String CourseString
        {
            get
            {
                return modelDummy.Course.Label;
            }
            set
            {
                CourseString = value;
            }
        }

        public SailingSchoolWPF.Model.Course Course
        {
            get
            {
                return modelDummy.Course;
            }
            set
            {
                Course = value;
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
                return modelDummy.CourseStatus;
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
                return !isStartDateChanged ? Model.StartDate : _startDate;
            }
            set
            {
                _startDate = value;
                this.isStartDateChanged = true;
                this.OnPropertyChanged("StartDate");
            }
        }

        private bool isStartDateChanged = false;
        private bool isEndDateChanged = false;

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get
            {
                return !isEndDateChanged ? Model.EndDate : _endDate;
            }
            set
            {
                _endDate = value;
                this.isEndDateChanged = true;
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

        IList<SailingSchoolWPF.Model.Instructor> instrList = new List<SailingSchoolWPF.Model.Instructor>();

        private ObservableCollection<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel> _instructors;
        public ObservableCollection<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel> Instructors
        {
            get
            {
                return this.prepareInstructorsForModel(instrList);
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

        private void ExecuteAddCommand()
        {
            SaveModelToDatabase();
            Application.Current.Windows[1].Close();
        }

        public void ExecuteDeleteCommand(SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel instr)
        {
            this.ErrorLabel = string.Empty;
            this.isInsructorChanged = true;
            instrList.Remove(prepareInstrToModel(instr));
            this.ReBindDataGrid();
        }

        private SailingSchoolWPF.Model.Instructor prepareInstrToModel(Instructor.InstructorViewModel instr)
        {
            SailingSchoolWPF.Model.Instructor instructor = new Model.Instructor();
            instructor.InstructorId = Convert.ToInt32(instr.Id);
            instructor.Label = instr.Label;
            return instructor;
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

            if (CheckFields())
                return;

            SailingSchoolWPF.Model.Course course = courseMgr.GetById(this.Course.CourseId);
            int maxInstructors = course.NeededInstructors;

            SailingSchoolWPF.Model.Instructor origQauli = this.InstructorTyp;
            SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel quali = new SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel(origQauli);
            if (this.Instructors == null)
            {
                this.Instructors = new ObservableCollection<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel>();
            }

            if (this.dummy.Count == maxInstructors)
            {
                this.ErrorLabel = string.Format("Der Kurs hat nur max. {0} Kursleiter", maxInstructors);
                return;
            }

            //prüfen, ob die notwendigen Qualification vorhanden sind
            //zuerst die  notwendenigen Qualifikationen aus dem Kurs holen
            IList<SailingSchoolWPF.Model.Qualification> courseQualies = this.qualiMgr.GetQualifications("Course", this.Course.CourseId);

            ////dann die Qualifikationen des Kursleiter
            IList<SailingSchoolWPF.Model.Qualification> instrQualies = this.qualiMgr.GetQualifications("Instructor", this.InstructorTyp.InstructorId);

            ////jetzt vergleichen
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
                    // in der Update-Methode muss jetzt geprüft werden, ob die geblockte Zeit von dem aktuellen Kurs ausgeht
                    foreach (SailingSchoolWPF.Model.BlockedTimeSpan blocked in timeResult)
                        if (blocked.Course.CourseId != modelDummy.Course.CourseId)
                        {
                            this.ErrorLabel = "Der Kursleiter steht nicht zur Verfügung";
                            return;
                        }
                }
            }
            this.instrList.Add(prepareInstrToModel(quali));
            this.isInsructorChanged = true;
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

        private ObservableCollection<Instructor.InstructorViewModel> prepareInstructorsForModel(ICollection<SailingSchoolWPF.Model.Instructor> collection)
        {
            IList<Instructor.InstructorViewModel> instrList = new List<Instructor.InstructorViewModel>();
            foreach (SailingSchoolWPF.Model.Instructor instr in collection)
            {
                Instructor.InstructorViewModel i = new Instructor.InstructorViewModel(instr);
                instrList.Add(i);
            }
            return new ObservableCollection<Instructor.InstructorViewModel>(instrList);
        }


        private void SaveModelToDatabase()
        {
            Model.StartDate = this._startDate != null ? this._startDate : Model.StartDate;
            Model.EndDate = this._endDate != null ? this._endDate : Model.EndDate;
            Model.CourseStatus = this._courseStatus;

            if (Model.Instructors == null)
            {
                Model.Instructors = new List<SailingSchoolWPF.Model.Instructor>();
            }
            foreach (SailingSchoolWPF.Model.Instructor instr in prepareInstructors(dummy))
            {
                Model.Instructors.Add(instr);
            }

            Model.Course = modelDummy.Course;

            coursePlaningMgr.Update(Model);

            // prüfen, ob geblockte Zeiten aktualisiert werden müssen
            if (this.isInsructorChanged || this._startDate != null || this._endDate != null)
            {
                IList<BlockedTimeSpan> blockedList = new List<BlockedTimeSpan>();
                foreach (SailingSchoolWPF.Model.Instructor instr in instrList)
                {
                    BlockedTimeSpan block = new BlockedTimeSpan();
                    block.Course = modelDummy.Course;
                    block.Instructor = instr;
                    block.Reason = modelDummy.Course.Label;
                    block.StartDate = this._startDate != null ? (DateTime)this._startDate : (DateTime)Model.StartDate;
                    block.EndDate = this._endDate != null ? (DateTime)this._endDate : (DateTime)Model.EndDate;
                    blockedList.Add(block);
                }

                blockTimesMgr.Update(blockedList, true);
            }


            // Status der TAs ändern, falls welche vorhanden sind
            List<TrainingActivity> tas = this.trainingActivityMgr.GetByCoursePlaning(Model.CoursePlaningId);
            if (tas.Count > 0)
            {
                foreach (TrainingActivity ta in tas)
                {
                    if (this.CourseStatus == CourseStatus.BEENDET)
                    {
                        ta.TrainingActivityStatus = TrainingActivityStatus.BEENDET;
                    }

                    if (this.CourseStatus == CourseStatus.GESTARTET)
                    {
                        ta.TrainingActivityStatus = TrainingActivityStatus.GESTARTET;
                    }

                    if (this.CourseStatus == CourseStatus.ABGEBROCHEN)
                    {
                        ta.TrainingActivityStatus = TrainingActivityStatus.ABGEBROCHEN;
                    }
                }

                foreach (TrainingActivity ta in tas)
                {
                    this.trainingActivityMgr.Update(ta);
                }

            }
        }

        private void ReBindDataGrid()
        {
            this.Instructors.Clear();
            Instructors = new ObservableCollection<SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel>(prepareInstructorsForModel(instrList));
        }

        public bool CheckFields()
        {
            if (this.StartDate == null)
            {
                this.ErrorLabel = "Bitte wählen Sie Start- und Enddatum aus";
                return true;
            }

            if (this.EndDate == null)
            {
                this.ErrorLabel = "Bitte wählen Sie Start- und Enddatum aus";
                return true;
            }

            if (this.InstructorTyp == null)
                return true;

            foreach (SailingSchoolWPF.Model.Instructor i in instrList)
            {
                if (this.InstructorTyp.InstructorId == i.InstructorId)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
}