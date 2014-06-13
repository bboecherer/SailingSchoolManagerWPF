using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Adress
    {
        [Key]
        public virtual int AdressId { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string AddressLine3 { get; set; }
        public virtual string Street { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual string State { get; set; }

    }
}
