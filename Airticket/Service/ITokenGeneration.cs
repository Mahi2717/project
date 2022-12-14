using Airticket.AdminCred;
using Airticket.UserCred;

namespace Airticket.Service
{
    public interface ITokenGeneration
    {
        public string GenerateToken(Login userCreds);
        string GenerateToken(AdminLogin adminLogin);
    }
}
