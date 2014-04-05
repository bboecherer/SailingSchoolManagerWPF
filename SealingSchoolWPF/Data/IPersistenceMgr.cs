using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    interface IPersistenceMgr<T> where T : SealingSchoolObject
    {
        IList<T> GetAll();

        void Delete(T entity);

        void Create(T entity);

        void Update(T entity);

        T GetById(int id);
    }
}