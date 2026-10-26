# Sputnik Devs Academy™ — Unified Student Residence WIL Sandbox

Welcome to the **Sputnik Devs Academy™ Multi-Disciplinary Work-Integrated Learning (WIL) Sandbox Platform**.

This repository serves as the unified hands-on engineering, data, and AI sandbox for Work-Integrated Learning (WIL) students, learnership candidates, and junior interns at **Sputnik Devs Studio (Pty) Ltd** (`Reg: 2025/656647/07`). It mirrors the real-world domain and architectural patterns of the **Sputnik Devs Student Residence Management Ecosystem (Varsnik & Resnik)** while operating in complete isolation from commercial production databases and proprietary client infrastructure.

---

> [!IMPORTANT]
> ### 🎓 Student WIL Portal & Daily Standup Logbook
> Every enrolled student receives an official **Student Portal Access Code (`SD-PORTAL-XXXX`)** upon placement approval.
> * **Student Portal & Daily Logbook:** [https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal)
> * **Apply for WIL Placement:** [https://sputnikdevs.com/academy/apply](https://sputnikdevs.com/academy/apply)
> * **Verify Official Certificates & Transcripts:** [https://sputnikdevs.com/academy/verify](https://sputnikdevs.com/academy/verify)

---

> [!TIP]
> ### ⚡ One-Click Cloud Development with GitHub Codespaces (Recommended)
> **Never used Codespaces before? Don't worry!**  
> GitHub Codespaces gives you a dedicated high-performance Linux computer in the cloud, displayed right inside your web browser. 
> 
> * ❌ **Do you need to install .NET SDK or Python?** **No.** .NET 10, PostgreSQL 16 client tools, and Python 3 are pre-installed in the cloud container.
> * ❌ **Do you need to install Docker or PostgreSQL locally?** **No.** The project uses built-in SQLite by default and includes a 1-command PostgreSQL 16 script inside Codespaces.
> * ❌ **Will your laptop freeze?** **No.** All building and running happens on GitHub's cloud servers (8 GB RAM). Your laptop only runs a lightweight browser tab.
> 
> [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox)
>
> **How to launch in 4 easy steps:**
> 1. **Fork this repository** to your personal GitHub account using the **Fork** button at the top-right of GitHub (so you have your own personal sandbox copy!).
> 2. Click **Code ➔ Codespaces ➔ Create codespace on main** inside your fork (or click the badge above).
> 3. Wait ~30 seconds for your cloud editor to boot. Open the integrated terminal (press `` Ctrl + ` ``) and run:
>    ```bash
>    dotnet run --project SputnikDevs.Residence.SandboxApi
>    ```
> 4. VS Code will detect port `5035` and show a prompt: *"Your application running on port 5035 is available. Open in Browser"*. Click **Open in Browser** to view the interactive **Swagger UI**!

---

## 🏛️ Institutional Cohort Pods & Mentorship Structure

To ensure every student receives daily support and structured feedback, cohorts are organized into dedicated **Institutional Pods**:

| Cohort Pod | Partner Institution | Pod Coordinator (Daily Standups & Gate 3 Oral Defense) | Principal Engineer (Gate 4 Architecture & Batch Merge) |
| :--- | :--- | :--- | :--- |
| **Pod Alpha (`POD-ALPHA-RICHFIELD`)** | **Richfield Graduate Institute of Technology** | **Kenneth Takudzwa Katsande** (`kennethtk@sputnikdevs.com`) | **Takudzwa Mupanesure** (`sputnikdevs@sputnikdevs.com`) |
| **Pod Bravo (`POD-BRAVO-ROSEBANK`)** | **IIE Rosebank College** | **Prince Lwazi Nkiwane** (`princeln@sputnikdevs.com`) | **Takudzwa Mupanesure** (`sputnikdevs@sputnikdevs.com`) |

---

## 🧭 6 Specialization Tracks on One Unified Polyglot Monorepo

Students from different academic streams work on the **same Student Residence Sandbox business domain** (`Rooms`, `Students`, `MaintenanceTickets`, `VisitorGatePasses`, `Billing`) through 6 specialized engineering tracks:

| Track Code | Module Codes | Specialization Track | Primary Tech Stack | Workspace Folder | Track Syllabus |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **Track 01** | `SD-BE-101..104` | **Backend & Cloud API Engineering** | C# 12, ASP.NET Core Web API (.NET 10), EF Core, PostgreSQL 16, xUnit | `SputnikDevs.Residence.SandboxApi/` | **[TRACK_01_BACKEND.md](docs/tracks/TRACK_01_BACKEND.md)** |
| **Track 02** | `SD-FE-101..104` | **Modern Web & SaaS UI Engineering** | **Angular 19+ SPA** (TypeScript, Signals, RxJS) or **Blazor / Razor**, Tailwind CSS | `frontend/web-angular/` & `frontend/web-blazor-razor/` | **[TRACK_02_FRONTEND_UI.md](docs/tracks/TRACK_02_FRONTEND_UI.md)** |
| **Track 03** | `SD-DB-101..104` | **Database Administration & Data Engineering** | PostgreSQL 16, 3NF DDL Constraints, Composite Indexes, SQL Views, CSV ETL | `database/` | **[TRACK_03_DATABASE_SQL.md](docs/tracks/TRACK_03_DATABASE_SQL.md)** |
| **Track 04** | `SD-DS-101..104` | **Big Data, BI & Data Science** *(MSc Led)* | Python 3, Pandas, NumPy, Scikit-Learn, SLA Telemetry, Executive KPI Dashboards | `analytics/` | **[TRACK_04_BIG_DATA_BI.md](docs/tracks/TRACK_04_BIG_DATA_BI.md)** |
| **Track 05** | `SD-AI-101..104` | **Applied AI & Intelligent Automation** *(MSc Led)* | Python/C# NLP Ticket Triage, Sentiment Analysis, RAG Residence Policy Assistant | `ai-agents/` | **[TRACK_05_APPLIED_AI.md](docs/tracks/TRACK_05_APPLIED_AI.md)** |
| **Track 06** | `SD-MB-101..104` | **Mobile & Cross-Platform Apps** | **Flutter 3.x & Dart 3** or **.NET 10 MAUI**, Offline SQLite Sync, QR Gate Pass | `mobile/mobile-flutter/` & `mobile/mobile-maui/` | **[TRACK_06_MOBILE_FLUTTER_MAUI.md](docs/tracks/TRACK_06_MOBILE_FLUTTER_MAUI.md)** |

---

## ⏳ 1-Month, 3-Month & 6-Month Progressive WIL Pathways

Whether your college requires a **19-Day Intensive Sprint (152h)**, a **3-Month Semester WIL Placement (480h)**, or a **6-Month National Diploma / Degree WIL Internship (960h)**, our staged rotation model scales seamlessly:

* **Stage 1 — Core Track Mastery (Month 1 / Days 1–19 / 152 Hours):** Complete the 19 daily milestones and oral code defense in your primary track. *(1-Month WIL students graduate at the end of Stage 1).*
* **Stage 2 — Cross-Disciplinary Track Rotation & Pod Capstone (Months 2–3 / 480 Hours Cumulative):** Rotate into a **Secondary Track** in Month 2, then collaborate across Backend, Frontend, Database, Data Science, and AI in a Month 3 Pod Capstone & Live Staging QA/UAT Sprint. *(3-Month WIL students graduate at the end of Stage 2).*
* **Stage 3 — Senior WIL Associate, Peer Teaching Assistant (TA) & R&D Sprint (Months 4–6 / 960 Hours Cumulative):** Rotate into a **3rd Track**, serve as a **Peer Teaching Assistant (Gate 2 PR Reviewer)** for incoming Stage 1 students, and deliver an advanced R&D automation capstone. *(6-Month WIL students graduate at the end of Stage 3).*
* 👉 Read the full **[Stage 2 & Stage 3 Rotation Guide](docs/STAGE_2_AND_3_ROTATION_GUIDE.md)**.

---

## 📚 Essential Reading for All Students

Before submitting your first Pull Request, read the documentation in `docs/`:

1. **[Developer Onboarding & Fork Workflow](docs/ONBOARDING.md):** How to fork the repo, name branches, pass the 4-Gate review pipeline, and log daily check-ins.
2. **[Codespaces PostgreSQL 16 Guide](docs/CODESPACES_POSTGRES_GUIDE.md):** How to launch PostgreSQL 16, apply EF Core migrations, and inspect tables with `psql`.
3. **[AI-Assisted Coding Policy](docs/AI_USAGE_POLICY.md):** How to use AI tools ethically while preparing for your Coordinator's daily 2-question Oral Code Defense.
4. **[Daily Cadence & Logbook Template](docs/DAILY_CADENCE_AND_LOGBOOK.md):** Daily standup format, peer review rules, and university logbook export.
5. **[19-Day Pilot Sprint Backlog (Track 01)](docs/PILOT_19_DAY_SPRINT_BACKLOG.md):** Detailed daily reference for Backend API tasks.
6. **[Stage 2 & 3 Multi-Month Rotation Guide](docs/STAGE_2_AND_3_ROTATION_GUIDE.md):** Guide for 3-Month and 6-Month WIL placements.
7. **[Evaluation Rubric](docs/EVALUATION_RUBRIC.md):** How the 4-Pillar Engineering Competency Rubric is scored on your final Transcript.

---

## 🏅 Cryptographically Signed Certificates & Official Academic Transcripts

Upon completing your required WIL hours and passing the oral code defense, Sputnik Devs Studio issues an **Encrypted, QR-Verifiable Digital Completion Certificate + Official WIL Academic Transcript** (with Company Seal & 4-Pillar Competency Breakdown), permanently verifiable at:
👉 **[https://sputnikdevs.com/academy/verify](https://sputnikdevs.com/academy/verify)**

&copy; 2026 Sputnik Devs Studio (Pty) Ltd. Johannesburg, South Africa.
