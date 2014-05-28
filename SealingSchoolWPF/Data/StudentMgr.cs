using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
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

                foreach (Student stud in ctx.Students)
                {
                    ctx.Entry(stud).Reference(s => s.Adress).Load();
                    ctx.Entry(stud).Reference(s => s.Bank).Load();
                    ctx.Entry(stud).Reference(s => s.Contact).Load();

                    Students.Add(stud);
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
                try
                {
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

        public void Update(Student entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                Student original = ctx.Students.Find(entity.StudentId);
                ctx.Entry(original).Reference(s => s.Adress).Load();
                ctx.Entry(original).Reference(s => s.Bank).Load();
                ctx.Entry(original).Reference(s => s.Contact).Load();

                original.FirstName = entity.FirstName;
                original.LastName = entity.LastName;
                original.Label = entity.FirstName + " " + entity.LastName;

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
                    try
                    {
                        ctx.Entry(original).State = EntityState.Modified;
                        ctx.ChangeTracker.DetectChanges();
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
                    catch (Exception ex)
                    { }
                }
            }
        }

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
    }
}