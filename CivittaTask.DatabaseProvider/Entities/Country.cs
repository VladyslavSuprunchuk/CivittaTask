using System.Text.Json.Serialization;

namespace CivittaTask.DatabaseProvider.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string CountryCode { get; set; }

        public string FullName { get; set; }

        public List<Region> Regions { get; set; }

        public List<HolidayType> HolidayTypes { get; set; }

        public int FromDateId { get; set; } 
        public CountryDate FromDate { get; set; }

        public int ToDateId { get; set; } 
        public CountryDate ToDate { get; set; }
    }
}
