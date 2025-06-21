# 📚 BookNest: Library Management System (LMS)

![Angular](https://img.shields.io/badge/Angular-16.2.16-red)
![TypeScript](https://img.shields.io/badge/TypeScript-5.3-blue)
![RxJS](https://img.shields.io/badge/RxJS-7.8-purple)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-teal)
![SCSS](https://img.shields.io/badge/SCSS-Styled-blueviolet)
![JWT Auth](https://img.shields.io/badge/Auth-JWT-green)
![.NET Core](https://img.shields.io/badge/.NET-8.0-blue)
![Entity Framework Core](https://img.shields.io/badge/EF_Core-8.0-green)
![SQL Server](https://img.shields.io/badge/SQL_Server-20.0-red)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean_Architecture-blueviolet)

A complete Library Management System with modern Angular frontend and .NET Core backend, featuring role-based access control, JWT authentication, and comprehensive library management features.

## 🌟 System Overview

BookNest LMS is a full-stack application that provides:
- **Frontend**: Responsive Angular SPA with lazy-loaded modules
- **Backend**: Robust .NET Core API with Clean Architecture
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: Secure JWT token-based system
- **Features**: Book management, borrowing system, wishlists, and admin dashboard

## 🚀 Technology Stack

### Frontend (Angular)
| Layer            | Technology               |
|------------------|--------------------------|
| Framework        | Angular 16.2.16          |
| UI Framework     | Bootstrap 5, SCSS        |
| State Handling   | RxJS, Services           |
| Routing          | Angular Router + Guards  |
| API Integration  | RESTful HTTP (Interceptors) |
| Auth             | JWT (Token-based)        |

### Backend (.NET Core)
| Layer            | Technology               |
|------------------|--------------------------|
| Framework        | .NET Core 8.0            |
| Database         | SQL Server 20.0+         |
| ORM              | Entity Framework Core 8.0|
| Authentication   | JWT Bearer Tokens        |
| API Documentation| Swagger UI               |
| Architecture     | Clean Architecture       |

## 🏗️ Project Structure

### Frontend (Angular)
```
src/
└── app/
├── core/ # Global services and interceptors
│ ├── interceptors/
│ └── services/
├── data/ # Models, interfaces
├── layout/ # Shared layout UI
│ ├── header/
│ ├── footer/
│ └── loader/
├── modules/ # Feature modules per role
│ ├── admin/
│ ├── librarian/
│ └── student/
├── shared/ # Shared components
│ ├── components/
│ ├── guards/
│ ├── modules/auth/
│ └── services/
├── app-routing.module.ts
└── app.component.*
```

### Backend (.NET Core)
```
├── LMS.API/ # API endpoints
├── LMS.Application/ # Application layer
├── LMS.Common/ # Common utilities
├── LMS.Domain/ # Domain models
├── LMS.Infrastructure/ # Infrastructure
│   ├── Context/ # Database
│   ├── Repository/ # Repository pattern
│   └── Mappers/ # AutoMapper
├── Program.cs # Startup
└── appsettings.json # Config
```

## ✅ Key Features

### 🔐 Authentication & Security
- JWT Token-Based Authentication
- Role-Based Authorization (Admin, Librarian, Student)
- Auto-login via LocalStorage
- Password reset via OTP
- Rate Limiting for API protection

### 📚 Book Management
- CRUD operations for books
- Advanced search and filtering
- Genre management
- Book availability tracking
- Review system

### 🔄 Transaction System
- Borrow/return request flow
- Approval system for librarians
- Transaction history
- Late return penalties

### 👥 User Management
- Student registration
- User CRUD for admins
- Role assignment
- Block/unblock users

### 🎨 Dashboard & Personalization
- Role-specific dashboards
- Student wishlists
- Notifications system
- Email alerts for transactions

## 👨‍💼 Role-based Features

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

## 🛠️ Setup Instructions

### Frontend Setup
1. Clone the repository:
```bash
git clone https://github.com/Utsav-7/BookNest_LMS_Full_Stack.git
cd LMS_Frontend
```

2. Install dependencies:
```bash
npm install
```

3. Configure environment:
Edit `src/environments/environment.ts`:
```ts
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5240/api/v1'
};
```

4. Run the app:
```bash
ng serve --open
```
Access at: http://localhost:4200

### Backend Setup
1. Clone the repository:
```bash
git clone https://github.com/Utsav-7/BookNest_LMS_Full_Stack.git
cd LMS_Backend/LMS.API
```

2. Configure appsettings.json:
```json
{
  "Jwt": {
    "Issuer": "http://localhost/",
    "Audience": "http://localhost/",
    "SecretKey": "your-secret-key",
    "ExpireTimeInMinutes": "60"
  },
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": "587",
    "EnableSsl": true,
    "Username": "your-email@gmail.com",
    "SenderEmail": "sender-email@gmail.com",
    "SenderName": "BookNest Team",
    "SenderPassword": "your-app-password"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=LMS_DB;Trusted_Connection=True;"
  }
}
```

3. Apply database migrations:
```bash
dotnet ef database update
```

4. Run the application:
```bash
dotnet run
```

5. Access Swagger UI at:
http://localhost:5240/swagger

## 🌐 API Endpoints

| Category        | Method | Endpoint                                      | Description                          |
|-----------------|--------|-----------------------------------------------|--------------------------------------|
| **Auth**        | POST   | `/auth/register`                              | Student registration                 |
|                 | POST   | `/auth/login`                                 | User login                           |
| **Users**       | GET    | `/users`                                      | Get all users (Admin)                |
| **Books**       | GET    | `/books`                                      | Get all books                        |
| **Borrow**      | POST   | `/transactions/borrow-requests`               | Borrow request (Student)             |
| **Return**      | POST   | `/transactions/return-requests`               | Return request (Student)             |
| **Genres**      | GET    | `/genre/all`                                  | List all genres                      |
| **Wishlist**    | GET    | `/wishlist/my-list`                           | Get wishlist (Student)               |

## 🤝 Contributing
1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

**BookNest LMS** - Modern library management for the digital age 📚✨
