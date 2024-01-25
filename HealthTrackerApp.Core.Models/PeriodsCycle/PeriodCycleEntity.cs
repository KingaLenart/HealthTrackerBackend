using HealthTrackerApp.Core.Models.Users;

namespace HealthTrackerApp.Core.Models.PeriodsCycle
{
    public class PeriodCycleEntity : IDateEntity
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        
        public DateTime PeriodStartDate { get; set; }
        public bool? IsFirstPeriod { get; set; }
        public DateTime? PeriodFinishiDate { get; set; }
        
        public long? PeriodCycleLenght { get; set; }
        public long? MenstruationLength { get; set; }
        
    }
}


