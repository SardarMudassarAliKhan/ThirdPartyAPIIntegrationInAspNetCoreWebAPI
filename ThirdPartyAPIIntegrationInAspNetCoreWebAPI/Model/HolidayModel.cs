namespace ThirdPartyAPIIntegrationInAspNetCoreWebAPI.Model
{
    public class HolidayModel
    {
        public string? Date { get; set; }

        public string? LocalName { get; set; }

        public string? Name { get; set; }

        public string? CountryCode { get; set; }

        public bool @Fixed { get; set; }

        public bool Global { get; set; }

        public List<string> Counties { get; set; }

        public int? LaunchYear { get; set; }

        public string? Type { get; set; }
    }
}
