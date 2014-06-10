using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class BoatTyp : SealingSchoolObject
    {
        [Key]
        public int BoatTypID { get; set; }
        public string Name { get; set; }
        public int CrewAmount { get; set; }
        public String Description { get; set; }

        public virtual ICollection<Material> Material { get; set; }


        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            try
            {
                BoatTyp boatTyp = (BoatTyp)obj;


                if (BoatTypID != boatTyp.BoatTypID)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.BoatTypID;
        }
    }
}
