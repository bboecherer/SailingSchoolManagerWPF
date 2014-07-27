using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Data
{
    /// <summary>
    /// Entity Manager for Invoice
    /// @Author Benjamin Böcherer
    /// </summary>
    public class InvoiceMgr : IPersistenceMgr<Invoice>
    {
        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        /// <value>
        /// The invoices.
        /// </value>
        public IList<Invoice> Invoices { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList<Invoice></returns>
        public IList<Invoice> GetAll()
        {
            Invoices = new List<Invoice>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Invoice i in ctx.Invoices)
                {
                    Invoices.Add(i);
                }
            }
            return Invoices;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Invoice entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Invoices.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(Invoice entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.Invoices.Add(entity);
                    ctx.SaveChanges();
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Invoice entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                Invoice original = ctx.Invoices.Find(entity.InvoiceId);
                if (original != null)
                {
                    entity.PaidDate = DateTime.Now;
                    entity.PaymentTargetDate = DateTime.Now;
                    original.PaidDate = DateTime.Now;
                    original.PaymentTargetDate = DateTime.Now;
                    ctx.Entry(original).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Invoice</returns>
        public Invoice GetById(int id)
        {
            Invoice invoice;
            using (var ctx = new SchoolDataContext())
            {
                invoice = (Invoice)ctx.Invoices.Where(i => i.InvoiceId == id);
            }
            return invoice;
        }

        /// <summary>
        /// Gets the by status.
        /// </summary>
        /// <param name="paymentStatus">The payment status.</param>
        /// <returnsIList<Invoice>></returns>
        public IList<Invoice> GetByStatus(PaymentStatus paymentStatus)
        {
            Invoices = new List<Invoice>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Invoice i in ctx.Invoices.Where(i => i.PaymentStatus == paymentStatus))
                {
                    Invoices.Add(i);
                }
            }
            return Invoices;
        }


    }
}