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
                    ctx.Entry(c).Reference(i => i.Instructor).Load();
                    ctx.Entry(c.Instructor).Reference(i => i.Adress).Load();
                    ctx.Entry(c.Instructor).Reference(i => i.Bank).Load();
                    ctx.Entry(c.Instructor).Reference(i => i.Contact).Load();


                    ctx.Instructors.Attach(c.Instructor);
                    c.Instructor = ctx.Instructors.Find(c.Instructor.InstructorId);
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
                    Instructor inst = ctx.Instructors.Find(entity.Instructor.InstructorId);
                    entity.Instructor = inst;
                    ctx.Courses.Add(entity);
                    ctx.Entry(entity.Instructor).State = EntityState.Unchanged;
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

        public void Update(Course entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                Course original = ctx.Courses.Find(entity.CourseId);

                if (original != null)
                {
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
                course = (Course)ctx.Courses.Where(c => c.CourseId == id);
                ctx.Entry(course).Reference(s => s.Instructor).Load();
            }
            return course;
        }

    }
}