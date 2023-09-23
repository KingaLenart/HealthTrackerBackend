﻿using HealthTrackerApp.Core.Models.Users;

namespace HealthTrackerApp.Core.Models.PhysicalActivities
{
    public class PhysicalActivitieEntity :IDateEntity
    {
        public Guid Id { get; set; }
        public virtual TypeOfPhysicalActivityEntity TypeOfPhysicalActivity { get; set; }
        public DateTime TrainingDay { get; set; }
        public TimeSpan TrainingLength { get; set; }
        public int CaloriesBurned { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        
    }
}
