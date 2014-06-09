using SealingSchoolWPF.ViewModel.BusinessUnit;
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

namespace SealingSchoolWPF.Pages.BusinessUnit
{
    /// <summary>
    /// Interaction logic for Qualification.xaml
    /// </summary>
    public partial class BoatTyp : UserControl
    {
        public BoatTyp()
        {
            InitializeComponent();
            var viewModel = BoatTypListViewModel.Instance;
            this.DataContext = viewModel;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = BoatTypListViewModel.Instance;
            var obj = ((FrameworkElement)sender).DataContext as BoatTypViewModel;

            viewModel.ExecuteDeleteCommand(obj.Id);
        }
    }
}
