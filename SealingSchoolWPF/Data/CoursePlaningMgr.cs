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
    /// Entity Manager for CoursePlanning
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CoursePlaningMgr : IPersistenceMgr<CoursePlaning>
    {
        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public IList<CoursePlaning> Courses { get; set; }
        /// <summary>
        /// The block mat MGR
        /// </summary>
        public BlockedMaterialMgr blockMatMgr = new BlockedMaterialMgr();


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList<CoursePlaning></returns>
        public IList<CoursePlaning> GetAll()
        {
            Courses = new List<CoursePlaning>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (CoursePlaning c in ctx.CoursePlanings)
                {
                    if (c.Instructors != null)
                    {
                        foreach (Instructor q in c.Instructors)
                            ctx.Instructors.Attach(q);
                    }

                    if (c.Course != null)
                    {
                        ctx.Courses.Attach(c.Course);
                    }

                    Courses.Add(c);
                }
            }
            return Courses;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(CoursePlaning entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.CoursePlanings.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(CoursePlaning entity)
        {
            CreateWithAnswer(entity);
        }

        /// <summary>
        /// Creates the with answer.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Boolean</returns>
        public Boolean CreateWithAnswer(CoursePlaning entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    Course c = ctx.Courses.Find(entity.Course.CourseId);
                    ctx.Courses.Attach(c);
                    ctx.Entry(c).State = EntityState.Unchanged;
                    entity.Course = c;
                    entity.Label = c.Label;

                    List<Instructor> qualies = new List<Instructor>();

                    if (entity.Instructors != null)
                    {
                        foreach (Instructor q in entity.Instructors)
                        {
                            Instructor dummy = ctx.Instructors.Find(q.InstructorId);
                            ctx.Instructors.Attach(dummy);
                            ctx.Entry(dummy).State = EntityState.Unchanged;
                            qualies.Add(dummy);
                        }

                        entity.Instructors.Clear();
                        entity.Instructors = qualies;
                    }
                    ctx.CoursePlanings.Add(entity);

                    foreach (Instructor instr in entity.Instructors)
                    {
                        BlockedTimeSpan blocked = new BlockedTimeSpan();
                        blocked.Course = entity.Course;
                        blocked.StartDate = (DateTime)entity.StartDate;
                        blocked.EndDate = (DateTime)entity.EndDate;
                        blocked.Instructor = instr;

                        if (entity.Course != null)
                        {
                            blocked.Reason = string.Format("Kurs {0}", entity.Course.Label);
                        }
                        else
                        {
                            blocked.Reason = "Privat";
                        }


                        ctx.BlockedTimeSpans.Add(blocked);
                    }

                    IList<Material> availableMaterial = blockMatMgr.LoadUseableMaterialPerBoatTyp(c.BoatTyp, (DateTime)entity.StartDate, (DateTime)entity.EndDate);


                    foreach (CourseMaterialTyp courseMatTyp in c.CourseMaterialTyps)
                    {
                        int numberOfBlockedMat = 0;
                        for (int i = 0; i < c.Capacity; i++)
                        {
                            Material tempMat = null;
                            foreach (Material mat in availableMaterial)
                            {
                                if (courseMatTyp.MaterialTyp.Id == mat.MaterialTyp.Id)
                                {
                                    BlockedMaterial BlockedMaterial = new BlockedMaterial();
                                    BlockedMaterial.StartDate = (DateTime)entity.StartDate;
                                    BlockedMaterial.EndDate = (DateTime)entity.EndDate;

                                    Material dummy = ctx.Materials.Find(mat.MaterialId);
                                    ctx.Materials.Attach(dummy);
                                    ctx.Entry(dummy).State = EntityState.Unchanged;
                                    BlockedMaterial.Material = dummy;
                                    if (entity.BlockedMaterial == null)
                                    {
                                        entity.BlockedMaterial = new List<BlockedMaterial>();
                                    }
                                    entity.BlockedMaterial.Add(BlockedMaterial);
                                    ctx.BlockedMaterials.Add(BlockedMaterial);
                                    tempMat = mat;
                                    break;
                                }
                            }
                            if (tempMat != null)
                            {
                                availableMaterial.Remove(tempMat);
                                numberOfBlockedMat++;
                            }
                        }
                        if (numberOfBlockedMat < c.Capacity)
                        {
                            return false;
                        }

                    }


                    ctx.SaveChanges();
                    return true;

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
                    } return false;
                }
                catch (Exception) { return false; }

            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(CoursePlaning entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                CoursePlaning original = ctx.CoursePlanings.Find(entity.CoursePlaningId);
                entity.Label = entity.Course.Label;
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
        /// <returns>CoursePlaning</returns>
        public CoursePlaning GetById(int id)
        {
            CoursePlaning course;
            using (var ctx = new SchoolDataContext())
            {
                course = (CoursePlaning)ctx.CoursePlanings.Where(c => c.CoursePlaningId == id);
            }
            return course;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="courseStatus">The course status.</param>
        /// <returns>IEnumerable<CoursePlaning></returns>
        public IEnumerable<CoursePlaning> GetAll(CourseStatus courseStatus)
        {
            var courseList = new List<CoursePlaning>();

            using (var ctx = new SchoolDataContext())
            {
                var dummy = this.GetAll();


                foreach (CoursePlaning c in dummy)
                {
                    if (c.CourseStatus == courseStatus)
                    {
                        courseList.Add(c);
                    }
                }
            }
            return courseList;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="courseStatus">The course status.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>IEnumerable<CoursePlaning></returns>
        public IEnumerable<CoursePlaning> GetAll(CourseStatus courseStatus, DateTime? startDate, DateTime? endDate)
        {
            var courseList = new List<CoursePlaning>();

            using (var ctx = new SchoolDataContext())
            {
                var dummy = this.GetAll();

                foreach (CoursePlaning c in dummy)
                {
                    if (c.CourseStatus == courseStatus)
                    {
                        // TODO: Zeitraum eingrenzen
                        if (c.StartDate >= startDate && c.EndDate <= endDate)
                        {
                            courseList.Add(c);
                        }
                    }
                }
            }
            return courseList;
        }

        /// <summary>
        /// Gets the instructor reference.
        /// </summary>
        /// <param name="instructorId">The instructor identifier.</param>
        /// <returns>IEnumerable<CoursePlaning></returns>
        public IEnumerable<CoursePlaning> GetInstructorReference(int instructorId)
        {
            var courseList = new List<CoursePlaning>();

            using (var ctx = new SchoolDataContext())
            {
                var dummy = this.GetAll();

                foreach (CoursePlaning c in dummy)
                {
                    if (c.CourseStatus == CourseStatus.BEENDET)
                    {
                        foreach (Instructor i in c.Instructors)
                        {
                            if (i.InstructorId == instructorId)
                            {
                                courseList.Add(c);
                            }
                        }
                    }
                }
            }
            return courseList;
        }

        /// <summary>
        /// Gets the by status.
        /// </summary>
        /// <param name="courseStatus">The course status.</param>
        /// <returns>IEnumerable<CoursePlaning></returns>
        internal IEnumerable<CoursePlaning> GetByStatus(CourseStatus courseStatus)
        {
            var courseList = new List<CoursePlaning>();

            using (var ctx = new SchoolDataContext())
            {
                var dummy = this.GetAll();

                foreach (CoursePlaning c in dummy)
                {
                    if (c.CourseStatus == CourseStatus.BEENDET)
                    {
                        courseList.Add(c);
                    }
                }
            }
            return courseList;
        }

    }
}