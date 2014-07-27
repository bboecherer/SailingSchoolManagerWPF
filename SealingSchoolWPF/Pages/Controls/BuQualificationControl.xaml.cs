using SailingSchoolWPF.ViewModel.BusinessUnit;
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

namespace SailingSchoolWPF.Pages.Controls
{
    /// <summary>
    /// Interaction logic for QualificationControl.xaml
    /// </summary>
    public partial class BuQualificationControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuQualificationControl"/> class.
        /// </summary>
        public BuQualificationControl()
        {
            InitializeComponent();
            var viewModel = QualificationViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
