# 📚 BookNest : Library Management System (LMS) - Frontend UI
![Angular](https://img.shields.io/badge/Angular-16.2.16-red)
![TypeScript](https://img.shields.io/badge/TypeScript-5.3-blue)
![RxJS](https://img.shields.io/badge/RxJS-7.8-purple)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-teal)
![SCSS](https://img.shields.io/badge/SCSS-Styled-blueviolet)
![JWT Auth](https://img.shields.io/badge/Auth-JWT-green)
![Responsive UI](https://img.shields.io/badge/UI-Responsive-orange)
![Lazy Loading](https://img.shields.io/badge/Module-Lazy_Loading-success)
![Role Guard](https://img.shields.io/badge/AccessControl-Role_Based-lightgrey)
![VS Code](https://img.shields.io/badge/IDE-VS_Code-blue)


This is the **frontend application** for the Library Management System, developed using **Angular v16.2.16**. It serves as a clean, scalable SPA (Single Page Application) with **role-based access** and **JWT authentication**, supporting **Admin**, **Librarian**, and **Student** roles.

## 🚀 Tech Stack

| Layer            | Technology               |
|------------------|--------------------------|
| Frontend         | Angular 16.2.16          |
| UI Framework     | Bootstrap 5, SCSS        |
| State Handling   | RxJS, Services            |
| Routing          | Angular Router + Guards |
| API Integration  | RESTful HTTP (with Interceptors) |
| Auth             | JWT (Token-based)        |


## ✅ Key Features

### 🔐 Authentication & Role Access
- Secure Login/Registration with JWT
- Auto-login via LocalStorage
- Role-based route protection using guards
- Lazy-loaded modules for each user role

### 📚 Book & Transaction Management
- View/search/filter books
- Borrow/return flow for students
- Approval system for librarians
- Book CRUD for admin/librarian

### 🧑‍💼 User Management
- Admin can manage users
- Librarians can manage book flow
- Students have a personalized dashboard (wishlist, history)

### 🎨 UI/UX
- Modular design using `layout` and `shared` components
- Reusable loaders, headers, and footers
- Blurred background modals
- Mobile responsive design
- Custom reactive form validations


## 🧩 Project Structure
```
src/
└── app/
├── core/ # Global services and interceptors
│ ├── interceptors/
│ └── services/
├── data/ # Models, interfaces (e.g., IUser, IBook)
├── layout/ # Shared layout UI like header, footer, loader
│ ├── header/
│ ├── footer/
│ └── loader/
├── modules/ # Feature modules per role
│ ├── admin/
│ ├── librarian/
│ └── student/
├── shared/ # Shared reusable components
│ ├── components/
│ ├── guards/
│ ├── modules/auth/ # Auth module shared across pages
│ └── services/ # Form validation service, token services, etc.
├── app-routing.module.ts
└── app.component.* # Root application files
```

## Role-based Features
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
| Book Review (Add)       | ✗     | ✗         | ✓       |


## 🛠️ Setup Instructions

1. 📥 Clone the Repository
```bash
git clone https://github.com/UtsavBacancy-7/Utsav_LMS_Frontend_2025.git
cd LMS_Frontend
```
2. 📦 Install Dependencies
``` bash
npm install
```
3. ⚙️ Set Environment Variables
Edit `src/environments/environment.ts`:
```ts
export const environment = {
  production: false,
  apiUrl: 'https://localhost:5240/api/v1'
};
```
4. ▶️ Run the App
```bash
ng serve --open
```
- App will run at http://localhost:4200.

### 📬 Communication Flow
- Interceptors auto-attach JWT tokens
- Guards prevent unauthorized route access
- Reactive forms use a custom ValidationService
- Modals with blurred background and live data refresh

### 🤝 Contributing
- Contributions are welcome! Feel free to fork this repo, create a branch, and submit a pull request. Please ensure your code follows Clean Architecture and is properly formatted.
