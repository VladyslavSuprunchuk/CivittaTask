using System.Text.Json.Serialization;

namespace CivittaTask.Shared.DTOs
{
    public class CountryDTO
    {
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("regions")]
        public List<string> Regions { get; set; }

        [JsonPropertyName("holidayTypes")]
        public List<string> HolidayTypes { get; set; }

        [JsonPropertyName("fromDate")]
        public CountryDateDTO FromDate { get; set; }

        [JsonPropertyName("toDate")]
        public CountryDateDTO ToDate { get; set; }
    }
}
