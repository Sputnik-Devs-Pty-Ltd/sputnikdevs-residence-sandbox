# Track 03: Database Administration, SQL & Data Engineering (19-Day WIL Syllabus)

* **Track Code:** `DatabaseAndDataEngineering` (`Track 03`)
* **Target Workspace:** `database/`
* **Core Tech Stack:** PostgreSQL 16, Advanced SQL (DDL, DML, Joins, CTEs, Window Functions), Composite Indexing, `EXPLAIN ANALYZE`, SQL Views, Stored Functions, Bash/Python CSV ETL Pipelines.
* **Student Portal & Oral Defense Questions:** [https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal)

---

## 19-Day Milestone Schedule (152 Credit Hours)

| Day | Phase | Milestone Title | Deliverable Summary |
| :--- | :--- | :--- | :--- |
| **Day 01** | Week 1 | PostgreSQL 16 Provisioning & ER Diagram Modeling | Launch PostgreSQL 16 (`./scripts/start-postgres.sh`), inspect schema in `psql`, document 3NF Entity-Relationship Diagram in `database/erd.md`. |
| **Day 02** | Week 1 | DDL Schema Hardening & `CHECK` Constraints | Write `database/migrations/01_constraints.sql` enforcing `CurrentOccupancy <= Capacity`, valid priorities, and non-empty student numbers. |
| **Day 03** | Week 1 | Bulk Seed Script & Realistic Dataset Generation | Write SQL script (`02_bulk_seed.sql`) generating 120 rooms, 350 students, and 500 maintenance tickets across 6 months. |
| **Day 04** | Week 1 | Relational Joins & Occupancy Audit Queries | Write analytical `INNER JOIN` and `LEFT JOIN` queries detecting unallocated students, under-utilized floors, and over-capacity anomalies. |
| **Day 05** | Week 1 | Aggregations, `GROUP BY`, `HAVING` & Week 1 Oral Defense | Write block-by-block occupancy and maintenance volume rollups; pass Week 1 Oral Code Defense. |
| **Day 06** | Week 2 | Common Table Expressions (CTEs) & SLA Resolution Time Analysis | Write multi-stage CTE queries calculating mean time to resolution (MTTR) in hours per category and technician. |
| **Day 07** | Week 2 | SQL Window Functions (`RANK`, `ROW_NUMBER`, `LAG`) | Rank residence blocks by maintenance frequency and compute month-over-month ticket growth rates. |
| **Day 08** | Week 2 | Query Performance Tuning & `EXPLAIN ANALYZE` | Capture baseline query plans on filtered ticket searches and create B-Tree composite indexes (`03_indexes.sql`) reducing cost. |
| **Day 09** | Week 2 | Reporting SQL Views (`vw_residence_kpi`, `vw_sla_breaches`) | Create reusable database views for executive dashboards and overdue SLA monitoring. |
| **Day 10** | Week 2 | Transactions, Isolation Levels & Concurrency Safety | Write transactional room transfer script (`BEGIN ... COMMIT / ROLLBACK`) preventing race conditions when two students claim the last bed. |
| **Day 11** | Week 3 | PostgreSQL Functions & Stored Procedures | Write `fn_assign_student_to_room(student_id, room_id)` encapsulating capacity checks and occupancy increments atomically. |
| **Day 12** | Week 3 | Database Triggers & Audit Trail Logging | Create `ResidenceAuditLog` table and `AFTER UPDATE` trigger recording every room allocation and ticket status change. |
| **Day 13** | Week 3 | CSV ETL Ingestion Pipeline & Staging Tables | Build staging table workflow (`stg_student_imports`) to cleanse, deduplicate, and upsert messy college CSV rosters. |
| **Day 14** | Week 3 | Data Quality Audit & Orphan Record Remediation | Write automated SQL integrity check suite verifying zero orphan foreign keys or negative occupancy counts. |
| **Day 15** | Week 3 | Backup, Restore (`pg_dump` / `pg_restore`) & Disaster Recovery Drill | Create automated backup script and document point-in-time recovery runbook in `database/DR_RUNBOOK.md`. |
| **Day 16** | Week 4 | Capstone Feature: Materialized Views & Executive Data Mart | Build materialized view `mv_monthly_residence_scorecard` with refresh procedure for sub-millisecond BI queries. |
| **Day 17** | Week 4 | Capstone Polish: Role-Based Database Security & Least Privilege | Configure read-only analyst role (`residence_bi_reader`) vs application read/write role (`residence_app_rw`). |
| **Day 18** | Week 4 | Complete SQL Runbook & Performance Benchmark Report | Document before/after `EXPLAIN ANALYZE` benchmarks in `database/README.md`. |
| **Day 19** | Week 4 | Final 30-Minute Live Oral Code Defense & Sign-Off | Live SQL defense in `psql`, index justification, and graduation sign-off. |
