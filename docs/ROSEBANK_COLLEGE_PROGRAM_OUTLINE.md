# Sputnik Devs Studio — Institutional WIL & Remote Internship Program Outline

**Document Type:** Institutional Partnership & Program Specification  
**Target Partner:** Rosebank College (The Independent Institute of Education - IIE)  
**Host Organization:** Sputnik Devs Studio (Pty) Ltd  
**Academic Alignment:** Diploma / Bachelor of Information Technology in Software Development (NQF Level 6/7)  
**Placement Modality:** 100% Remote, Project-Based Work-Integrated Learning (WIL)  

---

## 1. Executive Summary & Value Proposition

Sputnik Devs Studio is an engineering-driven software development studio headquartered in Gauteng, South Africa. We design, build, and operate cloud platforms, enterprise SaaS, and student housing logistics software (notably our Student Residence & Hostel Management ecosystem).

This document outlines our structured, repeatable **Remote Work-Integrated Learning (WIL) & Software Engineering Internship Program**, tailored specifically to bridge the gap between academic computer science curricula and industry expectations for South African students.

### Why This Partnership Benefits Rosebank College Students:
1. **Zero Commuting Overhead:** Fully remote workflows eliminate transport costs, making high-tier enterprise software training accessible to students across all socioeconomic backgrounds.
2. **Modern Enterprise Tech Stacks:** Students transition beyond academic theoretical exercises to work on modern C# 12 / .NET 10 Web APIs, Entity Framework Core, PostgreSQL, Docker containers, and Git/GitHub version control.
3. **Engineered Isolation & Production Safety:** Students operate inside isolated, production-grade architectural sandboxes, allowing hands-on experimentation without security risks.
4. **Structured Mentorship Without Administrative Friction:** Pre-defined daily cadences, automated sandboxes, and objective evaluation rubrics provide academic institutions with transparent, verifiable proof of student competency.

---

## 2. Cohort Structure & Scalability Model

To preserve our high mentorship standards without overwhelming our core engineering leadership (3 co-founders), we operate an intentional **Cohort Intake Model**:

```
┌────────────────────────────────────────────────────────┐
│                   STUDIO FOUNDERS                      │
│        (Takudzwa Mupanesure, Kenneth Katsande, Prince) │
└──────────────────────────┬─────────────────────────────┘
                           │ Async Standups, PR Reviews,
                           │ Weekly Demos & Code Defenses
┌──────────────────────────▼─────────────────────────────┐
│                    STUDENT COHORT                      │
│             (2 to 5 Students per Intake)               │
│                                                        │
│  • Track A: Intensive 19-Day WIL Sprint (152 Hours)    │
│  • Track B: Comprehensive 3-to-6-Month Internship       │
└────────────────────────────────────────────────────────┘
```

| Parameter | Specifications |
| :--- | :--- |
| **Cohort Size** | 2 to 5 students per cycle |
| **Duration Options** | • **Track A (Short-Cycle WIL):** 19 working days (152 hours) — designed for immediate graduation requirement sign-offs.<br>• **Track B (Full Placement):** 12 to 24 weeks (3 to 6 months) — designed for in-depth engineering immersion. |
| **Working Schedule** | Monday – Friday, 09:00 – 17:00 SAST (40 hours/week) |
| **Supervision Ratio** | Maximum 2 students per mentor, backed by asynchronous tracking tools. |

---

## 3. Curriculum Architecture & Learning Outcomes

Students are embedded into the **Student Residence & Logistics Sandbox**, an architectural replica of our real-world hostel management SaaS.

### Core Learning Modules

```
┌─────────────────────────┐     ┌─────────────────────────┐     ┌─────────────────────────┐
│        MODULE 1         │     │        MODULE 2         │     │        MODULE 3         │
│  Domain Modeling & EF   │ ──> │ REST APIs, DTOs & HTTP  │ ──> │ Advanced Querying &     │
│  Core Migrations        │     │ Contracts               │     │ Business Workflows      │
└─────────────────────────┘     └─────────────────────────┘     └─────────────────────────┘
                                                                             │
                                                                             ▼
┌─────────────────────────┐     ┌─────────────────────────┐     ┌─────────────────────────┐
│        MODULE 6         │     │        MODULE 5         │     │        MODULE 4         │
│ Final Presentation,     │ <── │ Docker Containerization │ <── │ Automated Testing       │
│ Defense & Certification │     │ & Local DevOps          │     │ (xUnit & Integration)   │
└─────────────────────────┘     └─────────────────────────┘     └─────────────────────────┘
```

