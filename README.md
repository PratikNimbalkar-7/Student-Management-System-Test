# Student Management System API

## Overview

Student Management System is a RESTful Web API developed using ASP.NET Core 8.0. It provides CRUD operations for managing students and secures all endpoints using JWT Authentication. The project follows a 3-Tier Architecture with Repository Pattern and includes Global Exception Handling, Serilog Logging, Swagger Documentation, and Unit Testing.

---

## Features

- Student CRUD Operations
- JWT Authentication
- Role-Based Authorization
- Repository Pattern
- 3-Tier Architecture
- Entity Framework Core
- SQL Server Database
- Global Exception Handling Middleware
- Serilog Logging
- Swagger API Documentation
- Unit Testing using xUnit and Moq

---

## Technology Stack

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Serilog
- Swagger (OpenAPI)
- xUnit
- Moq

---

## Project Architecture

```
StudentManagement.API
│
├── Controllers
├── Middleware
├── Program.cs
└── appsettings.json

StudentManagement.BAL
│
├── DTOs
├── Interfaces
└── Services

StudentManagement.DAL
│
├── Context
├── Repository
└── Migrations

StudentManagement.Models
│
└── Entities

StudentManagement.Common

StudentManagement.Tests
```

---

## Project Structure

### API Layer

- Controllers
- JWT Authentication
- Swagger
- Middleware
- Dependency Injection

### Business Layer

- Business Logic
- DTOs
- Services
- Interfaces

### Data Access Layer

- Entity Framework Core
- Repository Pattern
- SQL Server

### Models

- Student Entity
- User Entity

### Test Layer

- xUnit
- Moq

---

## Database

### Student Table

| Column | Type |
|----------|------|
| Id | int |
| Name | nvarchar |
| Email | nvarchar |
| Age | int |
| Course | nvarchar |
| CreatedDate | datetime |

---

## Authentication

### Login Credentials

```
Username : admin
Password : admin@123
```

---

## API Endpoints

### Authentication

| Method | Endpoint |
|----------|------------------|
| POST | /api/Auth/login |

### Student

| Method | Endpoint |
|----------|------------------------|
| GET | /api/Student |
| GET | /api/Student/{id} |
| POST | /api/Student |
| PUT | /api/Student |
| DELETE | /api/Student/{id} |

---

## Swagger

Run the application and open:

```
https://localhost:xxxx/swagger
```

Login using

```
POST /api/Auth/login
```

Copy the generated JWT Token.

Click **Authorize** in Swagger and enter:

```
Bearer <your_token>
```

Now all protected Student APIs can be accessed.

---

## Exception Handling

The application uses custom Global Exception Middleware to return standardized JSON error responses.

Example:

```json
{
  "success": false,
  "message": "Something went wrong."
}
```

---

## Logging

Serilog is configured for structured logging.

Logs are stored inside:

```
Logs/
```

Example log:

```
Get All Students API called.
Student Added Successfully.
Student Deleted Successfully.
```

---

## Unit Testing

Unit tests are implemented using:

- xUnit
- Moq

Covered scenarios:

- Get All Students
- Get Student By Id
- Add Student
- Update Student
- Delete Student

---

## Clone Repository

```bash
git clone <repository-url>
```

---

## Run Project

Restore packages

```bash
dotnet restore
```

Build project

```bash
dotnet build
```

Run project

```bash
dotnet run
```

---

## Database Migration

Add Migration

```powershell
Add-Migration InitialCreate
```

Update Database

```powershell
Update-Database
```

---

## NuGet Packages

- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore
- Serilog.AspNetCore
- Serilog.Sinks.File
- Serilog.Sinks.Console
- xUnit
- Moq

---

## Future Enhancements

- Docker Support
- User Management
- Refresh Token
- Role-Based Authorization
- Password Hashing
- Angular Frontend

---

## Author

**Pratik Nimbalkar**

Software Engineer (.NET Developer)

---

## Thank You