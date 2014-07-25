using SealingSchoolWPF.Pages.Boat.Update;
using SealingSchoolWPF.ViewModel.Boat;
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

namespace SealingSchoolWPF.Pages
{
    /// <summary>
    /// Interaction logic for MaterialListView.xaml
    /// </summary>
    public partial class BoatListView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoatListView"/> class.
        /// </summary>
        public BoatListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the DataGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            var boat = (BoatViewModel)grid.SelectedItem;

            if (boat != null)
            {
                UpdateBoat window = new UpdateBoat(boat);
                window.ShowDialog();
            }
        }
    }
}
