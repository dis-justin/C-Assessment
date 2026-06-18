namespace AssessmentApp.Models
{

    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();
    }

}
