using HealthTrackerApp.Core.Models.Users;

namespace HealthTracker.Core.Common.Dto.Users
{
    public class UserRegisterInDto
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }

    }
}
