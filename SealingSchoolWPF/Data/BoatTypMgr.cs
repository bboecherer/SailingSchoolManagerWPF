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
    public class BoatTypMgr : IPersistenceMgr<BoatTyp>
    {
        public IList<BoatTyp> BoatTyps { get; set; }

        public IList<BoatTyp> GetAll()
        {
            BoatTyps = new List<BoatTyp>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (BoatTyp i in ctx.BoatTyps)
                {
                    ctx.Entry(i).Reference(s => s.MaterialGroup).Load();
                    if (i.MaterialGroup != null)
                    {
                        ctx.MaterialGroups.Attach(i.MaterialGroup);
                    }
                    BoatTyps.Add(i);
                }
            }
            return BoatTyps;
        }

        public void Delete(BoatTyp entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.BoatTyps.Attach(entity);
                ctx.BoatTyps.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(BoatTyp entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.BoatTyps.Add(entity);
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

        public void Update(BoatTyp entity)
        {
            throw new NotImplementedException();
        }

        public BoatTyp GetById(int id)
        {
            BoatTyp BoatTyp;
            using (var ctx = new SchoolDataContext())
            {
                BoatTyp = ctx.BoatTyps.Find(id);
            }
            return BoatTyp;
        }
    }
}