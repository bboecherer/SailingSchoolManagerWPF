using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class Boat : SealingSchoolObject
    {
        [Key]
        public int BoatId { get; set; }
        public Material Material { get; set; }
        public int Crew { get; set; }

        public virtual ICollection<Material> NeededMaterials { get; set; }
    }
}
