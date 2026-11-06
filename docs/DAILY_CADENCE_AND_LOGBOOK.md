# Sputnik Devs Studio — Daily Cadence & WIL Logbook Template

* **Student Name:** Brian Mkandla
* **Institution:** Richfield Graduate Institute of Technology
* **Cohort Pod:** Pod Alpha — Richfield Graduate Institute Cohort (`POD-A-RICHFIELD`)
* **Program:** Work-Integrated Learning (WIL) / Software Development Placement
* **Pod Alpha Director:** Kenneth Takudzwa Katsande (`[KK]` · `@Katsande-Kenneth`)
* **Principal Architect:** Takudzwa Mupanesure (`[TM]` · `@Takudzwamz`)

---

## 1. Remote Work Cadence & Expectations

To ensure seamless coordination without placing an unsustainable meeting burden on either the student or the core founders, we follow a **structured asynchronous-first cadence**:

```
09:00 SAST ───────> Workday Commences (Review daily tasks in sprint backlog)
09:30 SAST ───────> Post Daily Async Standup in WIL Portal / Channel
10:00 - 13:00 ────> Core Engineering Block (Coding, Testing, Documentation)
13:00 - 14:00 ────> Lunch Break
14:00 - 16:30 ────> Core Engineering Block & PR Submission
16:30 - 17:00 ────> Complete Daily Logbook Entry & Push Branch
```

### Daily Async Standup Format (Post by 09:30 AM)
Every morning, post your standup in the dedicated WIL Portal / studio channel using this exact template:

```markdown
**Daily Standup — [Date]**
• 🎯 Yesterday: Completed Day 11 milestone — hardened POST /api/v1/tickets/{id}/comments normalization & UTC auditing. PR #12 merged.
• 🚀 Today: Implementing GET /api/v1/tickets PagedResult<T> pagination, search filtering, and sorting (Issue #13).
• 🚧 Blockers: None.
• ⏱ Planned Hours: 8 hours.
```

---

## 2. Dual-Verification Code Review & Weekly Walkthrough

* **Daily Dual-Verification Protocol (Effective Day 11 — 2026-10-27):**
  - **Days 01–10:** Reviewed and signed off directly by Principal Architect Takudzwa Mupanesure (`[TM]`).
  - **Day 11–19 (Pod Alpha — Richfield):** Dual-Verified by Pod Alpha Director Kenneth Takudzwa Katsande (`[KK]` · `@Katsande-Kenneth`) and co-signed by Principal Architect Takudzwa Mupanesure (`[TM]` · `@Takudzwamz`) (`Dual-Verified [KK / TM]`).
* **Weekly Walkthrough:** Every Friday afternoon (15:00 – 15:45 SAST).

---

## 3. Official 19-Day WIL Logbook

*(Updated daily. At the end of the sprint, this table and the synchronized Sputnik Devs WIL Portal record form the official submission verified and stamped for college credit).*

### Placement Metadata
* **Student Number:** 402311213
* **Credential ID:** `SD-PORTAL-BRIAN`
* **Placement Start Date:** `2026-10-13`
* **Target Hours:** 152 Hours (19 Working Days × 8 Hours/Day)

