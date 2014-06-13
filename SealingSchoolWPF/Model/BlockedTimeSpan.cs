using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{
  public class BlockedTimeSpan
  {
    [Key]
    public virtual int BlockedTimeSpanId { get; set; }
    public virtual DateTime StartDate { get; set; }
    public virtual DateTime EndDate { get; set; }

    public virtual Course Course { get; set; }

    public virtual Instructor Instructor { get; set; }

    public virtual String Reason { get; set; }


    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();

      builder.Append( "Von " + StartDate.ToShortDateString() + " bis " + this.EndDate.ToShortDateString() );

      if ( this.Course != null )
      {
        builder.Append( string.Format( ", Kurs {0}", this.Course.Label ) );
      }
      else
      {
        builder.Append( ", privat" );

      }

      return builder.ToString();
    }

    public override bool Equals( object obj )
    {
      BlockedTimeSpan blocked;
      try
      {
        blocked = (BlockedTimeSpan) obj;
      }
      catch ( Exception )
      {
        return false;
      }

      if ( BlockedTimeSpanId != blocked.BlockedTimeSpanId )
      {
        return false;
      }

      return true;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode() ^ this.BlockedTimeSpanId;
    }
  }
}
