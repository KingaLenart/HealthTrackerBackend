using HealthTracker.Core.Common.Dto.Pregnancies;
using HealthTrackerApp.Core.Services.Pregnancies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthTrackerAPI.Controllers.Pregnancies
{
    [Route("api/pregnancy")]
    [Authorize]
    public class PregnancyWriteController : ControllerBase
    {
        private readonly PregnancyWriteService pregnancyWriteService;

        public PregnancyWriteController(PregnancyWriteService pregnancyWriteService)
        {
            this.pregnancyWriteService = pregnancyWriteService;
        }

        [HttpPost]
        public async Task AddPregnancy([FromBody] PregnancyInDto pregnancyInDto)
        {
            await pregnancyWriteService.PregnancyCreate(pregnancyInDto);
        }

        [HttpPut("update")]
        public async Task UpdatePregnancy([FromBody] PregnancyInDto pregnancyInDto)
        {
            await pregnancyWriteService.PregnancyUpdate(pregnancyInDto);
        }

        [HttpDelete("{id}")]
        public async Task DeletePregnancy(Guid id)
        {
            await pregnancyWriteService.PregnancyDelete(id);
        }

        [HttpPut("termination")]
        public async Task StopPregnancy([FromBody] TerminationOfPregnancyInDto terminationOfPregnancyInDto)
        {
            await pregnancyWriteService.TerminationOfPregnancy(terminationOfPregnancyInDto);
        }
    }
}
