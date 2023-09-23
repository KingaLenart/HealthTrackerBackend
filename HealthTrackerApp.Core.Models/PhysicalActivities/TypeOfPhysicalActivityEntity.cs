namespace HealthTrackerApp.Core.Models.PhysicalActivities
{
    public class TypeOfPhysicalActivityEntity : IDateEntity
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public static class RoleIds
    {
        public const int Walking = 1;
        public const int Riding = 2;
        public const int Running = 3;
        public const int Dancing = 4;
        public const int Swimming = 5;  
        public const int PlayingTennis = 6;
        
    }
}

