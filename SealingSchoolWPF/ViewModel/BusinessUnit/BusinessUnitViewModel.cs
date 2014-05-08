using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.ViewModel.BusinessUnit
{
    public class BusinessUnitViewModel : ViewModel<SealingSchoolWPF.Model.BusinessUnit>
    {
        public BusinessUnitViewModel(SealingSchoolWPF.Model.BusinessUnit model)
            : base(model)
        {
        }
    }
}