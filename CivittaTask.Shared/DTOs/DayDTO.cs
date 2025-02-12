using System.Text.Json.Serialization;

namespace CivittaTask.Shared.DTOs
{
    public class DayDTO
    {
        [JsonPropertyName("isWorkDay")]
        public bool IsWorkDay { get; set; }
    }
}
