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

namespace SealingSchoolWPF.ViewModel.Course
{
  public class UpdateCourseViewModel : ViewModel<Model.Course>
  {
    public Model.Course CourseDummy { get; set; }

    #region ctor
    public UpdateCourseViewModel( Model.Course model )
      : base( model )
    {
      instance = this;
      this.CourseDummy = model;
    }

    static UpdateCourseViewModel instance = null;
    static readonly object padlock = new object();

    public static UpdateCourseViewModel Instance
    {
      get
      {
        lock ( padlock )
        {
          if ( instance == null )
          {
            instance = new UpdateCourseViewModel( new SealingSchoolWPF.Model.Course() );
          }
          return instance;
        }
      }
    }
    #endregion

    #region properties
    public string Label
    {
      get
      {
        return CourseDummy.Label;
      }
      set
      {
        CourseDummy.Label = value;
        this.OnPropertyChanged( "Label" );
      }
    }

    private Double _ratingValue;
    public Double RatingValue
    {
      get
      {
        return _ratingValue != null && _ratingValue != 0 ? _ratingValue : Model.RatingValue;
      }
      set
      {
        _ratingValue = value;
        this.OnPropertyChanged( "RatingValue" );
      }
    }

    public int Duration
    {
      get
      {
        return CourseDummy.Duration;
      }
      set
      {
        CourseDummy.Duration = value;
        this.OnPropertyChanged( "Duration" );
      }
    }

    public int Capacity
    {
      get
      {
        return CourseDummy.Capacity;
      }
      set
      {
        CourseDummy.Capacity = value;
        this.OnPropertyChanged( "Capacity" );
      }
    }

    public Decimal NetPrice
    {
      get
      {
        return CourseDummy.NetPrice;
      }
      set
      {
        CourseDummy.NetPrice = value;
        this.OnPropertyChanged( "NetPrice" );
      }
    }

    public Decimal GrossPrice
    {
      get
      {
        return CourseDummy.GrossPrice;
      }
      set
      {
        CourseDummy.GrossPrice = value;
        this.CalculatePrice( value );
        this.OnPropertyChanged( "GrossPrice" );
      }
    }

    public Decimal NetAmount
    {
      get
      {
        return CourseDummy.NetAmount;
      }
      set
      {
        CourseDummy.NetAmount = value;
        this.OnPropertyChanged( "NetAmount" );
      }
    }

