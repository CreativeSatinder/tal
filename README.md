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

   Create database Bookings

   GO

   use Bookings

   GO

   CREATE TABLE Appointments
	(
		ID BIGINT Identity PRIMARY KEY, 
		DateOfAppointment DateTime, 
		TimeOfAppointment TIME, 
		CreatedBy VARCHAR(100)
	)

   GO

**Things covered :**

	Proper Naming convention used
	Dependency injection
 	
	Screenshots are given below

	Add (Reserved Timeslot)
 	![image](https://github.com/CreativeSatinder/tal/assets/126883284/b602d7b1-f3fd-441c-b25d-fcc892b8c59b)

	Add (Success)
 	![image](https://github.com/CreativeSatinder/tal/assets/126883284/be6a8d5c-b940-46ec-8c28-7f69a8f2d8bc)

	Delete (Not found)
 	![image](https://github.com/CreativeSatinder/tal/assets/126883284/e1fbf792-c5e0-4499-8ffb-e32c605551f8)

	Delete (Success)
 	![image](https://github.com/CreativeSatinder/tal/assets/126883284/11239526-cc9b-4644-b33d-646f0fbddde0)

	Find
 	![image](https://github.com/CreativeSatinder/tal/assets/126883284/1dd01e42-86ea-403a-87a2-c6c8d4201848)

	Keep
 	![image](https://github.com/CreativeSatinder/tal/assets/126883284/fafd2da8-c997-4be1-a27f-452d31d4fb46)


Areas of Improvement

•	Connectionstring is hardcoded as of now, I can make it configurable and include more configuration keys/parameters such as ReservedTimeSlots using database config table. Also, can implement key-vault service depending on requirements.
•       Keep asking the commands untill user wants to exit from system is not implemented. After processing one action, program will exit and have to relaunch for next command.
•	Unit Tests are not implemented yet due to time constraint. I would be able to implement unit testing frameworks such as MSTest, xUnit, nUnit or Moq  to create fake objects that can simulate the behaviour of real objects. Also, would be able to implement 
        quality gate using tools such as Checkmarx, SONAR
•	Given more time, I would be able to implement detailed object-oriented approach with abstraction, inheritance with base classes & interfaces using SOLID principles. 
•	Given more time, I would be able to create a Relational database with more entities and include normalisation principles.
•	Given more time, you can add logging and error handling.
