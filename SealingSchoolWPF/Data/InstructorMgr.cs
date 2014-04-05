using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    public class InstructorMgr : IPersistenceMgr<Instructor>
    {
        public IList<Instructor> Instructors { get; set; }

        public IList<Instructor> GetAll()
        {
            Instructors = new List<Instructor>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Instructor s in ctx.Instructors)
                {
                    Instructors.Add(s);
                }
            }
            return Instructors;
        }

        public void Delete(Instructor entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Instructors.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(Instructor entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Instructors.Add(entity);
                ctx.SaveChanges();
            }
        }

        public void Update(Instructor entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                Instructor original = ctx.Instructors.Find(entity.Id);

                if (original != null)
                {
                    ctx.Entry(original).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public Instructor GetById(int id)
        {
            Instructor instructor;
            using (var ctx = new SchoolDataContext())
            {
                instructor = (Instructor)ctx.Instructors.Where(i => i.Id == id);
            }
            return instructor;
        }
    }
}