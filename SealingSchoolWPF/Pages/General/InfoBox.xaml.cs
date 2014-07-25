using SealingSchoolWPF.ViewModel.General;
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

namespace SealingSchoolWPF.Pages.General
{
    /// <summary>
    /// Interaction logic for InfoBox.xaml
    /// </summary>
    public partial class InfoBox : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoBox"/> class.
        /// </summary>
        public InfoBox()
        {
            InitializeComponent();
            var viewModel = new InfoBoxViewModel();
            this.DataContext = viewModel;
        }
    }
}
