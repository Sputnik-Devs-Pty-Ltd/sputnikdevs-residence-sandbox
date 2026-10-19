# Running PostgreSQL 16 in GitHub Codespaces — Step-by-Step Guide

Welcome to the upgraded **PostgreSQL 16** environment for the **Sputnik Devs Residence Sandbox API**!

Your GitHub Codespace now supports running a live **PostgreSQL 16** database server and the **`psql` CLI** directly inside your cloud container on port `5433` — with **zero installation or RAM impact on your laptop**.

---

## 1. Pull the Latest `main` Branch & Start PostgreSQL

Whether you are using your existing Codespace or a newly rebuilt Codespace, run the following in your Codespace terminal:

```bash
git checkout main
git pull origin main
./scripts/start-postgres.sh
```

### What `./scripts/start-postgres.sh` Does Automatically:
1. Installs **PostgreSQL 16** and the **`psql` client** inside your cloud Codespace container (if not already installed).
2. Configures PostgreSQL to listen on **port `5433`** (matching `appsettings.json` and `appsettings.Development.json`).
3. Starts the background PostgreSQL service and configures the `postgres` user (`Password=postgres`).
4. Creates the `residence_sandbox_db` database if it does not exist yet.
5. Configures `~/.pgpass` so you can run `psql` commands immediately **without being prompted for a password**.
6. Restores the local `dotnet-ef` CLI tool (`.config/dotnet-tools.json`).

> [!TIP]
> If you rebuild your Codespace container (`Ctrl+Shift+P` -> **Codespaces: Rebuild Container**), `./scripts/start-postgres.sh` will run automatically every time your Codespace starts!

---

## 2. Apply Your EF Core Migrations to PostgreSQL

Once `./scripts/start-postgres.sh` displays `✅ PostgreSQL is READY on localhost:5433!`, apply your Day 04 EF Core migration (`20261015080443_InitialCreate`) to PostgreSQL:

```bash
dotnet ef database update --project SputnikDevs.Residence.SandboxApi -- --DatabaseProvider=Postgres
```

---

## 3. Run the API Against Live PostgreSQL (Auto-Migration & Seeding)

You can run the API against PostgreSQL either by passing `--DatabaseProvider=Postgres` on the command line **or** by setting `"DatabaseProvider": "Postgres"` in `SputnikDevs.Residence.SandboxApi/appsettings.Development.json`:

```bash
dotnet run --project SputnikDevs.Residence.SandboxApi -- --DatabaseProvider=Postgres
```

On startup:
- `DbInitializer.SeedAsync` detects PostgreSQL (`context.Database.IsNpgsql()`), ensures all EF Core migrations are applied (`MigrateAsync()`), and seeds the **4 rooms**, **3 students**, and **6 maintenance tickets** (including comments) into `residence_sandbox_db`.
- Open the **Swagger UI** on port `5035` to test `GET /api/rooms`, `GET /api/students`, and `GET /api/tickets` backed by live PostgreSQL!

---

## 4. Inspect Tables & Seeded Data Using `psql`

Open a second terminal tab in your Codespace (or stop the API with `Ctrl+C`) and inspect your live PostgreSQL database directly with `psql`:

### List All Tables (`\dt`)
```bash
psql -h localhost -p 5433 -U postgres -d residence_sandbox_db -c "\dt"
```

Expected output:
```text
                   List of relations
 Schema |         Name          | Type  |  Owner   
--------+-----------------------+-------+----------
 public | MaintenanceTickets    | table | postgres
 public | Rooms                 | table | postgres
 public | Students              | table | postgres
 public | TicketComments        | table | postgres
 public | __EFMigrationsHistory | table | postgres
(5 rows)
```

### Query Applied EF Core Migrations
```bash
psql -h localhost -p 5433 -U postgres -d residence_sandbox_db -c 'SELECT "MigrationId", "ProductVersion" FROM "__EFMigrationsHistory";'
```

### Query Seeded Rooms, Students, and Maintenance Tickets
```bash
# View all 4 seeded rooms
psql -h localhost -p 5433 -U postgres -d residence_sandbox_db -c 'SELECT "RoomNumber", "BuildingName", "Floor", "Capacity" FROM "Rooms" ORDER BY "RoomNumber";'

# View all 3 seeded students
psql -h localhost -p 5433 -U postgres -d residence_sandbox_db -c 'SELECT "StudentNumber", "FirstName", "LastName", "Email" FROM "Students" ORDER BY "StudentNumber";'

# View all 6 seeded maintenance tickets (including HVAC, PestControl, Furniture & Resolved state)
psql -h localhost -p 5433 -U postgres -d residence_sandbox_db -c 'SELECT "Title", "Category", "Priority", "Status", "AssignedTechnician" FROM "MaintenanceTickets" ORDER BY "CreatedAtUtc";'
```

### Open an Interactive `psql` Shell
```bash
psql -h localhost -p 5433 -U postgres -d residence_sandbox_db
```
*(Type `\q` and press Enter to exit the interactive `psql` shell).*

---

## 5. Switching Back and Forth Between SQLite and PostgreSQL

- **Default (SQLite):**
  ```bash
  dotnet run --project SputnikDevs.Residence.SandboxApi
  ```
- **PostgreSQL 16:**
  ```bash
  dotnet run --project SputnikDevs.Residence.SandboxApi -- --DatabaseProvider=Postgres
  ```
  *(Or change `"DatabaseProvider": "Postgres"` in `SputnikDevs.Residence.SandboxApi/appsettings.Development.json` to make PostgreSQL your default).*
