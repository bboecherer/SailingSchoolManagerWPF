﻿using SealingSchoolWPF.Data;
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

namespace SealingSchoolWPF.ViewModel.Course
{
  public class UpdateCoursePlaningViewModel : ViewModel<SealingSchoolWPF.Model.CoursePlaning>
  {
    static SealingSchoolWPF.Model.CoursePlaning modelDummy = new SealingSchoolWPF.Model.CoursePlaning();

    #region ctor
    public UpdateCoursePlaningViewModel( SealingSchoolWPF.Model.CoursePlaning model )
      : base( model )
    {
      modelDummy.CoursePlaningId = model.CoursePlaningId;
      modelDummy.StartDate = model.StartDate;
      modelDummy.EndDate = model.EndDate;
      modelDummy.Course = model.Course;
      modelDummy.CourseStatus = model.CourseStatus;
      modelDummy.Instructors = model.Instructors;
    }

    static UpdateCoursePlaningViewModel instance = null;
    static readonly object padlock = new object();

    public static UpdateCoursePlaningViewModel Instance
    {
      get
      {
        lock ( padlock )
        {
          if ( instance == null )
          {
            instance = new UpdateCoursePlaningViewModel( modelDummy );
          }
          return instance;
        }
      }
    }
    #endregion

    #region properties
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

