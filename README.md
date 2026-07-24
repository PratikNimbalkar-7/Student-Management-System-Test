# Student Management System

## Project Overview

The Student Management System is a RESTful Web API developed using **ASP.NET Core 8**. It provides CRUD operations for managing students and secures APIs using **JWT Authentication**. The application follows a **3-Tier Architecture** with the **Repository Pattern** and includes **Global Exception Handling**, **Serilog Logging**, **Swagger API Documentation**, and **Unit Testing**.

---

# Features

- Student CRUD Operations
- JWT Authentication
- Repository Pattern
- 3-Tier Architecture
- Entity Framework Core
- SQL Server
- Global Exception Middleware
- Serilog Logging
- Swagger API Documentation
- Unit Testing using xUnit & Moq

---

# Technology Stack

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger (OpenAPI)
- Serilog
- xUnit
- Moq

---

# Project Structure

```text
Student Management System Test
│
├── Student Management System
│   ├── Controllers
│   ├── Middleware
│   ├── Program.cs
│   ├── appsettings.json
│   └── Properties
│
├── StudentManagementBAL
│   ├── Interfaces
│   ├── Services
│
├── StudentManagementDAL
│   ├── Context
│   ├── Repository
│   └── Migrations
│
├── StudentManagementDATA
│   └── Entities
│
├── StudentManagementDTOs
│   ├── StudentsDTOs
│   └── AuthDTOs
│
└── StudentManagement.Test
    ├── StudentServiceTests
    └── Unit Tests
```

---

# Architecture

```text
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

JWT Authentication is implemented to secure all Student APIs.

### Login Credentials

```text
Username : admin
Password : admin@123
```

---

# API Endpoints

## Authentication

| Method | Endpoint |
|---------|----------|
| POST | /api/Auth/login |

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
| Name | nvarchar(100) |
| Email | nvarchar(100) |
| Age | int |
| Course | nvarchar(100) |
| CreatedDate | datetime |

---

# Swagger Authentication

### Step 1

Run the Login API.

```http
POST /api/Auth/login
```

### Step 2

Request Body

```json
{
  "username": "admin",
  "password": "admin@123"
}
```

### Step 3

Copy the generated JWT Token.

Example Response

```json
{
  "success": true,
  "message": "Login Successful",
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIs...",
    "username": "admin",
    "role": "Admin"
  }
}
```

### Step 4

Open **Swagger**.

Click **Authorize**.

### Step 5

**Paste only the JWT Token**.

Example

```text
eyJhbGciOiJIUzI1NiIs...
```

> **Note:** This project uses **HTTP Bearer Authentication**. Swagger automatically adds the `Bearer` prefix to the Authorization header. Do **not** type `Bearer` manually.

### Step 6

Click **Authorize**.

Now all protected Student APIs can be accessed successfully.

---

# Exception Handling

A custom Global Exception Middleware is implemented to handle all unhandled exceptions and return a standard JSON response.

Example

```json
{
  "success": false,
  "message": "Something went wrong."
}
```

---

# Logging

Serilog is configured for structured logging.

Log files are automatically created inside:

```text
Logs/
```

Example Logs

```text
Get All Students API called.

Student Added Successfully.

Student Updated Successfully.

Student Deleted Successfully.
```

---

# Unit Testing

Unit testing is implemented using:

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
git clone <Repository_URL>
```

## Restore Packages

```bash
dotnet restore
```

## Build Solution

```bash
dotnet build
```

## Run Application

```bash
dotnet run
```

---

# Database Migration

```powershell
Add-Migration InitialCreate
```

```powershell
Update-Database
```

---

# Swagger URL

```text
https://localhost:5001/swagger
```

> **Note:** The port number may vary depending on your Visual Studio launch settings.

---

# Future Enhancements

- Docker Support
- Password Hashing
- User Management
- Angular Frontend
- Role-Based Authorization

---

# Author

**Pratik Nimbalkar**

Software Engineer | ASP.NET Core Developer

---

# Thank You

Thank you for reviewing this project.
