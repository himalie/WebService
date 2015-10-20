using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace InventWebService.Models
{
    public interface IRepository<TEntity>
    {
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        List<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        TEntity GetById(string id);
    }
}