using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyIntandemBooking.Areas.Identity.Data;

namespace MyIntandemBooking.Models
{
    public class MyInTandemBookingContext : IdentityDbContext<MyInTandemBookingUser>
    {
        public MyInTandemBookingContext(DbContextOptions<MyInTandemBookingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Enrollment>()
                .HasKey(t => new { t.UserID, t.EventID });
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
    }
}
