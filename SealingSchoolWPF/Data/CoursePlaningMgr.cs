using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
  public class CoursePlaningMgr : IPersistenceMgr<CoursePlaning>
  {
    public IList<CoursePlaning> Courses { get; set; }

    public IList<CoursePlaning> GetAll()
    {
      Courses = new List<CoursePlaning>();

      using ( var ctx = new SchoolDataContext() )
      {
        foreach ( CoursePlaning c in ctx.CoursePlanings )
        {
          if ( c.Instructors != null )
          {
            foreach ( Instructor q in c.Instructors )
              ctx.Instructors.Attach( q );
          }

          if ( c.Course != null )
          {
            ctx.Courses.Attach( c.Course );
          }

          Courses.Add( c );
        }
      }
      return Courses;
    }

    public void Delete( CoursePlaning entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        ctx.CoursePlanings.Remove( entity );
        ctx.SaveChanges();
      }
    }

    public void Create( CoursePlaning entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        try
        {
          Course c = ctx.Courses.Find( entity.Course.CourseId );
          ctx.Courses.Attach( c );
          ctx.Entry( c ).State = EntityState.Unchanged;
          entity.Course = c;
          entity.Label = c.Label;

          List<Instructor> qualies = new List<Instructor>();

          if ( entity.Instructors != null )
          {
            foreach ( Instructor q in entity.Instructors )
            {
              Instructor dummy = ctx.Instructors.Find( q.InstructorId );
              ctx.Instructors.Attach( dummy );
              ctx.Entry( dummy ).State = EntityState.Unchanged;
              qualies.Add( dummy );
            }

            entity.Instructors.Clear();
            entity.Instructors = qualies;
          }
          ctx.CoursePlanings.Add( entity );

          foreach ( Instructor instr in entity.Instructors )
          {
            BlockedTimeSpan blocked = new BlockedTimeSpan();
            blocked.Course = entity.Course;
            blocked.StartDate = (DateTime) entity.StartDate;
            blocked.EndDate = (DateTime) entity.EndDate;
            blocked.Instructor = instr;

            if ( entity.Course != null )
            {
              blocked.Reason = string.Format( "Kurs {0}", entity.Course.Label );
            }
            else
            {
              blocked.Reason = "Privat";
            }


            ctx.BlockedTimeSpans.Add( blocked );
          }

          ctx.SaveChanges();
        }
        catch ( DbEntityValidationException ex )
        {
          List<string> errorMessages = new List<string>();
          foreach ( DbEntityValidationResult validationResult in ex.EntityValidationErrors )
          {
            string entityName = validationResult.Entry.Entity.GetType().Name;
            foreach ( DbValidationError error in validationResult.ValidationErrors )
            {
              errorMessages.Add( entityName + "." + error.PropertyName + ": " + error.ErrorMessage );
            }
          }
        }
        catch ( Exception ) { }
      }
    }

    public void Update( CoursePlaning entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        CoursePlaning original = ctx.CoursePlanings.Find( entity.CoursePlaningId );
        entity.Label = entity.Course.Label;
        if ( original != null )
        {
          ctx.Entry( original ).CurrentValues.SetValues( entity );
          ctx.SaveChanges();
        }
      }
    }

    public CoursePlaning GetById( int id )
    {
      CoursePlaning course;
      using ( var ctx = new SchoolDataContext() )
      {
        course = (CoursePlaning) ctx.CoursePlanings.Where( c => c.CoursePlaningId == id );
      }
      return course;
    }

    public IEnumerable<CoursePlaning> GetAll( CourseStatus courseStatus )
    {
      var courseList = new List<CoursePlaning>();

      using ( var ctx = new SchoolDataContext() )
      {
        var dummy = this.GetAll();


        foreach ( CoursePlaning c in dummy )
        {
          if ( c.CourseStatus == courseStatus )
          {
            courseList.Add( c );
          }
        }
      }
      return courseList;
    }

    public IEnumerable<CoursePlaning> GetAll( CourseStatus courseStatus, DateTime? startDate, DateTime? endDate )
    {
      var courseList = new List<CoursePlaning>();

      using ( var ctx = new SchoolDataContext() )
      {
        var dummy = this.GetAll();

        foreach ( CoursePlaning c in dummy )
        {
          if ( c.CourseStatus == courseStatus )
          {
            // TODO: Zeitraum eingrenzen
            if ( c.StartDate >= startDate && c.EndDate <= endDate )
            {
              courseList.Add( c );
            }
          }
        }
      }
      return courseList;
    }

    public IEnumerable<CoursePlaning> GetInstructorReference( int instructorId )
    {
      var courseList = new List<CoursePlaning>();

      using ( var ctx = new SchoolDataContext() )
      {
        var dummy = this.GetAll();

        foreach ( CoursePlaning c in dummy )
        {
          if ( c.CourseStatus == CourseStatus.BEENDET )
          {
            foreach ( Instructor i in c.Instructors )
            {
              if ( i.InstructorId == instructorId )
              {
                courseList.Add( c );
              }
            }
          }
        }
      }
      return courseList;
    }

    internal IEnumerable<CoursePlaning> GetByStatus( CourseStatus courseStatus )
    {
      var courseList = new List<CoursePlaning>();

      using ( var ctx = new SchoolDataContext() )
      {
        var dummy = this.GetAll();

        foreach ( CoursePlaning c in dummy )
        {
          if ( c.CourseStatus == CourseStatus.BEENDET )
          {
            courseList.Add( c );
          }
        }
      }
      return courseList;
    }
  }
}