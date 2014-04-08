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
    public class InstructorMgr : IPersistenceMgr<Instructor>
    {
        public IList<Instructor> Instructors { get; set; }

        public IList<Instructor> GetAll()
        {
            Instructors = new List<Instructor>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Instructor instructor in ctx.Instructors)
                {
                    ctx.Entry(instructor).Reference(s => s.Adress).Load();
                    ctx.Entry(instructor).Reference(s => s.Bank).Load();
                    ctx.Entry(instructor).Reference(s => s.Contact).Load();
                    Instructors.Add(instructor);
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
                ctx.Entry(original).Reference(s => s.Adress).Load();
                ctx.Entry(original).Reference(s => s.Bank).Load();
                ctx.Entry(original).Reference(s => s.Contact).Load();

                original.FirstName = entity.FirstName;
                original.LastName = entity.LastName;

                if (original.Adress != null)
                {
                    if (entity.Adress != null)
                    {
                        original.Adress.AddressLine1 = entity.Adress.AddressLine1;
                        original.Adress.AddressLine2 = entity.Adress.AddressLine1;
                        original.Adress.AddressLine3 = entity.Adress.AddressLine1;
                        original.Adress.City = entity.Adress.City;
                        original.Adress.Country = entity.Adress.Country;
                        original.Adress.State = entity.Adress.State;
                        original.Adress.ZipCode = entity.Adress.ZipCode;
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

        public Instructor GetById(int id)
        {
            Instructor instructor;
            using (var ctx = new SchoolDataContext())
            {
                instructor = (Instructor)ctx.Instructors.Where(s => s.Id == id);
                ctx.Entry(instructor).Reference(s => s.Adress).Load();
                ctx.Entry(instructor).Reference(s => s.Bank).Load();
                ctx.Entry(instructor).Reference(s => s.Contact).Load();
            }
            return instructor;
        }
    }
}