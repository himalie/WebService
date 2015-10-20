using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace InventWebService.Models
{
    public class InventoryPartInStockRepository : IRepository<InvPartInStock>
    {
        InventEntities dbContext_;
        public InventoryPartInStockRepository()
        {
            dbContext_ = new InventEntities();
        }
        public bool Insert(InvPartInStock entity)
        {
            try
            {
                dbContext_.InvPartInStocks.Add(entity);
                dbContext_.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(InvPartInStock entity)
        {
            return true;
        }
        public bool Delete(InvPartInStock entity)
        {
            return true;
        }

        public List<InvPartInStock> SearchFor(Expression<Func<InvPartInStock, bool>> predicate)
        {
            return dbContext_.InvPartInStocks.Where(predicate).ToList();
            //return collection
            //    .AsQueryable<TEntity>()
            //        .Where(predicate.Compile())
            //            .ToList();
        }
        public List<InvPartInStock> GetAll()
        {
            try
            {
                return dbContext_.InvPartInStocks.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public InvPartInStock GetById(string id)
        {
            try
            {
                return dbContext_.InvPartInStocks.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}