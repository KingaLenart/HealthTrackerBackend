namespace HealthTracker.Core.Common.Dto.Users
{
    public class UserAuthenticateOutDto
    {
        public string Email { get; set; }
        public string AccesToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
