using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Jarloo.Calendar;

namespace SealingSchoolWPF.Pages
{
  /// <summary>
  /// Interaction logic for Calendar.xaml
  /// </summary>
  public partial class Calendar : UserControl
  {
    public Calendar()
    {
      InitializeComponent(); List<string> months = new List<string> { "Januar", "Februar", "März", "April", "mai", "Juni", 
        "Juli", "August", "September", "Oktober", "November", "Dezember" };
      cboMonth.ItemsSource = months;

      for ( int i = -50; i < 50; i++ )
      {
        cboYear.Items.Add( DateTime.Today.AddYears( i ).Year );
      }

      cboMonth.SelectedItem = months.FirstOrDefault( w => w == DateTime.Today.ToString( "MMMM" ) );
      cboYear.SelectedItem = DateTime.Today.Year;

      cboMonth.SelectionChanged += ( o, e ) => RefreshCalendar();
      cboYear.SelectionChanged += ( o, e ) => RefreshCalendar();
    }

    private void RefreshCalendar()
    {
      if ( cboYear.SelectedItem == null ) return;
      if ( cboMonth.SelectedItem == null ) return;

      int year = (int) cboYear.SelectedItem;

      int month = cboMonth.SelectedIndex + 1;

      DateTime targetDate = new DateTime( year, month, 1 );

      CalendarView.BuildCalendar( targetDate );
    }

    private void Calendar_DayChanged( object sender, DayChangedEventArgs e )
    {
      //save the text edits to persistant storage
    }
  }
}
