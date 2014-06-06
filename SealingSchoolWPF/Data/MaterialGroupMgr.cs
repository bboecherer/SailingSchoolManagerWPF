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
    public class MaterialGroupMgr : IPersistenceMgr<MaterialGroup>
    {
        public IList<MaterialGroup> MaterialGroups { get; set; }

        public IList<MaterialGroup> GetAll()
        {
            MaterialGroups = new List<MaterialGroup>();

            using (var ctx = new SchoolDataContext())
            {
                foreach (MaterialGroup i in ctx.MaterialGroups)
                {
                   
                    MaterialGroups.Add(i);
                }
            }
            return MaterialGroups;
        }

        public void Delete(MaterialGroup entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.MaterialGroups.Attach(entity);
                ctx.MaterialGroups.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(MaterialGroup entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    ctx.MaterialGroups.Add(entity);
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

        public void Update(MaterialGroup entity)
        {
            throw new NotImplementedException();
        }

        public MaterialGroup GetById(int id)
        {
            MaterialGroup MaterialGroup;
            using (var ctx = new SchoolDataContext())
            {
                MaterialGroup = ctx.MaterialGroups.Find(id);
            }
            return MaterialGroup;
        }
    }
}