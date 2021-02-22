using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        //List<T> GetById(int id);

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetById(int id);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
