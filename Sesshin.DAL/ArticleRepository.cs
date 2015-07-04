using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Sesshin.Model;

namespace Sesshin.DAL
{ 
    public class ArticleRepository : IArticleRepository
    {
        SesshinAdminContext context = new SesshinAdminContext();

        public IQueryable<Article> All
        {
            get { return context.Articles; }
        }

        public IQueryable<Article> AllIncluding(params Expression<Func<Article, object>>[] includeProperties)
        {
            IQueryable<Article> query = context.Articles;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }
         
        public Article Find(string englishName)
        {
            return context.Articles.SingleOrDefault(a=>a.EnglishName == englishName);
        }

        public Article Find(int id)
        {
            return context.Articles.Find(id);
        }

        public void InsertOrUpdate(Article article)
        {
            article.DateCreated = DateTime.Now;

            if (article.ID == default(int)) {
                // New entity
                context.Articles.Add(article);
            } else {
                // Existing entity
                context.Entry(article).State = EntityState.Modified;
            }
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
            var article = context.Articles.Find(id);
            context.Articles.Remove(article);
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

    public interface IArticleRepository : IDisposable
    {
        IQueryable<Article> All { get; }
        IQueryable<Article> AllIncluding(params Expression<Func<Article, object>>[] includeProperties);
        Article Find(int id);
        void InsertOrUpdate(Article article);
        void Delete(int id);
        void Save();
    }
}