namespace HealthTrackerApp.Core.Models.Authentication
{
    public class RoleEntity : IDateEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
    }

    public static class RoleEntityIds
    {
        public const int Admin = 1;
        public const int Woman = 2;
        public const int Man = 3;
    }
}
