using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCASPDOTNETCODEFIRST.Repository
{
    public interface IGenericRepository<T> where T : class  
    {

       

        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
       

        // other data access methods could also be included.

        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
    }
}
