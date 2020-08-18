using DataAccessLayer.Repository;
using System;
using System.Linq;

namespace ServiceLayer.Service.User
{
    class UserService : IUserService, IDisposable
    {
        private UnitOfWork unitOfWork;
        private bool disposedValue;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public DataAccessLayer.EF.User GetUserByUsername(string username) 
            => unitOfWork.UserRepository.Get().AsQueryable().FirstOrDefault(u => u.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase));

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    unitOfWork.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UserService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
