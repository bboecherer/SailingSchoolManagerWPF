using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.ViewModel.Course
{
    /// <summary>
    /// ViewModel for BlockedTimes
    /// @Author Benjamin Böcherer
    /// </summary>
  public class BlockedTimesViewModel : ViewModel<SailingSchoolWPF.Model.BlockedTimeSpan>
  {
    #region ctor
    public BlockedTimesViewModel( SailingSchoolWPF.Model.BlockedTimeSpan model )
      : base( model )
    {
    }
    #endregion

    #region properties

    public int Id
    {
      get
      {
        return Model.BlockedTimeSpanId;
      }
      set
      {
        Model.BlockedTimeSpanId = value;
        this.OnPropertyChanged( "Id" );
      }
    }

    public String StartDate
    {
      get
      {
        return Model.StartDate.ToShortDateString();
      }
      set
      {
        if ( StartDate != value )
        {
          Model.StartDate = DateTime.Parse( value );
          this.OnPropertyChanged( "StartDate" );
        }
      }
    }

    public String EndDate
    {
      get
      {
        return Model.EndDate.ToShortDateString();
      }
      set
      {
        if ( EndDate != value )
        {
          Model.EndDate = DateTime.Parse( value );
          this.OnPropertyChanged( "EndDate" );
        }
      }
    }

    public String Reason
    {
      get
      {
        return Model.Reason != null ? Model.Reason : "Privat";
      }
      set
      {
        Model.Reason = value;
        this.OnPropertyChanged( "Reason" );
      }
    }

    public SailingSchoolWPF.Model.Course Course
    {
      get
      {
        return Model.Course;
      }
      set
      {
        if ( Course != value )
        {
          Model.Course = value;
          this.OnPropertyChanged( "Course" );
        }
      }
    }
    #endregion
  }
}
