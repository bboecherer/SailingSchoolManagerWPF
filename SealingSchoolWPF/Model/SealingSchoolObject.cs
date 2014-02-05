using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public abstract class SealingSchoolObject
    {
        public String Label { get; set; }
        public String AdditionalInfo { get; set; }
        public String CustomField1 { get; set; }
        public String CustomField2 { get; set; }
        public String CustomField3 { get; set; }
        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}