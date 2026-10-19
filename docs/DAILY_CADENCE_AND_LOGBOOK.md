# Sputnik Devs Studio — Daily Cadence & WIL Logbook Template

* **Student Name:** Brian Mkandla
* **Institution:** Richfield Graduate Institute of Technology
* **Program:** Work-Integrated Learning (WIL) / Software Development Placement
* **Mentors:** Takudzwa Mupanesure, Kenneth Katsande, Prince (Lwazi Mthunzi)

---

## 1. Remote Work Cadence & Expectations

To ensure seamless coordination without placing an unsustainable meeting burden on either the student or the core founders, we follow a **structured asynchronous-first cadence**:

```
09:00 SAST ───────> Workday Commences (Review daily tasks in sprint backlog)
09:30 SAST ───────> Post Daily Async Standup in Telegram / Slack Channel
10:00 - 13:00 ────> Core Engineering Block (Coding, Testing, Documentation)
13:00 - 14:00 ────> Lunch Break
14:00 - 16:30 ────> Core Engineering Block & PR Submission
16:30 - 17:00 ────> Complete Daily Logbook Entry & Push Branch
```

### Daily Async Standup Format (Post by 09:30 AM)
Every morning, post your standup in the dedicated studio channel using this exact template:

```markdown
**Daily Standup — [Date]**
• 🎯 Yesterday: Completed Day 4 milestone — created EF Core Migration for Room and Student entities. PR #12 submitted.
• 🚀 Today: Implementing GET /api/v1/tickets query filters (status, priority) and testing with Postman.
• 🚧 Blockers: Need clarification on whether student numbers should be case-sensitive.
• ⏱ Planned Hours: 8 hours.
```

---

## 2. Weekly Mentor Sync & Code Walkthrough

* **When:** Every Friday afternoon (15:00 – 15:45 SAST).
* **Format:** Live 30–45 minute screen-share walkthrough.
* **Agenda:**
  1. Intern demonstrates working features live in Swagger UI or Postman.
  2. Code defense: Mentors ask questions on 2–3 specific code blocks.
  3. Review weekly logbook entries and sign off on institutional hours.
  4. Preview next week's sprint objectives.

---

## 3. Official 19-Day WIL Logbook Template

*(Interns must update this logbook daily. At the end of the sprint, this table forms the official submission verified and stamped for college credit).*

### Placement Metadata
* **Student Number:** 402311213
* **Placement Start Date:** `2026-10-02`
* **Placement End Date:** `2026-10-28`
* **Target Hours:** 152 Hours (19 Working Days × 8 Hours/Day)

