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
using SealingSchoolWPF.ViewModel.InstructorViewModel;

namespace SealingSchoolWPF.Pages.Instructor.Update
{
  /// <summary>
  /// Interaction logic for Rating.xaml
  /// </summary>
  public partial class Rating : UserControl
  {
    public Rating()
    {
      InitializeComponent();
      var viewModel = UpdateInstructorViewModel.Instance;
      this.DataContext = viewModel;
    }
  }
}
