# CivittaTask

This project is a solution for a task assigned by Civitta, involving interaction with the kayaposoft.com API to retrieve data about holidays and working days, as well as saving this data to a database.

## Task Description
The project includes:

      1. Calling the API to fetch data about holidays or working days.

      2. Saving the retrieved data to a database.

      3. Supporting local execution with configurable database connections.

      4. Validating and processing the data.
## Project Setup

### Local Execution

To run the project locally, you need to configure the database connection. By default, the following connection string is used: `Server=localhost\\SQLEXPRESS01;User Id=sa;Password=1234;`
If you are using a different database, update the connection string in the `appsettings.json`.

### Remote  Execution
For remote execution, such as testing or production, you need to replace the connection string with the one provided in the email. Do not include sensitive connection strings in the code or repository for security reasons.