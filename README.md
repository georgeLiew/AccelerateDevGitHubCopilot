# Library App

## Description

Library App is a .NET 8 console application that models a simple library system for managing patrons, books, and loans. It features a layered architecture with clean separation between domain logic, infrastructure, and user interface. Data is stored in JSON files, and the project includes unit tests for core business logic.

## Project Structure

- AccelerateDevGitHubCopilot.sln
- README.md
- src/
  - Library.ApplicationCore/
    - Library.ApplicationCore.csproj
    - Entities/
    - Enums/
    - Interfaces/
    - Services/
  - Library.Console/
    - appSettings.json
    - CommonActions.cs
    - ConsoleApp.cs
    - ConsoleState.cs
    - Library.Console.csproj
    - Program.cs
    - Json/
      - Authors.json
      - Books.json
      - BookItems.json
      - Patrons.json
      - Loans.json
  - Library.Infrastructure/
    - Library.Infrastructure.csproj
    - Data/
      - JsonData.cs
      - JsonPatronRepository.cs
      - JsonLoanRepository.cs
- tests/
  - UnitTests/
    - UnitTests.csproj
    - PatronFactory.cs
    - LoanFactory.cs
    - ApplicationCore/
      - PatronService/
        - RenewMembership.cs
      - LoanService/
        - ReturnLoan.cs
        - ExtendLoan.cs

## Key Classes and Interfaces

- **Domain Entities**
  - `Library.ApplicationCore.Entities.Patron` — Represents a library patron.
  - `Library.ApplicationCore.Entities.Loan` — Represents a book loan.
  - `Library.ApplicationCore.Entities.Book` — Represents a book.
  - `Library.ApplicationCore.Entities.BookItem` — Represents a physical copy of a book.
  - `Library.ApplicationCore.Entities.Author` — Represents a book author.

- **Services**
  - `Library.ApplicationCore.Services.PatronService` — Handles patron membership renewal.
  - `Library.ApplicationCore.Services.LoanService` — Handles loan extension and return.

- **Repositories**
  - `Library.Infrastructure.Data.JsonPatronRepository` — Patron data access via JSON.
  - `Library.Infrastructure.Data.JsonLoanRepository` — Loan data access via JSON.

- **Data Manager**
  - `Library.Infrastructure.Data.JsonData` — Loads, saves, and populates entities from JSON files.

- **Interfaces**
  - `Library.ApplicationCore.Interfaces.IPatronRepository` — Patron repository contract.
  - `Library.ApplicationCore.Interfaces.ILoanRepository` — Loan repository contract.
  - `Library.ApplicationCore.Interfaces.IPatronService` — Patron service contract.
  - `Library.ApplicationCore.Interfaces.ILoanService` — Loan service contract.

- **Console UI**
  - `Library.Console.ConsoleApp` — Main console application logic.
  - `Library.Console.ConsoleState` — UI state machine.
  - `Library.Console.CommonActions` — UI action flags.

## Usage

1. **Build the project:**
   ```sh
   dotnet restore
   dotnet build```
