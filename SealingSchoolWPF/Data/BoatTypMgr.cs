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
    /// Entity Manager for BoatTyp
    /// @Author Stefan Müller
    /// </summary>
    public class BoatTypMgr : IPersistenceMgr<BoatTyp>
    {
        /// <summary>
        /// Gets or sets the boat typs.
        /// </summary>
        /// <value>
        /// The boat typs.
        /// </value>
        public IList<BoatTyp> BoatTyps { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList<BoatTyp></returns>
        public IList<BoatTyp> GetAll()
        {
            BoatTyps = new List<BoatTyp>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (BoatTyp i in ctx.BoatTyps)
                {

                    BoatTyps.Add(i);
                }
            }
            return BoatTyps;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(BoatTyp entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.BoatTyps.Attach(entity);
                ctx.BoatTyps.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
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

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(BoatTyp entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BoatTyp</returns>
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