namespace HealthTracker.Core.Common.Dto.Pregnancies
{
    public class PregnancyInDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime? Conceiving { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsGirl { get; set; }
    }
}
