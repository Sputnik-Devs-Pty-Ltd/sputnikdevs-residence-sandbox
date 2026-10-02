# Sputnik Devs Academy — Student Residence Sandbox API

Welcome to the **Sputnik Devs Academy & Work-Integrated Learning (WIL) Sandbox Project**.

This standalone repository serves as the hands-on engineering sandbox for junior developers, interns, and WIL students at Sputnik Devs Studio (Pty) Ltd. It mirrors the real-world domain and architectural patterns of the **Sputnik Devs Student Residence Management System**, but operates in complete isolation from our commercial production databases and proprietary business infrastructure.

---

## 🎯 Purpose & Scope

* **Pilot Intern:** Brian Mkandla (19-Day Intensive WIL Sprint)
* **Institutional Partner:** Rosebank College / Academic HEIs
* **Focus Discipline:** Backend & Cloud Architecture (Track 01)
* **Core Tech Stack:** C# 12, ASP.NET Core Web API (.NET 10), Entity Framework Core, PostgreSQL, Docker, Swagger / OpenAPI.

---

## 🚀 Quickstart Guide

### 1. Prerequisites
Ensure you have the following installed on your local machine:
* [.NET 10 SDK](https://dotnet.microsoft.com/download)
* [Docker Desktop](https://www.docker.com/) or local PostgreSQL 16+
* [Git](https://git-scm.com/)
* Recommended IDE: JetBrains Rider, VS Code (with C# Dev Kit), or Visual Studio 2022+

### 2. Local Database Setup (Docker)
Start a dedicated local PostgreSQL instance with one command:
```bash
docker run --name sputnik-residence-sandbox-db \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=postgres \
  -e POSTGRES_DB=residence_sandbox_db \
  -p 5433:5432 \
  -d postgres:16-alpine
```

### 3. Build & Run the API
```bash
# Clone this repository
git clone https://github.com/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox.git
cd sputnikdevs-residence-sandbox

# Restore & Build
dotnet restore
dotnet build

# Apply Initial Migrations & Run
cd SputnikDevs.Residence.SandboxApi
dotnet run
```
Once running, navigate to:
* **Interactive Swagger UI:** `http://localhost:5055/swagger`
* **Health Endpoint:** `http://localhost:5055/health`

---

## 📚 Essential Reading for Interns

Before opening your first Pull Request, you **must** read and adhere to our engineering standards located in the `docs/` directory:

1. **[Developer Onboarding Guide](docs/ONBOARDING.md):** Git workflow, branch conventions, PR templates, and local dev setup.
2. **[AI-Assisted Coding Policy](docs/AI_USAGE_POLICY.md):** Guidelines for using AI tools (GitHub Copilot, ChatGPT, Claude) ethically and productively while ensuring full line-by-line code comprehension.
3. **[Daily Cadence & Logbook Template](docs/DAILY_CADENCE_AND_LOGBOOK.md):** Daily check-ins, PR milestones, and supervisor sign-offs.
4. **[19-Day Pilot Sprint Backlog](docs/PILOT_19_DAY_SPRINT_BACKLOG.md):** Daily milestone breakdown from Day 1 to Day 19.
5. **[Evaluation Rubric](docs/EVALUATION_RUBRIC.md):** How your code hygiene, architecture, and oral defense will be assessed.

---

## 🛡️ Git Workflow & PR Standards

* **Main Branch is Protected:** Never push directly to `main`.
* **Branch Naming Standard:**
  * `feature/day-01-environment-setup`
  * `feature/day-04-issues-endpoints`
  * `fix/room-allocation-logic`
* **Pull Request Requirements:**
  * Each PR must address a specific daily backlog task.
  * Must compile with 0 warnings/errors.
  * Must pass automated checks.
  * Requires review and sign-off from designated mentor (**Takudzwa Mupanesure**, **Kenneth Katsande**, or **Prince**).

---

## 🏢 Academic & Company Verification

Upon successful completion of the sprint and passing the 30-minute oral code defense, an official verifiable credential will be issued by Sputnik Devs Studio and logged at:
`https://sputnikdevs.com/academy/verify`

&copy; 2026 Sputnik Devs Studio (Pty) Ltd. Johannesburg, South Africa.
