# Track 04: Big Data, BI & Data Science (19-Day WIL Syllabus)

* **Track Code:** `AiAndBigData` (`Track 04`)
* **Target Workspace:** `analytics/`
* **Core Tech Stack:** Python 3, Pandas, NumPy, SQLite / PostgreSQL Connectors, Matplotlib / Plotly, Statistical Anomaly Detection, Predictive Churn & Maintenance SLA Modeling.
* **Student Portal & Oral Defense Questions:** [https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal)

---

## 19-Day Milestone Schedule (152 Credit Hours)

| Day | Phase | Milestone Title | Deliverable Summary |
| :--- | :--- | :--- | :--- |
| **Day 01** | Week 1 | Analytics Workspace Setup & Database Extraction | Fork repo, set up Python environment in `analytics/`, extract `Rooms`, `Students`, and `MaintenanceTickets` into Pandas DataFrames. |
| **Day 02** | Week 1 | Data Profiling, Missing Value Imputation & Schema Validation | Audit column distributions, handle null `ResolvedAt` / `AssignedTechnician` fields, and export clean dataset summary. |
| **Day 03** | Week 1 | Synthetic High-Volume Dataset Generator (10,000+ Records) | Write `analytics/generate_synthetic_telemetry.py` simulating 12 months of multi-campus residence occupancy and ticket telemetry. |
| **Day 04** | Week 1 | Exploratory Data Analysis (EDA): Occupancy & Floor Utilization | Compute occupancy rates per campus block, floor, and room capacity tier with summary tables. |
| **Day 05** | Week 1 | Maintenance Ticket Volume & Category Distribution | Analyze ticket frequency across `Plumbing`, `Electrical`, `Wi-Fi/Network`, `Furniture`, and `Appliance`; pass Week 1 Oral Defense. |
| **Day 06** | Week 2 | Time-Series SLA Resolution & MTTR Telemetry | Engineer `ResolutionHours` feature, compute P50 (Median), P90, and P95 turnaround times per priority level. |
| **Day 07** | Week 2 | SLA Breach Rate & Bottleneck Identification | Flag tickets exceeding SLA thresholds (`Critical > 24h`, `High > 48h`, `Medium > 72h`) and isolate bottleneck blocks/categories. |
| **Day 08** | Week 2 | Technician Workload Balancing & Productivity Index | Analyze ticket assignment distribution and resolution efficiency across maintenance staff. |
| **Day 09** | Week 2 | Cohort & Seasonal Trend Analysis | Identify peak maintenance surges (move-in month, exam weeks, winter heating load) using rolling 7-day averages. |
| **Day 10** | Week 2 | Executive Visual Storytelling (Charts & Heatmaps) | Generate publication-grade visual charts (Floor-by-Category heatmaps, SLA Pareto curves) saved to `analytics/reports/`. |
| **Day 11** | Week 3 | Feature Engineering for Predictive Residence Analytics | Construct room-level and student-level feature matrices (historical ticket count, repeat failure rate, days since last inspection). |
| **Day 12** | Week 3 | Statistical Anomaly Detection (Chronic Problem Rooms) | Use Z-score / IQR outlier detection to flag rooms with abnormally high repeat maintenance failures. |
| **Day 13** | Week 3 | Predictive Ticket Resolution Time Estimator | Train and evaluate a baseline regression model predicting expected resolution hours from category, priority, and block. |
| **Day 14** | Week 3 | Student Retention & Lease Renewal Risk Scoring | Build a rule-based + statistical risk score identifying students impacted by repeated unresolved critical maintenance issues. |
| **Day 15** | Week 3 | Automated Daily KPI Pipeline Script (`run_daily_kpi.py`) | Package data extraction, cleaning, KPI calculation, and JSON/CSV export into an automated CLI script. |
| **Day 16** | Week 4 | Capstone Feature: Interactive Executive BI Report Pack | Produce a comprehensive JSON + HTML executive intelligence dashboard summarizing cost, SLA health, and preventative recommendations. |
| **Day 17** | Week 4 | Capstone Polish: Data Pipeline Unit Tests & Reproducibility | Add `pytest` validation checks ensuring zero NaN leakage, deterministic random seeds, and schema assertions. |
| **Day 18** | Week 4 | Executive Findings Brief & Methodology Documentation | Write data science methodology and business recommendations in `analytics/README.md`. |
| **Day 19** | Week 4 | Final 30-Minute Live Oral Code Defense & Sign-Off | Defend Pandas pipelines, statistical metrics, and business insights live before graduation sign-off. |
