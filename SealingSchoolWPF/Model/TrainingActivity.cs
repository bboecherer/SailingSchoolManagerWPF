using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
  public class TrainingActivity : SealingSchoolObject
  {

    [Key]
    public virtual int TrainingActivityId { get; set; }
    public virtual Decimal GrossPriceOrg { get; set; }
    public virtual Decimal NetPriceOrg { get; set; }
    public virtual Decimal VatAmountOrg { get; set; }
    public virtual DateTime? RegDateTime { get; set; }
    public virtual DateTime? CancelDateTime { get; set; }
    public virtual DateTime? StartDateTime { get; set; }
    public virtual TrainingActivityStatus TrainingActivityStatus { get; set; }
    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }

    public override string ToString()
    {
      return Label;
    }

    public override bool Equals( object obj )
    {
      TrainingActivity ta;
      try
      {
        ta = (TrainingActivity) obj;
      }
      catch ( Exception )
      {
        return false;
      }

      if ( TrainingActivityId != ta.TrainingActivityId )
      {
        return false;
      }

      return true;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode() ^ this.TrainingActivityId;
    }
  }
}
