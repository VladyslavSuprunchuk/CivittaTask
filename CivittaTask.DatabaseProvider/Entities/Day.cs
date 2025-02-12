namespace CivittaTask.DatabaseProvider.Entities
{
    public class Day
    {
        public int Id { get; set; }

        public bool IsWorkDay { get; set; }

        public DateTime Date { get; set; }

        public string CountryCode { get; set; }
    }
}
