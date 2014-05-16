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
    public class MaterialTypMgr : IPersistenceMgr<MaterialTyp>
    {
        public IList<MaterialTyp> MaterialTyps { get; set; }

        public IList<MaterialTyp> GetAll()
        {
            MaterialTyps = new List<MaterialTyp>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (MaterialTyp i in ctx.MaterialTyps)
                {
                    MaterialTyps.Add(i);
                }
            }
            return MaterialTyps;
        }

        public void Delete(MaterialTyp entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.MaterialTyps.Attach(entity);
                ctx.MaterialTyps.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(MaterialTyp entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.MaterialTyps.Add(entity);
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

        public void Update(MaterialTyp entity)
        {
            throw new NotImplementedException();
        }

        public MaterialTyp GetById(int id)
        {
            MaterialTyp Mat;
            using (var ctx = new SchoolDataContext())
            {
                Mat = ctx.MaterialTyps.Find(id);
            }
            return Mat;
        }
    }
}