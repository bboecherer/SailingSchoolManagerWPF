using FirstFloor.ModernUI.Windows.Controls;
using SailingSchoolWPF.ViewModel.Material;
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

namespace SailingSchoolWPF.Pages.Material.Update
{
    /// <summary>
    /// Interaction logic for UpdateMaterial.xaml
    /// </summary>
    public partial class UpdateMaterial : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        UpdateMaterialViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMaterial"/> class.
        /// </summary>
        /// <param name="material">The material.</param>
        public UpdateMaterial(MaterialViewModel material)
        {
            InitializeComponent();
            viewModel = new UpdateMaterialViewModel(GetMaterialDataFromModel(material));
            this.DataContext = viewModel;
        }


        /// <summary>
        /// Gets the material data from model.
        /// </summary>
        /// <param name="material">The material.</param>
        /// <returns></returns>
        private Model.Material GetMaterialDataFromModel(MaterialViewModel material)
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
            mat.BoatTyps = material.BoatTyps;
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
