# Calendar Booking : TAL
repository to share the code with TAL

Please download and map the code to yor local and open in Visual Studio. Build the solution it will add the required packages.

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

Areas of Improvement

•	Connectionstring is hardcoded as of now, I can make it configurable and include more configuration keys/parameters such as ReservedTimeSlots using database config table. Also, can implement key-vault service depending on requirements.
•  Keep asking the commands untill user wants to exit from system is not implemented. After processing one action, program will exit and have to relaunch for next command.
•	Unit Tests are not implemented yet due to time constraint. I would be able to implement unit testing frameworks such as MSTest, xUnit, nUnit or Moq  to create fake objects that can simulate the behaviour of real objects. Also, would be able to implement quality gate       using tools such as Checkmarx, SONAR
•	Given more time, I would be able to implement detailed object-oriented approach with abstraction, inheritance with base classes & interfaces using SOLID principles. 
•	Given more time, I would be able to create a Relational database with more entities and include normalisation principles.
•	Given more time, I would have used MVC architecture for easier maintenance, better scalability, more flexibility, and higher testability.
•	If provided with additional time, I would have used Angular JS or React for front end to enrich the user experience.
•	If provided with additional time, I would leverage a cloud platform such as Azure App Service and Azure SQL services to host it.
•  Given more time, you can add logging and error handling.
