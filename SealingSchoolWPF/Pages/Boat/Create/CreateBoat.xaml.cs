using FirstFloor.ModernUI.Windows.Controls;
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

namespace SealingSchoolWPF.Pages.Boat.Create
{
    /// <summary>
    /// Interaction logic for CreateMaterial.xaml
    /// </summary>
    public partial class CreateBoat : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        CreateBoatViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBoat"/> class.
        /// </summary>
        public CreateBoat()
        {
            InitializeComponent();
            viewModel = new CreateBoatViewModel(new SealingSchoolWPF.Model.Boat());
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
