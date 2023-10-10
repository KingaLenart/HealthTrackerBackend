namespace HealthTracker.Core.Common.Dto.Periods
{
    public class PeriodCycleInDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public bool? IsFirstPeriod { get; set; }
        public DateTime PeriodFinishiDate { get; set; }
    }
}
    