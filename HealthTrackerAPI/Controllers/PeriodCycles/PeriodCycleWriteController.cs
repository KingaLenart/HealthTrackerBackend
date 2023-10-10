using HealthTracker.Core.Common.Dto.Periods;
using HealthTrackerApp.Core.Services.PeriodCycle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthTrackerAPI.Controllers.PeriodCycles
{
    [Route("api/periodCycle")]
    [Authorize]
    public class PeriodCycleWriteController : ControllerBase
    {
        private readonly PeriodCycleWriteService periodCycleWriteService;

        public PeriodCycleWriteController(PeriodCycleWriteService periodCycleWriteService)
        {
            this.periodCycleWriteService = periodCycleWriteService;
        }

        [HttpPost]
        public async Task <PeriodCycleOutDto> AddPeriod([FromBody] PeriodCycleInDto periodCycleInDto)
        {
            return await periodCycleWriteService.PeriodCycleCreate(periodCycleInDto);
        }
    }
}
