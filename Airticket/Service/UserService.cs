using Airticket.Models;
using System.Collections.Generic;
using System;
using Airticket.Data;
using System.Linq;

namespace Airticket.Service
{
    public class UserService : IUserService
    {
        private readonly TicketDbContext _ticketDbContext;
        public UserService(TicketDbContext ticketDbContext)
        { _ticketDbContext = ticketDbContext; }
        public User AddUser(User user)
        {
            try
            {
                _ticketDbContext.User.Add(user); _ticketDbContext.SaveChanges();
                return user;
            }
            catch (Exception) { throw; }



        }
        public List<User> GetAllUser()
        {
            if (_ticketDbContext.User.Count() > 0)
                return _ticketDbContext.User.ToList();
            return null;
        }
    }
}
