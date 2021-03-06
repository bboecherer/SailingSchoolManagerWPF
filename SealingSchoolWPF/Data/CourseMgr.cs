﻿using SailingSchoolWPF.Model;
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
    /// Entity Manager for course
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CourseMgr : IPersistenceMgr<Course>
    {
        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public IList<Course> Courses { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList<Course></returns>
        public IList<Course> GetAll()
        {
            Courses = new List<Course>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Course c in ctx.Courses)
                {
                    if (c.Qualifications != null)
                    {
                        foreach (Qualification q in c.Qualifications)
                            ctx.Qualifications.Attach(q);
                    }
                    if (c.CourseMaterialTyps != null)
                    {
                        foreach (CourseMaterialTyp q in c.CourseMaterialTyps)
                        {
                            ctx.CourseMaterialTyps.Attach(q);
                            if (q.MaterialTyp != null)
                            {
                                ctx.MaterialTyps.Attach(q.MaterialTyp);
                            }
                        }

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
        public void Delete(Course entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Courses.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(Course entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    List<Qualification> qualies = new List<Qualification>();

                    if (entity.Qualifications != null)
                    {
                        foreach (Qualification q in entity.Qualifications)
                        {
                            Qualification dummy = ctx.Qualifications.Find(q.QualificationId);
                            ctx.Qualifications.Attach(dummy);
                            ctx.Entry(dummy).State = EntityState.Unchanged;
                            qualies.Add(dummy);
                        }

                        entity.Qualifications.Clear();
                        entity.Qualifications = qualies;
                    }

                    if (entity.BoatTyp != null)
                    {
                        BoatTyp dummy = ctx.BoatTyps.Find(entity.BoatTyp.BoatTypID);
                        ctx.BoatTyps.Attach(dummy);
                        ctx.Entry(dummy).State = EntityState.Unchanged;
                        entity.BoatTyp = dummy;
                    }

                    List<CourseMaterialTyp> matTyp = new List<CourseMaterialTyp>();
                    if (entity.CourseMaterialTyps != null)
                    {
                        foreach (CourseMaterialTyp q in entity.CourseMaterialTyps)
                        {
                            MaterialTyp dummy = ctx.MaterialTyps.Find(q.MaterialTyp.Id);
                            ctx.MaterialTyps.Attach(dummy);
                            ctx.Entry(dummy).State = EntityState.Unchanged;
                            q.MaterialTyp = dummy;
                            matTyp.Add(q);
                        }

                        entity.CourseMaterialTyps.Clear();
                        entity.CourseMaterialTyps = matTyp;
                    }
                    ctx.Courses.Add(entity);
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
        public void Update(Course entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                List<Qualification> dummy = new List<Qualification>();

                if (entity.Qualifications != null)
                {
                    foreach (Qualification q in entity.Qualifications)
                    {
                        Qualification quali = ctx.Qualifications.Find(q.QualificationId);
                        ctx.Entry(quali).State = EntityState.Unchanged;
                        dummy.Add(quali);
                    }
                }

                entity.Qualifications.Clear();

                foreach (Qualification q in dummy)
                {
                    entity.Qualifications.Add(q);
                }

                /*if (entity.CourseMaterialTyps != null)
                {
                    foreach (CourseMaterialTyp m in entity.CourseMaterialTyps)
                    {
                        CourseMaterialTyp matTyp = ctx.CourseMaterialTyps.Find(m.Id);
                        if (matTyp != null)
                        {
                            ctx.Entry(matTyp).State = EntityState.Unchanged;
                        }
                    }
                }*/

                Course original = ctx.Courses.Find(entity.CourseId);
                original.RatingValue = entity.RatingValue;

                if (original != null)
                {
                    original.Qualifications.Clear();
                    foreach (Qualification q in entity.Qualifications)
                    {
                        ctx.Qualifications.Attach(q);
                        ctx.Entry(q).State = EntityState.Unchanged;
                        original.Qualifications.Add(q);
                    }

                    if (entity.BoatTyp != null)
                    {
                        BoatTyp bootDummy = ctx.BoatTyps.Find(entity.BoatTyp.BoatTypID);
                        ctx.BoatTyps.Attach(bootDummy);
                        ctx.Entry(bootDummy).State = EntityState.Unchanged;
                    }

                    /*original.CourseMaterialTyps.Clear();
                    foreach (CourseMaterialTyp m in entity.CourseMaterialTyps)
                    {
                        ctx.CourseMaterialTyps.Add(m);
                        if (m.Id > 0)
                        {
                            ctx.Entry(m).State = EntityState.Unchanged;
                        }
                        original.CourseMaterialTyps.Add(m);
                    }*/
                    ctx.Entry(original).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Course</returns>
        public Course GetById(int id)
        {
            Course course;
            using (var ctx = new SchoolDataContext())
            {
                course = (Course)ctx.Courses.Find(id);
            }
            return course;
        }

    }
}