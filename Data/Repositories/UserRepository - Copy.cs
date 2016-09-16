using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.GenericRepo;
using NewsApp.Models;
using NewsApp.Models.Enums;

namespace Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        UserRole GetUserRole(int id);
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public NewsContext NewsContext
        {
            get
            {
                return Context as NewsContext;
            }
        }

        public UserRepository(NewsContext context) : base(context) { }


        public UserRole GetUserRole(int id)
        {
            return Get(id).Role;
        }
    }
}
