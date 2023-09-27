namespace HealthTrackerApp.Core.Models.Authentication
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public int JwtExpireTime { get; set; }
    }
}
