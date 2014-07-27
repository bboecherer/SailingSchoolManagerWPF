using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Data
{
    /// <summary>
    /// Entity Manager for BusinessUnit
    /// @Author Benjamin Böcherer
    /// </summary>
    public class BusinessUnitMgr : IPersistenceMgr<BusinessUnit>
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<BusinessUnit> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(BusinessUnit entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.BusinessUnits.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Create(BusinessUnit entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(BusinessUnit entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public BusinessUnit GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the bu.
        /// </summary>
        /// <returns></returns>
        internal BusinessUnit GetBu()
        {
            BusinessUnit bu = null;
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    bu = ctx.BusinessUnits.FirstOrDefault<BusinessUnit>();
                }
                catch (Exception)
                { }

            }
            return bu;
        }
    }
}
