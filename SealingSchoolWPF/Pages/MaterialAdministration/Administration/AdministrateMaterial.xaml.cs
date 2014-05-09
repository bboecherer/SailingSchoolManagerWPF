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
        UpdateMaterialAdministrationViewModel viewModel;

        public AdministrateMaterial(SealingSchoolWPF.ViewModel.MaterialAdministrationViewModel.MaterialAdministrationViewModel material)
        {
            InitializeComponent();
            viewModel = new UpdateMaterialAdministrationViewModel(GetMaterialDataFromModel(material));
            this.DataContext = viewModel;
        }


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
            mat.MaterialType = material.MaterialType;
            return mat;
        }
        private void ModernWindow_Closed(object sender, EventArgs e)
        {
            viewModel.Close();
        }
    }
}
