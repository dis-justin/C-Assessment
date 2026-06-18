using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace AssessmentApp.Models
{
    public class Event : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Address { get; set; }

        public int Capacity { get; set; }

        public bool IsActive { get; set; }

        // TODO: Add a many-to-one relationship between Event and Location.
        // Requirements:
        // - Add a foreign key property named LocationId.
        // - LocationId should be an int.
        // - Many Event records can reference the same Location.
        // - Each Event should belong to one Location.
        //
        // Relationship example:
        // - One Location can have many Events.
        // - One Event belongs to one Location.



        // TODO: Add the Location navigation property.
        // Requirements:
        // - Add a navigation property named Location.
        // - The property type should be Location.
        // - Initialize it using null! to satisfy nullable reference type warnings.



        // TODO: Add a one-to-many relationship between Event and EventDate.
        // Requirements:
        // - Add a collection navigation property named EventDates.
        // - The property type should be ICollection<EventDate>.
        // - Initialize it with a new List<EventDate>().
        // - One Event can have many EventDate records.
        // - Each EventDate should belong to one Event.
        //
        // Relationship example:
        // - One Event can have many EventDates.
        // - One EventDate belongs to one Event.



        // TODO: Add a many-to-many relationship between Event and User using EventRegistration.
        // Requirements:
        // - Add a collection navigation property named EventRegistrations.
        // - The property type should be ICollection<EventRegistration>.
        // - Initialize it with a new List<EventRegistration>().
        //
        // Relationship example:
        // - One Event can have many EventRegistrations.
        // - One User can have many EventRegistrations.
        // - Therefore, many Users can register for many Events.



    }
}
