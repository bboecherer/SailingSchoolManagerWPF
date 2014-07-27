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
using SailingSchoolWPF.ViewModel.Course;

namespace SailingSchoolWPF.Pages.Courses.Workflows
{
    /// <summary>
    /// Interaction logic for CreateNewStudent.xaml
    /// </summary>
    public partial class CreatePlaningPage2 : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePlaningPage2"/> class.
        /// </summary>
        public CreatePlaningPage2()
        {
            InitializeComponent();
            var viewModel = CreateCoursePlaningViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
