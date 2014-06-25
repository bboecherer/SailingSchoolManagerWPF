using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;
using SealingSchoolWPF.Model;

namespace SealingSchoolWPF.ViewModel.General
{
  public class LiveTilesViewModel : ViewModel
  {
    #region properties

    public int CourseCount
    {
      get
      {
        return courseMgr.GetAll().Count;
      }
    }

    public System.Windows.Media.SolidColorBrush BackgroundColor
    {
      get
      {
        return new SolidColorBrush( AppearanceManager.Current.AccentColor );
      }
      set
      {
        BackgroundColor = value;
      }
    }


    public int StudentCount
    {
      get
      {
        return studentMgr.GetAll().Count;
      }
    }

    public int InstructorCount
    {
      get
      {
        return instructorMgr.GetAll().Count;
      }
    }

    public int InvoiceCount
    {
      get
      {
        return invoiceMgr.GetByStatus(PaymentStatus.NICHT_GEZAHLT).Count;
      }
    }

    public int CreditNoteCount
    {
      get
      {
        return 0;
      }
    }

    public int TaCount
    {
      get
      {
        return trainingActivityMgr.GetAll().Count;
      }
    }
    #endregion
  }
}
