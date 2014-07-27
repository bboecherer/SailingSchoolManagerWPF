using FirstFloor.ModernUI.Windows.Controls;
using SailingSchoolWPF.ViewModel.InstructorViewModel;
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

namespace SailingSchoolWPF.Pages.Instructor.Create
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class CreateInstructor : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        CreateInstructorViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInstructor"/> class.
        /// </summary>
        public CreateInstructor()
        {
            InitializeComponent();
            viewModel = new CreateInstructorViewModel(new SailingSchoolWPF.Model.Instructor());
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
