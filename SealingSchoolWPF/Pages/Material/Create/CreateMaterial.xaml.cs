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
        CreateMaterialViewModel viewModel;

        public CreateMaterial()
        {
            InitializeComponent();
            viewModel = new CreateMaterialViewModel(new SealingSchoolWPF.Model.Material());
            this.DataContext = viewModel;
        }

        private void ModernWindow_Closed(object sender, EventArgs e)
        {
            viewModel.Close();
        }
    }
}
