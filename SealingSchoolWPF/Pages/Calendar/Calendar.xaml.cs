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
        /// <summary>
        /// Initializes a new instance of the <see cref="Calendar"/> class.
        /// </summary>
        public Calendar()
        {
            InitializeComponent();
            var viewModel = new CalendarViewModel();
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the IsVisibleChanged event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.DataContext = null;
            var viewModel = new CalendarViewModel();
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the ShowDialog event of the radScheduleView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Windows.Controls.ShowDialogEventArgs"/> instance containing the event data.</param>
        private void radScheduleView_ShowDialog(object sender, Telerik.Windows.Controls.ShowDialogEventArgs e)
        {
            //if ( e.DialogViewModel is AppointmentDialogViewModel )
            e.Cancel = true;
        }
    }
}
