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

                foreach (Boat boat in ctx.Boats)
                {
                    ctx.Entry(boat).Reference(s => s.Material).Load();
                    ctx.Entry(boat).Reference(s => s.NeededMaterials).Load();
                    

                    Boats.Add(boat);
                }
            }
            return Boats;
        }

        public void Delete(Boat entity)
        {
            using (var ctx = new SchoolDataContext())
            {
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
                Boat original = ctx.Boats.Find(entity.BoatId);
                ctx.Entry(original).Reference(s => s.Material).Load();
                ctx.Entry(original).Reference(s => s.NeededMaterials).Load();


                original.Crew = entity.Crew;

                if (original.Material != null)
                {
                    if (entity.Material != null)
                    {
                        original.Material.Name = entity.Material.Name;
                        original.Material.MaterialStatus = entity.Material.MaterialStatus;
                        original.Material.Price = entity.Material.Price;
                        original.Material.RepairAction = entity.Material.RepairAction;
                        original.Material.Brand = entity.Material.Brand;
                        original.Material.Currency = entity.Material.Currency;
                        original.Material.AdditionalInfo = entity.Material.AdditionalInfo;
                        original.Material.CreatedOn = entity.Material.CreatedOn;
                        original.Material.ModifiedOn = DateTime.Now;
                    }
                }

                //TODO: NeededMaterials anpassen
                if (original.NeededMaterials != null)
                {
                    if (entity.NeededMaterials != null)
                    {
                        original.Material.Name = entity.Material.Name;
                        original.Material.MaterialStatus = entity.Material.MaterialStatus;
                        original.Material.Price = entity.Material.Price;
                        original.Material.RepairAction = entity.Material.RepairAction;
                        original.Material.Brand = entity.Material.Brand;
                        original.Material.Currency = entity.Material.Currency;
                        original.Material.AdditionalInfo = entity.Material.AdditionalInfo;
                        original.Material.CreatedOn = entity.Material.CreatedOn;
                        original.Material.ModifiedOn = DateTime.Now;
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

        public Boat GetById(int id)
        {
            Boat boat;
            using (var ctx = new SchoolDataContext())
            {
                boat = (Boat)ctx.Boats.Where(s => s.BoatId == id);
                ctx.Entry(boat).Reference(s => s.Material).Load();
                ctx.Entry(boat).Reference(s => s.NeededMaterials).Load();
                
            }
            return boat;
        }
    }
}