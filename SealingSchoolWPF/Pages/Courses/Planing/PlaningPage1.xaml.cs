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
using SealingSchoolWPF.ViewModel.Course;

namespace SealingSchoolWPF.Pages.Course.Planing
{
    /// <summary>
    /// Interaction logic for CreateNewStudent.xaml
    /// </summary>
    public partial class PlaningPage1 : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaningPage1"/> class.
        /// </summary>
        public PlaningPage1()
        {
            InitializeComponent();
            var viewModel = UpdateCoursePlaningViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
