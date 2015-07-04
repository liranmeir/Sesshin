using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Sesshin.Model;

namespace Sesshin.DAL
{ 
    public class ProductRepository : IProductRepository
    {
        SesshinAdminContext context = new SesshinAdminContext();

        public IQueryable<Product> All
        {
            get { return context.Products; }
        }

        public IQueryable<Product> AllIncluding(params Expression<Func<Product, object>>[] includeProperties)
        {
            IQueryable<Product> query = context.Products;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Product Find(int id)
        {
            return context.Products.Find(id);
        }

        public Product Find(string englishName)
        {
            return context.Products.SingleOrDefault(p=>p.EnglishName == englishName);
        }

        public void InsertOrUpdate(Product product)
        {
            product.DateModified = DateTime.Now;
            

            if (product.Id == default(int)) {
                // New entity
                
                context.Products.Add(product);
            } else {
                // Existing entity
                
                context.Entry(product).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }
}