using FrontEnd.Models;
using NuGet.Common;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISecurityHelper
    {
        LoginModel GetUser(UserViewModel user);
        TokenModel Login(UserViewModel user);

    }
}
