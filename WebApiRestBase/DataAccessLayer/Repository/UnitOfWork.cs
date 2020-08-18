using DataAccessLayer.EF;
using System;
using System.Data.Entity;

namespace DataAccessLayer.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DbContext context;
        private GenericRepository<User> userRepository;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
