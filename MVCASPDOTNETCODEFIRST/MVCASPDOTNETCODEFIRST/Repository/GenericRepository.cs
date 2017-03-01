using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVCASPDOTNETCODEFIRST.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        
        private DbSet<T> _entitySet;
        private readonly MyDbContext _context;
        

        public GenericRepository(MyDbContext context)
        {
            _context = new MyDbContext();
            _entitySet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entitySet;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            return _entitySet.Where(where);
        }

        public void Add(T entity)
        {
            _entitySet.Add(entity);
        }

        public void Attach(T entity)
        {
            _entitySet.Attach(entity);
        }

        public void Delete(T entity)
        {
            _entitySet.Remove(entity);
        }

        

       
    }
}