using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Data
{
    /// <summary>
    /// Entity Manager for Student
    /// @Author Benjamin Böcherer
    /// </summary>
    public class StudentMgr : IPersistenceMgr<Student>
    {
        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        public IList<Student> Students { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList<Student></returns>
        public IList<Student> GetAll()
        {
            Students = new List<Student>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Student stud in ctx.Students)
                {
                    ctx.Entry(stud).Reference(s => s.Adress).Load();
                    ctx.Entry(stud).Reference(s => s.Bank).Load();
                    ctx.Entry(stud).Reference(s => s.Contact).Load();

                    if (stud.Qualifications != null)
                    {
                        foreach (Qualification q in stud.Qualifications)
                            ctx.Qualifications.Attach(q);
                    }

                    Students.Add(stud);
                }
            }
            return Students;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Student entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Students.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(Student entity)
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

                    ctx.Students.Add(entity);
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
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Student entity)
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

                Student original = ctx.Students.Find(entity.StudentId);
                ctx.Entry(original).Reference(s => s.Adress).Load();
                ctx.Entry(original).Reference(s => s.Bank).Load();
                ctx.Entry(original).Reference(s => s.Contact).Load();

                original.FirstName = entity.FirstName.Trim();
                original.LastName = entity.LastName.Trim();
                original.Label = entity.LastName.Trim() + ", " + entity.FirstName.Trim();

                entity.Label = entity.LastName.Trim() + ", " + entity.FirstName.Trim();
                entity.FirstName = entity.FirstName.Trim();
                entity.LastName = entity.LastName.Trim();

                if (original.Adress != null)
                {
                    if (entity.Adress != null)
                    {
                        original.Adress.City = entity.Adress.City;
                        original.Adress.Country = entity.Adress.Country;
                        original.Adress.State = entity.Adress.State;
                        original.Adress.ZipCode = entity.Adress.ZipCode;
                        original.Adress.Street = entity.Adress.Street;
                        original.Adress.AddressLine1 = entity.Adress.Street + ", " + entity.Adress.ZipCode + " " + entity.Adress.City;
                    }
                }

                if (original.Bank != null)
                {
                    if (entity.Bank != null)
                    {
                        original.Bank.AccountNo = entity.Bank.AccountNo;
                        original.Bank.BankName = entity.Bank.BankName;
                        original.Bank.BankNo = entity.Bank.BankNo;
                        original.Bank.Bic = entity.Bank.Bic;
                        original.Bank.Iban = entity.Bank.Iban;
                        original.Bank.Sepa = entity.Bank.Sepa;
                    }
                }

                if (original.Contact != null)
                {
                    if (entity.Contact != null)
                    {
                        original.Contact.Email = entity.Contact.Email;
                        original.Contact.Fax1 = entity.Contact.Fax1;
                        original.Contact.Fax2 = entity.Contact.Fax2;
                        original.Contact.Tel1 = entity.Contact.Tel1;
                        original.Contact.Tel2 = entity.Contact.Tel2;
                        original.Contact.Tel3 = entity.Contact.Tel3;
                        original.Contact.WebSite = entity.Contact.WebSite;
                        original.Contact.WantsEmailNotification = entity.Contact.WantsEmailNotification;
                        original.Contact.WantsTelNotification = entity.Contact.WantsTelNotification;
                    }
                }

                original.AdditionalInfo = entity.AdditionalInfo;
                original.CreatedOn = entity.CreatedOn;
                original.ModifiedOn = DateTime.Now;

                if (original != null)
                {
                    original.Qualifications.Clear();
                    foreach (Qualification q in entity.Qualifications)
                    {
                        ctx.Qualifications.Attach(q);
                        ctx.Entry(q).State = EntityState.Unchanged;
                        original.Qualifications.Add(q);
                    }

                    try
                    {
                        ctx.Entry(original).CurrentValues.SetValues(entity);
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
                    catch (Exception)
                    { }
                }
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Student</returns>
        public Student GetById(int id)
        {
            Student student;
            using (var ctx = new SchoolDataContext())
            {
                student = (Student)ctx.Students.Where(s => s.StudentId == id);
                ctx.Entry(student).Reference(s => s.Adress).Load();
                ctx.Entry(student).Reference(s => s.Bank).Load();
                ctx.Entry(student).Reference(s => s.Contact).Load();
            }
            return student;
        }

        /// <summary>
        /// Gets the by course planing.
        /// </summary>
        /// <param name="coursePlaning">The course planing.</param>
        /// <returns>List<Student></returns>
        public List<Student> GetByCoursePlaning(CoursePlaning coursePlaning)
        {
            var dummy = new List<Student>();
            using (var ctx = new SchoolDataContext())
            {
                foreach (TrainingActivity t in ctx.TrainingActivities.Where(t => t.TrainingActivityStatus == TrainingActivityStatus.BEENDET))
                {
                    if (t.Course.CourseId == coursePlaning.Course.CourseId)
                    {
                        dummy.Add(t.Student);
                    }
                }
            }
            return dummy;
        }
    }
}