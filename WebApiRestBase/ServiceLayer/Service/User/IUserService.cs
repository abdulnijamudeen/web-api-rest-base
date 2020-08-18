using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.User
{
    interface IUserService
    {
        DataAccessLayer.EF.User GetUserByUsername(string username);
    }
}
