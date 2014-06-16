using SealingSchoolWPF.Pages.Boat.Create;
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

namespace SealingSchoolWPF.Pages.Boat.General
{
    /// <summary>
    /// Interaction logic for MaterialView.xaml
    /// </summary>
    public partial class BoatView : UserControl
    {
        public BoatView()
        {
            InitializeComponent();
            var viewModel = new BoatListViewModel();
            boatList.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new BoatListViewModel();
            boatList.DataContext = null;
            boatList.DataContext = viewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateBoat window = new CreateBoat();
            window.ShowDialog();
        }
    }
}
