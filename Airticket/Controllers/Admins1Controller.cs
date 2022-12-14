using Airticket.AdminCred;
using Airticket.Data;
using Airticket.Models;
using Airticket.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admins1Controller : ControllerBase
    {

private readonly IAdminLoginService _adminloginService;
        private readonly TicketDbContext _context;

        public Admins1Controller(TicketDbContext context, IAdminLoginService adminloginService)
        {
            _context = context;
            _adminloginService = adminloginService;

        }

        [HttpPost]
        [Route("Login")]
        public ActionResult AdminLogin(AdminLogin admin)
        {
            var result = _adminloginService.adminlogin(admin);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Invalid adminName or Password");
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(Admin admin)
        {
            var result = _adminloginService.Register(admin);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Not able to register");
        }
    }
}
