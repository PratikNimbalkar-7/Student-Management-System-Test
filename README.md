# Student Management System

## Project Overview

Student Management System is a RESTful Web API developed using **ASP.NET Core 8**. The application provides CRUD operations for managing students and secures APIs using JWT Authentication. It follows a 3-Tier Architecture with Repository Pattern and includes Global Exception Handling, Serilog Logging, Swagger API Documentation, and Unit Testing.

---

# Features

- Student CRUD Operations
- JWT Authentication
- Authorization using Bearer Token
- Repository Pattern
- 3-Tier Architecture
- Entity Framework Core
- SQL Server
- Global Exception Middleware
- Serilog Logging
- Swagger Documentation
- Unit Testing using xUnit & Moq

---

# Technology Stack

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- Serilog
- xUnit
- Moq

---

# Project Structure

```text
Student Management System Test
│
├── Student Management System
│     ├── Controllers
│     ├── Middleware
│     ├── Program.cs
│     ├── appsettings.json
│     └── Properties
│
├── StudentManagementBAL
│     ├── DTOs
│     ├── Interfaces
│     └── Services
│
├── StudentManagementDAL
│     ├── Context
│     ├── Repository
│     └── Migrations
│
├── StudentManagementDATA
│     └── Entities
│
├── StudentManagementDTOs
│     ├── StudentsDTOs
│     └── AuthDTOs
│
└── StudentManagement.Test
      ├── StudentServiceTests
      └── Unit Tests
```

---

# Architecture

```
Client

     │

     ▼

Student Controller

     │

     ▼

Student Service (BAL)

     │

     ▼

Student Repository (DAL)

     │

     ▼

Entity Framework Core

     │

     ▼

SQL Server
```

---

# Authentication

JWT Authentication is implemented.

### Login Credentials

```
Username : admin
Password : admin@123
```

---

# API Endpoints

## Authentication

| Method | Endpoint |
|---------|----------|
| POST | /api/Auth/login |

---

## Student

| Method | Endpoint |
|---------|----------|
| GET | /api/Student |
| GET | /api/Student/{id} |
| POST | /api/Student |
| PUT | /api/Student |
| DELETE | /api/Student/{id} |

---

# Database

## Student Table

| Column | Type |
|---------|------|
| Id | int |
| Name | nvarchar |
| Email | nvarchar |
| Age | int |
| Course | nvarchar |
| CreatedDate | datetime |

---

# JWT Authentication

1. Execute

```
POST /api/Auth/login
```

2. Enter

```json
{
  "username": "admin",
  "password": "admin@123"
}
```

3. Copy JWT Token

4. Click **Authorize** in Swagger

5. Enter

```
Bearer YOUR_TOKEN
```

---

# Exception Handling

Global Exception Middleware is implemented.

Example Response

```json
{
  "success": false,
  "message": "Something went wrong."
}
```

---

# Logging

Serilog is configured.

Log Location

```
Logs/
```

Example

```
Get All Students API called.

Student Added Successfully.

Student Updated Successfully.

Student Deleted Successfully.
```

---

# Unit Testing

Implemented using

- xUnit
- Moq

Test Cases

- Get All Students
- Get Student By Id
- Add Student
- Update Student
- Delete Student

---

# NuGet Packages

- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore
- Serilog.AspNetCore
- Serilog.Sinks.Console
- Serilog.Sinks.File
- xUnit
- Moq

---

# How to Run

## Clone Repository

```bash
git clone <Repository URL>
```

## Restore Packages

```bash
dotnet restore
```

## Build Project

```bash
dotnet build
```

## Run Project

```bash
dotnet run
```

---

# Database Migration

```
Add-Migration InitialCreate
```

```
Update-Database
```

---

# Swagger URL

```
https://localhost:5001/swagger
```

(Port may vary based on your launch settings.)

---

# Future Enhancements

- User Management
- Password Hashing
- Docker Support
- Angular Frontend
- Role-Based Authorization

---

# Author

**Pratik Nimbalkar**

Software Engineer (.NET Developer)

---

# Thank You
