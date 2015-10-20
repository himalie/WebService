using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace InventWebService.Models
{
    public class InventoryPartRepository : IRepository<InventoryPart>
    {
        InventEntities dbContext_;
        public InventoryPartRepository()
        {
            dbContext_  = new InventEntities();
        }
        public bool Insert(InventoryPart entity)
        {
            try
            {
                dbContext_.InventoryParts.Add(entity);
                dbContext_.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                 return false;
            }
        }
        public bool Update(InventoryPart entity)
        {
            return true;
        }
        public bool Delete(InventoryPart entity)
        {
            return true;
        }

        public List<InventoryPart> SearchFor(Expression<Func<InventoryPart, bool>> predicate)
        {
            return dbContext_.InventoryParts.Where(predicate).ToList();
            //return collection
            //    .AsQueryable<TEntity>()
            //        .Where(predicate.Compile())
            //            .ToList();
        }
        public List<InventoryPart> GetAll()
        {
            try {
                return dbContext_.InventoryParts.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public InventoryPart GetById(string id)
        {
            try
            {
                return dbContext_.InventoryParts.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}