using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
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
                ctx.Courses.Add(entity);
                ctx.SaveChanges();
            }
        }

        public void Update(Course entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                Course original = ctx.Courses.Find(entity.Id);

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
                course = (Course)ctx.Courses.Where(c => c.Id == id);
                ctx.Entry(course).Reference(s => s.Instructor).Load();
            }
            return course;
        }

    }
}