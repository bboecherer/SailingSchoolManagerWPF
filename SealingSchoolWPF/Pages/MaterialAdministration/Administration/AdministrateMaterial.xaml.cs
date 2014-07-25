using FirstFloor.ModernUI.Windows.Controls;
using SealingSchoolWPF.ViewModel.MaterialAdministrationViewModel;
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

namespace SealingSchoolWPF.Pages.MaterialAdministration.Administration
{
    /// <summary>
    /// Interaction logic for UpdateMaterial.xaml
    /// </summary>
    public partial class AdministrateMaterial : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        UpdateMaterialAdministrationViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrateMaterial"/> class.
        /// </summary>
        /// <param name="material">The material.</param>
        public AdministrateMaterial(SealingSchoolWPF.ViewModel.MaterialAdministrationViewModel.MaterialAdministrationViewModel material)
        {
            InitializeComponent();
            viewModel = new UpdateMaterialAdministrationViewModel(GetMaterialDataFromModel(material));
            this.DataContext = viewModel;
        }


        /// <summary>
        /// Gets the material data from model.
        /// </summary>
        /// <param name="material">The material.</param>
        /// <returns></returns>
        private Model.Material GetMaterialDataFromModel(MaterialAdministrationViewModel material)
        {

            Model.Material mat = new Model.Material();
            mat.MaterialId = Convert.ToInt32(material.Id);
            mat.MaterialStatus = material.MaterialStatus;
            mat.Name = material.Name;
            mat.Price = material.Price;
            mat.Brand = material.Brand;
            mat.Currency = material.Currency;
            mat.RepairAction = material.RepairAction;
            mat.SerialNumber = material.SerialNumber;
            mat.MaterialTyp = material.MaterialTyp;
            return mat;
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