    private string _saveImage = "/Resources/Images/save_16xLG.png";
    public string SaveImage
    {
      get
      {
        return _saveImage;
      }
      set
      {
        _saveImage = value;
        this.OnPropertyChanged( "SaveImage" );
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

    public string Notes
    {
      get
      {
        return CourseDummy.AdditionalInfo;
      }
      set
      {
        CourseDummy.AdditionalInfo = value;
        this.OnPropertyChanged( "Notes" );
      }
    }

    public string Description
    {
      get
      {
        return CourseDummy.Description;
      }
      set
      {
        CourseDummy.Description = value;
        this.OnPropertyChanged( "Description" );
      }
    }

    public IEnumerable<Currency> CurrencyTypeValues
    {
      get
      {
        return Enum.GetValues( typeof( Currency ) )
            .Cast<Currency>();
      }
    }

    public Currency Currency
    {
      get
      {
        return CourseDummy.Currency;
      }
      set
      {
        CourseDummy.Currency = value;
        this.OnPropertyChanged( "Currency" );
      }
    }

    public int NeededInstructors
    {
      get
      {
        return CourseDummy.NeededInstructors;
      }
      set
      {
        CourseDummy.NeededInstructors = value;
        this.OnPropertyChanged( "NeededInstructors" );
      }
    }

    private IList<SealingSchoolWPF.Model.Qualification> GetQualificationTypNames()
    {
      QualificationTypNames = new List<SealingSchoolWPF.Model.Qualification>();
      foreach ( Model.Qualification quali in qualiMgr.GetAll() )
      {
        QualificationTypNames.Add( quali );
      }
      return QualificationTypNames;
    }

    private IList<SealingSchoolWPF.Model.Qualification> QualificationTypNames;

    public IEnumerable<SealingSchoolWPF.Model.Qualification> QualificationValues
    {
      get
      {
        return GetQualificationTypNames();
      }
    }

    private SealingSchoolWPF.Model.Qualification _qualificationTyp;
    public SealingSchoolWPF.Model.Qualification QualificationTyp
    {
      get
      {
        return _qualificationTyp;
      }
      set
      {
        _qualificationTyp = value;
        this.OnPropertyChanged( "QualificationTyp" );
      }
    }

    private ObservableCollection<QualificationViewModel> qualifications;
    public ObservableCollection<QualificationViewModel> Qualifications
    {
      get
      {
        return qualiList();
      }
      set
      {
        if ( Qualifications != value )
        {
          qualifications = value;
          this.OnPropertyChanged( "Qualifications" );
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

    private void ExecuteAddCommand()
    {
      Model.ModifiedOn = DateTime.Now;

      Model.Qualifications.Clear();

      if ( prepared != null )
      {
        foreach ( QualificationViewModel q in prepared )
        {
          Model.Qualifications.Add( prepareQualiToSave( q ) );
        }
      }

      Model.RatingValue = this._ratingValue;

      courseMgr.Update( Model );
      this.SaveImage = "/Resources/Images/StatusAnnotations_Complete_and_ok_16xLG_color.png";
      this.IsButtonEnabled = false;
    }

    public void ExecuteDeleteCommand( QualificationViewModel quali )
    {
      this.prepared.Remove( quali );
    }

    private ICommand addQualiCommand;
    public ICommand AddQualiCommand
    {
      get
      {
        if ( addQualiCommand == null )
        {
          addQualiCommand = new RelayCommand( p => ExecuteAddQualiCommand() );
        }
        return addQualiCommand;
      }
    }

    private void ExecuteAddQualiCommand()
    {
      if ( this.QualificationTyp == null )
        return;
      SealingSchoolWPF.Model.Qualification origQauli = this.QualificationTyp;
      QualificationViewModel quali = new QualificationViewModel( origQauli );

      foreach ( QualificationViewModel q in prepared )
      {
        if ( q.ShortName == quali.ShortName )
          return;
      }

      this.prepared.Add( quali );
    }
    #endregion

    #region helpers
    public void Close()
    {
      instance = null;
    }

    private SealingSchoolWPF.Model.Qualification prepareQualiToSave( QualificationViewModel q )
    {
      SealingSchoolWPF.Model.Qualification quali = new Model.Qualification();
      quali.QualificationId = q.Id;
      return quali;
    }

    private void CalculatePrice( decimal p )
    {
      decimal grossPrice = p;
      decimal netPrice = decimal.MinValue;
      decimal vat = 19;

      netPrice = grossPrice / ( ( 100 + vat ) / 100 );
      this.NetAmount = ( netPrice * vat / 100 );
      this.NetPrice = netPrice;
    }

    private ObservableCollection<QualificationViewModel> prepared;
    private ObservableCollection<QualificationViewModel> qualiList()
    {
      if ( prepared == null || prepared.Count == 0 )
      {
        prepared = new ObservableCollection<QualificationViewModel>();
      }
      foreach ( QualificationViewModel q in prepareQualifications( Model.Qualifications ) )
      {
        prepared.Add( q );
      }
      return prepared;
    }

    private ObservableCollection<QualificationViewModel> prepareQualifications( ICollection<SealingSchoolWPF.Model.Qualification> collection )
    {
      ObservableCollection<QualificationViewModel> list = new ObservableCollection<QualificationViewModel>();

      foreach ( Model.Qualification q in collection )
      {
        QualificationViewModel model = new QualificationViewModel( q );
        list.Add( model );
      }

      return list;
    }
    #endregion
  }
}