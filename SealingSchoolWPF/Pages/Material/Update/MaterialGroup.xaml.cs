using SailingSchoolWPF.ViewModel.BusinessUnit;
using SailingSchoolWPF.ViewModel.Material;
using System.Windows;
using System.Windows.Controls;

namespace SailingSchoolWPF.Pages.Material.Update
{
    /// <summary>
    /// Interaction logic for CreateNewStudent.xaml
    /// </summary>
    public partial class MaterialGroup : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialGroup"/> class.
        /// </summary>
        public MaterialGroup()
        {
            InitializeComponent();
            var viewModel = UpdateMaterialViewModel.Instance;
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Click event of the Buttontest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Buttontest_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = UpdateMaterialViewModel.Instance;
            var obj = ((FrameworkElement)sender).DataContext as BoatTypViewModel;
            viewModel.ExecuteDeleteCommand(obj);
        }
    }
}
