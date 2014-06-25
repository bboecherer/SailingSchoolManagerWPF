using SealingSchoolWPF.Pages.Material.Update;
using SealingSchoolWPF.ViewModel.Material;
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

namespace SealingSchoolWPF.Pages
{
  /// <summary>
  /// Interaction logic for MaterialListView.xaml
  /// </summary>
  public partial class MaterialListView : UserControl
  {
    public MaterialListView()
    {
      InitializeComponent();
    }

    private void DataGrid_MouseDoubleClick( object sender, MouseButtonEventArgs e )
    {
      var grid = sender as DataGrid;
      var material = (MaterialViewModel) grid.SelectedItem;

      if ( material != null )
      {
        UpdateMaterial window = new UpdateMaterial( material );
        window.ShowDialog();
      }
    }
  }
}
