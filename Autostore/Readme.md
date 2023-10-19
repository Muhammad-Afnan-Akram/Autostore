# Autostore

Autostore is an autoparts management system designed to efficiently manage customers, employees, stocks, and transactions. This project is built on .NET 7.0 and follows the Model-View-Controller (MVC) architecture for the Web API. It incorporates essential features for authentication, utilizing Identity and JWT (JSON Web Tokens), along with robust exception handling.

## Features

- **Authentication**: User authentication and authorization using Identity and JWT tokens for secure access to the system.

- **Models**: Well-structured models to represent entities like customers, employees, stocks, and transactions.

- **Repositories (Repos)**: Repository pattern implementation for data access, ensuring a clean separation between data storage and application logic.

- **Controllers**: API endpoints and HTTP request handling logic are organized within controllers.

- **Unit of Work**: Implementation of the Unit of Work pattern to manage transactions and data consistency across the application.

- **Services**: Business logic and services that handle operations related to customers, employees, stocks, and transactions.

- **Exception Handling**: Robust exception handling for graceful error management and reporting.

## Technologies Used

- .NET 7.0
- Identity for Authentication
- JWT (JSON Web Tokens)
- Entity Framework for Data Access
- ASP.NET Core MVC
- C# Programming Language

## Getting Started

To get started with Autostore, follow these steps:

1. **Clone the Repository**:
- git clone https://github.com/Muhammad-Afnan-Akram/Autostore.git

2. **Set Up the Development Environment**:
- Install .NET 7.0.
- Configure your database connection in the app settings.

3. **Build and Run the Project**:
- dotnet build
- dotnet run


4. **Access the Web API**:
The API will be available at `http://localhost:5000` by default. You can use tools like Postman or cURL to interact with the endpoints.

## Documentation

For detailed documentation on how to use and extend Autostore, please refer to the [wiki](https://github.com/yourusername/autostore/wiki).

## Contributing

We welcome contributions! If you'd like to contribute to Autostore, please follow our [Contribution Guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For any inquiries or support, please contact [Your Name](mailto:your.email@example.com).

Happy coding!

