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
    public class BlockedMaterialMgr
    {
        public IList<BlockedMaterial> BlockedMaterials { get; set; }

        public IList<BlockedMaterial> GetAll()
        {
            BlockedMaterials = new List<BlockedMaterial>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (BlockedMaterial block in ctx.BlockedMaterials)
                {
                    

                    if (block.Material != null)
                    {
                        ctx.Materials.Attach(block.Material);
                    }

                    BlockedMaterials.Add(block);
                }
            }

            return BlockedMaterials;
        }

        public void Delete(BlockedMaterial entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.BlockedMaterials.Attach(entity);
                ctx.BlockedMaterials.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(BlockedMaterial entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.Materials.Attach(entity.Material);
                    ctx.Entry(entity.Material).State = EntityState.Unchanged;
                    ctx.BlockedMaterials.Add(entity);
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
                catch (Exception) { }
            }
        }

        public void Update(BlockedMaterial entity)
        {
            using (var ctx = new SchoolDataContext())
            {

                BlockedMaterial original = ctx.BlockedMaterials.Find(entity.BlockedMaterialId);

                if (original != null)
                {
                    ctx.Entry(original).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public BlockedMaterial GetById(int id)
        {
            BlockedMaterial BlockedMaterial;
            using (var ctx = new SchoolDataContext())
            {
                BlockedMaterial = (BlockedMaterial)ctx.BlockedMaterials.Find(id);
            }
            return BlockedMaterial;
        }


        public IList<BlockedMaterial> GetByMaterial(int MaterialId)
        {
            IList<BlockedMaterial> blockedTimespan = this.GetAll();
            IList<BlockedMaterial> blocked = new List<BlockedMaterial>();

            foreach (BlockedMaterial b in blockedTimespan)
            {
                if (b.Material.MaterialId == MaterialId)
                {
                    blocked.Add(b);
                }
            }

            return blocked;
        }


    }
}