using SealingSchoolWPF.ViewModel.BusinessUnit;
using SealingSchoolWPF.ViewModel.Material;
using System.Windows;
using System.Windows.Controls;

namespace SealingSchoolWPF.Pages.Material.Create
{
  /// <summary>
  /// Interaction logic for CreateNewStudent.xaml
  /// </summary>
  public partial class MaterialGroup : UserControl
  {
      public MaterialGroup()
    {
      InitializeComponent();
      var viewModel =CreateMaterialViewModel.Instance;
      this.DataContext = viewModel;
    }

    private void Buttontest_Click( object sender, RoutedEventArgs e )
    {
      var viewModel = CreateMaterialViewModel.Instance;
      var obj = ( (FrameworkElement) sender ).DataContext as BoatTypViewModel;
      viewModel.ExecuteDeleteCommand( obj );
    }
  }
}
