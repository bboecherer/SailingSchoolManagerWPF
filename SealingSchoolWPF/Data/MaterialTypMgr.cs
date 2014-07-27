using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Data
{
    /// <summary>
    /// Entity Manager for MaterialTyp
    /// @Author Stefan Müller
    /// </summary>
    public class MaterialTypMgr : IPersistenceMgr<MaterialTyp>
    {
        /// <summary>
        /// Gets or sets the material typs.
        /// </summary>
        /// <value>
        /// The material typs.
        /// </value>
        public IList<MaterialTyp> MaterialTyps { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList<MaterialTyp></returns>
        public IList<MaterialTyp> GetAll()
        {
            MaterialTyps = new List<MaterialTyp>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (MaterialTyp i in ctx.MaterialTyps)
                {
                    MaterialTyps.Add(i);
                }
            }
            return MaterialTyps;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(MaterialTyp entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.MaterialTyps.Attach(entity);
                ctx.MaterialTyps.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(MaterialTyp entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.MaterialTyps.Add(entity);
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

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(MaterialTyp entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>MaterialTyp</returns>
        public MaterialTyp GetById(int id)
        {
            MaterialTyp Mat;
            using (var ctx = new SchoolDataContext())
            {
                Mat = ctx.MaterialTyps.Find(id);
            }
            return Mat;
        }
    }
}