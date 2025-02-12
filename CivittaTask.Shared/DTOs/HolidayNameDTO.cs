using System.Text.Json.Serialization;

namespace CivittaTask.Shared.DTOs
{
    public class HolidayNameDTO
    {
        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
