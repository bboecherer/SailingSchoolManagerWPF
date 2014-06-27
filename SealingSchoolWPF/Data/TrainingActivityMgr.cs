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
  public class TrainingActivityMgr
  {

    public void Delete( TrainingActivity entity )
    {

    }

    public void Create( TrainingActivity entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        try
        {
          ctx.Courses.Attach( entity.Course );
          ctx.Entry( entity.Course ).State = EntityState.Unchanged;

          Student stud = ctx.Students.Find( entity.Student.StudentId );
          entity.Label = stud.Label + " / " + entity.Course.Label;
          entity.Student = stud;
          ctx.Students.Attach( stud );
          ctx.Entry( stud ).State = EntityState.Unchanged;

          CoursePlaning plan = ctx.CoursePlanings.Find( entity.CoursePlaning.CoursePlaningId );
          entity.CoursePlaning = plan;
          ctx.CoursePlanings.Attach( plan );
          ctx.Entry( plan ).State = EntityState.Unchanged;

          ctx.TrainingActivities.Add( entity );
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

    public void Update( TrainingActivity entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {

        TrainingActivity original = ctx.TrainingActivities.Find( entity.TrainingActivityId );

        if ( original != null )
        {
          ctx.Entry( original ).CurrentValues.SetValues( entity );
          ctx.SaveChanges();
        }
      }
    }


    public IList<TrainingActivity> GetAll()
    {
      IList<TrainingActivity> tas = new List<TrainingActivity>();

      using ( var ctx = new SchoolDataContext() )
      {
        foreach ( TrainingActivity ta in ctx.TrainingActivities )
        {
          ctx.Courses.Attach( ta.Course );
          ctx.Entry( ta.Course ).State = EntityState.Unchanged;
          ctx.Students.Attach( ta.Student );
          ctx.Entry( ta.Student ).State = EntityState.Unchanged;
          ctx.CoursePlanings.Attach( ta.CoursePlaning );
          ctx.Entry( ta.CoursePlaning ).State = EntityState.Unchanged;

          tas.Add( ta );
        }
      }
      return tas;

    }

    public IList<TrainingActivity> GetByStatus( TrainingActivityStatus status )
    {
      IList<TrainingActivity> tas = new List<TrainingActivity>();

      using ( var ctx = new SchoolDataContext() )
      {
        foreach ( TrainingActivity ta in ctx.TrainingActivities.Where( t => t.TrainingActivityStatus == status ) )
        {
          ctx.Courses.Attach( ta.Course );
          ctx.Entry( ta.Course ).State = EntityState.Unchanged;
          ctx.Students.Attach( ta.Student );
          ctx.Entry( ta.Student ).State = EntityState.Unchanged;
          ctx.CoursePlanings.Attach( ta.CoursePlaning );
          ctx.Entry( ta.CoursePlaning ).State = EntityState.Unchanged;

          tas.Add( ta );
        }
      }
      return tas;
    }

    public TrainingActivity GetById( int taId )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        TrainingActivity ta = ctx.TrainingActivities.Find( taId );
        ctx.Courses.Attach( ta.Course );
        ctx.Students.Attach( ta.Student );
        ctx.Adresses.Attach( ta.Student.Adress );

        return ta;
      }
    }

    public List<TrainingActivity> GetByCoursePlaning( int p )
    {
      List<TrainingActivity> tas = new List<TrainingActivity>();
      using ( var ctx = new SchoolDataContext() )
      {
        foreach ( TrainingActivity ta in ctx.TrainingActivities.Where( t => t.CoursePlaning.CoursePlaningId == p ) )
        {
          tas.Add( ta );
        }
      }
      return tas;
    }
  }
}