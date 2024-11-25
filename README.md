

# README for REST-Calculator with JWT Authentication

## CalculatorApp

CalculatorApp is a RESTful API built using .NET Core, featuring JWT-based authentication and authorization. It includes services to handle token generation and validation securely.

## Features

- JWT Authentication: Secure token-based authentication system.
- Token Validation: Validation of tokens to ensure proper authentication.
- Claims-Based Authorization: Role and user-specific access control using claims.
- Extensible Design: Easy-to-expand authentication and business logic.

## Prerequisites

- .NET 6.0 or higher installed on your system.
- A valid `appsettings.json` file for configuring JWT parameters.
- Postman or a similar tool for testing API endpoints (optional).

## Setup

### 1. Clone the Repository

git clone <repository_url>
cd CalculatorApp

appsettings.json

{
  "Jwt": {
    "SecretKey": "YourSuperSecretKey123!",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience"
  }
}

# Install dependancies, build and run the project

dotnet restore
dotnet build
dotnet run

# Endpoints

Generate Token
POST /auth/token

request body 
{
  "username": "testuser",
  "password": "testpassword"
}

Response

{
  "token": "<JWT Token>"
}


For other endpoint use the token in request header

Authorization: Bearer <JWT Token>

