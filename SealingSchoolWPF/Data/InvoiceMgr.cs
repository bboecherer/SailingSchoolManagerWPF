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
    public class InvoiceMgr : IPersistenceMgr<Invoice>
    {
        public IList<Invoice> Invoices { get; set; }

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

        public void Delete(Invoice entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Invoices.Remove(entity);
                ctx.SaveChanges();
            }
        }

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

        public Invoice GetById(int id)
        {
            Invoice invoice;
            using (var ctx = new SchoolDataContext())
            {
                invoice = (Invoice)ctx.Invoices.Where(i => i.InvoiceId == id);
            }
            return invoice;
        }

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