﻿using NewspaperSolution.EntityLayer.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSolution.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        void Add(T item);
        void Update(T item);
        void Remove(int id); //Passive duruma düşürür.
        
        T GetById(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);
       
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetAll();
        List<T> GetPassive();

        bool Any(Expression<Func<T, bool>> exp);

        int Save();

    }
}
