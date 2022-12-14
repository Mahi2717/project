using Airticket.AdminCred;
using Airticket.Models;
using System.Collections.Generic;
using System.Linq;

namespace Airticket.Service
{
    public class AdminLoginService : IAdminLoginService
    {
        private readonly IAdminService _adminService;
        private readonly ITokenGeneration _tokenGeneration;
        public AdminLoginService(IAdminService adminService, ITokenGeneration tokenGeneration)
        {
            _adminService = adminService;
            _tokenGeneration = tokenGeneration;
        }
        public AdminLogin adminlogin(AdminLogin adminCreds)
        {
            var admin = _adminService.GetAllAdmin().FirstOrDefault(u => u.Email == adminCreds.Email);
            if (admin != null)
            {



                if (admin.Password != adminCreds.Password)
                {
                    return null;
                }
                adminCreds.Password = admin.Password;
                adminCreds.token = _tokenGeneration.GenerateToken(adminCreds);
                return adminCreds;
            }
            return null;
        }
        public AdminLogin Register(Admin admin)
        {



            var adminDetails = _adminService.AddAdmin(admin);
            if (adminDetails != null)
                return new AdminLogin
                {
                    Email = admin.Email,
                    token = _tokenGeneration.GenerateToken(new AdminLogin { Email = admin.Email })
                };
            return null;
        }
    }

}

