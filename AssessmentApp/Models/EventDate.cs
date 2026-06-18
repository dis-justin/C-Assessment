namespace AssessmentApp.Models
{
    public class EventDate : BaseEntity
    {
        public int EventId { get; set; }

        public Event Event { get; set; } = null!;

        public DateTime StartDateTimeUtc { get; set; }

        public DateTime EndDateTimeUtc { get; set; }

        public string? Notes { get; set; }
    }
}
