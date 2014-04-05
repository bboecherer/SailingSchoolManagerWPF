using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    public class StudentMgr : IPersistenceMgr<Student>
    {
        public IList<Student> Students { get; set; }

        public IList<Student> GetAll()
        {
            Students = new List<Student>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Student s in ctx.Students)
                {
                    Students.Add(s);
                }
            }
            return Students;
        }

        public void Delete(Student entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Students.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(Student entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Students.Add(entity);
                ctx.SaveChanges();
            }
        }

        public void Update(Student entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                Student original = ctx.Students.Find(entity.Id);

                if (original != null)
                {
                    ctx.Entry(original).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public Student GetById(int id)
        {
            Student student;
            using (var ctx = new SchoolDataContext())
            {
                student = (Student)ctx.Students.Where(s => s.Id == id);
            }
            return student;
        }
    }
}