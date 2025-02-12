using System.Text.Json.Serialization;

namespace CivittaTask.DatabaseProvider.Entities
{
    public class CountryDate
    {
        public int Id { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }
    }
}
