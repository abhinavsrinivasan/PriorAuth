# PriorAuthPrototype

A C#/.NET 8 Web API project that simulates Prior Authorization workflows in healthcare.  
This project demonstrates full CRUD operations (Create, Read, Update, Delete) for managing prior auth requests.

---

## Features
- Create new Prior Authorization requests (POST)
- Retrieve a specific Prior Authorization by ID (GET)
- Update an existing Prior Authorization (PUT)
- Delete a Prior Authorization (DELETE)
- RESTful API built using ASP.NET Core 8
- Connected to a SQLite database via Entity Framework Core

---

## Tech Stack
- C# (.NET 8)
- Entity Framework Core (SQLite)
- Swagger UI for API testing
- REST API principles
- Layered Architecture: Controller → Service → Repository (DbContext)

---

## How to Run

### Clone the repository:
```bash
git clone https://github.com/abhinavsrinivasan/PriorAuthPrototype.git
cd PriorAuthPrototype
```
## Restore dependencies:
```bash
dotnet restore
```
## Apply Entity Framework migrations and create the database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
## Run the application:
```bash
dotnet run
```
## Open your browser and navigate to:
```bash
https://localhost:5001/swagger
```
