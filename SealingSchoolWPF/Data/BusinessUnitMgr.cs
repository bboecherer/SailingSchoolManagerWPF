using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    public class BusinessUnitMgr : IPersistenceMgr<BusinessUnit>
    {
        public IList<BusinessUnit> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(BusinessUnit entity)
        {
            using (var ctx = new SchoolDataContext())
            {
                ctx.BusinessUnits.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Create(BusinessUnit entity)
        {
            throw new NotImplementedException();
        }

        public void Update(BusinessUnit entity)
        {
            throw new NotImplementedException();
        }

        public BusinessUnit GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal BusinessUnit GetBu()
        {
            BusinessUnit bu = null;
            using (var ctx = new SchoolDataContext())
            {
                try
                {
                    bu = ctx.BusinessUnits.FirstOrDefault<BusinessUnit>();
                }
                catch (Exception )
                { }

            }
            return bu;
        }
    }
}
