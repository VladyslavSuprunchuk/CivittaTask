using System.Text.Json.Serialization;

namespace CivittaTask.DatabaseProvider.Entities
{
    public class HolidayName
    {
        public int Id { get; set; }

        public string Lang { get; set; }

        public string Text { get; set; }

        public int HolidayId { get; set; }
        public Holiday HolidayI{ get; set; }

    }
}
