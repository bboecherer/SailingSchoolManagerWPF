﻿using SealingSchoolWPF.Model;
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

    }


    public IList<TrainingActivity> GetAll()
    {
      IList<TrainingActivity> tas = new List<TrainingActivity>();

      using ( var ctx = new SchoolDataContext() )
      {
        foreach ( TrainingActivity ta in ctx.TrainingActivities )
        {
          tas.Add( ta );
        }
      }
      return tas;

    }
  }
}