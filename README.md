📦 Inventory Management System
A modular inventory management system with a clean architecture and domain-driven design. Built with:

Backend: ASP.NET Core 7, C#, EF Core

Frontend: Angular 17+, PrimeNG

Database: SQL Server (EF Core migrations)# Inventory Management


🧼 Clean Architecture Principles
Domain Layer: Contains pure business models/entities.

Application Layer: DTOs, services, and interface contracts.

Infrastructure Layer: Data access (EF Core), implementations of repositories.

API Layer: Controller endpoints, DI configuration, and startup logic.

🎯 Key Features
Product, Stock, Sales, and Price management

Fully modular services with interfaces

Repository Pattern with async EF Core

Global exception handling with middleware

PrimeNG UI with data tables, forms, drawers, dropdowns

CORS-enabled backend for frontend integration

Shared modules and standalone components in Angular

🛠 Design Patterns Used
Repository Pattern

Service Layer

DTO Mapping

Dependency Injection

