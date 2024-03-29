# Testing System Project

Welcome to the Testing System project repository!

## Getting Started

To run the project locally, follow these steps:

1. **Clone this repository to your local machine**:

2. **Open the project directory in your terminal**.

3. **Run the following commands to clean and restore dependencies**:
   ```bash
   dotnet clean
   dotnet restore
Set up the database:

Create a database named TestingSystemDb in SQL Server.
Copy the connection string and paste it into TestingSystem.Admin/appsettings.json for the TestingSystemDb connection and TestingSystem.Web/appsettings.json for the TestingSystemDb connection.

Apply database migrations:

Open the Package Manager Console (PMC) in your IDE.
Set the Default Project in the Package Manager Console Window to TestingSystem.Data.
Apply any pending migrations and update the database by running the following command in PMC:
update-database

Set up startup projects:

Set both TestingSystem.Admin and TestingSystem.Web projects as startup projects in your IDE. These projects represent the admin and web user interfaces, respectively.
You're all set! Run the projects by hitting the "Run" or "Start" button in your IDE to launch the admin and web user interfaces.
