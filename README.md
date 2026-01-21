# 📍 CollatzConjecture Project

- Given a positive integer, we seek to generate all the numbers in the Collatz series until reaching the sequence: 4, 2, 1.
- Display historical query information stored in MongoDB.

---

## 📅 Changelog

- **21/01/2026**:
  - **Full Stack**: The application was adapted to handle large numbers safely and accurately, respecting the limitations of each platform and ensuring consistent results between frontend and backend..
- **02/04/2025**:
  - **Full Stack**: Added history tracking functionality. Fixed minor bugs.
- **01/04/2025**:
  - **Backend**: Added connection to MongoDB database. Integrated Serilog. 
  - **Frontend**: Added graphical libraries: `@swimlane/ngx-charts`, `d3`, `@angular/cdk`, `@angular/animations`.
- **08/03/2025**:
  - **Backend/Frontend**: Initial upload of code including entities, interfaces, models, and services. Removed `frontend/.vscode` directory.

---

## 🎯 Objective

Practice .NET (C#), Design Patterns, and Onion Architecture.

### Technologies:

- **.NET (C#)** and **SQL Server**
- **Angular (TypeScript)**
- **Design Patterns**
- **Onion Architecture**

---

## 🚀 Features

### 🔧 Backend

Implements common design patterns including BaseEntity, Repository, UnitOfWork, and Factory (for task instance creation).

- Based on **Onion Architecture**
- Applies key **Design Patterns**:
  - `BaseEntity`
  - `UnitOfWork`
  - `Repository` (for data access)
  - `DTO` (Data Transfer Object)

- **Key Libraries**:
  - **Logging**:
    - `Serilog`
    - `Serilog.Settings.Configuration`
    - `Serilog.Sinks.Console`
  - **ORM**:
    - `Microsoft.EntityFrameworkCore`
    - `Microsoft.EntityFrameworkCore.Design`
    - `Microsoft.EntityFrameworkCore.SqlServer`
    - `Microsoft.EntityFrameworkCore.Tools`
    - `MongoDB.Driver` (for connecting to MongoDB)
  - **UI**:
    - `@swimlane/ngx-charts` 18.2.14 (for line charts)
    - `@angular/animations` 18.2.14 (for UI transitions)

---

### 💻 Frontend

- Built with **Angular 18.0.2 / 18.2.14**
- Features:
  - Reactive Forms
  - `AuthService` and HTTP Interceptors
  - Modular architecture
  - Service and model generation
  - Chart visualization using `@swimlane/ngx-charts`

---

### 🗄️ Database

- Uses **MongoDB**, deployed with **Docker Desktop**
- Includes:
  - Entity-Relationship diagram (based on SQL Server schema design)
  - Sample data files (`.json`)
  - **DDL scripts** for schema definition
  - **DML scripts** for sample data insertion

---

## 🧪 Installation

### ✅ Prerequisites

Ensure the following tools are installed:

- [.NET SDK 9.0.200](https://dotnet.microsoft.com/)
- [SQL Express](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [Node.js + npm](https://nodejs.org/) (for the frontend)
- [Postman 11.44.3](https://www.postman.com/downloads/)
- [MongoDB Compass 1.46.1](https://www.mongodb.com/try/download/compass)

---

### 🔧 Setup Steps

1. Clone the repository:
    ```bash
    git clone https://github.com/waltermillan/CollatzConjecture.git
    ```

2. Follow the setup video guide:
    - [Version 1 - Display Version](https://youtu.be/jPAvHBNRJhk)

3. Complete the remaining setup steps as outlined in the project documentation.

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
