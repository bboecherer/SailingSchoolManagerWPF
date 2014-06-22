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
                    if (mat.MaterialTyp != null)
                    {
                        ctx.MaterialTyps.Attach(mat.MaterialTyp);
                    }
                    if (mat.BoatTyps != null)
                    {
                        foreach (BoatTyp q in mat.BoatTyps)
                            ctx.BoatTyps.Attach(q);
                    }
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
                    List<BoatTyp> boatTyps = new List<BoatTyp>();

                    ctx.Materials.Add(entity);
                    if (entity.MaterialTyp != null)
                    {
                        MaterialTyp mt = ctx.MaterialTyps.Find(entity.MaterialTyp.Id);
                        ctx.MaterialTyps.Attach(mt);
                        ctx.Entry(mt).State = EntityState.Unchanged;
                        entity.MaterialTyp = mt;
                    }
                    if (entity.BoatTyps != null)
                    {
                        foreach (BoatTyp q in entity.BoatTyps)
                        {
                            BoatTyp dummy = ctx.BoatTyps.Find(q.BoatTypID);
                            ctx.BoatTyps.Attach(dummy);
                            ctx.Entry(dummy).State = EntityState.Unchanged;
                            boatTyps.Add(dummy);
                        }

                        entity.BoatTyps.Clear();
                        entity.BoatTyps = boatTyps;
                    }
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
                original.SerialNumber = entity.SerialNumber;
                original.CreatedOn = entity.CreatedOn;
                original.ModifiedOn = DateTime.Now;



                List<BoatTyp> boatTyps = new List<BoatTyp>();
                if (entity.BoatTyps != null)
                {
                    foreach (BoatTyp q in entity.BoatTyps)
                    {
                        BoatTyp dummy = ctx.BoatTyps.Find(q.BoatTypID);
                        ctx.Entry(dummy).State = EntityState.Unchanged;
                        boatTyps.Add(dummy);
                    }
                    entity.BoatTyps.Clear();
                }

                foreach (BoatTyp q in boatTyps)
                {
                    entity.BoatTyps.Add(q);
                }

                if (entity.MaterialTyp != null)
                {
                    MaterialTyp mt = ctx.MaterialTyps.Find(entity.MaterialTyp.Id);
                    ctx.MaterialTyps.Attach(mt);
                    ctx.Entry(mt).State = EntityState.Unchanged;
                    entity.MaterialTyp = mt;
                    original.MaterialTyp = mt;
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

        public Material GetById(int id)
        {
            Material material;
            using (var ctx = new SchoolDataContext())
            {
                material = (Material)ctx.Materials.Where(s => s.MaterialId == id);
               
                if (material.BoatTyps != null)
                {
                    foreach (BoatTyp q in material.BoatTyps)
                        ctx.BoatTyps.Attach(q);
                }
                if (material.MaterialTyp != null)
                {
                    ctx.MaterialTyps.Attach(material.MaterialTyp);
                }
            }
            return material;
        }
    }
}