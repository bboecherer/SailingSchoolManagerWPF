using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SealingSchoolWPF.ViewModel.General;
using Telerik.Windows.Controls.ScheduleView;

namespace SealingSchoolWPF.Pages
{
  /// <summary>
  /// Interaction logic for Calendar.xaml
  /// </summary>
  public partial class Calendar : UserControl
  {
    public Calendar()
    {
      InitializeComponent();
      var viewModel = new CalendarViewModel();
      this.DataContext = viewModel;
    }

    private void UserControl_IsVisibleChanged( object sender, DependencyPropertyChangedEventArgs e )
    {
      this.DataContext = null;
      var viewModel = new CalendarViewModel();
      this.DataContext = viewModel;
    }

    private void radScheduleView_ShowDialog( object sender, Telerik.Windows.Controls.ShowDialogEventArgs e )
    {
      //if ( e.DialogViewModel is AppointmentDialogViewModel )
      e.Cancel = true;
    }
  }
}
