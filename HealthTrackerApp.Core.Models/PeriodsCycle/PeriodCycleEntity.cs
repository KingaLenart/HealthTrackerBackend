using HealthTrackerApp.Core.Models.Users;

namespace HealthTrackerApp.Core.Models.PeriodsCycle
{
    public class PeriodCycleEntity : IDateEntity
    {
        public Guid Id { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public bool? IsFirstPeriod { get; set; }
        public DateTime PeriodFinishiDate { get; set; }
        
        public int PeriodCycleLenght { get; set; }
        public int MenstruationLength { get; set; }
        
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}


