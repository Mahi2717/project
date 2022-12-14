using Airticket.Models;
using System.Collections.Generic;

namespace Airticket.Service
{
    public interface IAdminService
    {
        List<Admin> GetAllAdmin();
        Admin AddAdmin(Admin user);
    }
}
