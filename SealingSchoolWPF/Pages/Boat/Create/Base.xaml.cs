using SailingSchoolWPF.ViewModel.Boat;
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

namespace SailingSchoolWPF.Pages.Boat.Create
{
    /// <summary>
    /// Interaction logic for CreateNewMaterial.xaml
    /// </summary>
    public partial class Base : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Base"/> class.
        /// </summary>
        public Base()
        {
            InitializeComponent();
            var viewModel = CreateBoatViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
