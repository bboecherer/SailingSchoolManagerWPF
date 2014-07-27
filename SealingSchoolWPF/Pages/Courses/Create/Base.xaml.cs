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
using FirstFloor.ModernUI.Windows.Controls;
using SailingSchoolWPF.ViewModel.Course;

namespace SailingSchoolWPF.Pages.Courses.Create
{
    /// <summary>
    /// Interaction logic for CreateNewStudent.xaml
    /// </summary>
    public partial class Base : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Base"/> class.
        /// </summary>
        public Base()
        {
            InitializeComponent();
            var viewModel = CreateCourseViewModel.Instance;
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Wird bei einer Überschreibung in einer abgeleiteten Klasse stets aufgerufen, wenn <see cref="M:System.Windows.FrameworkElement.ApplyTemplate" /> von Anwendungscode oder internem Prozesscode aufgerufen wird.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var frame = (ModernFrame)GetTemplateChild("ContentFrame");

        }

    }
}
