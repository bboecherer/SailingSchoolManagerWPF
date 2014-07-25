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
    /// Entity Manager for BlockedTimeSpans
    /// </summary>
    public class BlockedTimesMgr
    {
        /// <summary>
        /// Gets or sets the blocked time spans.
        /// </summary>
        /// <value>
        /// The blocked time spans.
        /// </value>
        public IList<BlockedTimeSpan> BlockedTimeSpans { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList of BlockedTimeSpan</returns>
        public IList<BlockedTimeSpan> GetAll()
        {
            BlockedTimeSpans = new List<BlockedTimeSpan>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (BlockedTimeSpan block in ctx.BlockedTimeSpans)
                {
                    if (block.Course != null)
                    {
                        ctx.Courses.Attach(block.Course);
                    }

                    if (block.Instructor != null)
                    {
                        ctx.Instructors.Attach(block.Instructor);
                    }

                    BlockedTimeSpans.Add(block);
                }
            }

            return BlockedTimeSpans;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(BlockedTimeSpan entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.BlockedTimeSpans.Attach(entity);
                ctx.BlockedTimeSpans.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(BlockedTimeSpan entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.Instructors.Attach(entity.Instructor);
                    ctx.Entry(entity.Instructor).State = EntityState.Unchanged;
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
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
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

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlockedTimeSpan</returns>
        public BlockedTimeSpan GetById(int id)
        {
            BlockedTimeSpan blockedTimespan;
            using (var ctx = new SchoolDataContext())
            {
                blockedTimespan = (BlockedTimeSpan)ctx.BlockedTimeSpans.Find(id);
            }
            return blockedTimespan;
        }


        /// <summary>
        /// Gets the by instructor.
        /// </summary>
        /// <param name="instructorId">The instructor identifier.</param>
        /// <returns>IList<BlockedTimeSpan></returns>
        public IList<BlockedTimeSpan> GetByInstructor(int instructorId)
        {
            IList<BlockedTimeSpan> blockedTimespan = this.GetAll();
            IList<BlockedTimeSpan> blocked = new List<BlockedTimeSpan>();

            foreach (BlockedTimeSpan b in blockedTimespan)
            {
                if (b.Instructor.InstructorId == instructorId)
                {
                    blocked.Add(b);
                }
            }

            return blocked;
        }

        /// <summary>
        /// Updates the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="updateCoursePlaning">if set to <c>true</c> [update course planing].</param>
        public void Update(IList<BlockedTimeSpan> list, bool updateCoursePlaning = false)
        {

            var dummy = this.GetByInstructor(list.FirstOrDefault().Instructor.InstructorId);
            foreach (BlockedTimeSpan b in dummy)
            {
                if (!updateCoursePlaning)
                {
                    if (b.Reason == null || b.Course == null)
                    {
                        this.Delete(b);
                    }
                }
                else
                {
                    //  this.Delete( b );
                }
            }

            foreach (BlockedTimeSpan blocked in list)
            {
                this.Create(blocked);
            }

        }
    }
}