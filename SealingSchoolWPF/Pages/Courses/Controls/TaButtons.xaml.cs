using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.Courses.Create;
using SealingSchoolWPF.Pages.Student.Create;
using SealingSchoolWPF.ViewModel.Course;
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

namespace SealingSchoolWPF.Pages.Courses.Controls
{
    /// <summary>
    /// Interaction logic for ButtonsToWork.xaml
    /// </summary>
    public partial class TaButtons : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaButtons"/> class.
        /// </summary>
        public TaButtons()
        {
            this.InitializeComponent();
            var viewModel = new TaButtonViewModel();
            this.DataContext = viewModel;
        }


    }
}
