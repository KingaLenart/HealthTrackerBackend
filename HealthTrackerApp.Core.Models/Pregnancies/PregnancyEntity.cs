using HealthTrackerApp.Core.Models.Users;

namespace HealthTrackerApp.Core.Models.Pregnancies
{
    public class PregnancyEntity : IDateEntity
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public DateTime? Conceiving { get; set; } 
        public DateTime? DueDate { get; set; }
        public bool? IsGirl { get; set; }
    }
}
