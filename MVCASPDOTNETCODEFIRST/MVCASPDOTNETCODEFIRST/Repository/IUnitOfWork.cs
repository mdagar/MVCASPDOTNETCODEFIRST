using MVCASPDOTNETCODEFIRST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVCASPDOTNETCODEFIRST.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> RepositoryFor<T>() where T : class;
        void SaveChanges();

    }
}
