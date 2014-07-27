using SailingSchoolWPF.ViewModel.InstructorViewModel;
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

namespace SailingSchoolWPF.Pages.Instructor.Update
{
    /// <summary>
    /// Interaction logic for CreateNewStudent.xaml
    /// </summary>
    public partial class Bankdata : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bankdata"/> class.
        /// </summary>
        public Bankdata()
        {
            InitializeComponent();
            var viewModel = UpdateInstructorViewModel.Instance;
            this.DataContext = viewModel;
        }
    }
}
