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
    #endregion

    #region helpers
    private ObservableCollection<Telerik.Windows.Controls.ScheduleView.Appointment> GetAppointments()
    {
      var appointments = new ObservableCollection<Appointment>();

      foreach ( SealingSchoolWPF.Model.CoursePlaning c in coursePlaningMgr.GetAll() )
      {
        if ( c.StartDate != null && c.EndDate != null
          && c.CourseStatus != CourseStatus.BEENDET && c.CourseStatus != CourseStatus.ABGEBROCHEN )
        {
          Appointment a = new Appointment();
          a.Subject = c.Label + "\n" + GetInstructors( c.Instructors );
          a.Start = (DateTime) c.StartDate;
          a.End = (DateTime) c.EndDate;
          a.Body = c.CourseStatus.ToString() + "\n" + GetInstructors( c.Instructors );
          a.TimeMarker = GetTimeMarker( c.CourseStatus );
          appointments.Add( a );
        }
      }

      foreach ( SealingSchoolWPF.Model.BlockedTimeSpan b in blockTimesMgr.GetAll() )
      {
        if ( b.Reason == null )
        {
          Appointment a = new Appointment();
          a.Subject = b.Instructor.Label + "\n" + "Nicht verfügbar";
          a.Start = b.StartDate;
          a.End = b.EndDate;
          a.TimeMarker = TimeMarker.OutOfOffice;
          appointments.Add( a );

        }
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
      return TimeMarker.Busy;
    }
    #endregion
  }
}
