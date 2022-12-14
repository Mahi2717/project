using Airticket.Models;
using Airticket.UserCred;

namespace Airticket.Service
{
    public interface ILoginService
    {
        Login login(Login userCreds);
        Login Register(User user);
    }
}
