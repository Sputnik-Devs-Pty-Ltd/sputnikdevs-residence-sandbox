# Sputnik Devs Studio — Multi-College WIL Engineering Onboarding Guide

Welcome to **Sputnik Devs Studio (Pty) Ltd**. You are joining our engineering organization as part of the **Sputnik Devs Academy™ Work-Integrated Learning (WIL) & Engineering Internship Program**.

Our engineering culture values **clean architecture**, **rigorous version control**, **peer collaboration**, and **deep line-by-line technical comprehension**. This guide walks you through setting up your cloud or local environment, forking the repository safely, and shipping your daily Pull Requests through our **4-Gate Verification Pipeline**.

---

## 1. Development Environment Options

We support three development environments. **If your laptop has 4 GB RAM or freezes when running heavy IDEs, always use Option A (GitHub Codespaces).**

| Environment | Machine Requirement | Setup Effort | Recommended For |
| :--- | :--- | :--- | :--- |
| **Option A: GitHub Codespaces** | Any laptop (even 2–4 GB RAM), web browser only | **0 min** (Instant cloud VM) | **⭐ Recommended** (Zero laptop freezing) |
| **Option B: Local Machine (SQLite)** | 4 GB+ RAM, .NET 10 SDK / Python 3 | **5 min** (No Docker needed) | Offline or local VS Code work |
| **Option C: Local Machine (Docker + Postgres)** | 8–16 GB RAM, Docker Desktop | **10 min** | Deep local DevOps practice |

---

## 2. Personal Fork & Multi-Student Isolation Strategy

Because students from **IIE Rosebank College (Pod Bravo)** and **Richfield Graduate Institute of Technology (Pod Alpha)** work concurrently across 5 specialization tracks, **every student works inside their own Personal GitHub Fork** of this sandbox repository:

1. Open `https://github.com/Sputnik-Devs-Pty-Ltd/sputnikdevs-residence-sandbox` in your browser.
2. Click the **Fork** button in the top-right corner to create `https://github.com/<your-github-username>/sputnikdevs-residence-sandbox`.
3. Paste your Fork URL into your **Student WIL Portal** ([https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal)) when submitting your Day 1 check-in.
4. Create feature branches inside your fork and open Pull Requests so automated CI checks and peer reviewers can inspect your diffs cleanly without overwriting another student's work.

> [!IMPORTANT]
> **Production Safety Guarantee:**  
> This Sandbox repository is 100% isolated from Sputnik Devs Studio's commercial production servers and live client databases. It contains zero production secrets. You can run migrations, test SQL queries, train analytics models, and experiment safely.

---

## 3. Step-by-Step Environment Setup

### 🚀 Option A: GitHub Codespaces (Recommended)
1. Navigate to your personal fork of `sputnikdevs-residence-sandbox` on GitHub.
2. Click the green **`<> Code`** button ➔ **Codespaces** tab ➔ **Create codespace on main**.
3. Wait ~30 seconds for VS Code in the browser to load.
4. In the terminal (`` Ctrl + ` ``), verify the backend API runs:
   ```bash
   dotnet run --project SputnikDevs.Residence.SandboxApi
   ```
5. Need PostgreSQL 16 inside Codespaces (for Track 01 Day 9+, Track 03 Database, or Track 04 Analytics)? Run:
   ```bash
   ./scripts/start-postgres.sh
   ```
   *(See [Codespaces PostgreSQL 16 Guide](CODESPACES_POSTGRES_GUIDE.md) for full details).*

### 💻 Option B: Local Machine Setup (Lightweight SQLite)
```bash
git clone https://github.com/<your-github-username>/sputnikdevs-residence-sandbox.git
cd sputnikdevs-residence-sandbox
dotnet build SputnikDevs.Residence.Sandbox.sln
dotnet run --project SputnikDevs.Residence.SandboxApi
```
Open **`http://localhost:5035/`** to access Swagger UI.

---

## 4. Branch Naming & Commit Conventions

**Never commit directly to `main`.** Every daily milestone (Days 1–19) must be completed on its own dedicated feature branch:

### Branch Naming Standard
```text
wil/<college>-<first_name>/day-<XX>-<short-topic>
```
**Examples:**
* `wil/rosebank-brian/day-04-tickets-filtering`
* `wil/richfield-thabo/day-06-frontend-ticket-modal`
* `wil/rosebank-lerato/day-08-postgres-indexing-views`
* `wil/richfield-sipho/day-11-pandas-sla-telemetry`
* `wil/rosebank-naledi/day-14-ai-ticket-triage-classifier`

### Conventional Commit Format
```bash
git commit -m "feat(day-04): add status and priority query filtering to tickets endpoint"
```

---

## 5. The 4-Gate Daily Verification Pipeline

Every daily milestone progresses through 4 structured quality gates before your hours are credited toward graduation:

1. **Gate 1 — Automated CI & Build Check:**
   Your Pull Request must compile cleanly (`0 errors`) and include proof of execution (Swagger JSON response, UI screenshot, SQL `EXPLAIN ANALYZE` output, or notebook chart).
2. **Gate 2 — Peer Student / Stage 3 TA Code Review:**
   Another student in your Pod (or a Stage 3 Senior WIL Associate) reviews your PR diff, tests your implementation, and leaves structured review comments. You must log the reviewer's name in your daily portal check-in.
3. **Gate 3 — Pod Coordinator Oral Defense Check (Kenneth or Prince):**
   Log into [https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal) and submit your Daily Check-In + PR URL. During standup or PR review, your Pod Coordinator (**Kenneth Katsande** for Pod Alpha / Richfield; **Prince Nkiwane** for Pod Bravo / Rosebank) will ask you **2 Oral Defense Questions** about why your code works.
   * **Score `3/4` or `4/4`:** Passes Gate 3 and advances to Principal Engineer sign-off.
   * **Score `1/4` or `2/4`:** Returned (`Revision Required`) so you can study the lines you generated and re-explain them clearly.
4. **Gate 4 — Principal Engineer Batch Sign-Off (Takudzwa Mupanesure):**
   Once Gate 3 is passed, Principal Engineer **Takudzwa Mupanesure** performs architectural sign-off and credits your official WIL hours toward your Certificate and Academic Transcript.
