﻿using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.ViewModel.General
{
    /// <summary>
    /// ViewModel for InfoBox
    /// @Author Benjamin Böcherer
    /// </summary>
    public class InfoBoxViewModel : ViewModel
    {
        InfoBoxMgr boxMgr = new InfoBoxMgr();

        public string Message
        {
            get
            {
                var dummy = boxMgr.GetAll();
                if (dummy != null && dummy.Count != 0)
                {
                    return dummy[0].Message;
                }
                else
                {
                    return "Kein Eintrag in der Datenbank hinterlegt";
                }

            }
        }
    }
}
