using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.ViewModel.General
{
    public class InfoBoxViewModel : ViewModel
    {
        InfoBoxMgr boxMgr = new InfoBoxMgr();

        public string Message
        {
            get
            {
                var dummy = boxMgr.GetAll();
                return dummy[0].Message;
            }
        }
    }
}