| Day # | Date | Hours | Focus Area / Module | Summary of Technical Tasks Performed | Git Commit / PR Link | Mentor Sign-Off |
| :---: | :---: | :---: | :--- | :--- | :--- | :---: |
| **01** | 2026-10-12 | 8h | Onboarding & Tooling | Configured cloud development workspace via GitHub Codespaces (.NET 10). Initialized sandbox API with built-in SQLite database and verified Swagger endpoint at `http://localhost:5035`. | `PR #1` | Approved [TM] |
| **02** | 2026-10-13 | 8h | Git & Branching Hygiene | Studied Conventional Commits and feature-branch workflows. Created feature branch `feature/wil-brian-init`, added the student profile to the technical logbook, submitted PR #1, and addressed mentor feedback by correcting the profile formatting in a follow-up commit. | `PR #1 · b69c566, 01c016a` | Approved [TM] |
| **03** | 2026-10-14 | 8h | Domain Modeling | Reviewed existing domain models; added XML documentation, `Room.AvailableSpots` and `MaintenanceTicket.IsClosedOrResolved` properties, and three ticket categories while preserving existing enum values and validation. Build and `git diff --check` passed. | `Commit b2e2ead / PR #2` | Approved [TM] |
| **04** | 2026-10-15 | 8h | EF Core & Relational Mapping | Reviewed existing Fluent API mappings and generated the PostgreSQL `InitialCreate` migration. Inspected the migration and SQL script. The migration was subsequently applied and verified against PostgreSQL 16 in the GitHub Codespace. Build and `git diff --check` passed. | `Commit f84b645 / PR #3` | Approved [TM] |
| **05** | 2026-10-16 | 8h | Data Seeding & Verification | Documented `DbInitializer` and `SeedAsync`; expanded seed data with HVAC, PestControl and Furniture tickets, resolution details and ticket comments. Verified PostgreSQL runtime seeding and confirmed the database contained 4 rooms, 3 students and 6 maintenance tickets. Restart verification confirmed that seed data was not duplicated. | `Commit 7c90ec4 / PR #5` | Approved [TM] |
| **06** | 2026-10-19 | 8h | PostgreSQL Integration & API Verification | Configured and verified PostgreSQL 16 in the GitHub Codespace on port 5433. Restored .NET tools, applied the initial EF Core migration, verified the database tables, started the API with the PostgreSQL provider, confirmed Swagger accessibility, and verified seeded records: 4 rooms, 3 students, and 6 maintenance tickets. Received mentor approval for PR #5 (database seeding) and PR #6 (logbook corrections). | `PR #6 · PR #7` | Approved [TM] |
| **07** | 2026-10-20 | 8h | REST Endpoints (Part 1 - Read Endpoints) | Implemented DTO mappings and read endpoints for Students, Rooms, and Maintenance Tickets. Added mapping helpers (`MapToDto`), related entity loading, XML documentation, calculated DTO properties (`AvailableSpots`, `IsClosedOrResolved`), and `.AsNoTracking()` for read queries. Built the API successfully and tested the endpoints through Swagger using the PostgreSQL provider in the GitHub Codespace. | `PR #8` | Approved [TM] |
| **08** | 2026-10-21 | 8h | REST Endpoints (Part 2) | Improved POST ticket endpoint validation by adding enum validation for `TicketCategory` and `TicketPriority`. Tested valid and invalid requests through Swagger, including invalid enum values, student and room references, blank fields, and input length limits. Verified the API build and whitespace checks passed, and submitted PR #9. | `PR #9` | Approved [TM] |
| **09** | 2026-10-22 | 8h | Model Validation & Error Handling | Added request validation for ticket status and student room assignment, including room existence and eager-loaded room capacity (`AvailableSpots`) checks. Configured `.github/workflows/main.yml` .NET 10 CI & automated API smoke test workflow. | `PR #10` | Approved [TM] |
| **10** | 2026-10-23 | 8h | Mid-Term Review & Status Workflow | Implemented `PATCH /api/v1/tickets/{id}/status` status enum validation and `ResolvedAtUtc` timestamp refresh/reset on status transitions. Completed Day 10 Formative Code Review with Principal Architect. | `PR #11` | Approved [TM] |
| **11** | 2026-10-26 | 8h | Ticket Comment Threading | Hardened `POST /api/v1/tickets/{id}/comments` in `TicketsController` with trimmed `AuthorName`, `AuthorRole`, and `Content` validation, closed-ticket blocking, and explicit UTC `CreatedAtUtc` timestamping. Passed Day 11 Architecture Defense under Pod Alpha Dual-Verification review. | `Commit 594a712 / PR #12` | Dual-Verified [KK / TM] |
| **12** | 2026-10-27 | 8h | Ticket Comment Validation Polish | Refined ticket comment validation in `POST /api/v1/tickets/{id}/comments` by standardizing JSON `{ message }` error responses, normalizing `AuthorRole` to canonical PascalCase (`AllowedRoles`), and adding `.AsNoTracking()` retrieval for ticket status checks. | `Commit 07545df / PR #14` | Dual-Verified [KK / TM] |
| **13** | 2026-10-28 | 8h | Advanced Query Filtering & Residence Endpoints | Enhanced GET /api/v1/tickets filtering with studentId and case-insensitive keyword search across ticket titles and descriptions. Added enum filter validation for status, priority, and category. Updated Program.cs to customise InvalidModelStateResponseFactory, returning consistent JSON { "message": "..." } responses for invalid model-state requests. Verified student and room filtering, title and description keyword searches using mixed-case terms, and invalid enum inputs through Swagger. | `Issue #13 · PR #15` | Pending Dual-Verification [KK / TM] |
| **14** | Scheduled | 8h | Cross-Origin (CORS) & OpenAPI Polish | Configure CORS policy for frontend consumption and JSON string enum converters for OpenAPI developer experience. | `Scheduled` | Pending Dual-Verification [KK / TM] |
| **15** | Scheduled | 8h | Unit Testing Foundations | Initialize xUnit test project `SputnikDevs.Residence.SandboxApi.Tests` and write unit tests for DTO validations and domain model constraints. | `Scheduled` | Pending Dual-Verification [KK / TM] |
| **16** | Scheduled | 8h | Integration Testing with WebApplicationFactory | Write integration tests verifying end-to-end HTTP request/response flows for ticket creation, comments, and status updates. | `Scheduled` | Pending Dual-Verification [KK / TM] |
| **17** | Scheduled | 8h | Containerization & Multi-Stage Dockerfile | Author multi-stage production-ready `Dockerfile` for the sandbox API and verify the stack (API + PostgreSQL) via Docker Compose. | `Scheduled` | Pending Dual-Verification [KK / TM] |
| **18** | Scheduled | 8h | Code Hygiene Audit & Refactoring | Refactor code based on static analysis, preserve XML documentation integrity, clean up unused namespaces, and finalize Swagger OpenAPI docs. | `Scheduled` | Pending Dual-Verification [KK / TM] |
| **19** | Scheduled | 8h | Final Presentation & Exit Defense | Conduct 45-minute live technical demonstration, defend architectural decisions, and complete final WIL exit assessment. | `Scheduled` | Pending Dual-Verification [KK / TM] |

---

## 4. Logbook Verification Sign-Off

**Total Hours Logged to Date:** 88 / 152 Hours (Days 01–11 Verified)  
**Student Signature:** Brian Mkandla  
**Pod Alpha Director (Day 11+ Dual-Verification):** Kenneth Takudzwa Katsande (`@Katsande-Kenneth`)  
**Principal Architect Sign-Off:** Takudzwa Mupanesure (`@Takudzwamz`)  
*(Sputnik Devs Studio (Pty) Ltd • Official Digital Seal — `SD-PORTAL-BRIAN`)*
