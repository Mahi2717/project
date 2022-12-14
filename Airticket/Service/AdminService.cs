using Airticket.Models;
using System.Collections.Generic;
using System;
using Airticket.Data;
using System.Linq;

namespace Airticket.Service
{
    public class AdminService : IAdminService
    {
        private readonly TicketDbContext _ticketDbContext;
        public AdminService(TicketDbContext ticketDbContext)
        { _ticketDbContext = ticketDbContext; }
        public Admin AddAdmin(Admin admin)
        {
            try
            {
                _ticketDbContext.Admin.Add(admin); _ticketDbContext.SaveChanges();
                return admin;
            }
            catch (Exception) { throw; }

        }

        public List<Admin> GetAllAdmin()
        {
            if (_ticketDbContext.Admin.Count() > 0)
                return _ticketDbContext.Admin.ToList();
            return null;
        }
    }
}
