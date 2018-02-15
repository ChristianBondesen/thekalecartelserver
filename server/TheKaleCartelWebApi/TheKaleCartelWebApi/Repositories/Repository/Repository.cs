using System;
using System.Linq;
using System.Linq.Expressions;
using TheKaleCartelWebApi.Data;

namespace TheKaleCartelWebApi.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly KaleDbContext _context;

        public Repository(KaleDbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual T Get(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Single(match);
        }

        public virtual void Add(T t)
        {
            _context.Set<T>().Add(t);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
