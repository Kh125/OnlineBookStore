# OnlineBookStore

OnlineBookStore is an ASP.NET Core 8 MVC web application for managing books and categories with role-based access using ASP.NET Core Identity.

## Tech Stack

- .NET 8 / ASP.NET Core MVC
- Entity Framework Core 8
- MySQL (Pomelo provider)
- ASP.NET Core Identity
- Razor Pages + Bootstrap

## Solution Structure

- `OnlineBookStore` - Web app (areas, controllers, views, startup config)
- `OnlineBookStore.Data` - `ApplicationDbContext`, repositories, migrations, view models
- `OnlineBookStore.Models` - Domain models (`Book`, `Category`, `Order`, etc.)
- `OnlineBookStore.Utils` - Shared constants and utility services
- `OnlineBookStore_Temp` - Temporary/auxiliary web project

## Current Features

- Authentication and registration with ASP.NET Core Identity
- Role constants for `Admin`, `Customer`, `Employee`, and `Company`
- Admin-only management for:
  - Categories (create, edit, delete, list)
  - Books (create, edit, delete, list)
- Customer area pages for home and book listing
- EF Core migrations and seed data for categories, books, users, orders, and order items

## Prerequisites

- .NET SDK 8.0+
- MySQL server running locally (or reachable from your environment)

## Getting Started

1. Clone and open the repository.
2. Update the database connection string in:
   - `OnlineBookStore/appsettings.json`
   - `ConnectionStrings:DefaultConnection`
3. Restore dependencies:

   ```bash
   dotnet restore /home/runner/work/OnlineBookStore/OnlineBookStore/OnlineBookStore.sln
   ```

4. Apply EF Core migrations:

   ```bash
   dotnet ef database update \
     --project /home/runner/work/OnlineBookStore/OnlineBookStore/OnlineBookStore.Data/OnlineBookStore.Data.csproj \
     --startup-project /home/runner/work/OnlineBookStore/OnlineBookStore/OnlineBookStore/OnlineBookStore.csproj
   ```

5. Run the web app:

   ```bash
   dotnet run --project /home/runner/work/OnlineBookStore/OnlineBookStore/OnlineBookStore/OnlineBookStore.csproj
   ```

6. Open the URL shown in terminal (typically `https://localhost:xxxx`).

## Build and Test

```bash
dotnet build /home/runner/work/OnlineBookStore/OnlineBookStore/OnlineBookStore.sln
dotnet test /home/runner/work/OnlineBookStore/OnlineBookStore/OnlineBookStore.sln
```

## Notes

- Identity roles are created when the register page is accessed for the first time.
- `EmailSender` is currently a stub implementation (`Task.CompletedTask`), so email confirmation is not actually sent.
