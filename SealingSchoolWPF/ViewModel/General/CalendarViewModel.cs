using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;
using SealingSchoolWPF.Model;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace SealingSchoolWPF.ViewModel.General
{
  public class CalendarViewModel : ViewModel
  {
    #region properties

    public System.Windows.Media.SolidColorBrush BackgroundColor
    {
      get
      {
        return new SolidColorBrush( AppearanceManager.Current.AccentColor );
      }
      set
      {
        BackgroundColor = value;
      }
    }


    public ObservableCollection<Appointment> Appointments
    {
      get
      {
        return GetAppointments();
      }
      set
      {
        Appointments = value;
      }
    }

    private ObservableCollection<Telerik.Windows.Controls.ScheduleView.Appointment> GetAppointments()
    {
      var appointments = new ObservableCollection<Appointment>();

      foreach ( SealingSchoolWPF.Model.CoursePlaning c in coursePlaningMgr.GetAll() )
      {

        appointments.Add( new Appointment()
        {
          Subject = c.Label,
          Start = (DateTime) c.StartDate,
          End = (DateTime) c.EndDate,
          Body = c.CourseStatus.ToString() + "\n" + GetInstructors( c.Instructors ),
          TimeMarker = GetTimeMarker( c.CourseStatus )
        } );
      }
      return appointments;
    }

    private string GetInstructors( ICollection<Model.Instructor> collection )
    {
      StringBuilder builder = new StringBuilder();
      foreach ( Model.Instructor inst in collection )
      {
        builder.Append( inst.Label ).Append( "\n" );
      }
      return builder.ToString();
    }

    private ITimeMarker GetTimeMarker( CourseStatus status )
    {
      if ( status == CourseStatus.PLANUNG )
      {
        return TimeMarker.Tentative;
      }
      if ( status == CourseStatus.BEENDET )
      {
        return TimeMarker.Free;
      }
      if ( status == CourseStatus.ABGEBROCHEN )
      {
        return TimeMarker.Free;
      }

      return TimeMarker.Busy;
    }
    #endregion
  }
}
