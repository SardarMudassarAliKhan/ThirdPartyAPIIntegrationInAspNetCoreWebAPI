using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThirdPartyAPIIntegrationInAspNetCoreWebAPI.Interfaces;
using ThirdPartyAPIIntegrationInAspNetCoreWebAPI.Model;

namespace ThirdPartyAPIIntegrationInAspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidaysApiService _holidaysApiService;

        public HolidaysController(IHolidaysApiService holidaysApiService)
        {
            _holidaysApiService = holidaysApiService;
        }

        [HttpGet]
        public async Task<IEnumerable<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            return await _holidaysApiService.GetHolidays(countryCode, year);
        }
    }
}
