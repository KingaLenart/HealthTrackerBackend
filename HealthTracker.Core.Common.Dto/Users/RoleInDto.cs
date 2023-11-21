using HealthTrackerApp.Core.Models.Users;

namespace HealthTracker.Core.Common.Dto.Users
{
    public class RoleInDto
    {
        public Guid UserId { get; set; }
        public Role Role { get; set; }
    }
}
