using FirstFloor.ModernUI.Windows.Controls;
using SealingSchoolWPF.ViewModel.BoatAdministrationViewModel;
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

namespace SealingSchoolWPF.Pages.BoatAdministration.Administration
{
    /// <summary>
    /// Interaction logic for AdministrateBoat.xaml
    /// </summary>
    public partial class AdministrateBoat : ModernWindow
    {
        UpdateBoatAdministrationViewModel viewModel;

        public AdministrateBoat(SealingSchoolWPF.ViewModel.BoatAdministrationViewModel.BoatAdministrationViewModel boat)
        {
            InitializeComponent();
            viewModel = new UpdateBoatAdministrationViewModel(GetBoatDataFromModel(boat));
            this.DataContext = viewModel;
        }


        private Model.Boat GetBoatDataFromModel(BoatAdministrationViewModel newBoat)
        {

            Model.Boat boat = new Model.Boat();
            boat.BoatID = Convert.ToInt32(newBoat.Id);
            boat.MaterialStatus = newBoat.MaterialStatus;
            boat.Name = newBoat.Name;
            boat.Price = newBoat.Price;
            boat.Brand = newBoat.Brand;
            boat.Currency = newBoat.Currency;
            boat.RepairAction = newBoat.RepairAction;
            boat.SerialNumber = newBoat.SerialNumber;
            boat.BoatTyp = newBoat.BoatTyp;
            return boat;
        }
        private void ModernWindow_Closed(object sender, EventArgs e)
        {
            viewModel.Close();
        }
    }
}
