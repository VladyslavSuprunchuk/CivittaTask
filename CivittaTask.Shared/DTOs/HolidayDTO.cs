using System.Text.Json.Serialization;

namespace CivittaTask.Shared.DTOs
{
    public class HolidayDTO
    {
        [JsonPropertyName("date")]
        public HolidayDateDTO Date { get; set; }

        [JsonPropertyName("name")]
        public List<HolidayNameDTO> Name { get; set; }

        [JsonPropertyName("holidayType")]
        public string HolidayType { get; set; }
    }
}
