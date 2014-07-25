using FirstFloor.ModernUI.Windows.Controls;
using SealingSchoolWPF.ViewModel.Material;
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

namespace SealingSchoolWPF.Pages.Material.Create
{
    /// <summary>
    /// Interaction logic for CreateMaterial.xaml
    /// </summary>
    public partial class CreateMaterial : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        CreateMaterialViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMaterial"/> class.
        /// </summary>
        public CreateMaterial()
        {
            InitializeComponent();
            viewModel = new CreateMaterialViewModel(new SealingSchoolWPF.Model.Material());
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Closed event of the ModernWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Closed(object sender, EventArgs e)
        {
            viewModel.Close();
        }
    }
}
