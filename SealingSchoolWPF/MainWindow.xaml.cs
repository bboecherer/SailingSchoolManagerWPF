﻿using FirstFloor.ModernUI.Windows.Controls;
using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.Resources.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Configuration;

namespace SailingSchoolWPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : ModernWindow
  {
    public MainWindow()
    {
      string cultureInfo = ConfigurationManager.AppSettings[ "DefaultCulture" ];
      Resource.Culture = new System.Globalization.CultureInfo( cultureInfo );
      InitializeComponent();
      BusinessUnitMgr bu = new BusinessUnitMgr();
      bu.GetBu();
      Thread.Sleep( 2000 );
    }

  }
}
