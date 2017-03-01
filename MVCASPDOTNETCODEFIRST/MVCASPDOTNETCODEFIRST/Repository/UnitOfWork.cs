using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCASPDOTNETCODEFIRST.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MyDbContext _context;

        

        public UnitOfWork()
        {
            
            _context = new MyDbContext();
        }


       

        public IGenericRepository<T> RepositoryFor<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}