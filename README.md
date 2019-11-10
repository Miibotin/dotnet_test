# REST-API w/ ASP<span>.NET Core 3.0

10/11/2019

This is REST-API made with ASP<span>.NET CORE 3.0.
For the database connection you only need to modify ```"MaintenanceDb"```  variable in appsettings.json with a proper database, user and password credentials.

Clone the repository and head to the directory of this project. Run command ```dotnet run``` (in cmd, shell etc...) to run the app.

## Essentials
* .NET SDK 3.0
* Microsoft.EntityFrameworkCore.Design v3.0.0
* Microsoft.EntityFrameworkCore.SqlServer v3.0.0
* Mysql.Data v8.0.18
* Mysql.Data.EntityFrameworkCore v8.0.18
* Pomelo.EntityFrameworkCore.MySql v3.0.0-rc3.final

## Routes

These routes are tested with _Postman_. All routes need the starting point where from the API can be called, for example ```https://localhost:3306/api/Unit/1``` 

### For UnitController.cs
* [GET] api/Unit/:id - Finds the record that has the corresponding ID in the url (like in the example above)
* [POST] api/Unit - Inserts a new record of Maintenance-object parameter to the database.
* [DELETE] api/Unit/:id - Finds and deletes the record that has the corresponding ID in the url.
* [PUT] api/Unit/:id - Finds and updates the record with Maintenance-object parameter, that has the corresponding ID in the url.

### For MaintenanceController.cs
* [GET] api/Maintenance - Fetches all the records from the database and puts them into a list.
* [GET] api/Maintenance/:unit - Fetches the records that has the corresponding unit-attribute from the url (e.g. ```api/Maintenance/Auto``` fetches every record that has the Unit-variable set to _"Auto"_ ).

## Setting up database

MySQL is used as a database. Name for the database and the table is up to you, but the column names are as followed:

* Id = int AUTO_INCREMENT NOT NULL PRIMARY_KEY
* Unit = varchar(50) NOT NULL
* Desc = varchar(255)
* Importance = enum('CRITICAL', 'IMPORTANT', 'INSIGNIFICANT') NOT NULL
* Added = datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
* Updated = datetime
* State = enum('OPEN', 'CLOSED')