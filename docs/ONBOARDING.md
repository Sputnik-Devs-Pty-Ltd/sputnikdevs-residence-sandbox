# Sputnik Devs Studio — Internship & WIL Engineering Onboarding Guide

Welcome to **Sputnik Devs Studio**. You are joining our engineering team as part of the **Work-Integrated Learning (WIL) & Engineering Internship Program**. 

Our engineering culture values **clean architecture**, **rigorous version control**, and **deep technical comprehension**. This document walks you through setting up your local environment, understanding our repository conventions, and shipping your first pull request.

---

## 1. Development Environment Options

We support two primary development environments. **If your machine has 4 GB RAM or freezes when running heavy software, use Option A (Codespaces).**

| Environment | Machine Requirement | Setup Effort | Recommended For |
| :--- | :--- | :--- | :--- |
| **Option A: GitHub Codespaces** | Any laptop (even 2–4 GB RAM), web browser only | **0 min** (Instant cloud VM) | **⭐ Recommended** (Zero laptop freezing) |
| **Option B: Local Machine (SQLite)** | 4 GB+ RAM, .NET 10 SDK | **5 min** (No Docker needed) | Offline or local VS Code work |
| **Option C: Local Machine (Docker + Postgres)** | 8–16 GB RAM, Docker Desktop | **10 min** | Deep local DevOps practice |

---

## 2. Project Isolation Strategy: Standalone Sandbox Repository

To protect production databases and allow you to learn, experiment, and break things safely, all internship engineering takes place in a **completely separate, dedicated repository**:

* **Repository URL:** `https://github.com/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox.git`
* **Sandbox Solution:** `SputnikDevs.Residence.Sandbox.sln`
* **API Project:** `SputnikDevs.Residence.SandboxApi/`
* **Database Target:** Built-in SQLite (Default, zero setup) or Local PostgreSQL 16 container

> [!IMPORTANT]
> **Production Safety Guarantee:** 
> The Sandbox repository is completely decoupled from the Sputnik Devs corporate web platform (`SputnikDevsCompanyWebApp`) and client eCommerce tiers. Interns are given contributor access **only** to this sandbox repository. It requires **zero production secrets** and has **zero access to live databases**. You can run migrations, drop tables, and experiment with zero risk to client workloads.

---

## 3. Step-by-Step Setup

### 🚀 Option A: GitHub Codespaces (Zero Setup, Zero Laptop Load — Recommended)

This runs the entire development environment, compiler, and database in GitHub's cloud Linux environment. It uses virtually zero RAM on your laptop and will not cause freezes.

1. In your browser, navigate to the repository:
   👉 `https://github.com/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox`
2. Click the green **`<> Code`** button and select the **Codespaces** tab.
3. Click **Create codespace on main**.
4. A full VS Code editor will open right in your web browser. The pre-installed container includes:
   - .NET 10 SDK
   - C# Dev Kit extensions
   - Automatic background `dotnet restore`
5. In the built-in terminal (Press ``Ctrl + ` ``), start the API:
   ```bash
   dotnet run --project SputnikDevs.Residence.SandboxApi
   ```
6. VS Code will detect port `5035` and display a popup: *"Open in Browser"*. Click it to immediately view the interactive **Swagger UI**!

---

### 💻 Option B: Local Machine Setup with SQLite (Lightweight, No Docker)

If you prefer to work locally on your laptop without Docker Desktop:

1. **Install Prerequisites:**
   - [.NET 10 SDK](https://dotnet.microsoft.com/download)
   - [Git](https://git-scm.com/)
   - [VS Code](https://code.visualstudio.com/) with the **C# Dev Kit** extension.
2. **Clone the repository:**
   ```bash
   git clone https://github.com/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox.git
   cd sputnikdevs-residence-sandbox
   ```
3. **Build the solution:**
   ```bash
   dotnet build SputnikDevs.Residence.Sandbox.sln
   ```
4. **Run the API:**
   ```bash
   dotnet run --project SputnikDevs.Residence.SandboxApi
   ```
   *(The API defaults to SQLite, automatically generating and seeding `residence_sandbox.db` in seconds without running any heavy background containers).*
5. Open your browser to:
   👉 **`http://localhost:5035/`**

---

### 🐳 Option C: Local PostgreSQL with Docker (Optional for 8GB+ RAM Machines)

If your machine has ample RAM (8 GB or more) and you want to practice with PostgreSQL:
1. Edit `SputnikDevs.Residence.SandboxApi/appsettings.Development.json` and set:
   ```json
   "DatabaseProvider": "PostgreSQL"
   ```
2. Start the isolated PostgreSQL container:
   ```bash
   cd SputnikDevs.Residence.SandboxApi
   docker compose up -d
   ```
3. Run the API:
   ```bash
   dotnet run
   ```

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
