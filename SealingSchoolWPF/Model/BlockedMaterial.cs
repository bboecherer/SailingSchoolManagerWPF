using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
  public class BlockedMaterial
  {
    [Key]
    public virtual int BlockedMaterialId { get; set; }
    public virtual DateTime StartDate { get; set; }
    public virtual DateTime EndDate { get; set; }

    //public virtual CoursePlaning CoursePlaning { get; set; }

    public virtual Material Material { get; set; }

    


    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();

      builder.Append( "Von " + StartDate.ToShortDateString() + " bis " + this.EndDate.ToShortDateString() );

      if ( this.Material != null )
      {
        builder.Append( string.Format( ", Material {0}", this.Material.Label ) );
      }
      else
      {
        builder.Append( "" );

      }

      return builder.ToString();
    }

    public override bool Equals( object obj )
    {
        BlockedMaterial blocked;
      try
      {
          blocked = (BlockedMaterial)obj;
      }
      catch ( Exception )
      {
        return false;
      }

      if (BlockedMaterialId != blocked.BlockedMaterialId)
      {
        return false;
      }

      return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode() ^ this.BlockedMaterialId;
    }
  }
}
