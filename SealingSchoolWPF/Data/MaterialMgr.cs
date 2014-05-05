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
    public class MaterialMgr : IPersistenceMgr<Material>
    {
        public IList<Material> Materials { get; set; }

        public IList<Material> GetAll()
        {
            Materials = new List<Material>();

            using (var ctx = new SchoolDataContext())
            {

                foreach (Material mat in ctx.Materials)
                {
                    Materials.Add(mat);
                }
            }
            return Materials;
        }

        public void Delete(Material entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Materials.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(Material entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.Materials.Add(entity);
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

        public void Update(Material entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                Material original = ctx.Materials.Find(entity.MaterialId);


                original.Name = entity.Name;
                original.MaterialStatus = entity.MaterialStatus;
                original.Price = entity.Price;
                original.RepairAction = entity.RepairAction;
                original.Brand = entity.Brand;
                original.Currency = entity.Currency;
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

        public Material GetById(int id)
        {
            Material material;
            using (var ctx = new SchoolDataContext())
            {
                material = (Material)ctx.Materials.Where(s => s.MaterialId == id);
                            }
            return material;
        }
    }
}