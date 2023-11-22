using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class SecurityHelper : ISecurityHelper
    {
        IServiceRepository ServiceRepository;

        public SecurityHelper(IServiceRepository serviceRepository)
        {
                ServiceRepository = serviceRepository;
        }

        public LoginModel GetUser(UserViewModel user)
        {
            HttpResponseMessage responseMessage = ServiceRepository
                .PostResponse("api/Authenticate/getuser", user);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            LoginModel loginModel = JsonConvert.DeserializeObject<LoginModel>(content);
            return loginModel;
        }

        public TokenModel Login(UserViewModel user)
        {
            try
            {
                TokenModel TokenModel;


                HttpResponseMessage responseMessage = ServiceRepository
                    .PostResponse("api/Authenticate/login", new { user.UserName, user.Password });
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                TokenModel = JsonConvert.DeserializeObject<TokenModel>(content);



                return TokenModel;



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
