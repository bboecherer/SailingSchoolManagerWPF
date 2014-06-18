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
    /// Interaction logic for UpdateMaterial.xaml
    /// </summary>
    public partial class Documents : UserControl
    {
        public Documents()
        {
            InitializeComponent();
            var viewModel = UpdateBoatAdministrationViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
