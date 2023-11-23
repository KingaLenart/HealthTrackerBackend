namespace HealthTracker.Core.Common.Dto.Pregnancies
{
    public class TerminationOfPregnancyInDto
    {
        public Guid Id { get; set; }
        public bool? TerminationOfPregnancy { get; set; }
        public DateTime? TerminationOfPregnancyDate { get; set; }
        public bool? Abortion { get; set; }
        public bool? Miscarriage { get; set; }
    }
}
