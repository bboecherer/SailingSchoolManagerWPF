using SailingSchoolWPF.Pages.Courses.Create;
using SailingSchoolWPF.Pages.Invoicing.Workflows;
using SailingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Invoicing
{
    /// <summary>
    /// ViewModel for Invoice buttons
    /// @Author Benjamin Böcherer
    /// </summary>
  class InvoiceButtonViewModel : ViewModel
  {
    #region commands
    private ICommand addCommand;
    public ICommand AddCommand
    {
      get
      {
        if ( addCommand == null )
        {
          addCommand = new RelayCommand( p => ExecuteAddCommand() );
        }
        return addCommand;
      }
    }

    private void ExecuteAddCommand()
    {
      CreateInvoiceWF window = new CreateInvoiceWF();
      window.ShowDialog();
    }

    private ICommand addMultipleCommand;
    public ICommand AddMultipleCommand
    {
      get
      {
        if ( addMultipleCommand == null )
        {
          addMultipleCommand = new RelayCommand( p => ExecuteAddMultipleCommand() );
        }
        return addMultipleCommand;
      }
    }

    private void ExecuteAddMultipleCommand()
    {
      CreateMultipleInvoiceWF window = new CreateMultipleInvoiceWF();
      window.ShowDialog();
    }


    #endregion
  }
}
