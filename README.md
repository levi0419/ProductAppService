# ProductServiceApp

**ProductServiceApp** is a microservice-based backend application built with **.NET 6** and **MongoDB**, following a clean architecture with Domain, Application, Infrastructure, and API layers. It exposes RESTful endpoints for managing products and categories and includes Swagger documentation for easy API testing.

---

## Table of Contents

- [Features](#features)  
- [Tech Stack](#tech-stack)  
- [Prerequisites](#prerequisites)  
- [Getting Started](#getting-started)  
- [Project Structure](#project-structure)  
- [API Endpoints](#api-endpoints)  
- [Configuration](#configuration)  
- [Logging](#logging)  
- [Docker Support](#docker-support)  
- [Contributing](#contributing)  
- [License](#license)  

---

## Features

- CRUD operations for products and categories  
- MongoDB integration for persistent storage  
- Swagger/OpenAPI documentation  
- Serilog logging to console and file  
- Clean, modular architecture with dependency injection  

---

## Tech Stack

- **Backend:** ASP.NET Core Web API (.NET 6)  
- **Database:** MongoDB  
- **Logging:** Serilog  
- **API Documentation:** Swagger/OpenAPI  

---

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)  
- [MongoDB](https://www.mongodb.com/) installed and running locally or remotely  
- [Docker](https://www.docker.com/) (optional, for containerized deployment)  

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/levi0419/ProductAppService.git
cd ProductAppService
dotnet restore
dotnet run --project ProductService.Api

