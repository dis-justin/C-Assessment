using AssessmentApp.Models;

namespace AssessmentApp.Data
{
    public static class DbSeeder
    {
        public static void Seed(EventsDbContext dbContext)
        {
            // Prevent duplicate seed data
            if (dbContext.Events.Any())
            {
                return;
            }

            var bordenLocation = new Location
            {
                Name = "CFB Borden Training Centre",
                AddressLine1 = "123 Training Road",
                City = "Borden",
                Province = "ON",
                PostalCode = "L0M 1C0",
                CreatedAtUtc = DateTime.UtcNow
            };

            var ottawaLocation = new Location
            {
                Name = "Ottawa Conference Centre",
                AddressLine1 = "456 Briefing Avenue",
                City = "Ottawa",
                Province = "ON",
                PostalCode = "K1A 0K2",
                CreatedAtUtc = DateTime.UtcNow
            };

            var user1 = new User
            {
                Email = "alex.smith@example.com",
                DisplayName = "Alex Smith",
                CreatedAtUtc = DateTime.UtcNow
            };

            var user2 = new User
            {
                Email = "jordan.lee@example.com",
                DisplayName = "Jordan Lee",
                CreatedAtUtc = DateTime.UtcNow
            };

            var user3 = new User
            {
                Email = "casey.morgan@example.com",
                DisplayName = "Casey Morgan",
                CreatedAtUtc = DateTime.UtcNow
            };

            var apiWorkshop = new Event
            {
                Name = "ASP.NET Core Web API Workshop",
                Description = "Hands-on training for building RESTful APIs with ASP.NET Core.",
                Address = "123 Training Road, Borden, ON",
                Capacity = 30,
                IsActive = true,
                CreatedAtUtc = DateTime.UtcNow,
                Location = bordenLocation
            };

            var databaseTraining = new Event
            {
                Name = "Database Design Fundamentals",
                Description = "Introductory session covering relational design, indexes, and query performance.",
                Address = "123 Training Road, Borden, ON",
                Capacity = 25,
                IsActive = true,
                CreatedAtUtc = DateTime.UtcNow,
                Location = bordenLocation
            };

            var securityBriefing = new Event
            {
                Name = "Secure API Development Briefing",
                Description = "Overview of API security, authentication, authorization, and secure coding practices.",
                Address = "456 Briefing Avenue, Ottawa, ON",
                Capacity = 40,
                IsActive = true,
                CreatedAtUtc = DateTime.UtcNow,
                Location = ottawaLocation
            };

            var eventDates = new List<EventDate>
        {
            new EventDate
            {
                Event = apiWorkshop,
                StartDateTimeUtc = DateTime.UtcNow.AddDays(7).Date.AddHours(14),
                EndDateTimeUtc = DateTime.UtcNow.AddDays(7).Date.AddHours(16),
                Notes = "Introduction and controller basics.",
                CreatedAtUtc = DateTime.UtcNow
            },
            new EventDate
            {
                Event = apiWorkshop,
                StartDateTimeUtc = DateTime.UtcNow.AddDays(8).Date.AddHours(14),
                EndDateTimeUtc = DateTime.UtcNow.AddDays(8).Date.AddHours(16),
                Notes = "EF Core, DTOs, and validation.",
                CreatedAtUtc = DateTime.UtcNow
            },
            new EventDate
            {
                Event = databaseTraining,
                StartDateTimeUtc = DateTime.UtcNow.AddDays(10).Date.AddHours(13),
                EndDateTimeUtc = DateTime.UtcNow.AddDays(10).Date.AddHours(15),
                Notes = "Database relationships and indexing.",
                CreatedAtUtc = DateTime.UtcNow
            },
            new EventDate
            {
                Event = securityBriefing,
                StartDateTimeUtc = DateTime.UtcNow.AddDays(14).Date.AddHours(15),
                EndDateTimeUtc = DateTime.UtcNow.AddDays(14).Date.AddHours(17),
                Notes = "Authentication, JWTs, CORS, and secure API design.",
                CreatedAtUtc = DateTime.UtcNow
            }
        };

            var registrations = new List<EventRegistration>
        {
            new EventRegistration
            {
                Event = apiWorkshop,
                User = user1,
                RegisteredAtUtc = DateTime.UtcNow,
                RegistrationStatus = "Registered",
                CreatedAtUtc = DateTime.UtcNow
            },
            new EventRegistration
            {
                Event = apiWorkshop,
                User = user2,
                RegisteredAtUtc = DateTime.UtcNow,
                RegistrationStatus = "Registered",
                CreatedAtUtc = DateTime.UtcNow
            },
            new EventRegistration
            {
                Event = databaseTraining,
                User = user2,
                RegisteredAtUtc = DateTime.UtcNow,
                RegistrationStatus = "Registered",
                CreatedAtUtc = DateTime.UtcNow
            },
            new EventRegistration
            {
                Event = securityBriefing,
                User = user3,
                RegisteredAtUtc = DateTime.UtcNow,
                RegistrationStatus = "Waitlisted",
                CreatedAtUtc = DateTime.UtcNow
            }
        };

            dbContext.Locations.AddRange(bordenLocation, ottawaLocation);
            dbContext.Users.AddRange(user1, user2, user3);
            dbContext.Events.AddRange(apiWorkshop, databaseTraining, securityBriefing);
            dbContext.EventDates.AddRange(eventDates);
            dbContext.EventRegistrations.AddRange(registrations);

            dbContext.SaveChanges();
        }
    }
}
