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

namespace SealingSchoolWPF.Pages.Boat.Update
{
    /// <summary>
    /// Interaction logic for UpdateMaterial.xaml
    /// </summary>
    public partial class UpdateBoat : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        UpdateBoatViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBoat"/> class.
        /// </summary>
        /// <param name="material">The material.</param>
        public UpdateBoat(BoatViewModel material)
        {
            InitializeComponent();
            viewModel = new UpdateBoatViewModel(GetBoatDataFromModel(material));
            this.DataContext = viewModel;
        }


        /// <summary>
        /// Gets the boat data from model.
        /// </summary>
        /// <param name="boat">The boat.</param>
        /// <returns>Boat</returns>
        private Model.Boat GetBoatDataFromModel(BoatViewModel boat)
        {

            Model.Boat newBoat = new Model.Boat();
            newBoat.BoatID = Convert.ToInt32(boat.BoatID);
            newBoat.MaterialStatus = boat.MaterialStatus;
            newBoat.Name = boat.Name;
            newBoat.Price = boat.Price;

            return newBoat;
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
