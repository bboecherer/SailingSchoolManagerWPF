using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.Boat.Create;
using SealingSchoolWPF.ViewModel.Boat;
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

namespace SealingSchoolWPF.Pages.Boat.Controls
{
    /// <summary>
    /// Interaction logic for ButtonsToWork.xaml
    /// </summary>
    public partial class CreateButtons : UserControl
    {
        public CreateButtons()
        {
            InitializeComponent();
            var viewModel = CreateBoatViewModel.Instance;
            this.DataContext = viewModel;
        }

    }
}
