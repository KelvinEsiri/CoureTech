# CoureTech API

A .NET 8 Web API built as part of a technical assessment.

## What it does

- **Score Calculator** — takes a list of integers and calculates a score based on simple rules (even numbers = +1, odd = +3, number 8 = +5 bonus)
- **Phone Lookup** — takes a phone number and returns the country and mobile operators associated with it

## Projects

| Project | Purpose |
|---|---|
| `CoureTech.Api` | ASP.NET Core Web API (controllers, entry point) |
| `CoureTech.Application` | Business logic (services, DTOs, interfaces) |
| `CoureTech.Domain` | Entities and repository interfaces |
| `CoureTech.Infrastructure` | EF Core, in-memory database, repositories |

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- No database setup needed — the app uses an in-memory database that is seeded automatically on startup

## Setup

1. Clone the repository
   ```bash
   git clone https://github.com/KelvinEsiri/CoureTech.git
   ```

2. Restore dependencies
   ```bash
   dotnet restore
   ```

3. Build the solution
   ```bash
   dotnet build
   ```

## Running the API

```bash
cd CoureTech.Api
dotnet run
```

Swagger UI will be available at `http://localhost:5028/swagger`.

## Endpoints

### Score
```
GET /score?numbers=1,2,3,4,5
```
Returns `{ "score": 11 }`

### Phone Lookup
```
GET /phone/2348033432323
```
Returns country name, code, ISO, and list of operators.
