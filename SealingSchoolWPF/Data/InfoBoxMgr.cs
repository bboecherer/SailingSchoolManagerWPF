using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    public class InfoBoxMgr
    {

        public IList<InfoBox> Boxes { get; set; }

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


        public void Delete(InfoBox entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.InfoBoxes.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(InfoBox entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.InfoBoxes.Add(entity);
                ctx.SaveChanges();
            }
        }

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