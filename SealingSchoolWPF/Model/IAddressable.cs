using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public interface IAddressable
    {
         string Label { get; set; }

         string AddressLine1 { get; set; }

         string AddressLine2 { get; set; }

         string AddressLine3 { get; set; }

         string ZipCode { get; set; }

         string City { get; set; }
         
        string Country { get; set; }

         string State { get; set; }
    }
}
