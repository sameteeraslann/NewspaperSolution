using NewspaperSolution.EntityLayer.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSolution.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);

        T GetById(int id);

    }
}
