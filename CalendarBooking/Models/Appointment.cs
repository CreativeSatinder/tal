
namespace CalendarBooking.Models
{
    public class Appointment
    {
        public long Id { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public TimeSpan TimeOfAppointment { get; set; }
    }
}