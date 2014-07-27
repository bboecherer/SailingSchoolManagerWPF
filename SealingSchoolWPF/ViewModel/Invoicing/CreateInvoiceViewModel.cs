using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SailingSchoolWPF.PDF;

namespace SailingSchoolWPF.ViewModel.Invoicing
{
    /// <summary>
    /// ViewModel for invoice creation
    /// @Author Benjamin Böcherer
    /// </summary>
  public class CreateInvoiceViewModel : ViewModel<SailingSchoolWPF.Model.Invoice>
  {
    #region ctor
    public CreateInvoiceViewModel( SailingSchoolWPF.Model.Invoice model )
      : base( model )
    {
      GetTrainingActivityTypNames();
    }

    static CreateInvoiceViewModel instance = null;
    static readonly object padlock = new object();

    public static CreateInvoiceViewModel Instance
    {
      get
      {
        lock ( padlock )
        {
          if ( instance == null )
          {
            instance = new CreateInvoiceViewModel( new SailingSchoolWPF.Model.Invoice() );
          }
          return instance;
        }
      }
    }
    #endregion

    #region properties

    private ObservableCollection<Invoice> invoices;
    public ObservableCollection<Invoice> Invoices
    {
      get
      {
        return this.GetInvoices();
      }
      set
      {
        if ( invoices != value )
        {
          invoices = value;
          this.OnPropertyChanged( "Invoices" );
        }
      }
    }


    private IList<SailingSchoolWPF.Model.TrainingActivity> GetTrainingActivityTypNames()
    {
      CourseTypNames = new List<SailingSchoolWPF.Model.TrainingActivity>();

      foreach ( SailingSchoolWPF.Model.TrainingActivity course in trainingActivityMgr.GetByStatus( TrainingActivityStatus.BEENDET ) )
      {
        CourseTypNames.Add( course );
        coursesList.Add( course );
      }

      TrainingActivityValues = coursesList;

      return CourseTypNames;
    }

    private IList<SailingSchoolWPF.Model.TrainingActivity> CourseTypNames;

    private IEnumerable<SailingSchoolWPF.Model.TrainingActivity> _trainingActivityValues;
    public IEnumerable<SailingSchoolWPF.Model.TrainingActivity> TrainingActivityValues
    {
      get
      {
        return coursesList;
      }
      set
      {
        _trainingActivityValues = value;
        this.OnPropertyChanged( "TrainingActivityValues" );
      }
    }

