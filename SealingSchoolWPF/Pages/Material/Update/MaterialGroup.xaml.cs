using SealingSchoolWPF.ViewModel.BusinessUnit;
using SealingSchoolWPF.ViewModel.Material;
using System.Windows;
using System.Windows.Controls;

namespace SealingSchoolWPF.Pages.Material.Update
{
  /// <summary>
  /// Interaction logic for CreateNewStudent.xaml
  /// </summary>
  public partial class MaterialGroup : UserControl
  {
      public MaterialGroup()
    {
      InitializeComponent();
      var viewModel =UpdateMaterialViewModel.Instance;
      this.DataContext = viewModel;
    }

    private void Buttontest_Click( object sender, RoutedEventArgs e )
    {
      var viewModel = UpdateMaterialViewModel.Instance;
      var obj = ( (FrameworkElement) sender ).DataContext as BoatTypViewModel;
      viewModel.ExecuteDeleteCommand( obj );
    }
  }
}
