using EventRegistrationSystem.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventRegistrationSystem.Models.Data
{
    public class EventDbContext : IdentityDbContext
    {
        public DbSet<Event> events {  get; set; }
        public DbSet<RegistrationEvent> registrationEvents {  get; set; }
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RegistrationEvent>().HasOne(e => e.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(e => e.EventId);
        }

    }
}
