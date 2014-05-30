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

            using (var ctx = new SchoolDataContext())
            {
                foreach (CoursePlaning c in ctx.CoursePlanings)
                {
                    //if (c.Qualifications != null)
                    //{
                    //    foreach (Qualification q in c.Qualifications)
                    //        ctx.Qualifications.Attach(q);
                    //}
                    Courses.Add(c);
                }
            }
            return Courses;
        }

        public void Delete(CoursePlaning entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.CoursePlanings.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(CoursePlaning entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    //List<Qualification> qualies = new List<Qualification>();

                    //if (entity.Qualifications != null)
                    //{
                    //    foreach (Qualification q in entity.Qualifications)
                    //    {
                    //        Qualification dummy = ctx.Qualifications.Find(q.QualificationId);
                    //        ctx.Qualifications.Attach(dummy);
                    //        ctx.Entry(dummy).State = EntityState.Unchanged;
                    //        qualies.Add(dummy);
                    //    }

                    //    entity.Qualifications.Clear();
                    //    entity.Qualifications = qualies;
                    //}
                    ctx.CoursePlanings.Add(entity);
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
                catch (Exception ex) { }
            }
        }

        public void Update(CoursePlaning entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                //List<Qualification> dummy = new List<Qualification>();

                //if (entity.Qualifications != null)
                //{
                //    foreach (Qualification q in entity.Qualifications)
                //    {
                //        Qualification quali = ctx.Qualifications.Find(q.QualificationId);
                //        ctx.Entry(quali).State = EntityState.Unchanged;
                //        dummy.Add(quali);
                //    }
                //}

                //entity.Qualifications.Clear();

                //foreach (Qualification q in dummy)
                //{
                //    entity.Qualifications.Add(q);
                //}

                CoursePlaning original = ctx.CoursePlanings.Find(entity.CoursePlaningId);

                if (original != null)
                {
                    //original.Qualifications.Clear();
                    //foreach (Qualification q in entity.Qualifications)
                    //{
                    //    ctx.Qualifications.Attach(q);
                    //    ctx.Entry(q).State = EntityState.Unchanged;
                    //    original.Qualifications.Add(q);
                    //}
                    ctx.Entry(original).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public CoursePlaning GetById(int id)
        {
            CoursePlaning course;
            using (var ctx = new SchoolDataContext())
            {
                course = (CoursePlaning)ctx.CoursePlanings.Where(c => c.CoursePlaningId == id);
            }
            return course;
        }

    }
}