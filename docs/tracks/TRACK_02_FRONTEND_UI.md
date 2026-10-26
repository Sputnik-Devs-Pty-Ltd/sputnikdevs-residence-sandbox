# Track 02: Frontend & Modern Web UI Engineering (19-Day WIL Syllabus)

* **Track Code:** `ModernWebUi` (`Track 02`)
* **Target Workspace:** `frontend/`
* **Core Tech Stack:** Semantic HTML5, CSS Grid/Flexbox, Tailwind CSS / Bootstrap 5, Modern ES6+ JavaScript (`fetch`, `async/await`), Chart.js, Accessibility (WCAG 2.1 AA).
* **Backend API Target:** Consumes the local or Codespaces Sandbox API (`http://localhost:5035/api/v1/...`).
* **Student Portal & Oral Defense Questions:** [https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal)

---

## 19-Day Milestone Schedule (152 Credit Hours)

| Day | Phase | Milestone Title | Deliverable Summary |
| :--- | :--- | :--- | :--- |
| **Day 01** | Week 1 | UI Workspace Setup, Design Tokens & API Connection | Fork repo, launch Sandbox API on port `5035`, scaffold `frontend/index.html` with dark/slate executive design tokens. |
| **Day 02** | Week 1 | Responsive Residence Room Matrix Grid | Fetch `GET /api/v1/rooms` and render a responsive CSS Grid of room cards with occupancy progress bars and availability badges. |
| **Day 03** | Week 1 | Interactive Room Filter Bar & Instant Search | Build client-side + query-string filter controls (`floor`, `buildingBlock`, `availableOnly`) with URL state persistence. |
| **Day 04** | Week 1 | Student Directory Table & Room Allocation Modal | Render searchable student table (`GET /api/v1/students`) and interactive modal invoking `POST /api/v1/students/{id}/assign-room`. |
| **Day 05** | Week 1 | Toast Notifications, Empty States & Skeleton Loaders | Build reusable toast alert component, shimmer loading skeletons, and empty-state illustrations; pass Week 1 Oral Defense. |
| **Day 06** | Week 2 | Maintenance Ticket Kanban Board (Open / In-Progress / Resolved) | Fetch `GET /api/v1/tickets` and render a 3-column Kanban board with priority color coding (`Low`, `Medium`, `High`, `Critical`). |
| **Day 07** | Week 2 | Log New Maintenance Ticket Form & Client-Side Validation | Build accessible form (`POST /api/v1/tickets`) with inline validation, character counters, and error recovery states. |
| **Day 08** | Week 2 | Technician Assignment & Status Drawer | Build slide-over detail drawer calling `PATCH /api/v1/tickets/{id}/status` and `PATCH /api/v1/tickets/{id}/assign`. |
| **Day 09** | Week 2 | Executive KPI Dashboard & Data Visualization | Connect to `GET /api/v1/dashboard/summary` and render occupancy donut charts and ticket resolution bar charts. |
| **Day 10** | Week 2 | Responsive Mobile Navigation & Breakpoint Audit | Optimize layout across `375px` (Mobile), `768px` (Tablet), and `1440px` (Desktop) viewports with zero horizontal overflow. |
| **Day 11** | Week 3 | Centralized API Client Module (`apiClient.js`) | Refactor raw `fetch()` calls into a clean ES6 module with timeout handling, HTTP status parsing, and retry logic. |
| **Day 12** | Week 3 | Dark / Light Theme Switcher with `localStorage` | Implement CSS custom property theme switching respecting `prefers-color-scheme` and persisting user preference. |
| **Day 13** | Week 3 | Client-Side Pagination & Table Sorting | Add sortable columns and paginated table controls for 100+ maintenance tickets. |
| **Day 14** | Week 3 | Accessibility (WCAG 2.1 AA) & Keyboard Navigation Audit | Add ARIA attributes, focus traps on modals, `Escape` key handlers, and verify contrast ratios. |
| **Day 15** | Week 3 | CSV Export Trigger & Printable Residence Report View | Add `@media print` stylesheet and 1-click CSV download button connected to the backend API. |
| **Day 16** | Week 4 | Capstone Feature: SLA Breach Alert Center UI | Build real-time visual countdown badges and SLA breach alert banner for overdue maintenance tickets. |
| **Day 17** | Week 4 | Capstone Polish: Micro-Interactions & Performance Audit | Optimize DOM rendering, debounce search inputs, and achieve Lighthouse Performance & Accessibility scores `>= 90`. |
| **Day 18** | Week 4 | Cross-Browser UAT Checklist & UI Documentation | Document component usage and screenshots in `frontend/README.md`. |
| **Day 19** | Week 4 | Final 30-Minute Live Oral Code Defense & Sign-Off | Live walkthrough of DOM manipulation, async `fetch` lifecycle, CSS architecture, and graduation sign-off. |
