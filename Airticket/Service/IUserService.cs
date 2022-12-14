using Airticket.Models;
using System.Collections.Generic;

namespace Airticket.Service
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User AddUser(User user);
    }
}
