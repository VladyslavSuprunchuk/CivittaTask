using System.Text.Json.Serialization;

namespace CivittaTask.Shared.DTOs
{
    public class HolidayDateDTO : CountryDateDTO
    {
        [JsonPropertyName("dayOfWeek")]
        public int DayOfWeek { get; set; }
    }
}
