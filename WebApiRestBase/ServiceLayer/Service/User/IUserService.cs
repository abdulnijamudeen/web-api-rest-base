using ServiceLayer.Form;

namespace ServiceLayer.Service.User
{
    public interface IUserService
    {
        DataAccessLayer.EF.User GetUserByUsername(string username);
        DataAccessLayer.EF.User AddUser(SignUp signUp);
    }
}
