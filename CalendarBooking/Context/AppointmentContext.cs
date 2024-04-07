using Microsoft.EntityFrameworkCore;

namespace CalendarBooking.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
    }
}