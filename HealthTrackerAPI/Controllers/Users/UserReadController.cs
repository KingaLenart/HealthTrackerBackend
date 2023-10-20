using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthTrackerAPI.Controllers.Users
{
    [Route("api/users")]
    [Authorize]
    public class UserReadController : ControllerBase
    {
        private readonly UserReadService userReadService;

        public UserReadController(UserReadService userReadService)
        {
            this.userReadService = userReadService;
        }

        [HttpGet]
        public async Task<List<UserOutDto>> GetAllUsersAsync()
        {
            return await userReadService.GetAllUsersAsync();
        }
    }
}
