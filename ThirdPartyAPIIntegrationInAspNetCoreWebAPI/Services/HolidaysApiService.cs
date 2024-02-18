using System.Text.Json;
using ThirdPartyAPIIntegrationInAspNetCoreWebAPI.Interfaces;
using ThirdPartyAPIIntegrationInAspNetCoreWebAPI.Model;

namespace ThirdPartyAPIIntegrationInAspNetCoreWebAPI.Services
{
    public class HolidaysApiService : IHolidaysApiService
    {
        public static readonly HttpClient client;

        static HolidaysApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://date.nager.at/")
            };
        }

        public async Task<IEnumerable<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            try
            {
                var url = string.Format("api/v2/PublicHolidays/{0}/{1}", year, countryCode);
                var result = new List<HolidayModel>();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var StringResponse = await response.Content.ReadAsStringAsync();
                    
                    result = JsonSerializer.Deserialize<List<HolidayModel>>(StringResponse,new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }

                return result;
            }
            catch (Exception)
            {
                throw new Exception("Error while fetching data from the API");
            }
            
        }
    }
}
