#!/usr/bin/env bash
set -euo pipefail

PG_PORT=5433
PG_DB="residence_sandbox_db"
PG_USER="postgres"
PG_PASS="postgres"

echo "================================================================"
echo "  Sputnik Devs Residence Sandbox — PostgreSQL Setup & Launcher  "
echo "================================================================"

# 1. Install PostgreSQL 16 & psql client if not present (e.g. inside GitHub Codespaces)
if ! command -v psql >/dev/null 2>&1 || [ ! -d /etc/postgresql ]; then
    echo "[1/4] Installing PostgreSQL server and psql client..."
    sudo apt-get update -qq
    sudo DEBIAN_FRONTEND=noninteractive apt-get install -y -qq postgresql postgresql-client
else
    echo "[1/4] PostgreSQL server and psql client are already installed."
fi

# 2. Configure PostgreSQL to listen on port 5433 (matching appsettings.json)
PG_CONF=$(find /etc/postgresql -name "postgresql.conf" | head -n 1)
if [ -n "$PG_CONF" ]; then
    CURRENT_PORT=$(sudo grep -E "^[[:space:]]*port[[:space:]]*=" "$PG_CONF" | awk -F'=' '{print $2}' | awk '{print $1}' || true)
    if [ "$CURRENT_PORT" != "$PG_PORT" ]; then
        echo "[2/4] Configuring PostgreSQL port to ${PG_PORT} in ${PG_CONF}..."
        sudo sed -i "s/^[[:space:]]*port[[:space:]]*=.*/port = ${PG_PORT}/" "$PG_CONF"
        sudo service postgresql restart
    else
        echo "[2/4] PostgreSQL is already configured for port ${PG_PORT}."
    fi
fi

# 3. Ensure PostgreSQL service is running on port 5433
if ! pg_isready -h localhost -p "${PG_PORT}" >/dev/null 2>&1; then
    echo "[3/4] Starting PostgreSQL service on port ${PG_PORT}..."
    sudo service postgresql start
    for _ in {1..10}; do
        if pg_isready -h localhost -p "${PG_PORT}" >/dev/null 2>&1; then
            break
        fi
        sleep 1
    done
else
    echo "[3/4] PostgreSQL service is running and accepting connections on port ${PG_PORT}."
fi

# 4. Configure user password, create database if missing, and set ~/.pgpass for passwordless psql
echo "[4/4] Verifying user '${PG_USER}' and database '${PG_DB}'..."
# In GitHub Codespaces (Ubuntu 24.04 Noble), /etc/sudoers.d/vscode defaults to ALL=(root) NOPASSWD:ALL,
# which allows passwordless `sudo` as root but prompts for a password on `sudo -u postgres`.
# Upgrade sudoers to ALL=(ALL:ALL) and use `sudo runuser -u postgres --` so Step 4 never prompts for a password.
if [ -f /etc/sudoers.d/vscode ]; then
    sudo sed -i 's/ALL=(root)/ALL=(ALL:ALL)/g' /etc/sudoers.d/vscode 2>/dev/null || true
fi

(cd /tmp && sudo runuser -u postgres -- psql -p "${PG_PORT}" -c "ALTER USER ${PG_USER} WITH PASSWORD '${PG_PASS}';" >/dev/null)

DB_EXISTS=$(cd /tmp && sudo runuser -u postgres -- psql -p "${PG_PORT}" -tAc "SELECT 1 FROM pg_database WHERE datname='${PG_DB}'")
if [ "$DB_EXISTS" != "1" ]; then
    (cd /tmp && sudo runuser -u postgres -- psql -p "${PG_PORT}" -c "CREATE DATABASE ${PG_DB} OWNER ${PG_USER};" >/dev/null)
    echo "      Created database '${PG_DB}'."
else
    echo "      Database '${PG_DB}' already exists."
fi

# Configure ~/.pgpass so `psql -h localhost -p 5433 -U postgres -d residence_sandbox_db` works without password prompt
PGPASS_LINE="localhost:${PG_PORT}:*:${PG_USER}:${PG_PASS}"
if [ ! -f "$HOME/.pgpass" ] || ! grep -qF "$PGPASS_LINE" "$HOME/.pgpass"; then
    echo "$PGPASS_LINE" >> "$HOME/.pgpass"
    chmod 600 "$HOME/.pgpass"
fi

# Restore local .NET tools (dotnet-ef) if manifest exists
REPO_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
if [ -f "${REPO_ROOT}/.config/dotnet-tools.json" ]; then
    dotnet tool restore --tool-manifest "${REPO_ROOT}/.config/dotnet-tools.json" >/dev/null 2>&1 || true
fi

echo ""
echo "✅ PostgreSQL is READY on localhost:${PG_PORT}!"
echo "   • Database : ${PG_DB}"
echo "   • Username : ${PG_USER}"
echo "   • Password : ${PG_PASS}"
echo ""
echo "Quick Commands:"
echo "   1. Apply EF Core Migrations to PostgreSQL:"
echo "      dotnet ef database update --project SputnikDevs.Residence.SandboxApi -- --DatabaseProvider=Postgres"
echo ""
echo "   2. Run API with PostgreSQL (auto-migrates & seeds 4 rooms, 3 students, 6 tickets):"
echo "      dotnet run --project SputnikDevs.Residence.SandboxApi -- --DatabaseProvider=Postgres"
echo ""
echo "   3. Inspect PostgreSQL tables & seeded data with psql:"
echo "      psql -h localhost -p 5433 -U postgres -d residence_sandbox_db -c \"\\dt\""
echo "================================================================"
