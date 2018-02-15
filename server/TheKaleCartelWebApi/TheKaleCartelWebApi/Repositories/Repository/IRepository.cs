using System;
using System.Linq;
using System.Linq.Expressions;

namespace TheKaleCartelWebApi.Repositories.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(Expression<Func<T, bool>> match);
        void Add(T t);
        void Save();
    }
}
