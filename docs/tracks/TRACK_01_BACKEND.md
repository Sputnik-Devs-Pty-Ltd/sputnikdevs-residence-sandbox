# Track 01: Backend & Cloud API Engineering (19-Day WIL Syllabus)

* **Track Code:** `BackendAndCloud` (`Track 01`)
* **Target Workspace:** `SputnikDevs.Residence.SandboxApi/`
* **Core Tech Stack:** C# 12, ASP.NET Core Web API (.NET 10), Entity Framework Core, PostgreSQL 16 / SQLite, xUnit, Docker.
* **Student Portal & Oral Defense Questions:** [https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal)

---

## 19-Day Milestone Schedule (152 Credit Hours)

| Day | Phase | Milestone Title | Deliverable Summary |
| :--- | :--- | :--- | :--- |
| **Day 01** | Week 1 | Environment, Codespaces & Domain Architecture | Fork sandbox repo, boot Codespaces or local .NET 10, inspect `Room`, `Student`, and `MaintenanceTicket` entities, submit PR #1. |
| **Day 02** | Week 1 | Rooms Query Filtering (`GET /api/v1/rooms`) | Add optional query filters (`availableOnly`, `floor`, `buildingBlock`) using `IQueryable<Room>` & `AsNoTracking()`. |
| **Day 03** | Week 1 | Room Details, Creation & Validation (`POST /api/v1/rooms`) | Implement `GET /api/v1/rooms/{id}` (`404 NotFound`) and `POST /api/v1/rooms` (`201 CreatedAtAction`) with duplicate room number guard. |
| **Day 04** | Week 1 | Student Directory, Search & Allocation (`POST /api/v1/students/{id}/assign-room`) | Implement student search by name/number and room assignment verifying `CurrentOccupancy < Capacity`. |
| **Day 05** | Week 1 | Student De-Allocation & Week 1 Code Review | Implement `POST /api/v1/students/{id}/unassign-room`, guard occupancy underflow (`>= 0`), pass Week 1 Oral Defense. |
| **Day 06** | Week 2 | Maintenance Tickets Filtering & Pagination | Add `status`, `priority`, `category`, `roomId`, `studentId`, `page`, and `pageSize` filters to `GET /api/v1/tickets`. |
| **Day 07** | Week 2 | Ticket Creation & Foreign-Key Validation | Implement `POST /api/v1/tickets` validating `StudentId` and `RoomId` exist and defaulting status to `Open`. |
| **Day 08** | Week 2 | Ticket Status Lifecycle & Technician Assignment | Implement `PATCH /api/v1/tickets/{id}/status` and `PATCH /api/v1/tickets/{id}/assign` with `ResolvedAt` timestamp automation. |
| **Day 09** | Week 2 | PostgreSQL 16 Migration & Indexing | Switch to PostgreSQL 16 (`./scripts/start-postgres.sh`), generate EF Core migration, verify tables in `psql`. |
| **Day 10** | Week 2 | Executive KPI Summary Endpoint (`GET /api/v1/dashboard/summary`) | Build aggregated residence occupancy & maintenance SLA telemetry endpoint. |
| **Day 11** | Week 3 | Structured Logging & Global Exception Middleware | Implement `ILogger<T>` structured logs and global `ProblemDetails` exception handling middleware. |
| **Day 12** | Week 3 | DTO Refactoring & Request Validation | Decouple EF Core entities from API contracts using dedicated Request/Response DTOs and DataAnnotations. |
| **Day 13** | Week 3 | Service Layer Extraction (`ITicketService`, `IRoomAllocationService`) | Extract business logic out of thin controllers into scoped application services. |
| **Day 14** | Week 3 | Unit Testing with xUnit (`SputnikDevs.Residence.Tests`) | Write 10+ automated xUnit tests covering room capacity limits, ticket transitions, and edge cases. |
| **Day 15** | Week 3 | Integration Testing & OpenAPI Documentation | Add XML doc comments, `[ProducesResponseType]` attributes, and integration test suite. |
| **Day 16** | Week 4 | Capstone Feature: SLA Breach Escalation Engine | Build `GET /api/v1/tickets/overdue` identifying tickets breaching 24h (`Critical`) or 72h (`High`) SLA windows. |
| **Day 17** | Week 4 | Capstone Polish: CSV Export & Bulk Seeding | Add `GET /api/v1/tickets/export.csv` streaming RFC-4180 compliant CSV exports for residence managers. |
| **Day 18** | Week 4 | Codebase Freeze, Security Audit & Documentation | Complete `README` API reference, audit async/await & status codes, pass `dotnet build` + `dotnet test`. |
| **Day 19** | Week 4 | Final 30-Minute Live Oral Code Defense & Sign-Off | Defend architecture, explain lines of code live, and receive Cryptographically Signed Certificate & Transcript. |

> See **[PILOT_19_DAY_SPRINT_BACKLOG.md](../PILOT_19_DAY_SPRINT_BACKLOG.md)** for additional code snippets and guidance.
