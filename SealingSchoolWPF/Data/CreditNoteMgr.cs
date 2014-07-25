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
    /// Entity Manager for CreditNote
    /// </summary>
    public class CreditNoteMgr : IPersistenceMgr<CreditNote>
    {
        /// <summary>
        /// Gets or sets the credit notes.
        /// </summary>
        /// <value>
        /// The credit notes.
        /// </value>
        public IList<CreditNote> CreditNotes { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList<CreditNote></returns>
        public IList<CreditNote> GetAll()
        {
            CreditNotes = new List<CreditNote>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (CreditNote i in ctx.CreditNotes)
                {
                    CreditNotes.Add(i);
                }
            }
            return CreditNotes;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(CreditNote entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.CreditNotes.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(CreditNote entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.CreditNotes.Add(entity);
                    ctx.SaveChanges();
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(CreditNote entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                CreditNote original = ctx.CreditNotes.Find(entity.Id);
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
        /// <returns>CreditNote</returns>
        public CreditNote GetById(int id)
        {
            CreditNote CreditNote;
            using (var ctx = new SchoolDataContext())
            {
                CreditNote = ctx.CreditNotes.Find(id);
            }
            return CreditNote;
        }
    }
}