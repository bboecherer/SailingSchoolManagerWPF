using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    /// <summary>
    /// Entity Manager for InfoBox
    /// </summary>
    public class InfoBoxMgr
    {

        /// <summary>
        /// Gets or sets the boxes.
        /// </summary>
        /// <value>
        /// The boxes.
        /// </value>
        public IList<InfoBox> Boxes { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IList<InfoBox></returns>
        public IList<InfoBox> GetAll()
        {
            Boxes = new List<InfoBox>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (InfoBox i in ctx.InfoBoxes)
                {
                    Boxes.Add(i);
                }
            }
            return Boxes;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(InfoBox entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.InfoBoxes.Remove(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(InfoBox entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.InfoBoxes.Add(entity);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(InfoBox entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                InfoBox original = ctx.InfoBoxes.Find(entity.Id);

                if (original != null)
                {
                    ctx.Entry(original).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                }
            }
        }
    }
}