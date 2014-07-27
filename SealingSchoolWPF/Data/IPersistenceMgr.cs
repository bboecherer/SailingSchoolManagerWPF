using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Data
{
    /// <summary>
    /// Interface for the persistence manager
    /// @Author Benjamin Böcherer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IPersistenceMgr<T> where T : SealingSchoolObject
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList<T></returns>
        IList<T> GetAll();

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns> T d</returns>
        T GetById(int id);
    }
}