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
            const string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Bookings;Trusted_Connection=True;";

            // Configure services for Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppointmentContext>(options => options.UseSqlServer(connString))
                .AddTransient<IAppointmentService, AppointmentService>()
                .BuildServiceProvider();

            // Resolve the service
            var appointmentService = serviceProvider.GetService<IAppointmentService>();
            bool moreCommands = true;

            Console.Write("Please enter your name : ");
            string userName = Console.ReadLine();

            while (moreCommands)
            {
                Console.Clear();

                Console.WriteLine("Hello, {0} \n", userName);

                var inputCommamds = $"1. ADD DD/MM hh:mm \n" +
                         "2. DELETE DD/MM hh:mm \n" +
                         "3. FIND DD/MM \n" +
                         "4. KEEP DD/MM \n";

                //Display the available options
                Console.WriteLine("Please enter following commands only : \n" +
                    "" + inputCommamds);

                // Wait for user input
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
                                    appointmentService.AddAppointment(date, time, userName);
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

                // Ask user if they want to continue
                Console.WriteLine("\nDo you want to continue? (yes/no)");
                string continueInput = Console.ReadLine().ToLower();
                if (continueInput != "yes")
                {
                    moreCommands = false;
                }
            }

            // Wait for user to press Enter to exit
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

        }
    }
}
