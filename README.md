# Calendar Booking : TAL
repository to share the code with TAL

Instructions to create the database.

Open Visual Studio.
Navigate to the "SQL Server Object Explorer".
Connect to their SQL Server Express LocalDB instance (if not already connected).
Open a new query window.
Paste the provided SQL script into the query window.
Execute the below script to create the database and tables.

   Create database AppointmentsDB
   GO
   use AppointmentsDB
   GO
   CREATE TABLE Appointments(ID BIGINT Identity, DateOfAppointment DateTime, TimeOfAppointment TIME)
   GO

Please download and map the code to yor local and open in Visual Studio. Build the solution it will add the required packages.

Areas of Improvement.

1. Requirement for the action KEEP is not clear. If had more time, i can implement that also. As of now Keep is just re-checking if the given time slot is within the allowed range then keeping it as it is. 
2. Keep asking the commands untill user wants to exit from system is not implemented. After processing one action, program will exit and have to relaunch for next command.
3. Connectionstring is hardcoded as of now, need to be made configurable.
4. **Unit Tests are not implemented yet due to time constraint.**
   
