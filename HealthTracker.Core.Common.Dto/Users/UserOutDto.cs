namespace HealthTracker.Core.Common.Dto.Users
{
    public class UserOutDto
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float Weight { get; set; }
        public float Heights { get; set; }
    }
}
