# BookNest: Library Management System (LMS) - Backend API
![.NET Core](https://img.shields.io/badge/.NET-8.0-blue)
![Entity Framework Core](https://img.shields.io/badge/EF_Core-8.0-green)
![SQL Server](https://img.shields.io/badge/SQL_Server-20.0-red)
![JWT](https://img.shields.io/badge/JWT-Auth-orange)
![Swagger](https://img.shields.io/badge/Swagger-UI-lightgrey)
![Postman](https://img.shields.io/badge/Postman-API_Testing-orange)
![Visual Studio](https://img.shields.io/badge/IDE-Visual_Studio_2022-purple)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean_Architecture-blueviolet)


## Technology Stack

- **Backend Framework**: .NET Core 8.0
- **Database**: Microsoft SQL Server 20.0+
- **ORM**: Entity Framework Core 8.0+ (Code-First)
- **Authentication**: JWT Bearer Tokens
- **API Documentation**: Swagger UI, Postman
- **Code Development & Maintain**: Visual Studio 2022, Git & Github

## Project Structure (CLEAN Architecture)
```
├── LMS.API/
│   ├── Controllers/ # API endpoints grouped by domain
│   ├── Middlewares/ # Custom middleware (Logger, Rate Limiting)
│   ├── Properties/
│   └── appsettings.json # Configuration settings
│
├── LMS.Application/ # Application layer
│   ├── DTOs/ # Data Transfer Objects
│   ├── Interfaces/ # Service contracts
│   └── Services/ # Calling Repository method implementation
│
├── LMS.Common/ # Common layer
│   ├── Exceptions/ # Custom Exceptions 
│   └── Validators/ # Custom Validators
│
├── LMS.Domain/ # Domain layer
│   ├── Entities/ # Core domain models
│   └── Enums/ # Domain enumerations
│
├── LMS.Infrastructure/ # Infrastructure layer
│   ├── Context/ # DbContext and database config
│   ├── Extensions/ # Extension methods
│   ├── Helpers/ # Utility classes
│   ├── Mappers/ # AutoMapper profiles
│   ├── Migrations/ # EF Core migrations
│   ├── Repository/ # Repository pattern implementation
│   └── Scripts/ # Database scripts
│
├── Program.cs # Startup configuration
├── LMS.Backend.http # HTTP client requests
├── logs.txt # Application logs
└── README.md # Project documentation
```

## Setup Instructions
### Prerequisites
- .NET 8.0 SDK
- SQL Server 20.0+
- Visual Studio 2022 

## Features
### 🛡️ Authentication
- JWT Token-Based Authentication
- Role-Based Authorization (Admin, Librarian, Student)
### 👥 Roles & Responsibilities
- 👑 Admin
  - Full system access
  - Manage all users (Add, Block/Unblock)
  - View books and transactions
  - Assign/revoke Librarian role
- 📘 Librarian
  - Approve/Reject borrow/return requests
  - View/Add/Edit books (no delete)
  - View student profiles (read-only)
- 🎓 Student
  - Register/Login
  - Search/View books
  - Send borrow/return requests
  - View personal transaction history
  - Add books to wishlist

## 🎯 Features Summary
- 🔐 JWT Authentication + Role-based access
- 📚 Book Management (Add/Edit/View)
- 🔄 Borrow & Return Book Flow
- 📖 Book Search with filter
- 🔔 Wishlist + Notification System
- 📊 Role-Based Dashboards (Admin/Librarian/Student)
- ⚙️ Configurable Borrow Limits and Penalty System

## 🧩 API Versioning
- This project implements **API Versioning** using `Asp.Versioning.Http` to support backward compatibility and future scalability. Each API endpoint is versioned using URL segment-based routing (e.g., `/api/v1/...`), allowing clients to consume a stable contract while the backend evolves.

🔹 **Benefits:**
- Multiple versions can coexist (v1, v2, etc.)
- Easy deprecation and maintenance of older versions
- Clear separation of logic per version for better traceability
- 📘 Example:
  - GET /api/v1/books
  - GET /api/v2/books

## 🔒 Rate Limiting
- To prevent abuse and ensure fair resource usage, **Rate Limiting** is implemented using middleware (`AspNetCoreRateLimit`) based on IP address and client identity.

🔹 **Features:**
- Configurable request quotas per IP (e.g., 100 requests per 15 minutes)
- Throttling policy stored in `appsettings.json`
- HTTP 429 (`Too Many Requests`) is returned when the limit is exceeded

## Role-based module access
| Feature / Role          | Admin | Librarian | Student |
|-------------------------|-------|-----------|---------|
| Register                | ✗     | ✗         | ✓       |
| Login                   | ✓     | ✓         | ✓       |
| View Dashboard          | ✓     | ✓         | ✓       |
| Manage Users            | ✓     | ✗         | ✗       |
| Block/Unblock Users     | ✓     | ✗         | ✗       |
| View All Transactions   | ✓     | ✓         | ✗       |
| View Books              | ✓     | ✓         | ✓       |
| Add/Edit Book           | ✓     | ✓         | ✗       |
| Delete Book             | ✓     | ✗         | ✗       |
| Search / Filter Books   | ✓     | ✓         | ✓       |
| Borrow Book Request     | ✗     | ✗         | ✓       |
| Return Book Request     | ✗     | ✗         | ✓       |
| Approve/Reject Requests | ✓     | ✓         | ✗       |
| Track Book Copies       | ✓     | ✓         | ✗       |
| View Student Profiles   | ✓     | ✓         | ✗       |
| View Own History        | ✗     | ✗         | ✓       |
| Add to Wishlist         | ✗     | ✗         | ✓       |
| Get Notifications       | ✗     | ✗         | ✓       |
| Receive Email Alert     | ✗     | ✓         | ✓       |
| Book Review (Add/View)  | ✗     | ✗         | ✓       |

## API's Endpoints
| Category        | Method | Endpoint                                      | Description                          |
|-----------------|--------|-----------------------------------------------|--------------------------------------|
| **Auth**        | POST   | `/auth/register`                              | Student registration                 |
|                 | POST   | `/auth/login`                                 | User login                           |
|                 | POST   | `/auth/send-otp`                              | Send OTP for password reset          |
|                 | POST   | `/auth/reset-password`                        | Reset password with OTP              |
| **Users**       | GET    | `/users`                                      | Get all users (Admin)                |
|                 | POST   | `/users`                                      | Create user (Admin)                  |
|                 | PUT    | `/users`                                      | Update user (Admin)                  |
|                 | DELETE | `/users`                                      | Delete user (Admin)                  |
|                 | GET    | `/users/get-by-id`                            | Get user by ID                       |
|                 | GET    | `/users/get-by-role`                          | Filter users by role                 |
| **Books**       | GET    | `/books`                                      | Get all books                        |
|                 | POST   | `/books`                                      | Add new book (Admin/Librarian)       |
|                 | PUT    | `/books`                                      | Update book (Admin/Librarian)        |
|                 | DELETE | `/books`                                      | Delete book (Admin)                  |
|                 | GET    | `/books/get-by-id`                            | Get book details                     |
|                 | GET    | `/books/book-page`                            | Paginated book list                  |
| **Borrow**      | POST   | `/transactions/borrow-requests`               | Request to borrow book (Student)     |
|                 | PATCH  | `/transactions/borrow-requests`               | Approve/reject request (Librarian)   |
|                 | DELETE | `/transactions/borrow-requests`               | Cancel request                       |
|                 | GET    | `/transactions/borrow-requests-by-userId`     | Get user's borrow requests           |
| **Return**      | POST   | `/transactions/return-requests`               | Request to return book (Student)     |
|                 | PATCH  | `/transactions/return-requests`               | Approve return (Librarian)           |
|                 | GET    | `/transactions/return-requests-by-id`         | Get return request details           |
| **Genres**      | GET    | `/genre/all`                                  | List all genres                      |
|                 | POST   | `/genre/create`                               | Add new genre (Admin)                |
|                 | PUT    | `/genre/update`                               | Update genre (Admin)                 |
| **Wishlist**    | GET    | `/wishlist/my-list`                           | Get user's wishlist (Student)        |
|                 | POST   | `/wishlist/add-to-wishlist`                   | Add to wishlist (Student)            |
| **Dashboard**   | GET    | `/dashboard/stats`                            | System stats (Admin)                 |
|                 | GET    | `/dashboard/student-stats`                    | Student activity (Student)           |

### Installation
1. Clone the repository:
  ```bash
  git clone https://github.com/UtsavBacancy-7/Utsav_LMS_Backend_2025.git
  cd LMS/LMS.API
  ```
2. Configure the database:
  - Update connection string in appsettings.json:
  ```json
  "Jwt": {
    "Issuer": "http://localhost/",
    "Audience": "http://localhost/",
    "SecretKey": "<JWT-Secret-key-for-token-generation>",
    "ExpireTimeInMinutes": "<Token-expire-time>"
  },
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": "<smtp-port-(eg., 587)>",
    "EnableSsl": true,
    "Username": "<user-email-or-username>",
    "SenderEmail": "<sender-email-address>",
    "SenderName": "BookNest Team",
    "SenderPassword": "<google-app-passkey>"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=LMS_DB;Trusted_Connection=True;"
  }
  ```
(Notes: https://developers.google.com/identity/passkeys for generating Google App Passkey.)

3. Apply database migrations:
  ```bash
  dotnet ef database update
  ```
4. Run the application:
  ```bash
  dotnet run
  ```
5. Access Swagger UI at:
  ```bash
  http://localhost:5240/swagger
  ```

## 🤝 Contributing
Contributions are welcome! Feel free to fork this repo, create a branch, and submit a pull request. Please ensure your code follows Clean Architecture and is properly formatted.