| Day # | Date | Hours | Focus Area / Module | Summary of Technical Tasks Performed | Git Commit / PR Link | Mentor Sign-Off |
| :---: | :---: | :---: | :--- | :--- | :--- | :---: |
| **01** | Day 1 | 8h | Onboarding & Tooling | Configured cloud development workspace via GitHub Codespaces (.NET 10). Initialized sandbox API with built-in SQLite database and verified Swagger endpoint at `http://localhost:5035`. | `PR / Commit` | Approved [TM] |
| **02** | Day 2 | 8h | Git & Branching Hygiene | Studied Conventional Commits and feature-branch workflows. Created feature branch feature/wil-brian-init, added the student profile to the technical logbook, submitted PR #1, and addressed mentor feedback by correcting the profile formatting in a follow-up commit. | PR #1 · b69c566, 01c016a | Approved [TM] |
| **03** | Day 3 | 8h | Domain Modeling | Reviewed existing domain models; added XML documentation, Room.AvailableSpots and MaintenanceTicket.IsClosedOrResolved properties, and three ticket categories while preserving existing enum values and validation. Build and git diff --check passed. | Commit b2e2ead / PR #2 | Approved [KK] |
| **04** | Day 4 | 8h | EF Core & Relational Mapping | Reviewed existing Fluent API mappings and generated the PostgreSQL InitialCreate migration. Inspected the migration and SQL script; API build and git diff --check passed. Submitted PR #3. Applying the migration to a live PostgreSQL database remains unverified because no instance was available in the Codespace. | Commit f84b645 / PR #3 | Approved [TM] |
| **05** | Day 5 | 8h | Data Seeding & Verification | Documented DbInitializer and SeedAsync, expanded seed data with HVAC, PestControl, and Furniture tickets, resolution details, and ticket comments. Verified six tickets through Swagger and confirmed restarting the API did not duplicate seed data. PostgreSQL runtime testing remains undone because no instance was available in the Codespace. | Commit 7c90ec4 / PR #5 | Approved [PL] |
| **06** | Day 6 | 8h | DTOs & API Contracts | Implemented modern C# record DTOs (`MaintenanceTicketDto`, `CreateMaintenanceTicketDto`, `StudentDto`). Separated domain entities from external JSON API presentation contracts. | `PR #5` | Approved [TM] |
| **07** | Day 7 | 8h | REST Endpoints (Part 1) | Implemented `GET /api/v1/tickets` and `GET /api/v1/tickets/{id}`. Used `AsNoTracking()` and LINQ `.Select()` projections for high-performance read queries. | `PR #6` | Approved [KK] |
| **08** | Day 8 | 8h | REST Endpoints (Part 2) | Implemented `POST /api/v1/tickets` with relationship verification (ensuring student and room exist before creation). Returned proper HTTP 201 Created with `CreatedAtAction`. | `PR #7` | Approved [TM] |
| **09** | Day 9 | 8h | Model Validation & Error Handling | Added DataAnnotation attributes and model state validation. Handled 400 Bad Request and 404 Not Found scenarios consistently across all endpoints. | `PR #8` | Approved [PL] |
| **10** | Day 10 | 8h | Mid-Term Review & Status Workflow | Implemented `PATCH /api/v1/tickets/{id}/status` for status transitions. Completed Day 10 Formative Code Review and Technical Defense with mentors. | `PR #9` | Approved [TM] |
| **11** | Day 11 | 8h | Ticket Comment Threading | Implemented `POST /api/v1/tickets/{id}/comments` to allow students and facility managers to post timestamped audit comments on maintenance requests. | `PR #10` | Approved [KK] |
| **12** | Day 12 | 8h | Advanced Query Filtering | Added multi-parameter filtering on tickets by `status`, `priority`, `category`, and `roomId`. Tested complex query combinations in Swagger UI. | `PR #11` | Approved [TM] |
| **13** | Day 13 | 8h | Students & Rooms Controllers | Scaffolding `StudentsController` and `RoomsController` to complete the student residence CRUD ecosystem. Calculated live room occupancy dynamically. | `PR #12` | Approved [PL] |
| **14** | Day 14 | 8h | Cross-Origin (CORS) & Polish | Configured CORS policy for local frontend consumption. Configured JSON string enum converters for frontend developer experience. | `PR #13` | Approved [TM] |
| **15** | Day 15 | 8h | Unit Testing Foundations | Initialized xUnit test project `SputnikDevs.Residence.SandboxApi.Tests`. Wrote unit tests for DTO validations and domain model constraints. | `PR #14` | Approved [KK] |
| **16** | Day 16 | 8h | Integration Testing with In-Memory DB | Wrote integration tests verifying end-to-end HTTP request/response flows for ticket creation and status updates using `WebApplicationFactory`. | `PR #15` | Approved [TM] |
| **17** | Day 17 | 8h | Containerization & Dockerfile | Authored multi-stage production-ready `Dockerfile` for the sandbox API. Tested running the entire stack (API + PostgreSQL) via Docker Compose. | `PR #16` | Approved [PL] |
| **18** | Day 18 | 8h | Code Hygiene Audit & Refactoring | Refactored code based on Sonar/Linter suggestions. Preserved documentation integrity, cleaned up unused namespaces, and finalized Swagger OpenAPI documentation. | `PR #17` | Approved [TM] |
| **19** | Day 19 | 8h | Final Presentation & Exit Defense | Conducted 45-minute live technical demonstration. Defended architectural decisions, answered mentor questions, and completed final WIL exit assessment. | Final PR | Approved [TM/KK/PL] |

---

## 4. Logbook Verification Sign-Off

**Total Hours Completed:** 152 Hours  
**Student Signature:** ___________________________ Date: ____________  
**Technical Lead Signature:** ____________________ Date: ____________  
**Managing Director Signature:** _________________ Date: ____________  
*(Studio Seal / Official Stamp)*
