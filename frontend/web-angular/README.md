# Track 02A: Angular 19+ Enterprise SPA Workspace (`frontend/web-angular/`)

Welcome to **Track 02A (`SD-FE-101..104`) — Angular 19+ Enterprise SPA** inside the **Sputnik Devs Residence Sandbox** monorepo.

## Architecture & Tech Stack
* **Framework:** Angular 19+ (Standalone Components, Signals & RxJS)
* **Language:** TypeScript 5.x (Strict Mode)
* **Styling:** Tailwind CSS + CSS Custom Property Theme Tokens (Dark & Light Mode)
* **Backend API:** `.NET 10` Residence Sandbox API (`http://localhost:5035/api/v1`)

## Workspace Structure
```text
frontend/web-angular/
├── package.json
├── tsconfig.json
└── src/
    └── app/
        ├── models/
        │   └── residence.models.ts        # Strongly-typed Room, Student, Ticket & Dashboard DTOs
        ├── services/
        │   └── residence-api.service.ts   # Angular HttpClient service with RxJS & Signals
        └── app.component.ts               # Root Residence Operations Shell Component
```

## Running in GitHub Codespaces or Locally
1. Ensure the .NET 10 Sandbox API is running on `http://localhost:5035`:
   ```bash
   dotnet run --project ../../SputnikDevs.Residence.SandboxApi
   ```
2. Install dependencies & start the Angular dev server:
   ```bash
   cd frontend/web-angular
   npm install
   npm start
   ```
3. Follow the 19-Day milestone schedule in **[`../../docs/tracks/TRACK_02_FRONTEND_UI.md`](../../docs/tracks/TRACK_02_FRONTEND_UI.md)**.
