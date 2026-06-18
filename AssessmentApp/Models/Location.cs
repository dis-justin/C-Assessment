namespace AssessmentApp.Models
{
    public class Location : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? AddressLine1 { get; set; }

        public string? City { get; set; }

        public string? Province { get; set; }

        public string? PostalCode { get; set; }

        // One location can have many events.
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
