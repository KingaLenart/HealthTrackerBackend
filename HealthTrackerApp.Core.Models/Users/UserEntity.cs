using HealthTrackerApp.Core.Models.Authentication;
using HealthTrackerApp.Core.Models.PeriodsCycle;
using HealthTrackerApp.Core.Models.PhysicalActivities;
using HealthTrackerApp.Core.Models.Pregnancies;

namespace HealthTrackerApp.Core.Models.Users
{
    public class UserEntity : IDateEntity
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        
        public Gender Gender { get; set; }
        
        public string Password { get; set; }
        public string ForgotPasswordToken { get; set; }

        public List <string> RefreshTokens { get; set; }

        public DateTime DateOfBirth { get; set; }
        public float Weight { get; set; }
        public float Heights { get; set; }
        
        public ICollection<PeriodCycleEntity>? PeriodsCycle { get; set; }
 
        public bool IsPregnant { get; set; }
        public ICollection<PregnancyEntity>? Pregnancy { get; set; }

        public ICollection<PhysicalActivitieEntity>? PhysicalActivities { get; set; }
    }

    public enum Gender
    {
        Woman,
        Man
    }
}
