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
    public partial class Notes : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notes"/> class.
        /// </summary>
        public Notes()
        {
            InitializeComponent();
            var viewModel = UpdateMaterialAdministrationViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
