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
    public class CourseMgr : IPersistenceMgr<Course>
    {
        public IList<Course> Courses { get; set; }

        public IList<Course> GetAll()
        {
            Courses = new List<Course>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Course c in ctx.Courses)
                {
                    if (c.Qualifications != null)
                    {
                        foreach (Qualification q in c.Qualifications)
                            ctx.Qualifications.Attach(q);
                    }
                    Courses.Add(c);
                }
            }
            return Courses;
        }

        public void Delete(Course entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Courses.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(Course entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    List<Qualification> qualies = new List<Qualification>();

                    if (entity.Qualifications != null)
                    {
                        foreach (Qualification q in entity.Qualifications)
                        {
                            Qualification dummy = ctx.Qualifications.Find(q.QualificationId);
                            ctx.Qualifications.Attach(dummy);
                            ctx.Entry(dummy).State = EntityState.Unchanged;
                            qualies.Add(dummy);
                        }

                        entity.Qualifications.Clear();
                        entity.Qualifications = qualies;
                    }
                    ctx.Courses.Add(entity);
                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    List<string> errorMessages = new List<string>();
                    foreach (DbEntityValidationResult validationResult in ex.EntityValidationErrors)
                    {
                        string entityName = validationResult.Entry.Entity.GetType().Name;
                        foreach (DbValidationError error in validationResult.ValidationErrors)
                        {
                            errorMessages.Add(entityName + "." + error.PropertyName + ": " + error.ErrorMessage);
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        public void Update(Course entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                List<Qualification> dummy = new List<Qualification>();

                if (entity.Qualifications != null)
                {
                    foreach (Qualification q in entity.Qualifications)
                    {
                        Qualification quali = ctx.Qualifications.Find(q.QualificationId);
                        ctx.Entry(quali).State = EntityState.Unchanged;
                        dummy.Add(quali);
                    }
                }

                entity.Qualifications.Clear();

                foreach (Qualification q in dummy)
                {
                    entity.Qualifications.Add(q);
                }

                Course original = ctx.Courses.Find(entity.CourseId);

                if (original != null)
                {
                    original.Qualifications.Clear();
                    foreach (Qualification q in entity.Qualifications)
                    {
                        ctx.Qualifications.Attach(q);
                        ctx.Entry(q).State = EntityState.Unchanged;
                        original.Qualifications.Add(q);
                    }
                    ctx.Entry(original).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public Course GetById(int id)
        {
            Course course;
            using (var ctx = new SchoolDataContext())
            {
                course = (Course)ctx.Courses.Find(id);
            }
            return course;
        }

    }
}