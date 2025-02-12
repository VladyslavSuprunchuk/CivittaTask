using System.Text.Json.Serialization;

namespace CivittaTask.Shared.DTOs
{
    public class CountryDateDTO
    {
        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("month")]
        public int Month { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}
