using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Sesshin.Model;

namespace Sesshin.DAL
{ 
    public class TherapistRepository : ITherapistRepository
    {
        SesshinAdminContext context = new SesshinAdminContext();

        public IQueryable<Therapist> All
        {
            get { return context.Therapists; }
        }

        public IQueryable<Therapist> AllIncluding(params Expression<Func<Therapist, object>>[] includeProperties)
        {
            IQueryable<Therapist> query = context.Therapists;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Therapist Find(int id)
        {
            return context.Therapists.Find(id);
        }

        public void InsertOrUpdate(Therapist therapist)
        {
            if (therapist.Id == default(int)) {
                // New entity
                context.Therapists.Add(therapist);
            } else {
                // Existing entity
                context.Entry(therapist).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var therapist = context.Therapists.Find(id);
            context.Therapists.Remove(therapist);
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

    public interface ITherapistRepository : IDisposable
    {
        IQueryable<Therapist> All { get; }
        IQueryable<Therapist> AllIncluding(params Expression<Func<Therapist, object>>[] includeProperties);
        Therapist Find(int id);
        void InsertOrUpdate(Therapist therapist);
        void Delete(int id);
        void Save();
    }
}