# Track 05: Applied AI & Intelligent Automation (19-Day WIL Syllabus)

* **Track Code:** `AppliedAiAndAutomation` (`Track 05`)
* **Target Workspace:** `ai-agents/`
* **Core Tech Stack:** Python 3 / C# .NET 10, NLP Text Classification, Urgency & Sentiment Scoring, Retrieval-Augmented Generation (RAG) over Residence Rules, Automated Triage API Integration.
* **Student Portal & Oral Defense Questions:** [https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal)

---

## 19-Day Milestone Schedule (152 Credit Hours)

| Day | Phase | Milestone Title | Deliverable Summary |
| :--- | :--- | :--- | :--- |
| **Day 01** | Week 1 | AI Workspace Setup & Maintenance Corpus Exploration | Fork repo, inspect `MaintenanceTicket` descriptions, and create labeled sample dataset (`ai-agents/data/tickets_labeled.json`). |
| **Day 02** | Week 1 | Text Preprocessing & Tokenization Pipeline | Build deterministic text normalizer handling South African student residence slang, typos, and room references. |
| **Day 03** | Week 1 | Automated Ticket Category Classifier | Build classifier mapping raw ticket descriptions to `Plumbing`, `Electrical`, `Wi-Fi`, `Security`, or `Furniture` with confidence scores. |
| **Day 04** | Week 1 | Emergency & Safety Hazard Urgency Detector | Build high-recall urgency detector flagging life-safety keywords (exposed wires, burst geyser, sparks, broken lock) as `Critical`. |
| **Day 05** | Week 1 | Evaluation Metrics (Precision, Recall, F1 & Confusion Matrix) | Evaluate classifier accuracy on held-out test tickets and document error analysis; pass Week 1 Oral Defense. |
| **Day 06** | Week 2 | Duplicate Ticket & Outage Cluster Detection | Use TF-IDF / cosine similarity to detect when 5+ students on the same floor report the same Wi-Fi or water outage simultaneously. |
| **Day 07** | Week 2 | Student Frustration & Sentiment Scoring Engine | Score ticket sentiment (`Calm`, `Concerned`, `Distressed/Urgent`) so residence managers prioritize distressed residents. |
| **Day 08** | Week 2 | Smart Technician Routing & Recommendation Rule Engine | Combine predicted category, urgency, and technician current workload to recommend the optimal assignee. |
| **Day 09** | Week 2 | Residence Handbook Knowledge Base & Chunking (RAG Part 1) | Structure residence rules, curfew policies, Wi-Fi troubleshooting, and emergency contacts into searchable knowledge chunks. |
| **Day 10** | Week 2 | Semantic Retrieval & Grounded FAQ Assistant (RAG Part 2) | Build retrieval pipeline returning top-K relevant policy clauses with strict citation grounding (zero hallucinated rules). |
| **Day 11** | Week 3 | Self-Service Troubleshooting Deflection Bot | Build pre-ticket assistant offering instant self-fix steps (e.g., router reset, prepaid meter keypad code) before logging a ticket. |
| **Day 12** | Week 3 | Structured JSON Output Schema & Guardrails | Enforce strict JSON schema validation on all AI triage outputs (`category`, `priority`, `confidence`, `reasoning`, `suggested_action`). |
| **Day 13** | Week 3 | Prompt Injection & Safety Guardrail Filter | Implement input sanitization blocking adversarial prompts, PII leakage, or off-topic requests. |
| **Day 14** | Week 3 | REST API Microservice / Endpoint Integration | Expose the AI Triage Engine via HTTP (`POST /api/v1/ai/triage-ticket`) so the Residence Sandbox API can auto-classify new tickets. |
| **Day 15** | Week 3 | Automated Regression Benchmark Suite | Build 50-case golden evaluation suite verifying classification accuracy and latency (`< 200ms` local inference). |
| **Day 16** | Week 4 | Capstone Feature: Automated Daily Residence Ops Briefing Generator | Build an executive summarizer generating a daily morning briefing of critical incidents, cluster outages, and SLA risks. |
| **Day 17** | Week 4 | Capstone Polish: Human-in-the-Loop Confidence Thresholds | Route low-confidence predictions (`confidence < 0.70`) to a human Coordinator review queue with explainable reasoning. |
| **Day 18** | Week 4 | AI System Card, Ethics & Architecture Documentation | Document model limitations, false-negative mitigation, and latency metrics in `ai-agents/README.md`. |
| **Day 19** | Week 4 | Final 30-Minute Live Oral Code Defense & Sign-Off | Defend NLP/RAG pipeline, precision/recall trade-offs, and guardrail code live before graduation sign-off. |
