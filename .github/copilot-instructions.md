# Copilot Instructions for Library App

## Project Overview
- **Library App** is a .NET 8 console application for managing library patrons, books, and loans.
- The architecture is layered:
  - **ApplicationCore**: Domain entities, enums, interfaces, and business services.
  - **Infrastructure**: Data access via JSON files, repository implementations.
  - **Console**: User interface, state machine, and DI setup.
  - **Tests**: Unit tests for service logic.

## Key Patterns & Conventions
- **Repository Pattern**: Data access is abstracted via interfaces (`IPatronRepository`, `ILoanRepository`). Implementations use JSON files and manual relationship mapping.
- **Service Layer**: Business logic is in `PatronService` and `LoanService`, injected via DI.
- **State Machine UI**: `ConsoleApp` uses `ConsoleState` and `CommonActions` enums to drive user interaction.
- **Data Population**: Navigation properties (e.g., Patron.Loans) are populated in-memory after loading flat JSON data.
- **Immediate Persistence**: Updates to patrons/loans are saved and all data is reloaded to maintain consistency.
- **Configuration**: File paths and settings are loaded from `appSettings.json`.

## Developer Workflows
- **Build**: `dotnet restore` then `dotnet build` from repo root.
- **Run**: `dotnet run --project src/Library.Console/Library.Console.csproj`
- **Test**: `dotnet test` (unit tests in `tests/UnitTests`)
- **Debug**: Set breakpoints in `ConsoleApp` or service classes; run via VS Code or CLI.

## Integration Points
- **JSON Data**: All persistent data is stored in `src/Library.Console/Json/*.json` files.
- **Dependency Injection**: Configured in `Program.cs` using Microsoft.Extensions.DependencyInjection.
- **Configuration**: Uses Microsoft.Extensions.Configuration to load settings.

## Project-Specific Advice
- When adding new actions to the UI, update `CommonActions` and handle them in `ConsoleApp`.
- When extending data models, update both the entity classes and the JSON population logic in `JsonData`.
- For new repository types, follow the pattern in `JsonPatronRepository` and `JsonLoanRepository`.
- Always reload data after updates to ensure navigation properties are correct.
- Use the provided unit test factories (`PatronFactory`, `LoanFactory`) for creating test data.

## Key Files & Directories
- `src/Library.ApplicationCore/Entities/` — Domain models
- `src/Library.ApplicationCore/Services/` — Business logic
- `src/Library.Infrastructure/Data/` — Data access and population
- `src/Library.Console/ConsoleApp.cs` — Main UI logic
- `src/Library.Console/Program.cs` — DI and app startup
- `src/Library.Console/Json/` — Data files
- `tests/UnitTests/` — Unit tests

---
For questions about conventions or unclear patterns, review the README or ask for clarification.