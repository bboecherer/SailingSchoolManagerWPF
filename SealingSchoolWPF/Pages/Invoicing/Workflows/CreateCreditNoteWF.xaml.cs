using FirstFloor.ModernUI.Windows.Controls;
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

namespace SealingSchoolWPF.Pages.Invoicing.Workflows
{
    /// <summary>
    /// Interaction logic for CreateTrainingActivitiesWF.xaml
    /// </summary>
    public partial class CreateCreditNoteWF : ModernWindow
    {

        /// <summary>
        /// The view model
        /// </summary>
        CreateCreditNoteViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCreditNoteWF"/> class.
        /// </summary>
        public CreateCreditNoteWF()
        {
            InitializeComponent();
            viewModel = CreateCreditNoteViewModel.Instance;
            viewModel.Close();
            viewModel = CreateCreditNoteViewModel.Instance;
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the 1 event of the ModernWindow_Closing control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }
    }
}