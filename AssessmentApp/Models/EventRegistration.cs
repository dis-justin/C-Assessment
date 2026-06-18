namespace AssessmentApp.Models
{
    public class EventRegistration : BaseEntity
    {
        public int EventId { get; set; }

        public Event Event { get; set; } = null!;

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public DateTime RegisteredAtUtc { get; set; }

        public string RegistrationStatus { get; set; } = "Registered";
    }
}
