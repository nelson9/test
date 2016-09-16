using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Models.Enums;
using System.Web;

namespace NewsApp.Services
{
    public interface IUserService
    {
        UserRole GetUserRole();
    }

    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserRole GetUserRole()
        {
            var userId = HttpContext.Current.Request.Cookies["userId"].Value;

            if (userId != null)
            {
                return _userRepository.GetUserRole(Int32.Parse(userId));
            }
            return UserRole.Annonymous;
        }

    }
}