### Tangible Technical Competencies Acquired:
1. **Clean Architecture in .NET:** Designing decoupled layers (Domain, Data, DTOs, Controllers).
2. **Relational Database Mastery:** Fluent API schema design, code-first migrations, foreign key cascading, and database indexing with PostgreSQL and EF Core.
3. **RESTful Contract Design:** Proper HTTP verbs, status codes, query filtering, and defensive input validation.
4. **Professional Git & GitHub Workflows:** Branch naming conventions, Conventional Commits, self-documenting pull requests, and peer code reviews.
5. **DevOps & Containerization:** Managing databases and multi-stage API builds using Docker and Docker Compose.
6. **Code Defense & Communication:** Articulating architectural choices, defending implementations during reviews, and writing concise daily asynchronous standups.

---

## 4. Academic Rigor, Governance & Anti-Cheating Safeguards

We recognize the challenge that unmonitored remote work and generative AI pose to academic assessment. Our program incorporates strict verification mechanisms:

### 1. The "Code Defense Test"
* AI assistance is permitted strictly as an educational tutor (explaining compiler errors, suggesting test edge cases).
* In every weekly review, students must verbally defend random code snippets selected by mentors. Inability to explain how their code works results in immediate PR rejection and required re-implementation.

### 2. Auditable Version Control History
* Every milestone requires an atomic Git commit and pull request. Mentors evaluate the progression of commits over time, verifying authentic human development rather than single-blob copy-pastes.

### 3. Formal Daily Logbooks
* Students maintain an official Daily Logbook ([DAILY_CADENCE_AND_LOGBOOK.md](file:///home/sputniktech/repos/Sputnikdevsclients/docs/internship/DAILY_CADENCE_AND_LOGBOOK.md)) detailing hours, tasks, git links, and mentor sign-offs, fully compliant with CHE / SAQA audit standards.

### 4. Objective 4-Pillar Evaluation Rubric
* Grading is based on a structured mathematical rubric ([EVALUATION_RUBRIC.md](file:///home/sputniktech/repos/Sputnikdevsclients/docs/internship/EVALUATION_RUBRIC.md)) assessing Code Quality (30%), Technical Comprehension (25%), Git Hygiene (20%), and Professionalism (25%).

---

## 5. Institutional Support & Documentation Provided to Colleges

Upon completion of each cohort or student placement, Sputnik Devs Studio provides the partner institution with an official academic verification package:

1. **Official Verification Letter:** Printed on corporate letterhead ([COMPLETION_VERIFICATION_LETTER_TEMPLATE.md](file:///home/sputniktech/repos/Sputnikdevsclients/docs/internship/COMPLETION_VERIFICATION_LETTER_TEMPLATE.md)) validating total hours, dates, and final competency ratings.
2. **Signed Daily Logbook:** Complete chronological record of daily tasks and mentor approvals.
3. **Formal Rubric Evaluation Sheet:** Detailed breakdown of student performance across all 4 engineering pillars.
4. **Public Portfolio Artifact:** A polished GitHub repository showcasing the student's code and pull requests, serving as tangible proof of employability.

---

## 6. Pilot Program Implementation: Brian Mkandla

To immediately operationalize this institutional partnership, Sputnik Devs Studio is launching the pilot run with **Brian Mkandla** (Rosebank College 3rd-year student):
* **Placement Type:** 19-Day Intensive WIL Sprint (152 Supervised Hours).
* **Launch Date:** Immediate commencement.
* **Sprint Backlog:** Detailed day-by-day roadmap already live in [PILOT_19_DAY_SPRINT_BACKLOG.md](file:///home/sputniktech/repos/Sputnikdevsclients/docs/internship/PILOT_19_DAY_SPRINT_BACKLOG.md).
* **Pilot Objective:** Validate student onboarding speed, remote cadence adherence, and refine the framework for subsequent cohorts in the upcoming academic calendar.

---

## 7. Contact & Partnership Coordination

For institutional inquiries, cohort agreements, or WIL compliance audits:

**Takudzwa Mupanesure**  
Chief Executive Officer & Founder  
Sputnik Devs Studio (Pty) Ltd  
Email: takudzwa@sputnikdevs.com  
Website: [https://sputnikdevs.com](https://sputnikdevs.com)  

**Kenneth Katsande**  
Director of Operations & Co-Founder  
Sputnik Devs Studio (Pty) Ltd  
Email: kenneth@sputnikdevs.com  
