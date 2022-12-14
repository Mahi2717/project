using Airticket.AdminCred;
using Airticket.Models;

namespace Airticket.Service
{
    public interface IAdminLoginService
    {
        AdminLogin adminlogin(AdminLogin adminCreds);
        AdminLogin Register(Admin admin);
    }
}
