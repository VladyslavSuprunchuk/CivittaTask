namespace CivittaTask.DatabaseProvider.Entities
{
    public class HolidayType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
