# Sputnik Devs Studio — Internship & WIL Engineering Onboarding Guide

Welcome to **Sputnik Devs Studio**. You are joining our engineering team as part of the **Work-Integrated Learning (WIL) & Engineering Internship Program**. 

Our engineering culture values **clean architecture**, **rigorous version control**, and **deep technical comprehension**. This document walks you through setting up your local environment, understanding our repository conventions, and shipping your first pull request.

---

## 1. Prerequisites & Tooling Installation

Before writing code, ensure your development machine has the following tools installed:

| Tool | Recommended Version | Verification Command | Installation Link |
| :--- | :--- | :--- | :--- |
| **.NET SDK** | .NET 10.0 (or .NET 8.0 LTS) | `dotnet --version` | [dot.net/download](https://dotnet.microsoft.com/download) |
| **Git** | 2.40+ | `git --version` | [git-scm.com](https://git-scm.com/) |
| **Docker & Docker Compose** | Docker Desktop / Docker Engine | `docker --version` | [docker.com](https://www.docker.com/) |
| **Code Editor** | VS Code, Visual Studio 2022, or JetBrains Rider | — | [code.visualstudio.com](https://code.visualstudio.com/) |
| **API Client** | Postman, Bruno, or VS Code REST Client | — | Optional (Swagger UI included) |

### Recommended VS Code Extensions
- **C# Dev Kit** (`ms-dotnettools.csdevkit`)
- **C#** (`ms-dotnettools.csharp`)
- **Docker** (`ms-azuretools.vscode-docker`)
- **GitLens** (`eamodio.gitlens`)

---

## 2. Project Isolation Strategy: Standalone Sandbox Repository

To protect production databases and allow you to learn, experiment, and break things safely, all internship engineering takes place in a **completely separate, dedicated repository**:

* **Repository URL:** `https://github.com/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox.git`
* **Sandbox Solution:** `SputnikDevs.Residence.Sandbox.sln`
* **API Project:** `SputnikDevs.Residence.SandboxApi/`
* **Database Target:** Local PostgreSQL 16 container (or SQLite fallback)

> [!IMPORTANT]
> **Production Safety Guarantee:** 
> The Sandbox repository is completely decoupled from the Sputnik Devs corporate web platform (`SputnikDevsCompanyWebApp`). Interns are given contributor access **only** to the sandbox repository. It requires **zero production secrets** and has **zero access to live databases**. You can run migrations, drop tables, and experiment locally with zero risk to client workloads.

---

## 3. Step-by-Step Local Setup

### Step 3.1: Clone the Standalone Sandbox Repository
```bash
git clone https://github.com/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox.git
cd sputnikdevs-residence-sandbox
```

### Step 3.2: Start the Local PostgreSQL Database
We provide a pre-configured Docker Compose file that spins up an isolated PostgreSQL 16 instance on port **5433** (preventing collisions with any default Postgres instances you may have):

```bash
cd SputnikDevs.Residence.SandboxApi
docker compose up -d
```

Verify that the database container is healthy:
```bash
docker ps --filter "name=sputnik_sandbox_postgres"
```

*(Optional SQLite Fallback):* If you are working on a machine where Docker cannot run, simply edit `appsettings.Development.json` and set `"DatabaseProvider": "Sqlite"`. The API will automatically create a local `residence_sandbox.db` file with zero configuration.

### Step 3.3: Build the Solution
```bash
dotnet build ../SputnikDevs.Residence.Sandbox.sln
```

### Step 3.4: Launch the API
```bash
dotnet run
```

When the application boots:
1. It automatically runs `DbInitializer.SeedAsync()` to create the schema and populate mock students, rooms, and tickets.
2. The interactive **Swagger UI** will be available at:
   👉 **`http://localhost:5035/`** (or the port displayed in your terminal).

Open that URL in your browser to verify that the sample endpoints (`GET /api/v1/tickets`) respond with `200 OK`!

---

## 4. Git Branching & Workflow Rules

We follow a strict, professional feature-branch workflow. **No developer commits directly to `main`.**

### Branch Naming Convention
All branches must follow this structure:
```
<type>/wil-<student_first_name>-<short-description>
```

**Examples:**
* `feature/wil-brian-ticket-filtering`
* `feature/wil-brian-room-occupancy-check`
* `fix/wil-brian-null-technician-validation`
* `test/wil-brian-tickets-controller-unit-tests`

### Commit Message Format (Conventional Commits)
Commits should be atomic and descriptive:
```
<type>(<scope>): <concise present-tense description>

[optional body with reasoning]
```

**Allowed Types:**
* `feat`: A new feature or endpoint.
* `fix`: A bug fix.
* `refactor`: Code restructuring without changing behavior.
* `test`: Adding or updating tests.
* `docs`: Documentation updates or logbook entries.

**Example:**
```bash
git commit -m "feat(tickets): add priority and category query filters to GET /api/v1/tickets"
```

---

## 5. Pull Request (PR) & Code Review Standards

### Before Submitting a PR:
1. Ensure the code compiles with **0 errors and 0 warnings**: `dotnet build`
2. Run any tests: `dotnet test`
3. Verify formatting and remove unused `using` directives.
4. Review your own diff (`git diff main`) to catch stray comments or temporary debug logs.

### PR Description Template:
Every PR must include:
```markdown
## Summary of Changes
- Implemented filtering on GET /api/v1/tickets by Status and Priority.
- Added input validation ensuring StudentId and RoomId exist before creating a ticket.

## Testing Performed
- [x] Verified via Swagger UI: POST /api/v1/tickets with invalid RoomId returns 400 Bad Request.
- [x] Verified GET /api/v1/tickets?status=Assigned filters correctly.

## Learning Reflection
- Practiced LINQ conditional filtering using `IQueryable<T>`.
```

### Code Review Expectations
- A mentor will review your PR within 24 hours.
- Feedback is an opportunity to learn enterprise best practices. Never take critique personally.
- Once approved, your mentor will merge your PR into the development branch.

---

## 6. Communication & Getting Help

- **Daily Check-In:** Post your standup in the Telegram/Slack channel by **09:30 AM** daily.
- **The 30-Minute Rule:** If you are stuck on a technical blocker for more than 30 minutes:
  1. Read the error stack trace carefully.
  2. Consult Microsoft .NET documentation.
  3. Formulate a specific question: *"Here is what I am trying to achieve, here is the error, and here are the two approaches I tried."*
  4. Post in the channel for mentor guidance.
