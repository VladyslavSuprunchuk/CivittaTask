using System.Text.Json.Serialization;

namespace CivittaTask.DatabaseProvider.Entities
{
    public class Holiday
    {
        public int Id { get; set; }

        public string CountryCode { get; set; }

        public int DateId { get; set; }
        public HolidayDate Date { get; set; }

        public List<HolidayName> Name { get; set; }

        public string HolidayType { get; set; }
    }
}
