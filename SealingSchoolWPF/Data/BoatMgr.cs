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
    public class BoatMgr : IPersistenceMgr<Boat>
    {
        public IList<Boat> Boats { get; set; }

        public IList<Boat> GetAll()
        {
            Boats = new List<Boat>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Boat i in ctx.Boats)
                {
                    ctx.Entry(i).Reference(s => s.BoatTyp).Load();
                    if (i.BoatTyp != null)
                    {
                        ctx.BoatTyps.Attach(i.BoatTyp);
                    }
                    Boats.Add(i);
                }
            }
            return Boats;
        }

        public void Delete(Boat entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Boats.Attach(entity);
                ctx.Boats.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(Boat entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.Boats.Add(entity);
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

        public void Update(Boat entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                Boat original = ctx.Boats.Find(entity.BoatID);
                ctx.Entry(original).Reference(s => s.BoatTyp).Load();

                original.Name = entity.Name;
                original.MaterialStatus = entity.MaterialStatus;
                original.Price = entity.Price;
                original.RepairAction = entity.RepairAction;
                original.Brand = entity.Brand;
                original.Currency = entity.Currency;
                original.AdditionalInfo = entity.AdditionalInfo;
                original.SerialNumber = entity.SerialNumber;
                original.CreatedOn = entity.CreatedOn;
                original.ModifiedOn = DateTime.Now;
                original.BoatTyp = entity.BoatTyp;


                if (entity.BoatTyp != null)
                {
                    ctx.Entry(original.BoatTyp).State = System.Data.Entity.EntityState.Unchanged;
                }
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
                    catch (Exception)
                    { }
                }
            }
        }

        public Boat GetById(int id)
        {
            Boat Boat;
            using (var ctx = new SchoolDataContext())
            {
                Boat = ctx.Boats.Find(id);
            }
            return Boat;
        }
    }
}