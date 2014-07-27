using SailingSchoolWPF.Pages.Boat.Create;
using SailingSchoolWPF.ViewModel.Boat;
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

namespace SailingSchoolWPF.Pages.Boat.General
{
    /// <summary>
    /// Interaction logic for MaterialView.xaml
    /// </summary>
    public partial class BoatView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoatView"/> class.
        /// </summary>
        public BoatView()
        {
            InitializeComponent();
            var viewModel = new BoatListViewModel();
            boatList.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindDataContext();
        }

        /// <summary>
        /// Handles the 1 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateBoat window = new CreateBoat();
            window.ShowDialog();
        }
        /// <summary>
        /// Binds the data context.
        /// </summary>
        private void BindDataContext()
        {
            var viewModel = new BoatListViewModel();
            boatList.DataContext = null;
            boatList.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the IsVisibleChanged event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            BindDataContext();
        }

        /// <summary>
        /// Handles the MouseEnter event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            BindDataContext();
        }
    }
}
