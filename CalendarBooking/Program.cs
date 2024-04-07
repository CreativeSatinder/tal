using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CalendarBooking.Models;
using CalendarBooking.Services;


namespace CalendarBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configure services for Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppointmentContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AppointmentsDB;Trusted_Connection=True;"))
                .AddTransient<IAppointmentService, AppointmentService>()
                .BuildServiceProvider();

            // Resolve the service
            var appointmentService = serviceProvider.GetService<IAppointmentService>();

            // Display available options
            Console.WriteLine("Available commands:");
            Console.WriteLine("ADD DD/MM hh:mm");
            Console.WriteLine("DELETE DD/MM hh:mm");
            Console.WriteLine("FIND DD/MM");
            Console.WriteLine("KEEP hh:mm");
            Console.WriteLine();

            // Wait for user input
            Console.WriteLine("Enter a command:");
            string input = Console.ReadLine();
                
            // Parse the input command
            string[] commandParts = input.Split(' ');
            if (commandParts.Length >= 2) 
            {
                string action = commandParts[0].ToUpper();
                string[] arguments = commandParts[1].Split('/');
                if (arguments.Length == 2 && (action == "ADD" || action == "DELETE"))
                {
                    // Extract date and time from arguments
                    if (DateTime.TryParseExact(commandParts[1], "dd/MM", null, System.Globalization.DateTimeStyles.None, out DateTime date) && TimeSpan.TryParse(commandParts[2], out TimeSpan time))
                    { 
                        // Execute action based on parsed command
                        switch (action)
                        {
                            case "ADD":
                                // Execute ADD logic with appointmentDateTime
                                appointmentService.AddAppointment(date, time);
                                break;
                            case "DELETE":
                                // Execute DELETE logic with appointmentDateTime
                                appointmentService.DeleteAppointment(date, time);
                                break;
                            default:
                                Console.WriteLine("Invalid command.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date/time format.");
                    }
                }
                else if (arguments.Length == 2 && action == "FIND")
                {
                    // Parse and execute the KEEP command
                    if (DateTime.TryParseExact(commandParts[1], "dd/MM", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                    {
                        // Execute FIND logic with appointmentDateTime.Date
                        appointmentService.FindFreeTimeslot(date);
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                    }
                }
                else if (arguments.Length == 1 && action == "KEEP")
                {
                    // Parse and execute the KEEP command
                    if (TimeSpan.TryParseExact(arguments[0], "hh\\:mm", null, out TimeSpan keepTime))
                    {
                        // Execute KEEP logic with keepTime
                        Console.WriteLine($"Keeping timeslot at {keepTime}");
                        appointmentService.KeepTimeslot(keepTime);
                    }
                    else
                    {
                        Console.WriteLine("Invalid time format.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command or arguments.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }

            // Wait for user to press Enter to exit
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

        }
    }
}
