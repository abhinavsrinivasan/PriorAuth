PriorAuthPrototype
A simple C#/.NET 8 Web API project that simulates Prior Authorization workflows in healthcare.
This project demonstrates full CRUD operations (Create, Read, Update, Delete) for managing prior auth requests.

Features
Create new Prior Authorization requests (POST)

Retrieve a specific Prior Authorization by ID (GET)

Update an existing Prior Authorization (PUT)

Delete a Prior Authorization (DELETE)

RESTful API built using ASP.NET Core 8

Connected to a SQLite database via Entity Framework Core

Tech Stack
C# (.NET 8)

Entity Framework Core (SQLite)

Swagger UI for API testing

REST API principles

Layered Architecture: Controller → Service → Repository (DbContext)

How to Run
Clone the repository:

bash
Copy
Edit
git clone https://github.com/your-username/PriorAuthPrototype.git
Navigate into the project:

bash
Copy
Edit
cd PriorAuthPrototype
Restore dependencies:

bash
Copy
Edit
dotnet restore
Run the project:

bash
Copy
Edit
dotnet run
Access Swagger UI:

Open your browser and visit:
http://localhost:5067/swagger

API Endpoints

Method	Endpoint	Description
POST	/api/PriorAuthorization	Create a new prior auth request
GET	/api/PriorAuthorization/{id}	Retrieve a prior auth by ID
PUT	/api/PriorAuthorization/{id}	Update a prior auth by ID
DELETE	/api/PriorAuthorization/{id}	Delete a prior auth by ID

📄 Example Request Body (POST)
json
Copy
Edit
{
  "patientName": "Abhinav",
  "providerName": "Koli Orthopedics",
  "requestDate": "2025-04-28T15:26:14.673Z",
  "procedureCode": "PROC123",
  "status": "Pending",
  "isUrgent": true
}


Contact

www.linkedin.com/in/abhisrini/ | abhisriny@gmail.com