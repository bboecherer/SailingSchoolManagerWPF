using SailingSchoolWPF.Data;
using SailingSchoolWPF.Pages.Instructor.Create;
using SailingSchoolWPF.Pages.Student.Create;
using SailingSchoolWPF.ViewModel.InstructorViewModel;
using SailingSchoolWPF.ViewModel.StudentViewModel;
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

namespace SailingSchoolWPF.Pages.Instructor.Controls
{
    /// <summary>
    /// Interaction logic for ButtonsToWork.xaml
    /// </summary>
    public partial class CreateButtons : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateButtons"/> class.
        /// </summary>
        public CreateButtons()
        {
            InitializeComponent();
            var viewModel = CreateInstructorViewModel.Instance;
            this.DataContext = viewModel;
        }

    }
}
