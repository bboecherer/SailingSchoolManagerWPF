using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    /// <summary>
    /// Entity Manager for Boats
    /// </summary>
    public class BoatMgr : IPersistenceMgr<Boat>
    {
        /// <summary>
        /// Gets or sets the boats.
        /// </summary>
        /// <value>
        /// The boats.
        /// </value>
        public IList<Boat> Boats { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList of Boats</returns>
        public IList<Boat> GetAll()
        {
            Boats = new List<Boat>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (Boat i in ctx.Boats)
                {
                    if (i.BoatTyp != null)
                    {
                        ctx.BoatTyps.Attach(i.BoatTyp);
                    }
                    Boats.Add(i);
                }
            }
            return Boats;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Boat entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.Boats.Attach(entity);
                ctx.Boats.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(Boat entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    if (entity.BoatTyp != null)
                    {
                        BoatTyp bt = ctx.BoatTyps.Find(entity.BoatTyp.BoatTypID);
                        ctx.BoatTyps.Attach(bt);
                        ctx.Entry(bt).State = EntityState.Unchanged;
                        entity.BoatTyp = bt;
                    }
                    ctx.Boats.Add(entity);
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
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Boat entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                Boat original = ctx.Boats.Find(entity.BoatID);
                original.Name = entity.Name;
                original.MaterialStatus = entity.MaterialStatus;
                original.Price = entity.Price;
                original.RepairAction = entity.RepairAction;
                original.Brand = entity.Brand;
                original.Currency = entity.Currency;
                original.AdditionalInfo = entity.AdditionalInfo;
                original.SerialNumber = entity.SerialNumber;
                original.CreatedOn = entity.CreatedOn;
                original.ModifiedOn = DateTime.Now;

                if (entity.BoatTyp != null)
                {
                    BoatTyp bt = ctx.BoatTyps.Find(entity.BoatTyp.BoatTypID);
                    ctx.BoatTyps.Attach(bt);
                    ctx.Entry(bt).State = EntityState.Unchanged;
                    entity.BoatTyp = bt;
                    original.BoatTyp = bt;
                }
                if (original != null)
                {
                    try
                    {
                        ctx.Entry(original).State = EntityState.Modified;

                        ctx.ChangeTracker.DetectChanges();
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
                    catch (Exception)
                    { }
                }
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boat</returns>
        public Boat GetById(int id)
        {
            Boat Boat;
            using (var ctx = new SchoolDataContext())
            {
                Boat = ctx.Boats.Find(id);
            }
            return Boat;
        }
    }
}