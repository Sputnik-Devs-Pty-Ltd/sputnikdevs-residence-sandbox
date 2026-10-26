# Track 02: Modern Web & SaaS UI Engineering — Angular 19+ & Blazor (19-Day WIL Syllabus)

* **Track Code:** `ModernWebUi` (`Track 02` · Module Codes `SD-FE-101` to `SD-FE-104`)
* **Target Workspace:**
  * **Track 02A (Angular SPA):** `frontend/web-angular/` (Angular 19+, TypeScript, Standalone Components, Signals, RxJS, Tailwind CSS)
  * **Track 02B (Blazor / Razor / Modern JS):** `frontend/web-blazor-razor/` (HTML5, Tailwind CSS, ES6+ `fetch` / Blazor UI)
* **Backend API Target:** Consumes the Sputnik Devs Residence Sandbox API (`http://localhost:5035/api/v1/...`).
* **Student Portal & Oral Defense Questions:** [https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal)

---

## Module Breakdown (`152 Notional Hours` — Stage 1)

| Module Code | Module Title | Days | Hours | Focus Areas |
| :--- | :--- | :--- | :--- | :--- |
| **`SD-FE-101`** | **Component Architecture, Design Tokens & Responsive Grids** | Days 01–04 | 36h | Angular Standalone Components / Signals (or Blazor Components), Dark/Light Theme CSS Variables, Mobile-First Grid Layouts & WCAG 2.1 AA Accessibility. |
| **`SD-FE-102`** | **Asynchronous REST API Integration & Reactive State** | Days 05–09 | 40h | Angular `HttpClient` & Interceptors (or `apiClient.js`), RxJS Debounced Search, Pagination Controls & RFC 7807 Error Toast Notifications. |
| **`SD-FE-103`** | **Interactive Dashboards, Kanban & Reactive Form Validation** | Days 10–14 | 40h | Room Allocation Floor-Plan Matrix, 4-Column Maintenance Ticket SLA Kanban Board, Reactive Forms & Printable `@media print` Student Statements. |
| **`SD-FE-104`** | **Route Guards, Cross-Viewport QA, Lighthouse & Oral Defense** | Days 15–19 | 36h | JWT `CanActivateFn` Route Guards, Role-Based UI Views, 90+ Lighthouse Performance/Accessibility Audit, Unit Tests & Final Oral Code Defense. |

---

## 19-Day Milestone Schedule (152 Credit Hours)

| Day | Module | Milestone Title | Deliverable Summary |
| :--- | :--- | :--- | :--- |
| **Day 01** | `SD-FE-101` | UI Workspace Setup, Design Tokens & API Connection | Fork repo, launch Sandbox API on port `5035`, initialize `frontend/web-angular/` (or `frontend/web-blazor-razor/`) with dark/light executive theme tokens. |
| **Day 02** | `SD-FE-101` | Responsive Residence Room Matrix Grid Component | Fetch `GET /api/v1/rooms` and render a responsive grid of typed `RoomCardComponent` items with occupancy progress bars and availability badges. |
| **Day 03** | `SD-FE-101` | Interactive Room Filter Bar & Debounced Search (`RxJS` / `Signals`) | Build filter controls (`floor`, `buildingBlock`, `availableOnly`) with 300ms debounced search and URL query-param synchronization. |
| **Day 04** | `SD-FE-101` | Student Directory Table & Room Allocation Modal | Render searchable student table (`GET /api/v1/students`) and accessible modal invoking `POST /api/v1/students/{id}/assign-room`. |
| **Day 05** | `SD-FE-102` | Typed API Service, HTTP Error Interceptor & Shimmer Skeletons | Centralize HTTP calls in `ResidenceApiService` (`apiClient.js`), add shimmer loading skeletons, and display toast notifications on HTTP `400`/`409` errors. |
| **Day 06** | `SD-FE-102` | Maintenance Ticket Kanban Board (`Open` / `InProgress` / `Resolved`) | Fetch `GET /api/v1/tickets` and render a 3-column Kanban board with priority badges (`Low`, `Medium`, `High`, `Critical`). |
| **Day 07** | `SD-FE-102` | Reactive Maintenance Ticket Form & Validation | Build an Angular Reactive Form (or validated HTML5 form) for `POST /api/v1/tickets` with inline field validation and disabled in-flight submit states. |
| **Day 08** | `SD-FE-102` | Technician Assignment & Status Transition Drawer | Build a slide-over detail drawer calling `PATCH /api/v1/tickets/{id}/status` and `PATCH /api/v1/tickets/{id}/assign`. |
| **Day 09** | `SD-FE-102` | Executive KPI Dashboard & Occupancy Visualization | Connect to `GET /api/v1/dashboard/summary` and render occupancy donut charts and SLA ticket resolution metrics. |
| **Day 10** | `SD-FE-103` | Responsive Mobile Navigation & Breakpoint Audit (`375px`–`1440px`) | Optimize navigation drawer and tables across `375px` (Mobile), `768px` (Tablet), and `1440px` (Desktop) viewports with zero horizontal overflow. |
| **Day 11** | `SD-FE-103` | Dark / Light Theme Switcher with `localStorage` & System Sync | Implement semantic CSS custom property theme switching respecting `prefers-color-scheme` and persisting user preference. |
| **Day 12** | `SD-FE-103` | Client/Server Pagination & Multi-Column Table Sorting | Add sortable headers and pagination controls for large resident and maintenance ticket datasets. |
| **Day 13** | `SD-FE-103` | Student Financial Statement & `@media print` Invoice View | Build the student ZAR billing ledger view and print-ready `@media print` A4 statement stylesheet. |
| **Day 14** | `SD-FE-103` | Accessibility (WCAG 2.1 AA) & Keyboard Focus Trap Audit | Add ARIA attributes, `role="status"` live regions, modal keyboard focus traps, and `Escape` key handlers. |
| **Day 15** | `SD-FE-104` | JWT Authentication State & `CanActivateFn` Route Guards | Implement role-based route protection (`Admin`, `HouseWarden`, `Student`) and HTTP Bearer token injection. |
| **Day 16** | `SD-FE-104` | Capstone Feature: Real-Time SLA Breach Alert Center | Build live SLA countdown timers and an overdue breach alert center for residence managers. |
| **Day 17** | `SD-FE-104` | Capstone Polish: Component Unit Tests & Lighthouse `>= 90` | Write component unit tests and optimize bundle/DOM performance to achieve `90+` Lighthouse scores. |
| **Day 18** | `SD-FE-104` | Cross-Browser UAT Checklist & Architecture Documentation | Document component hierarchy, state flow, and before/after screenshots in your workspace `README.md`. |
| **Day 19** | `SD-FE-104` | Final 30-Minute Live Oral Code Defense & Graduation Sign-Off | Live walkthrough of component architecture, async state lifecycle, security guards, and graduation sign-off. |
