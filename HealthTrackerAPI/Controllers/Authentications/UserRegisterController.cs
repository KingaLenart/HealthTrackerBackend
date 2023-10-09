using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HealthTrackerAPI.Controllers.Authentications 
{
    [Route("api/register")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly UserRegisterService userRegisterService;

        public UserRegisterController(UserRegisterService userRegisterService)
        {
            this.userRegisterService = userRegisterService;
        }

        [HttpPost]
        public async Task<UserAuthenticateOutDto> Register([FromBody] UserRegisterInDto userRegistrationInDto)
        {
             return await userRegisterService.UserRegister(userRegistrationInDto); 
        }
    }
}

