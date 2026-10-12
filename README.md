# Sputnik Devs Academy — Student Residence Sandbox API

Welcome to the **Sputnik Devs Academy & Work-Integrated Learning (WIL) Sandbox Project**.

This standalone repository serves as the hands-on engineering sandbox for junior developers, interns, and WIL students at Sputnik Devs Studio (Pty) Ltd. It mirrors the real-world domain and architectural patterns of the **Sputnik Devs Student Residence Management System**, but operates in complete isolation from our commercial production databases and proprietary business infrastructure.

---

> [!TIP]
> ### ⚡ One-Click Cloud Development with GitHub Codespaces (Recommended)
> **No installations required. Zero strain on your laptop's RAM.**  
> Everything (.NET 10 SDK, C# Dev Kit, and dependencies) is pre-configured in GitHub's cloud environment.
>
> [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox)
>
> **How to launch in 3 easy steps:**
> 1. Click the **"Open in GitHub Codespaces"** badge above (or click the green **`<> Code`** button at the top-right of this page ➔ **Codespaces** tab ➔ **Create codespace on main**).
> 2. Once the VS Code editor opens in your web browser, open the terminal (press `` Ctrl + ` `` or click **Terminal ➔ New Terminal**).
> 3. Run the API:
>    ```bash
>    dotnet run --project SputnikDevs.Residence.SandboxApi
>    ```
> 4. VS Code will automatically detect port `5035` and show a prompt: *"Your application running on port 5035 is available. Open in Browser"*. Click **Open in Browser** to view the interactive **Swagger UI**!
>
> That's it! You are ready to start coding without worrying about memory limits or local database configuration.

---

## 🎯 Purpose & Scope

* **Pilot Intern:** Brian Mkandla (19-Day Intensive WIL Sprint)
* **Institutional Partner:** Rosebank College / Academic HEIs
* **Focus Discipline:** Backend & Cloud Architecture (Track 01)
* **Core Tech Stack:** C# 12, ASP.NET Core Web API (.NET 10), Entity Framework Core, SQLite (default) / PostgreSQL, Docker, Swagger / OpenAPI.

---

## 🚀 Development Options

### Option A: GitHub Codespaces (Cloud)
*(See the [⚡ One-Click Cloud Development](#-one-click-cloud-development-with-github-codespaces-recommended) section above).*

---

### Option B: Local Machine Development

#### 1. Prerequisites (If developing locally)
* [.NET 10 SDK](https://dotnet.microsoft.com/download)
* [Git](https://git-scm.com/)
* Recommended Editor: VS Code (with *C# Dev Kit* extension)

#### 2. Run Instantly with Built-In SQLite (Zero Setup Required)
The repository is pre-configured to use SQLite by default so you can run without Docker or local database services:
```bash
# Clone the repository
git clone https://github.com/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox.git
cd sputnikdevs-residence-sandbox

# Restore & Build
dotnet restore
dotnet build

# Run the API
dotnet run --project SputnikDevs.Residence.SandboxApi
```

Once running, navigate to:
* **Interactive Swagger UI:** `http://localhost:5035/`
* The API will automatically seed test rooms, students, and tickets into a local SQLite database file.

#### 3. Optional: Using PostgreSQL with Docker
If you want to practice with PostgreSQL:
1. Set `"DatabaseProvider": "PostgreSQL"` in `SputnikDevs.Residence.SandboxApi/appsettings.Development.json`.
2. Start the database container:
   ```bash
   cd SputnikDevs.Residence.SandboxApi
   docker compose up -d
   ```
3. Run the API as usual.

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
