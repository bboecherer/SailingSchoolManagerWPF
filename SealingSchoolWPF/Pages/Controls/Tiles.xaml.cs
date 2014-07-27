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
using SailingSchoolWPF.ViewModel.General;

namespace SailingSchoolWPF.Pages.Controls
{
    /// <summary>
    /// Interaction logic for Tiles.xaml
    /// </summary>
    public partial class Tiles : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tiles"/> class.
        /// </summary>
        public Tiles()
        {
            InitializeComponent();
            var viewModel = new LiveTilesViewModel();
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
            var viewModel = new LiveTilesViewModel();
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Click event of the Tile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            //Courses
        }

        /// <summary>
        /// Handles the 1 event of the Tile_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            //Invoices
        }

        /// <summary>
        /// Handles the 2 event of the Tile_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Tile_Click_2(object sender, RoutedEventArgs e)
        {
            //Students
        }

        /// <summary>
        /// Handles the 3 event of the Tile_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Tile_Click_3(object sender, RoutedEventArgs e)
        {
            //CreditNote
        }

        /// <summary>
        /// Handles the 4 event of the Tile_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Tile_Click_4(object sender, RoutedEventArgs e)
        {
            //Instructor
        }
    }
}
