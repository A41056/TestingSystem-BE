# Testing System Project

Welcome to the Testing System project repository!

## Getting Started

To run the project locally, follow these steps:

1. Clone this repository to your local machine:

2. Open the project directory in your terminal.

3. Run the following commands to clean and restore dependencies:
dotnet clean
dotnet restore

4. Set the `TestingSystem.Data` project as the startup project in your IDE. This project handles data access.

5. Open the Package Manager Console (PMC) in your IDE and run the following command to add an initial migration:
add-migration Init

6. After adding the migration, apply it to the database by running the following command in PMC:
update-database


7. Set both `TestingSystem.Admin` and `TestingSystem.Web` projects as startup projects in your IDE. These projects represent the admin and web user interfaces, respectively.

8. You're all set! Run the projects by hitting the "Run" or "Start" button in your IDE to launch the admin and web user interfaces.

## Contributing

If you'd like to contribute to this project, please fork the repository, make your changes, and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.



