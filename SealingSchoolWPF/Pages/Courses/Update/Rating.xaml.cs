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
using SailingSchoolWPF.ViewModel.InstructorViewModel;

namespace SailingSchoolWPF.Pages.Courses.Update
{
    /// <summary>
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Rating : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rating"/> class.
        /// </summary>
        public Rating()
        {
            InitializeComponent();
            var viewModel = UpdateCourseViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
