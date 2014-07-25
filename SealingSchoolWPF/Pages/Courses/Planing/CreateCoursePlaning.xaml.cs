using FirstFloor.ModernUI.Windows.Controls;
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

namespace SealingSchoolWPF.Pages.Courses.Planing
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class CreateCoursePlaning : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        CreateCoursePlaningViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCoursePlaning"/> class.
        /// </summary>
        public CreateCoursePlaning()
        {
            InitializeComponent();
            viewModel = new CreateCoursePlaningViewModel(new SealingSchoolWPF.Model.CoursePlaning());
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Closed event of the ModernWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Closed(object sender, EventArgs e)
        {
            viewModel.Close();
        }
    }
}
