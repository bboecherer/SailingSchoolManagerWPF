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
    public class BlockedTimesMgr
    {
        public IList<BlockedTimeSpan> BlockedTimeSpans { get; set; }

        public IList<BlockedTimeSpan> GetAll()
        {
            BlockedTimeSpans = new List<BlockedTimeSpan>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (BlockedTimeSpan c in ctx.BlockedTimeSpans)
                {
                    BlockedTimeSpans.Add(c);
                }
            }
            return BlockedTimeSpans;
        }

        public void Delete(BlockedTimeSpan entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.BlockedTimeSpans.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(BlockedTimeSpan entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.BlockedTimeSpans.Add(entity);
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
                catch (Exception ex) { }
            }
        }

        public void Update(BlockedTimeSpan entity)
        {
            using (var ctx = new SchoolDataContext())
            {

                BlockedTimeSpan original = ctx.BlockedTimeSpans.Find(entity.BlockedTimeSpanId);

                if (original != null)
                {
                    ctx.Entry(original).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public BlockedTimeSpan GetById(int id)
        {
            BlockedTimeSpan blockedTimespan;
            using (var ctx = new SchoolDataContext())
            {
                blockedTimespan = (BlockedTimeSpan)ctx.BlockedTimeSpans.Find(id);
            }
            return blockedTimespan;
        }

    }
}