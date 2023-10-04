namespace HealthTrackerApp.Core.Models.Authentication
{
    public class AuthenticationSettings
    {
        public const string AuthenticationKey = "Authentication";

        public string JwtKey { get; set; }
        public int JwtExpireTime { get; set; }
    }
}
