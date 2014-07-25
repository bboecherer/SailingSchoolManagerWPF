using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.Instructor.Create;
using SealingSchoolWPF.Pages.Student.Create;
using SealingSchoolWPF.ViewModel.StudentViewModel;
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
using SealingSchoolWPF.ViewModel.Course;

namespace SealingSchoolWPF.Pages.Courses.Controls
{
    /// <summary>
    /// Interaction logic for ButtonsToWork.xaml
    /// </summary>
    public partial class CreatePlaningButtons : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePlaningButtons"/> class.
        /// </summary>
        public CreatePlaningButtons()
        {
            InitializeComponent();
            var viewModel = CreateCoursePlaningViewModel.Instance;
            this.DataContext = viewModel;
        }

    }
}
