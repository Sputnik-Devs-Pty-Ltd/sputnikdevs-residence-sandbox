# Sputnik Devs Studio — Pilot 19-Day WIL Sprint Backlog

**Candidate:** Brian Mkandla  
**Tech Stack:** C# 12 / .NET 10, ASP.NET Core Web API, Entity Framework Core, PostgreSQL (Docker), Git / GitHub  
**Milestone Cadence:** 1 Working Day = 1 Measurable Pull Request / Deliverable  

---

## Sprint Overview

```
Week 1 (Days 01–05) ───> Environment, Git Hygiene, C# Domain Models & EF Core Migrations
Week 2 (Days 06–10) ───> RESTful API Endpoints, DTO Mapping, Validation & Midterm Review
Week 3 (Days 11–15) ───> Status Workflows, Advanced Filtering, & Automated Testing (xUnit)
Week 4 (Days 16–19) ───> Integration Tests, Dockerization, Final Presentation & Sign-Off
```

---

## Detailed Daily Milestone Breakdown

### Week 1: Foundations, Relational Modeling & Database Setup

#### Day 01: Cloud Environment Setup & First API Run
* **Objective:** Establish a repeatable, clean developer workspace with zero laptop strain.
* **Tasks:**
  - Launch your workspace via **GitHub Codespaces** (Option A — recommended) or clone locally with .NET 10 (Option B).
  - Study [ONBOARDING.md](ONBOARDING.md) and [AI_USAGE_POLICY.md](AI_USAGE_POLICY.md).
  - Run the API in the terminal: `dotnet run --project SputnikDevs.Residence.SandboxApi`.
  - Verify that the SQLite database auto-creates and seeds sample rooms, students, and tickets.
  - Open Swagger UI at `http://localhost:5035/` and test `GET /api/v1/tickets`.
* **Deliverable:** First successful run verified in Swagger UI with 0 errors.

#### Day 02: Git Hygiene & Branching Conventions
* **Objective:** Master professional Git feature-branch workflows.
* **Tasks:**
  - Review [ONBOARDING.md](ONBOARDING.md) Git conventions.
  - Create personal working branch: `feature/wil-brian-init`.
  - Practice authoring Conventional Commits (`docs(wil): ...`, `feat(sandbox): ...`).
* **Deliverable:** Submit PR #1 adding student profile to the internship logbook.

#### Day 03: Domain Modeling & Enum Design
* **Objective:** Design strongly-typed C# domain models for the student housing domain.
* **Tasks:**
  - Implement `BaseEntity` (Guid Id, CreatedAtUtc, UpdatedAtUtc).
  - Implement `Student` and `Room` domain entities.
  - Implement `MaintenanceTicket` and `TicketComment` entities.
  - Design enums: `TicketCategory`, `TicketPriority`, and `TicketStatus`.
* **Deliverable:** PR #2 containing all domain entity classes in `Domain/Entities/`.

#### Day 04: Entity Framework Core Fluent API Mapping
* **Objective:** Map C# entities to relational database tables with proper constraints.
* **Tasks:**
  - Create `SandboxDbContext.cs` inheriting from `DbContext`.
  - Configure primary keys, foreign keys, and indexes via Fluent API.
  - Configure enum string conversions so statuses appear as strings in PostgreSQL.
  - Run `dotnet ef migrations add InitialCreate` to generate migration files.
* **Deliverable:** PR #3 with clean migration files applying successfully to local PostgreSQL.

#### Day 05: Database Seeding & Data Resiliency
* **Objective:** Guarantee that any new developer has a pre-populated sandbox upon launch.
* **Tasks:**
  - Implement `DbInitializer.SeedAsync()`.
  - Seed 4 realistic campus rooms with varying capacities.
  - Seed 3 test students with assigned rooms.
  - Seed 3 categorized maintenance tickets with audit comments.
* **Deliverable:** PR #4 demonstrating automated database seeding in terminal logs.

---

### Week 2: RESTful Endpoints, DTOs & Validation

#### Day 06: Data Transfer Objects (DTOs) & API Separation
* **Objective:** Decouple domain models from external API contracts.
* **Tasks:**
  - Study why entities must not be returned directly over public HTTP APIs.
  - Create immutable C# record DTOs: `MaintenanceTicketDto`, `CreateMaintenanceTicketDto`, `StudentDto`, `RoomDto`.
  - Define mapping logic in private static helper methods or extension methods.
* **Deliverable:** PR #5 establishing DTO contracts in `DTOs/`.

#### Day 07: Read Endpoints (`GET /api/v1/tickets`)
* **Objective:** Implement high-performance query endpoints.
* **Tasks:**
  - Build `TicketsController` with `GET /api/v1/tickets` and `GET /api/v1/tickets/{id}`.
  - Incorporate `.AsNoTracking()` for read optimization.
  - Include related entities (`Student`, `Room`, `Comments`) using EF Core `.Include()`.
* **Deliverable:** PR #6 verified in Swagger UI returning formatted JSON ticket lists.

#### Day 08: Create Endpoints (`POST /api/v1/tickets`)
* **Objective:** Implement write operations with relational integrity checks.
* **Tasks:**
  - Implement `POST /api/v1/tickets`.
  - Add pre-checks verifying that `StudentId` and `RoomId` exist before saving.
  - Return `201 Created` with `CreatedAtAction` pointing to `GetTicketById`.
* **Deliverable:** PR #7 tested with valid and invalid foreign keys.

