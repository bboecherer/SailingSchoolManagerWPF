using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    public class QualificationMgr : IPersistenceMgr<Qualification>
    {
        public IList<Qualification> GetAll()
        {
            var Qual = new List<Qualification>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Qualification i in ctx.Qualifications)
                {
                    Qual.Add(i);
                }
            }
            return Qual;
        }

        public void Delete(Qualification entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Qualifications.Attach(entity);
                ctx.Qualifications.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(Qualification entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.Qualifications.Add(entity);
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

        public void Update(Qualification entity)
        {
            throw new NotImplementedException();
        }

        public Qualification GetById(int id)
        {
            Qualification quali;
            using (var ctx = new SchoolDataContext())
            {
                quali = ctx.Qualifications.Find(id);
            }
            return quali;
        }
    }
}