using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
    public class MaterialTyp : SealingSchoolObject
    {
        [Key]
        public int Id { get; set; }
        public String Description { get; set; }
        public String Name { get; set; }
        public bool IsEnabled { get; set; }


        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            try
            {
                MaterialTyp materialTyp = (MaterialTyp)obj;


                if (this.Id != materialTyp.Id)
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
            return base.GetHashCode() ^ this.Id;
        }
    }
}