#### Day 09: Model Validation & HTTP Problem Details
* **Objective:** Ensure robust validation and standardized error responses.
* **Tasks:**
  - Apply `[Required]`, `[MaxLength]`, and `[EmailAddress]` validation attributes.
  - Ensure controller validates `ModelState.IsValid` and returns structured `400 Bad Request`.
  - Implement safe handling for `404 Not Found` when requesting nonexistent IDs.
* **Deliverable:** PR #8 ensuring no unhandled 500 exceptions occur on bad user input.

#### Day 10: Status Transitions & Formative Midterm Defense
* **Objective:** Implement state transition logic and defend progress to mentors.
* **Tasks:**
  - Implement `PATCH /api/v1/tickets/{id}/status`.
  - Support updating technician assignment, status notes, and automated `ResolvedAtUtc` timestamps.
  - **Milestone Defense:** Conduct 30-minute formative code review with mentors.
* **Deliverable:** PR #9 merged; Formative Midterm Assessment recorded in evaluation rubric.

---

### Week 3: Workflows, Advanced Querying & Automated Testing

#### Day 11: Ticket Audit Comment Threading
* **Objective:** Enable multi-party communication on maintenance issues.
* **Tasks:**
  - Implement `POST /api/v1/tickets/{id}/comments`.
  - Store author name, author role ("Student", "Technician", "Admin"), and message content.
  - Verify that deleting a ticket cascades cleanly to its comments.
* **Deliverable:** PR #10 with working comment thread capabilities.

#### Day 12: Query Filtering, Sorting & Search
* **Objective:** Allow frontend applications to filter tickets efficiently.
* **Tasks:**
  - Enhance `GET /api/v1/tickets` with query parameters: `status`, `priority`, `category`, and `roomId`.
  - Build dynamic `IQueryable<T>` conditional query builder.
  - Sort results descending by `CreatedAtUtc`.
* **Deliverable:** PR #11 with multi-filter query tests in Swagger.

#### Day 13: Students & Rooms Management Controllers
* **Objective:** Expand API coverage across the residence domain.
* **Tasks:**
  - Build `StudentsController` (`GET`, `GET by Id`, `POST`).
  - Build `RoomsController` (`GET`, `GET by Id`).
  - Calculate dynamic room occupancy (`Students.Count >= Capacity`).
* **Deliverable:** PR #12 completing the student residence API endpoints.

#### Day 14: CORS, Formatting & Swagger Enhancements
* **Objective:** Polish API developer experience for mobile/frontend integration.
* **Tasks:**
  - Configure CORS policies allowing mobile/frontend localhost origins.
  - Add XML documentation comments to controller endpoints.
  - Configure Swagger OpenAPI metadata and descriptions.
* **Deliverable:** PR #13 with fully documented interactive Swagger UI at root `/`.

#### Day 15: Unit Testing with xUnit
* **Objective:** Introduce automated test-driven practices.
* **Tasks:**
  - Add `SputnikDevs.Residence.SandboxApi.Tests` xUnit project.
  - Write unit tests validating DTO model validation and enum parsing.
  - Write unit tests verifying room occupancy calculation logic.
* **Deliverable:** PR #14 with passing xUnit tests running via `dotnet test`.

---

### Week 4: Integration Tests, Dockerization & Exit Defense

#### Day 16: Integration Testing with `WebApplicationFactory`
* **Objective:** Test end-to-end HTTP pipeline without running external servers.
* **Tasks:**
  - Configure `WebApplicationFactory<Program>` with in-memory or SQLite database.
  - Write integration test verifying `POST /api/v1/tickets` creates a record in database.
  - Write integration test verifying `GET /api/v1/tickets/{id}` returns correct HTTP status.
* **Deliverable:** PR #15 with automated API integration tests.

#### Day 17: Containerization & Dockerfile Scaffolding
* **Objective:** Package the entire API into a portable Linux container.
* **Tasks:**
  - Author a multi-stage `Dockerfile` (`build` stage + `runtime` stage).
  - Update `docker-compose.yml` to run both the API container and PostgreSQL together.
  - Verify full stack boots with a single command: `docker compose up --build`.
* **Deliverable:** PR #16 with containerization verified locally.

#### Day 18: Code Audit, Refactoring & Linter Review
* **Objective:** Ensure enterprise code hygiene before final release.
* **Tasks:**
  - Conduct static analysis code audit (remove unused usings, simplify LINQ).
  - Ensure zero compiler warnings across all projects.
  - Finalize daily logbook entries in [DAILY_CADENCE_AND_LOGBOOK.md](DAILY_CADENCE_AND_LOGBOOK.md).
* **Deliverable:** PR #17 containing final code refactoring and cleanups.

#### Day 19: Final Technical Presentation & Program Exit Defense
* **Objective:** Showcase completed deliverables and receive formal WIL sign-off.
* **Tasks:**
  - Prepare a 30-minute slide and live code demonstration:
    1. Architecture overview & database schema.
    2. Live API walkthrough in Swagger / Postman.
    3. Code defense: Explain 3 technical challenges overcome during the sprint.
  - Mentors score summative exit defense on [EVALUATION_RUBRIC.md](EVALUATION_RUBRIC.md).
  - Sign off on final institutional logbook and issue official verification credential on `sputnikdevs.com/academy/verify`.
* **Deliverable:** Formal completion of the Sputnik Devs Studio WIL Pilot Program!
