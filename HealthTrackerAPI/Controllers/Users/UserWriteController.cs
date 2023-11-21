using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthTrackerAPI.Controllers.Users
{
    [Route("api/userAccount")]
    [Authorize]
    public class UserWriteController : ControllerBase
    {
        private readonly UserWriteService userWriteService;

        public UserWriteController(UserWriteService userWriteService)
        {
            this.userWriteService = userWriteService;
        }

        [HttpPut]
        public Task UpdateUser([FromBody] UserInDto userInDto)
        {
            return userWriteService.UpdateUserAsync(userInDto);
        }
        
        [HttpPut("givingRole")]
        public Task GivingRole([FromBody] RoleInDto roleInDto)
        {
            return userWriteService.GivingRoleAsync(roleInDto);
        }
    }
}
