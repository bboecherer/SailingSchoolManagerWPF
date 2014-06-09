using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
  public class QualificationMgr : IPersistenceMgr<Qualification>
  {
    public IList<Qualification> GetAll()
    {
      var Qual = new List<Qualification>();

      using ( var ctx = new SchoolDataContext() )
      {
        foreach ( Qualification q in ctx.Qualifications )
        {
          if ( q.Courses != null )
          {
            foreach ( Course c in q.Courses )
              ctx.Courses.Attach( c );
          }

          if ( q.Instructors != null )
          {
            foreach ( Instructor i in q.Instructors )
              ctx.Instructors.Attach( i );
          }

          if ( q.Students != null )
          {
            foreach ( Student s in q.Students )
              ctx.Students.Attach( s );
          }

          Qual.Add( q );
        }
      }
      return Qual;
    }

    public void Delete( Qualification entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        ctx.Qualifications.Attach( entity );
        ctx.Qualifications.Remove( entity );
        ctx.SaveChanges();
      }
    }

    public void Create( Qualification entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        try
        {
          ctx.Qualifications.Add( entity );
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
      }
    }

    public void Update( Qualification entity )
    {
      throw new NotImplementedException();
    }

    public Qualification GetById( int id )
    {
      Qualification quali;
      using ( var ctx = new SchoolDataContext() )
      {
        quali = ctx.Qualifications.Find( id );
      }
      return quali;
    }

    internal IList<Qualification> GetQualifications( string type, int id )
    {
      IList<Qualification> qualies = new List<Qualification>();
      var dummy = this.GetAll();


      using ( var ctx = new SchoolDataContext() )
      {
        if ( type == "Course" )
        {
          foreach ( Qualification q in dummy )
          {
            foreach ( Course c in q.Courses )
            {
              if ( c.CourseId == id )
              {
                qualies.Add( q );
              }
            }
          }

          //nur die Course-Qualies


        }

        if ( type == "Instructor" )
        {
          foreach ( Qualification q in dummy )
          {
            foreach ( Instructor i in q.Instructors )
            {
              if ( i.InstructorId == id )
              {
                qualies.Add( q );
              }
            }
          }
        }

        if ( type == "Student" )
        {
          foreach ( Qualification q in dummy )
          {
            foreach ( Student s in q.Students )
            {
              if ( s.StudentId == id )
              {
                qualies.Add( q );
              }
            }
          }
        }
      }
      return qualies;
    }
  }
}