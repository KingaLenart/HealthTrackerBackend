using AutoMapper;
using HealthTracker.Core.Common.Dto.Users;

namespace HealthTracker.Core.Common.Mappers.Users
{
    internal class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserAuthenticateOutDto, UserRegisterInDto>();
        }
    }
}
