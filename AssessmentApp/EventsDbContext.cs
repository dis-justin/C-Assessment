namespace AssessmentApp
{
    using AssessmentApp.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Emit;

    public class EventsDbContext : DbContext
    {
        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events => Set<Event>();

        public DbSet<Location> Locations => Set<Location>();

        public DbSet<EventDate> EventDates => Set<EventDate>();

        public DbSet<User> Users => Set<User>();

        public DbSet<EventRegistration> EventRegistrations => Set<EventRegistration>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureEvents(modelBuilder);
            ConfigureLocations(modelBuilder);
            ConfigureEventDates(modelBuilder);
            ConfigureUsers(modelBuilder);
            ConfigureEventRegistrations(modelBuilder);
        }

        private static void ConfigureEvents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(2000);

                entity.Property(e => e.Address)
                    .HasMaxLength(500);

                entity.Property(e => e.Capacity)
                    .IsRequired();

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);

                entity.Property(e => e.CreatedAtUtc)
                    .IsRequired();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(200);

                entity.Property(e => e.IsDeleted)
                    .HasDefaultValue(false);


                // TODO: Configure the many-to-one relationship between Event and Location using Fluent API.
                // Requirements:
                // - Specify that each Event has one Location.
                // - Use e => e.Location to reference the Location navigation property on Event.
                // - Specify that one Location can have many Events.
                // - Specify that Event.LocationId is the foreign key.
                // - Specify the DeleteBehavior to prevent deleting a Location if Events still reference it.
                //
                // - This relationship represents:
                //   Many Events belong to one Location.
                //   One Location can have many Events.



                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.IsActive);
            });
        }

        private static void ConfigureLocations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.Property(l => l.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(l => l.AddressLine1)
                    .HasMaxLength(300);

                entity.Property(l => l.City)
                    .HasMaxLength(100);

                entity.Property(l => l.Province)
                    .HasMaxLength(100);

                entity.Property(l => l.PostalCode)
                    .HasMaxLength(20);

                entity.Property(l => l.CreatedAtUtc)
                    .IsRequired();

                entity.Property(l => l.CreatedBy)
                    .HasMaxLength(200);

                entity.Property(l => l.UpdatedBy)
                    .HasMaxLength(200);

                entity.Property(l => l.IsDeleted)
                    .HasDefaultValue(false);

                entity.HasIndex(l => l.Name);
            });
        }

        private static void ConfigureEventDates(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventDate>(entity =>
            {
                entity.HasKey(ed => ed.Id);

                entity.Property(ed => ed.StartDateTimeUtc)
                    .IsRequired();

                entity.Property(ed => ed.EndDateTimeUtc)
                    .IsRequired();

                entity.Property(ed => ed.Notes)
                    .HasMaxLength(1000);

                entity.Property(ed => ed.CreatedAtUtc)
                    .IsRequired();

                entity.Property(ed => ed.CreatedBy)
                    .HasMaxLength(200);

                entity.Property(ed => ed.UpdatedBy)
                    .HasMaxLength(200);

                entity.Property(ed => ed.IsDeleted)
                    .HasDefaultValue(false);

                // One-to-many:
                // One Event has many EventDates.
                entity.HasOne(ed => ed.Event)
                    .WithMany(e => e.EventDates)
                    .HasForeignKey(ed => ed.EventId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(ed => ed.EventId);

                entity.HasIndex(ed => ed.StartDateTimeUtc);
            });
        }

        private static void ConfigureUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(u => u.DisplayName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(u => u.CreatedAtUtc)
                    .IsRequired();

                entity.Property(u => u.CreatedBy)
                    .HasMaxLength(200);

                entity.Property(u => u.UpdatedBy)
                    .HasMaxLength(200);

                entity.Property(u => u.IsDeleted)
                    .HasDefaultValue(false);

                // TODO: Configure a unique index on the User Email property using Fluent API.
                // Requirements:
                // - Create an index on the Email property.
                // - Specify that the email must be unique so no duplicates can exist



            });
        }

        private static void ConfigureEventRegistrations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRegistration>(entity =>
            {
                entity.HasKey(er => er.Id);

                entity.Property(er => er.RegisteredAtUtc)
                    .IsRequired();

                entity.Property(er => er.RegistrationStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(er => er.CreatedAtUtc)
                    .IsRequired();

                entity.Property(er => er.CreatedBy)
                    .HasMaxLength(200);

                entity.Property(er => er.UpdatedBy)
                    .HasMaxLength(200);

                entity.Property(er => er.IsDeleted)
                    .HasDefaultValue(false);

                // One Event has many EventRegistrations.
                entity.HasOne(er => er.Event)
                    .WithMany(e => e.EventRegistrations)
                    .HasForeignKey(er => er.EventId)
                    .OnDelete(DeleteBehavior.Cascade);

                // One User has many EventRegistrations.
                entity.HasOne(er => er.User)
                    .WithMany(u => u.EventRegistrations)
                    .HasForeignKey(er => er.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Prevent the same user from registering for the same event more than once.
                entity.HasIndex(er => new { er.EventId, er.UserId })
                    .IsUnique();

                entity.HasIndex(er => er.EventId);
                entity.HasIndex(er => er.UserId);
            });
        }
    }
}
