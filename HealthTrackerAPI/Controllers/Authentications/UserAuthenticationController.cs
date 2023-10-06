using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HealthTrackerAPI.Controllers.Authentications
{
    [Route("api/authorization")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly UserAuthenticationService userAuthenticationService;

        public UserAuthenticationController(UserAuthenticationService userAuthenticationService)
        {
            this.userAuthenticationService = userAuthenticationService;
        }

        [HttpPost("authenticate")]
        public Task<UserAuthenticateOutDto> Authenticate([FromBody] UserAuthenticateInDto userInDto)
        {
            return userAuthenticationService.AuthenticateUserAndGenerateTokens(userInDto);
        }

        [HttpPost("refreshToken")]
        public Task<UserAuthenticateOutDto> RefreshToken([FromBody] RefreshTokenInDto refreshToken)
        {
            return userAuthenticationService.ValidateAndGenerateTokens(refreshToken.RefreshToken);
        }

    }
}
