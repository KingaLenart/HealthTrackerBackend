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

        public bool? TerminationOfPregnancy { get; set; }
        public DateTime? TerminationOfPregnancyDate { get; set; }
        public bool? Abortion { get; set; }
        public bool? Miscarriage { get; set; }

        public bool IsPregnancyFinish { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Name { get; set; }
    }
}
