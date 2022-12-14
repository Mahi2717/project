using Airticket.Data;
using Airticket.Models;
using Airticket.Service;
using Airticket.UserCred;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users1Controller : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly TicketDbContext _context;
        public Users1Controller(TicketDbContext context, ILoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(Login user)
        {
            var result = _loginService.login(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Invalid userName or Password");
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(User user)
        {
            var result = _loginService.Register(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Not able to register");
        }
    }
}

