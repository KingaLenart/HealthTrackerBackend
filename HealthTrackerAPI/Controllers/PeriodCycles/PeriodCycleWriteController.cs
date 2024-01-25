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
        public async Task AddPeriod([FromBody] PeriodCycleInDto periodCycleInDto)
        {
            await periodCycleWriteService.PeriodCycleCreate(periodCycleInDto);
        }

        [HttpPut]
        public Task<PeriodCycleOutDto> UpdatePeriod ([FromBody] PeriodCycleInDto periodCycleInDto)
        {
            return periodCycleWriteService.PeriodCycleUpdate(periodCycleInDto);
        }

        [HttpDelete("{periodId}")]
        public Task DeletePEriod(Guid periodId)
        {
            return periodCycleWriteService.DeleteAsync(periodId);
        }
    }
}
