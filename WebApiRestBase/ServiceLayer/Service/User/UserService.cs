using DataAccessLayer.Repository;
using ServiceLayer.Form;
using ServiceLayer.Utility;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Web.Helpers;

namespace ServiceLayer.Service.User
{
    public class UserService : IUserService, IDisposable
    {
        private UnitOfWork unitOfWork;
        private bool disposedValue;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public DataAccessLayer.EF.User GetUserByUsername(string username) 
            => unitOfWork.UserRepository.Get().AsQueryable().FirstOrDefault(u => u.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase));

        public DataAccessLayer.EF.User AddUser(SignUp signUp)
        {
            var existingUser = GetUserByUsername(signUp.Username);
            if (existingUser == null)
            {
                var user = new DataAccessLayer.EF.User();
                user.Name = signUp.Name;
                user.Username = signUp.Username;
                user.PasswordHash = Crypto.HashPassword(signUp.Password); //TODO: var verified = Crypto.VerifyHashedPassword(hash, "foo");
                user.Role = signUp.Role; // TODO: Chech with Enum

                unitOfWork.UserRepository.Insert(user);
                unitOfWork.Save();
                return user;
            }
            throw new InvalidCredentialException("User Not Found"); // TODO: Handle Exception
        }

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
