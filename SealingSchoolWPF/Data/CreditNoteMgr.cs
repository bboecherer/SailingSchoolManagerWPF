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
    public class CreditNoteMgr : IPersistenceMgr<CreditNote>
    {
        public IList<CreditNote> CreditNotes { get; set; }

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

        public void Delete(CreditNote entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.CreditNotes.Remove(entity);
                ctx.SaveChanges();
            }
        }

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