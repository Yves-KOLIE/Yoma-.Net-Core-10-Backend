# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
# Build
dotnet build

# Run (Development, http://localhost:5079)
dotnet run

# Watch mode (hot reload)
dotnet watch run

# EF Core migrations
dotnet ef migrations add <Name>
dotnet ef database update
```

There are no test projects in this repo yet (no `*.Tests.csproj`, no test runner configured). If you add tests, add the corresponding `dotnet test` instructions here.

The project targets `net10.0` (see `backend.csproj`) and uses PostgreSQL via `Npgsql.EntityFrameworkCore.PostgreSQL`. A local Postgres instance with a `YOMABD` database is expected; the connection string lives in `appsettings.json` / `appsettings.Development.json`.

## Architecture

This is a single-project ASP.NET Core Web API (root namespace `YOMA`) backing an Angular frontend (CORS is locked to `http://localhost:4200` in `Program.cs`). There is no Clean Architecture / layered project split — everything lives in one project with these folders:

- **`Controllers/`** — one controller per resource, routed as `api/[controller]`. Controllers are thin: they call into a matching `Services/` class and a shared `Context` (both injected), then wrap the result in `ApiResult` (`Message`, `IsError`, `Data`) before returning `Ok(...)`/`BadRequest(...)`. Every action follows the same try/catch shape — catch `Exception`, return `BadRequest` with `ErrorDetails = ex.Message`. Follow this exact pattern for new endpoints rather than introducing a different response envelope.
- **`Services/`** — business logic and most EF Core queries. Naming is inconsistent (`XxxService`, or just `Xxx`, e.g. `Services/StudentRegistration.cs` defines `StudentRegistrationService`) — check the actual class name inside the file rather than assuming it matches the filename. Multi-step writes that touch several tables use `_context.Database.BeginTransactionAsync()` with manual commit/rollback (see `StudentRegistrationService.CreateStudentRegistrationAsync`).
- **`Models/Tables/`** — EF Core entities, one per DB table. Property names are `UPPER_SNAKE_CASE` and this is preserved end-to-end: JSON serialization has `PropertyNamingPolicy = null` set in `Program.cs`, so entity property casing is what the frontend receives — don't add camelCase conversion.
- **`Models/Views/`** — view/projection models returned to the client for some endpoints (not EF-mapped tables), e.g. `SubdivisionByYearViewModel`.
- **`Models/Tables/Context.cs`** — the single `DbContext` (`Context`), with all `DbSet`s and the `OnModelCreating` overrides (composite/self-referencing FKs on `Student` for `PARENT_1`/`PARENT_2`, unique indexes on email/matricule fields, check constraints on `BookRental`/`Book`). New entities need a `DbSet` added here plus any FK/constraint config.
- **`Migrations/`** — standard EF Core migrations against Postgres, generated in order; don't hand-edit past migrations, add a new one.
- **`Helpers/`** — static helper classes: `PasswordHelper` (BCrypt hashing/verification, code validation), `EmailHelper` (MailKit-based email sending, forgot-password code checks), `ConstantHelper` (shared string constants, e.g. `DEFAULT_PASSWORD`, save success/error messages).

### Auth

JWT bearer auth is fully wired in `Program.cs` (`Jwt:Issuer`/`Jwt:Audience`/`Jwt:SigningKey` from configuration, 15-minute access tokens issued by `JwtTokenService`), but **no controller currently has `[Authorize]`** — all endpoints are effectively open. Keep this in mind: adding `[Authorize]` to existing controllers is a behavior change that will start rejecting unauthenticated Angular requests, not just a hardening no-op.

There is no ASP.NET Identity/single `Users` table for login — three separate person types (`User` = professeur, `Student` = élève, `Parent`) share a `UserEmail` table keyed by `USER_TYPE_ID` (1/2/3), and `LoginController.Auth` branches on that type to look up the right table, verify the password (BCrypt via `PasswordHelper`), and issue a token via `JwtTokenService.CreateAccessToken(id, role)`. Forced password reset is driven by comparing against `ConstantHelper.DEFAULT_PASSWORD`. Any change to login/password logic needs to be replicated across all three `case` branches (professeur/élève/parent) — the controller doesn't share this logic in one place.

### Domain shape

The domain is a school management system: students, parents, school years/levels/subdivisions, courses (`Cours`), grades per school stage (`NotePrimary`/`NoteMiddleSchool`/`NoteHightSchool`, dispatched by `EducationLevel.SCHOOL_EDUCATION_ID`), school/bus fees and payments, payroll (`MonthlySalaryAssignment`, `SalaryAdvance`, `PayrollValidation`, primes), and a small book-rental module (`Book`, `BookRental`). `StudentRegistrationService.CreateStudentRegistrationAsync` is the widest-reaching write path — it creates the student, both parent links, fee snapshots, an optional `ExamClass` row, and per-course grade rows for the relevant `NoteMonth`s in one transaction; use it as the reference for how a new registration should cascade.
