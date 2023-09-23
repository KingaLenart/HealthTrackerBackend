using HealthTrackerApp.Core.Models.Users;


namespace HealthTrackerApp.Core.Models.Diets
{
    public class DietEntity : IDateEntity
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }   

        
    }
}
