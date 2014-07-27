using FirstFloor.ModernUI.Windows.Controls;
using SailingSchoolWPF.ViewModel.StudentViewModel;
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

namespace SailingSchoolWPF.Pages.Student.Create
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class CreateStudent : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        CreateStudentViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStudent"/> class.
        /// </summary>
        public CreateStudent()
        {

            InitializeComponent();
            viewModel = new CreateStudentViewModel(new SailingSchoolWPF.Model.Student());
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the Closing event of the ModernWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }
    }
}
