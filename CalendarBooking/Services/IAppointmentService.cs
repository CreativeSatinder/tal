
namespace CalendarBooking.Services
{
    public interface IAppointmentService
    {
        void AddAppointment(DateTime date, TimeSpan time);
        void DeleteAppointment(DateTime date, TimeSpan time);
        void FindFreeTimeslot(DateTime date);
        void KeepTimeslot(TimeSpan time);
    }
}