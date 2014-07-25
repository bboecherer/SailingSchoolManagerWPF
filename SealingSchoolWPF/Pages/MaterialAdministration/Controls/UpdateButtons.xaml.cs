using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.MaterialAdministration.Administration;
using SealingSchoolWPF.ViewModel.MaterialAdministrationViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace SealingSchoolWPF.Pages.MaterialAdministration.Controls
{
    /// <summary>
    /// Interaction logic for ButtonsToWork.xaml
    /// </summary>
    public partial class UpdateButtons : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateButtons"/> class.
        /// </summary>
        public UpdateButtons()
        {
            InitializeComponent();
            var viewModel = UpdateMaterialAdministrationViewModel.Instance;
            this.DataContext = viewModel;
        }

    }
}
