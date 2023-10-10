using AutoMapper;
using HealthTracker.Core.Common.Dto.Periods;
using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Models.PeriodsCycle;

namespace HealthTracker.Core.Common.Mappers.Users
{
    public class AutoMapMapper : Profile
    {
        public AutoMapMapper()
        {
            CreateMap<UserAuthenticateOutDto, UserRegisterInDto>();
            CreateMap<PeriodCycleOutDto, PeriodCycleInDto>();
            CreateMap<PeriodCycleOutDto, PeriodCycleEntity>();
            CreateMap<PeriodCycleEntity, PeriodCycleOutDto>();
        }
    }
}
