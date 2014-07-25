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
    /// <summary>
    /// Entity Manager for Blocked Materials.
    /// </summary>
    public class BlockedMaterialMgr
    {
        /// <summary>
        /// Gets or sets the blocked materials.
        /// </summary>
        /// <value>
        /// The blocked materials.
        /// </value>
        public IList<BlockedMaterial> BlockedMaterials { get; set; }
        /// <summary>
        /// The mat MGR
        /// </summary>
        public MaterialMgr matMgr = new MaterialMgr();

        /// <summary>
        /// returns a List of all existing Blocked Material
        /// </summary>
        /// <returns>IList of BlockedMaterial</returns>
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


        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(BlockedMaterial entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.BlockedMaterials.Attach(entity);
                ctx.BlockedMaterials.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
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

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
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

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlockedMaterial</returns>
        public BlockedMaterial GetById(int id)
        {
            BlockedMaterial BlockedMaterial;
            using (var ctx = new SchoolDataContext())
            {
                BlockedMaterial = (BlockedMaterial)ctx.BlockedMaterials.Find(id);
            }
            return BlockedMaterial;
        }

        /// <summary>
        /// Loads the useable material per boat typ.
        /// </summary>
        /// <param name="BoatTyp">The boat typ.</param>
        /// <param name="StartDate">The start date.</param>
        /// <param name="EndDate">The end date.</param>
        /// <returns>IList<Material></returns>
        public IList<Material> LoadUseableMaterialPerBoatTyp(BoatTyp BoatTyp, DateTime StartDate, DateTime EndDate)
        {
            IList<Material> Materials;
            var BlockedMaterial = new List<BlockedMaterial>();

            using (var ctx = new SchoolDataContext())
            {
                var query = ctx.BlockedMaterials.Where(s => s.StartDate >= StartDate && s.StartDate <= EndDate);
                query.Where(s => s.EndDate >= StartDate && s.EndDate <= EndDate);

                foreach (BlockedMaterial blockedMat in query)
                {

                    if (blockedMat.Material.BoatTyps != null)
                    {
                        foreach (BoatTyp q in blockedMat.Material.BoatTyps)
                        {
                            if (q.BoatTypID == BoatTyp.BoatTypID)
                            {

                                BlockedMaterial.Add(blockedMat);
                                break;
                            }
                        }
                    }

                }

                Materials = matMgr.GetAllForBootTyp(BoatTyp);
                var dummyMatList = new List<Material>();
                foreach (BlockedMaterial bMat in BlockedMaterial)
                {
                    foreach (Material mat in Materials)
                    {
                        if (bMat.Material != null && bMat.Material.MaterialId == mat.MaterialId)
                        {
                            dummyMatList.Add(mat);
                            break;
                        }
                    }

                }

                foreach (Material mat in dummyMatList)
                {
                    Materials.Remove(mat);
                }
            }
            return Materials;
        }

    }
}