    public SealingSchoolWPF.Model.Course Course
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
        return Enum.GetValues( typeof( CourseStatus ) )
            .Cast<CourseStatus>();
      }
    }

    public CourseStatus CourseStatus
    {
      get
      {
        return Model.CourseStatus;
      }
      set
      {
        CourseStatus = value;
        this.OnPropertyChanged( "CourseStatus" );
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
        this.OnPropertyChanged( "ErrorLabel" );
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
        this.OnPropertyChanged( "Page1ErrorLabel" );
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
        this.OnPropertyChanged( "IsComboBoxEnabled" );
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
        this.OnPropertyChanged( "IsComboBoxReadOnly" );
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
        this.OnPropertyChanged( "IsButtonEnabled" );
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
        this.OnPropertyChanged( "ImageSourceSave" );
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
        this.OnPropertyChanged( "ImageSourceNext" );
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
        this.OnPropertyChanged( "ImageSourceClear" );
      }
    }

    public DateTime? StartDate
    {
      get
      {
        return Model.StartDate;
      }
      set
      {
        StartDate = value;
        this.OnPropertyChanged( "StartDate" );
      }
    }

    public DateTime? EndDate
    {
      get
      {
        return Model.EndDate;
      }
      set
      {
        EndDate = value;
        this.OnPropertyChanged( "EndDate" );
      }
    }

    private IList<SealingSchoolWPF.Model.Instructor> GetInstructorTypNames()
    {
      InstructorTypNames = new List<SealingSchoolWPF.Model.Instructor>();
      foreach ( Model.Instructor quali in instructorMgr.GetAll() )
      {
        InstructorTypNames.Add( quali );
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
        this.OnPropertyChanged( "InstructorTyp" );
      }
    }

    private ObservableCollection<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel> _instructors;
    public ObservableCollection<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel> Instructors
    {
      get
      {
        return this.prepareInstructorsForModel( modelDummy.Instructors );
      }
      set
      {
        if ( _instructors != value )
        {
          _instructors = value;
          this.OnPropertyChanged( "Instructors" );
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
        if ( addCommand == null )
        {
          addCommand = new RelayCommand( p => ExecuteAddCommand() );
        }
        return addCommand;
      }
    }

    private ICommand addAndNextCommand;
    public ICommand AddAndNextCommand
    {
      get
      {
        if ( addAndNextCommand == null )
        {
          addAndNextCommand = new RelayCommand( p => ExecuteAddAndNextCommand() );
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
        if ( clearCommand == null )
        {
          clearCommand = new RelayCommand( p => ExecuteClearCommand() );
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
      Application.Current.Windows[ 1 ].Close();
    }

    public void ExecuteDeleteCommand( SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel instr )
    {
      this.ErrorLabel = string.Empty;
      this.dummy.Remove( instr );
      this.ReBindDataGrid();
    }

    private ICommand addInstructorCommand;
    public ICommand AddInstructorCommand
    {
      get
      {
        if ( addInstructorCommand == null )
        {
          addInstructorCommand = new RelayCommand( p => ExecuteAddInstructorCommand() );
        }
        return addInstructorCommand;
      }
    }

    private void ExecuteAddInstructorCommand()
    {
      this.ErrorLabel = string.Empty;

      if ( this.StartDate == null )
      {
        this.ErrorLabel = "Bitte wählen Sie Start- und Enddatum aus";
        return;
      }

      if ( this.EndDate == null )
      {
        this.ErrorLabel = "Bitte wählen Sie Start- und Enddatum aus";
        return;
      }

      if ( this.InstructorTyp == null )
        return;

      SealingSchoolWPF.Model.Course course = courseMgr.GetById( this.Course.CourseId );
      int maxInstructors = course.NeededInstructors;

      SealingSchoolWPF.Model.Instructor origQauli = this.InstructorTyp;
      SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel quali = new SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel( origQauli );
      if ( this.Instructors == null )
      {
        this.Instructors = new ObservableCollection<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel>();
      }

      if ( this.dummy.Count == maxInstructors )
      {
        this.ErrorLabel = string.Format( "Der Kurs hat nur max. {0} Kursleiter", maxInstructors );
        return;
      }

      //prüfen, ob die notwendigen Qualification vorhanden sind
      //zuerst die  notwendenigen Qualifikationen aus dem Kurs holen
      IList<SealingSchoolWPF.Model.Qualification> courseQualies = this.qualiMgr.GetQualifications( "Course", this.Course.CourseId );

      ////dann die Qualifikationen des Kursleiter
      IList<SealingSchoolWPF.Model.Qualification> instrQualies = this.qualiMgr.GetQualifications( "Instructor", this.InstructorTyp.InstructorId );

      ////jetzt vergleichen
      List<SealingSchoolWPF.Model.Qualification> results = new List<SealingSchoolWPF.Model.Qualification>();

      foreach ( var s1 in courseQualies )
      {
        foreach ( var s2 in instrQualies )
        {
          if ( s1.QualificationId == s2.QualificationId )
          {
            results.Add( s1 );
            // Aufhören wenn der Wert gefunden wurde
            break;
          }
        }
      }

      if ( results.Count() != courseQualies.Count() )
      {
        this.ErrorLabel = "Der Kursleiter verfügt nicht über die notwendigen Qualifikationen";
        return;
      }

      //prüfen, ob der Instructor zur Verfügung steht
      IList<SealingSchoolWPF.Model.BlockedTimeSpan> instrBlockedTimes = this.blockTimesMgr.GetByInstructor( this.InstructorTyp.InstructorId );

      IList<SealingSchoolWPF.Model.BlockedTimeSpan> timeResult = new List<SealingSchoolWPF.Model.BlockedTimeSpan>();

      // nur notwendig, wenn geblockte Zeiträume vorhanden sind
      if ( instrBlockedTimes != null || instrBlockedTimes.Count != 0 )
      {
        foreach ( SealingSchoolWPF.Model.BlockedTimeSpan blocked in instrBlockedTimes )
        {
          if ( !( blocked.EndDate < this.StartDate ) )
          {
            if ( blocked.StartDate < this.StartDate )
            {
              if ( TimeBetween( this.StartDate, blocked.StartDate, blocked.EndDate ) )
                timeResult.Add( blocked );
            }
            else
            {
              if ( TimeBetween( this.EndDate, blocked.StartDate, blocked.EndDate ) )
                timeResult.Add( blocked );
            }
          }
        }

        if ( timeResult.Count > 0 )
        {
          this.ErrorLabel = "Der Kursleiter steht nicht zur Verfügung";
          return;
        }
      }
      this.dummy.Add( quali );
      this.ReBindDataGrid();
    }
    #endregion

    #region helpers

    public bool TimeBetween( DateTime? datetime, DateTime? start, DateTime? end )
    {
      if ( start < end )
      {
        return ( start <= datetime && datetime <= end ) || ( start <= datetime && datetime >= end );
      }
      return !( end < datetime && datetime < start );
    }

    public void Close()
    {
      instance = null;
    }

    private List<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel> dummy = new List<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel>();

    private IList<SealingSchoolWPF.Model.Instructor> prepareInstructors( IList<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel> list )
    {
      IList<SealingSchoolWPF.Model.Instructor> instrList = new List<SealingSchoolWPF.Model.Instructor>();

      foreach ( SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel q in list )
      {
        SealingSchoolWPF.Model.Instructor instr = new Model.Instructor();
        instr.InstructorId = Convert.ToInt32( q.Id );
        instrList.Add( instr );
      }

      return instrList;
    }

    private ObservableCollection<Instructor.InstructorViewModel> prepareInstructorsForModel( ICollection<SealingSchoolWPF.Model.Instructor> collection )
    {
      IList<Instructor.InstructorViewModel> instrList = new List<Instructor.InstructorViewModel>();
      foreach ( SealingSchoolWPF.Model.Instructor instr in collection )
      {
        Instructor.InstructorViewModel i = new Instructor.InstructorViewModel( instr );
        instrList.Add( i );
      }
      return new ObservableCollection<Instructor.InstructorViewModel>( instrList );
    }


    private void SaveModelToDatabase()
    {
      Model.StartDate = this.StartDate;
      Model.EndDate = this.EndDate;
      Model.CourseStatus = this.CourseStatus;

      if ( Model.Instructors == null )
      {
        Model.Instructors = new List<SealingSchoolWPF.Model.Instructor>();
      }
      foreach ( SealingSchoolWPF.Model.Instructor instr in prepareInstructors( dummy ) )
      {
        Model.Instructors.Add( instr );
      }

      // Model.Course = this.Course;

      //   coursePlaningMgr.Create( Model );
    }

    private void ReBindDataGrid()
    {
      this.Instructors.Clear();
      Instructors = new ObservableCollection<SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel>( dummy );
    }

    public void CheckFields()
    {
      if ( this.StartDate == null )
      {
        this.Page1ErrorLabel = "Bitte Datum auswählen!";
        return;
      }
    }
    #endregion

  }
}