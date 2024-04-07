using CalendarBooking.Models;


namespace CalendarBooking.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentContext _context;

        public AppointmentService(AppointmentContext context)
        {
            _context = context;
        }

        public void AddAppointment(DateTime date, TimeSpan time)
        {
            // Check if the specified time slot is within the acceptable time range (9 AM - 5 PM)
            if (time < TimeSpan.FromHours(9) || time > TimeSpan.FromHours(17))
            {
                Console.WriteLine("Invalid time slot. Time must be between 9 AM and 5 PM.");
                return;
            }

            // Check if the time slot is reserved (4 PM - 5 PM every second day of the third week of any month)
            if (IsReservedTimeSlot(date, time))
            {
                Console.WriteLine("Time slot is reserved and unavailable.");
                return;
            }

            // Check if the appointment already exists
            if (_context.Appointments.Any(a => a.DateOfAppointment.Date == date.Date && a.TimeOfAppointment == time))
            {
                Console.WriteLine("An appointment already exists at this time slot.");
                return;
            }

            // Add the appointment
            _context.Appointments.Add(new Appointment { DateOfAppointment = date, TimeOfAppointment = time });
            _context.SaveChanges();
            Console.WriteLine("Appointment added successfully.");
        }

        public void DeleteAppointment(DateTime date, TimeSpan time)
        {
            // Find the appointment to delete
            var appointmentToDelete = _context.Appointments.FirstOrDefault(a => a.DateOfAppointment.Date == date.Date && a.TimeOfAppointment == time);

            // Check if appointment exists
            if (appointmentToDelete == null)
            {
                Console.WriteLine("No appointment found at this time slot.");
                return;
            }

            // Delete the appointment
            _context.Appointments.Remove(appointmentToDelete);
            _context.SaveChanges();
            Console.WriteLine("Appointment deleted successfully.");
        }

        public void FindFreeTimeslot(DateTime date)
        {
            // Get all appointments for the specified date
            var appointmentsForDate = _context.Appointments.Where(a => a.DateOfAppointment.Date == date.Date).ToList();

            // Find available time slots (9 AM - 5 PM) excluding reserved time slots
            var availableTimeSlots = Enumerable.Range(9, 8)
                .SelectMany(hour => new[] { TimeSpan.FromHours(hour), TimeSpan.FromHours(hour).Add(TimeSpan.FromMinutes(30)) })
                .Where(time => !IsReservedTimeSlot(date, time) && !appointmentsForDate.Any(a => a.TimeOfAppointment == time))
                .ToList();

            // Display available time slots
            if (availableTimeSlots.Any())
            {
                Console.WriteLine("Available time slots for " + date.ToShortDateString() + ":");
                foreach (var timeSlot in availableTimeSlots)
                {
                    Console.WriteLine(timeSlot.ToString("hh\\:mm"));
                }
            }
            else
            {
                Console.WriteLine("No available time slots for " + date.ToShortDateString() + ".");
            }
        }

        public void KeepTimeslot(TimeSpan time)
        {
            // Check if the specified time slot is within the acceptable time range (9 AM - 5 PM)
            if (time < TimeSpan.FromHours(9) || time > TimeSpan.FromHours(17))
            {
                Console.WriteLine("Invalid time slot. Time must be between 9 AM and 5 PM.");
                return;
            }

            // Implement logic to keep the timeslot (e.g., mark it as important, prioritize, etc.)
            Console.WriteLine("Timeslot kept successfully.");
        }

        // Helper method to check if a time slot is reserved (4 PM - 5 PM every second day of the third week of any month)
        private bool IsReservedTimeSlot(DateTime date, TimeSpan time)
        {
            return date.DayOfWeek == DayOfWeek.Tuesday && date.Day >= 15 && date.Day <= 21 && time >= TimeSpan.FromHours(16) && time < TimeSpan.FromHours(17);
        }
    }
}