    private SailingSchoolWPF.Model.TrainingActivity _trainingActivityTyp;
    public SailingSchoolWPF.Model.TrainingActivity TrainingActivityTyp
    {
      get
      {
        return _trainingActivityTyp;
      }
      set
      {
        _trainingActivityTyp = value;
        this.OnPropertyChanged( "TrainingActivityTyp" );
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

    //private bool CheckComboBox()
    //{
    //  return this.StartDate == null && this.EndDate == null;
    //}

    private ObservableCollection<SailingSchoolWPF.ViewModel.Course.CourseViewModel> _courses;
    public ObservableCollection<SailingSchoolWPF.ViewModel.Course.CourseViewModel> Courses
    {
      get
      {
        return _courses;
      }
      set
      {
        if ( _courses != value )
        {
          _courses = value;
          this.OnPropertyChanged( "Courses" );
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
        this.OnPropertyChanged( "Course" );
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

    //private DateTime? _startDate;
    //public DateTime? StartDate
    //{
    //  get
    //  {
    //    return _startDate;
    //  }
    //  set
    //  {
    //    _startDate = value;
    //    this.IsComboBoxReadOnly = !CheckComboBox();
    //    this.IsComboBoxEnabled = CheckComboBox();
    //    GetTrainingActivityTypNames();
    //    this.OnPropertyChanged( "StartDate" );
    //  }
    //}

    //private DateTime? _endDate;
    //public DateTime? EndDate
    //{
    //  get
    //  {
    //    return _endDate;
    //  }
    //  set
    //  {
    //    _endDate = value;
    //    this.IsComboBoxReadOnly = CheckComboBox();
    //    this.IsComboBoxEnabled = !CheckComboBox();
    //    coursesList.Clear();
    //    GetTrainingActivityTypNames();
    //    this.OnPropertyChanged( "EndDate" );
    //  }
    //}

    private IList<SailingSchoolWPF.Model.Student> GetStudentTypNames()
    {
      StudentTypNames = new List<SailingSchoolWPF.Model.Student>();
      foreach ( Model.Student quali in studentMgr.GetAll() )
      {
        StudentTypNames.Add( quali );
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
        this.OnPropertyChanged( "StudentTyp" );
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
        if ( _students != value )
        {
          _students = value;
          this.OnPropertyChanged( "Students" );
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
      this.Students.Clear();
      this.dummy.Clear();
      this.ReBindDataGrid();
    }

    private void ExecuteAddCommand()
    {
      SaveModelToDatabase();
      Application.Current.Windows[ 1 ].Close();

    }

    private ICommand addStudentCommand;
    public ICommand AddStudentCommand
    {
      get
      {
        if ( addStudentCommand == null )
        {
          addStudentCommand = new RelayCommand( p => ExecuteAddStudentCommand() );
        }
        return addStudentCommand;
      }
    }

    private void ExecuteAddStudentCommand()
    {
      this.ErrorLabel = string.Empty;

      if ( this.StudentTyp == null )
        return;

      SailingSchoolWPF.Model.Course course = courseMgr.GetById( this.TrainingActivityTyp.Course.CourseId );

      SailingSchoolWPF.Model.Student origStud = this.StudentTyp;
      SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel stud =
          new SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel( origStud );

      if ( this.Students == null )
      {
        this.Students = new ObservableCollection<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel>();
      }

      foreach ( SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel q in dummy )
      {
        if ( q.Id == stud.Id )
          return;
      }

      this.dummy.Add( stud );
      this.ReBindDataGrid();
    }

    public void ExecuteDeleteCommand( SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel stud )
    {
      this.ErrorLabel = string.Empty;
      this.dummy.Remove( stud );
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

    private IList<SailingSchoolWPF.Model.Student> prepareStudents( IList<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel> list )
    {
      IList<SailingSchoolWPF.Model.Student> studList = new List<SailingSchoolWPF.Model.Student>();

      foreach ( SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel q in list )
      {
        SailingSchoolWPF.Model.Student stud = new Model.Student();
        stud.StudentId = Convert.ToInt32( q.Id );
        studList.Add( stud );
      }

      return studList;
    }

    private void SaveModelToDatabase()
    {
      InvoiceItem item = new InvoiceItem();
      item.GrossPrice = this.TrainingActivityTyp.Course.GrossPrice;
      item.NetPrice = this.TrainingActivityTyp.Course.NetPrice;
      item.VatAmount = this.TrainingActivityTyp.Course.NetAmount;
      item.Amount = 1;
      item.ServiceLocation = "Italien";
      item.ServiceEndDate = DateTime.Now;
      item.ServiceStartDate = DateTime.Now;
      Model.InvoiceItems = new List<InvoiceItem>();
      Model.InvoiceItems.Add( item );

      Model.CreatedOn = DateTime.Now;
      Model.Printed = false;
      Model.GrossPrice = this.TrainingActivityTyp.Course.GrossPrice;
      Model.NetPrice = this.TrainingActivityTyp.Course.NetPrice;
      Model.VatAmount = this.TrainingActivityTyp.Course.NetAmount;
      Model.PaymentStatus = PaymentStatus.NICHT_GEZAHLT;
      Model.InvoiceStatus = InvoiceStatus.RECHNUNG;
      Model.PaymentTargetDate = DateTime.Now.Add( new TimeSpan( 14, 0, 0, 0 ) );
      Model.PaidDate = DateTime.Now;
      Model.ModifiedOn = DateTime.Now;
      Model.Label = this.TrainingActivityTyp.Student.Label + " / " + this.TrainingActivityTyp.Course.Label;

      try
      {
        this.invoiceMgr.Create( Model );
        TrainingActivity ta = this.trainingActivityMgr.GetById( this.TrainingActivityTyp.TrainingActivityId );
        ta.TrainingActivityStatus = TrainingActivityStatus.RECHNUNG_GESTELLT;
        this.trainingActivityMgr.Update( ta );

        PDFPrinter createInvoicePDF = new PDFPrinter();
        string name = DateTime.Now.ToString().Replace( ".", "_" ).Replace( ":", string.Empty ).Replace( " ", "_" );
        createInvoicePDF.createInvoicePDF( name.Trim(), ta, Model.InvoiceId );
      }
      catch ( Exception e )
      {

      }
    }

    private void ReBindDataGrid()
    {
      this.Students.Clear();
      Students = new ObservableCollection<SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel>( dummy );
      this.ErrorLabel = String.Empty;
    }

    private ObservableCollection<SailingSchoolWPF.Model.Invoice> GetInvoices()
    {
      IList<SailingSchoolWPF.Model.Invoice> invs = invoiceMgr.GetAll();
      invoices = new ObservableCollection<Invoice>( invs );
      return invoices;
    }

    public IList<TrainingActivity> coursesList = new List<TrainingActivity>();
    #endregion
  }
}