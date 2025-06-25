# 💼 Loan Management System - .NET Web API 💻

A modern, multi-layered **Loan Management System** built using **ASP.NET Web API**, designed to track loans, payments, and interest — following clean architecture and professional coding standards.

---

## 🚀 Features

✅ Full **CRUD** operations for Loans and Payments  
✅ Advanced **Search & Filtering** by loan status, amount range, interest rate, etc.  
✅ 📊 **Analytical Reports** — Loan status breakdown & payment summaries  
✅ 🎯 Total paid amount, remaining balance, and payment completion percentage per loan  
✅ SOLID principles with layered, maintainable architecture  
✅ DTOs and AutoMapper for clean data handling  
✅ Secure, RESTful API endpoints ready for production  

---

## 🏗️ Tech Stack

- **ASP.NET Web API (.NET Framework)**  
- **Entity Framework 6 (Code First)**  
- **AutoMapper** for DTO mapping  
- **SQL Server** for data storage  
- **Postman** for API testing  

---

## 🗂️ Project Architecture

| Layer         | Responsibility                       |
|---------------|---------------------------------------|
| `DAL`         | Entity Models, Repositories (Data Access) |
| `BLL`         | Business Logic, Services, DTOs       |
| `API`         | ASP.NET Web API Controllers          |

---

## ⚡ Setup & Installation

1. **Clone Repository**  
   ```bash
   git clone https://github.com/Bpbishal/loan-management-system.git
   cd loan-management-system
````

2. **Configure Database**

   * Update `Web.config` connection string to your SQL Server instance

3. **Run Migrations & Seed Data**

   ```powershell
   Update-Database
   ```

4. **Build & Launch API**
   Run the project in Visual Studio (IIS Express or preferred host)

---

## 🔥 API Endpoints

| Method | Endpoint                            | Description                        |
| ------ | ----------------------------------- | ---------------------------------- |
| GET    | `/api/customers/all`                | Get all customers                  |
| POST   | `/api/customers/create`             | Create a new customer              |
| GET    | `/api/loans/all`                    | Get all loans                      |
| GET    | `/api/loans/{id}`                   | Get loan by ID                     |
| POST   | `/api/loans/create`                 | Create a new loan                  |
| PUT    | `/api/loans/update`                 | Update loan details                |
| DELETE | `/api/loans/delete/{id}`            | Delete a loan                      |
| GET    | `/api/loans/search`                 | Search loans by status/amount/rate |
| GET    | `/api/loans/paymentstatus/{id}`     | Loan payment summary               |
| GET    | `/api/loans/report/statusbreakdown` | Loan status analytical report      |

---

## 🎨 Extra Features

✔ Total Paid, Remaining, and % Completion per Loan
✔ Analytical reports with status-wise loan breakdown
✔ Search loans using flexible filters
✔ Professional DTO mapping with AutoMapper
✔ Clean, scalable, maintainable code

---

## 📬 Contact

Developed by **\[Bishal Paul]**
🔗 GitHub: [https://github.com/Bpbishal](https://github.com/Bpbishal)
📧 Email: [bishalpaul816@gmail.com](mailto:bishalpaul816@gmail.com)

---

## 📝 License

MIT License — free to use and modify.

---

**🎉 Thank you for exploring the Loan Management System!**

```
```
