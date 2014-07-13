using SealingSchoolWPF.Pages.Invoicing.Workflows;
using SealingSchoolWPF.ViewModel.Invoicing;
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
    /// Interaction logic for CreditNotes.xaml
    /// </summary>
    public partial class CreditNotes : UserControl
    {
        public CreditNotes()
        {
            InitializeComponent();
            BindViewModel();
        }

        public void BindViewModel()
        {
            this.DataContext = null;
            var viewModel = CreateCreditNoteViewModel.Instance;
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateCreditNoteWF window = new CreateCreditNoteWF();
            window.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BindViewModel();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            BindViewModel();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            BindViewModel();
        }
    }
}