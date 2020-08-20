using DataAccessLayer.EF;
using ServiceLayer.Form;
using ServiceLayer.Form.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapper
{
    public class AuthMapper
    {
        public static UserDetailsClaim UserDetailsClaimMap(User user)
        {
            return new UserDetailsClaim()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Role = user.Role
            };
        }

        public static LoginRes LoginMap(User user, string token)
        {
            return new LoginRes()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Role = user.Role,
                Token = token
            };
        }
    }
}
