using SailingSchoolWPF.ViewModel.MaterialAdministrationViewModel;
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

namespace SailingSchoolWPF.Pages.MaterialAdministration.General
{
    /// <summary>
    /// Interaction logic for MaterialView.xaml
    /// </summary>
    public partial class MaterialAdministrationView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialAdministrationView"/> class.
        /// </summary>
        public MaterialAdministrationView()
        {
            InitializeComponent();
            var viewModel = new MaterialAdministrationListViewModel();
            materialAdministrationList.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new MaterialAdministrationListViewModel();
            materialAdministrationList.DataContext = null;
            materialAdministrationList.DataContext = viewModel;
        }


    }
}
