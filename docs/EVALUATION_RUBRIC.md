# Sputnik Devs Studio — Internship & WIL Evaluation Rubric

**Candidate Name:** Brian Mkandla (Pilot) / Intern Cohort  
**Evaluation Type:** Work-Integrated Learning (WIL) Competency Assessment  
**Assessment Stages:** Formative Midterm Review (Day 10) & Summative Exit Review (Day 19)  

---

## 1. Assessment Philosophy & Scoring Matrix

Interns are evaluated objectively across **four core engineering pillars**. Each pillar is scored on a scale from 1 to 4, mapped to enterprise competency levels:

| Score | Rating | Performance Descriptor |
| :---: | :--- | :--- |
| **4** | **Distinction (Exceeds Expectations)** | Demonstrates deep conceptual understanding, writes clean idiomatic C#, requires minimal mentor intervention, and proactively writes comprehensive unit tests. |
| **3** | **Competent (Meets Expectations)** | Ships working, clean code adhering to team standards; understands architecture and responds constructively to code review feedback. |
| **2** | **Developing (Needs Guidance)** | Meets functional requirements but struggles with edge cases, relies heavily on AI or mentor prompting, or has lapses in Git hygiene. |
| **1** | **Unsatisfactory (Below Standards)** | Code fails to compile or meet requirements; unable to explain submitted code during reviews; fails to communicate blockers. |

---

## 2. The Four Assessment Pillars

### Pillar 1: Code Quality, Architectural Integrity & Testing (Weight: 30%)
*Evaluates adherence to Clean Architecture, C# idioms, relational database design, and testing.*

| Criteria | 1 — Unsatisfactory | 2 — Developing | 3 — Competent | 4 — Distinction |
| :--- | :--- | :--- | :--- | :--- |
| **Separation of Concerns** | Mixes database queries, DTOs, and controller logic into single monolith methods. | Separates files but leaks EF Core entities directly into controller endpoints. | Cleanly isolates Domain Entities, DTO records, and REST Controllers. | Exemplary architecture; uses DTO mapping methods and strongly typed records. |
| **EF Core & Database Design** | Inappropriate relationships; unindexed queries; no foreign key constraints. | Functional schema but misses nullability rules or cascade delete implications. | Properly configures keys, indexes, string lengths, and enum string conversions. | Optimizes queries with `AsNoTracking()`, projections, and resilient seeding. |
| **Error Handling & Validation** | Returns unhandled 500 errors on invalid inputs or missing IDs. | Basic validation present but inconsistent status codes (e.g. 200 on error). | Consistently returns appropriate HTTP codes (400, 404, 201, 204). | Implements thorough input validation with clear problem detail messages. |
| **Automated Testing** | No tests written; relies entirely on manual verification. | Basic "happy-path" test written with minimal assertions. | Writes unit tests covering both positive and negative validation paths. | Comprehensive integration and unit tests covering edge cases and state transitions. |

---

### Pillar 2: Technical Comprehension & Code Defense (Weight: 25%)
*Evaluates the intern's ability to explain, defend, and reason about their code without AI assistance.*

| Criteria | 1 — Unsatisfactory | 2 — Developing | 3 — Competent | 4 — Distinction |
| :--- | :--- | :--- | :--- | :--- |
| **Conceptual Understanding** | Cannot explain what basic language features (e.g. `async/await`, `IQueryable`) do in their code. | Can explain basic syntax but struggles to explain why a specific pattern was used. | Accurately explains execution flow, dependency injection, and data transitions. | Articulates trade-offs (e.g., performance impact of eager vs lazy loading; tracking vs non-tracking). |
| **Defense Test Compliance** | Fails the Defense Test; admits to blind copy-pasting from AI or web. | Needs significant prompting to explain logic in their own pull request. | Confidently explains every line in their PR when questioned by mentors. | Defends design choices and suggests future optimizations independently. |

---

### Pillar 3: Git Hygiene, Process & DevOps Discipline (Weight: 20%)
*Evaluates professional version control standards and local environment orchestration.*

| Criteria | 1 — Unsatisfactory | 2 — Developing | 3 — Competent | 4 — Distinction |
| :--- | :--- | :--- | :--- | :--- |
| **Branching & Commits** | Commits directly to `main`; vague commit messages ("update", "fixed"). | Creates branches but commits include large messy blobs of unrelated changes. | Strictly follows branch naming (`feature/wil-...`) and Conventional Commits. | Atomic, beautifully structured commits with clear rationale in PR descriptions. |
| **Pull Request Discipline** | Submits PRs with compilation errors or without testing. | PRs work but descriptions are empty; ignores review comments. | Fulfills PR template, lists testing steps, and addresses feedback promptly. | Proactively self-reviews diffs, documents edge-case verifications, and ships clean PRs. |
| **Container & Environment Setup** | Cannot start local database without direct mentor intervention. | Relies on SQLite fallback because of difficulty operating Docker. | Independently operates Docker Compose and PostgreSQL locally. | Understands port mapping, health checks, environment variables, and Dockerfiles. |

---

### Pillar 4: Communication, Autonomy & Remote Professionalism (Weight: 25%)
*Evaluates reliability, time management, and effectiveness in a remote team.*

| Criteria | 1 — Unsatisfactory | 2 — Developing | 3 — Competent | 4 — Distinction |
| :--- | :--- | :--- | :--- | :--- |
| **Daily Standup Cadence** | Misses standups; silent for days at a time without explanation. | Posts standups irregularly or after midday; vague descriptions of work. | Consistently posts detailed standups by 09:30 AM SAST every morning. | Exemplary communication; clearly flags blockers early and communicates completion. |
| **Problem Solving Independence** | Gives up immediately upon encountering an error; asks questions without reading logs. | Spends days spinning wheels on a single blocker without asking for help. | Follows the 30-Minute Rule: investigates logs, consults docs, and asks targeted questions. | Highly resourceful; diagnoses root causes systematically before seeking validation. |
| **Logbook & Documentation Integrity** | Neglects logbook; attempts to backfill records at the end of the sprint. | Minimalist entries lacking technical depth or commit references. | Maintains accurate daily logbook entries with relevant PR links. | Impeccable documentation; captures technical reflections and architectural learnings. |

---

## 3. Score Calculation & Grade Boundaries

$$\text{Final Score (\%)} = (P_1 \times 7.5) + (P_2 \times 6.25) + (P_3 \times 5.0) + (P_4 \times 6.25)$$

* **Distinction (80% – 100%):** Demonstrates enterprise-readiness; recommended for junior engineering placement or advanced studio contracts.
* **Competent (65% – 79%):** Successfully meets all institutional WIL requirements; sound foundation in .NET backend engineering.
* **Conditional Pass (50% – 64%):** Requires additional practice in code comprehension or testing before independent deployment.
* **Unsuccessful (< 50%):** Did not fulfill core technical competencies or attendance requirements.

---

## 4. Evaluator Sign-Off Section

* **Intern Name:** Brian Mkandla  
* **Evaluator Name:** Takudzwa Mupanesure / Kenneth Katsande  
* **Title:** Technical Lead / Engineering Director, Sputnik Devs Studio  
* **Formative Midterm Score (Day 10):** _____ / 100%  
* **Summative Final Score (Day 19):** _____ / 100%  
* **Institutional Outcome:** [ ] Satisfactory (Credit Awarded)  [ ] Distinction  [ ] Unsatisfactory  

**Evaluator Signature:** ___________________________ Date: ____________
