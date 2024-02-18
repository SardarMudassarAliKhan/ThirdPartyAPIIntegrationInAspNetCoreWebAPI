using ThirdPartyAPIIntegrationInAspNetCoreWebAPI.Model;

namespace ThirdPartyAPIIntegrationInAspNetCoreWebAPI.Interfaces
{
    public interface IHolidaysApiService
    {
        Task<IEnumerable<HolidayModel>> GetHolidays(string countryCode, int year);
    }
}
