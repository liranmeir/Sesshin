using System;
using System.Linq;
using System.Linq.Expressions;
using Sesshin.Model;

namespace Sesshin.DAL
{
    public interface IProductRepository : IDisposable
    {
        IQueryable<Product> All { get; }
        IQueryable<Product> AllIncluding(params Expression<Func<Product, object>>[] includeProperties);
        Product Find(int id);
        void InsertOrUpdate(Product product);
        void Delete(int id);
        void Save();
    }
}