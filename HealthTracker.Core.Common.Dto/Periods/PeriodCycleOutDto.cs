namespace HealthTracker.Core.Common.Dto.Periods
{
    public class PeriodCycleOutDto
    {
        public Guid Id { get; set; }
        public bool? IsFirstPeriod { get; set; }
        public DateTime PeriodFinishiDate { get; set; }
        public TimeSpan PeriodCycleLenght { get; set; }
       
    }
}
