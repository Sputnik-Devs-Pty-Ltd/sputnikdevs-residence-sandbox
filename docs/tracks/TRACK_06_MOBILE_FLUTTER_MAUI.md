# Track 06: Mobile & Cross-Platform Engineering — Flutter & .NET MAUI (19-Day WIL Syllabus)

* **Track Code:** `MobileEngineering` (`Track 06` · Module Codes `SD-MB-101` to `SD-MB-104`)
* **Target Workspace:** `mobile/mobile-flutter/` (Flutter & Dart) or `mobile/mobile-maui/` (.NET MAUI)
* **Core Tech Stack:** Flutter 3.x & Dart 3 (or .NET 10 MAUI C#), RESTful JSON Integration, `FlutterSecureStorage` / Keychain Auth, Offline-First SQLite / Local Queue Sync, Expiring QR Gate Pass Rendering, Widget & Unit Testing.
* **Backend API Target:** Consumes the Sputnik Devs Residence Sandbox API (`http://localhost:5035/api/v1/...`).
* **Student Portal & Oral Defense Questions:** [https://sputnikdevs.com/academy/portal](https://sputnikdevs.com/academy/portal)

---

> [!TIP]
> ### 💻 Low-RAM / 4GB Laptop Mode (Zero Android Emulator Needed!)
> Running a full Android Studio Virtual Device (AVD Emulator) uses 6–8 GB of RAM and will freeze a 4 GB laptop. In this track, you **never** need to run a heavy local Android Emulator:
> 1. **Option A — Flutter Web Target (`<400 MB RAM`):** Run `flutter run -d chrome` or `flutter run -d web-server` inside GitHub Codespaces or locally to render your mobile UI inside Chrome DevTools Mobile Device View (`375x812` iPhone / Pixel viewport).
> 2. **Option B — Physical Android Phone via USB Cable (`0 MB Emulator RAM`):** Plug your personal Android phone into your laptop with **Developer Options -> USB Debugging** enabled, and run directly on your phone hardware.
> 3. **Option C — Automated GitHub Actions Cloud CI:** Every time you push a branch or open a Pull Request, GitHub Actions automatically runs `flutter analyze`, `flutter test`, and verifies your mobile code in the cloud!

---

## Module Breakdown (`152 Notional Hours` — Stage 1)

| Module Code | Module Title | Days | Hours | Focus Areas |
| :--- | :--- | :--- | :--- | :--- |
| **`SD-MB-101`** | **Cross-Platform UI, Adaptive Navigation & Theme Tokens** | Days 01–04 | 36h | Flutter Widget Trees (`StatelessWidget` / `StatefulWidget`) or MAUI XAML, Bottom Navigation, Dark/Light Theme Tokens, Virtualized `ListView.builder` Cards. |
| **`SD-MB-102`** | **REST API Client, Secure Token Storage & Offline Sync** | Days 05–09 | 40h | Typed Dart/C# DTO Serialization, `http`/`dio` Client, `FlutterSecureStorage` JWT persistence, Local SQLite/Hive Cache & Offline Mutation Queue. |
| **`SD-MB-103`** | **Student QR Gate Pass & Field Technician Ticket Triage** | Days 10–14 | 40h | Expiring 6-Digit PIN & QR Visitor Gate Pass Screen, Field Technician Ticket Status Workflow (`PATCH /tickets/{id}/status`), Photo Attachment & SLA Countdown Badges. |
| **`SD-MB-104`** | **Widget Testing, CI Release Packaging & Oral Defense** | Days 15–19 | 36h | Automated `flutter test` Widget Tests, Error Boundary Handling, Accessibility Touch Targets (`48x48dp`), Release Build Verification & Live Oral Defense. |

---

## 19-Day Milestone Schedule (152 Credit Hours)

| Day | Module | Milestone Title | Deliverable Summary |
| :--- | :--- | :--- | :--- |
| **Day 01** | `SD-MB-101` | Mobile Workspace Setup, Adaptive Shell & Bottom Navigation | Fork repo, inspect `mobile/mobile-flutter/`, configure adaptive Dark/Light theme tokens, and build the 4-tab Bottom Navigation shell (`Dashboard`, `Rooms`, `Tickets`, `Gate Pass`). |
| **Day 02** | `SD-MB-101` | Virtualized Room Occupancy Cards (`ListView.builder`) | Build reusable `RoomCard` widgets with occupancy progress bars, status badges, and pull-to-refresh (`RefreshIndicator`). |
| **Day 03** | `SD-MB-101` | Search Bar, Building Filter Chips & Shimmer Skeletons | Add filter chips (`Block A`, `Block B`, `Available Only`) and shimmer skeleton placeholders while loading. |
| **Day 04** | `SD-MB-101` | Student Profile Sheet & Room Assignment Bottom Modal | Build a modal bottom sheet displaying student details and invoking room allocation. |
| **Day 05** | `SD-MB-102` | Typed REST API Service & Error Handling (`SandboxApiClient`) | Connect `SandboxApiClient` to `GET /api/v1/rooms`, `/api/v1/students`, and `/api/v1/tickets` with timeout and RFC 7807 error snackbars. |
| **Day 06** | `SD-MB-102` | Field Technician Maintenance Ticket Feed & Priority Badges | Render maintenance tickets sorted by SLA urgency (`Critical`, `High`, `Medium`, `Low`) with color-coded semantic badges. |
| **Day 07** | `SD-MB-102` | Mobile Ticket Creation Form & Input Validation | Build a mobile-friendly `Form` with `TextFormField` validators to submit new maintenance requests (`POST /api/v1/tickets`). |
| **Day 08** | `SD-MB-102` | Secure JWT Storage (`FlutterSecureStorage`) & Role Switching | Implement login token storage and role toggle between **Student Resident View** and **Field Technician View**. |
| **Day 09** | `SD-MB-102` | Offline-First Local Cache & Pending Sync Queue | Cache rooms/tickets locally so the app renders offline, queueing new ticket submissions until network connectivity returns. |
| **Day 10** | `SD-MB-103` | Field Technician Status Triage (`InProgress` / `Resolved`) | Build the 1-tap technician status update bar calling `PATCH /api/v1/tickets/{id}/status` with optimistic UI updates. |
| **Day 11** | `SD-MB-103` | Student Visitor QR Gate Pass Generator & Curfew Timer | Build the Visitor Pass screen generating a scannable QR code + 6-digit PIN with a live 22:00 SAST curfew countdown timer. |
| **Day 12** | `SD-MB-103` | Security Guard Gate Pass Verification Scanner Screen | Build the Gate Guard verification view to validate 6-digit visitor PIN codes and display pass validity (`ACTIVE` vs `EXPIRED`). |
| **Day 13** | `SD-MB-103` | Student Financial Statement & Mobile Receipt Card | Build the mobile student billing ledger card showing monthly residence rent, NSFAS/bursary credits, and outstanding balance in `ZAR`. |
| **Day 14** | `SD-MB-103` | SLA Breach Alert Banner & Local Notification Trigger | Highlight overdue maintenance tickets (`SlaBreached == true`) with a persistent top alert banner for House Wardens. |
| **Day 15** | `SD-MB-104` | Automated Widget & Unit Testing (`flutter test`) | Write automated widget tests verifying `RoomCard`, `TicketStatusBadge`, and form validation rules. |
| **Day 16** | `SD-MB-104` | Capstone Feature: Emergency SOS & Welfare Check-In Card | Build a 1-tap Student Welfare Check-In & Campus Security Emergency card with confirmation dialog. |
| **Day 17** | `SD-MB-104` | Mobile Ergonomics, `48x48dp` Touch Targets & Accessibility Audit | Audit semantics labels for screen readers (TalkBack/VoiceOver), font scaling, and small-screen (`320px`) overflow protection. |
| **Day 18** | `SD-MB-104` | Release Build Verification & Mobile Architecture Documentation | Verify zero analyzer warnings (`flutter analyze`), run full test suite, and document screenshots in `mobile/mobile-flutter/README.md`. |
| **Day 19** | `SD-MB-104` | Final 30-Minute Live Oral Code Defense & Graduation Sign-Off | Defend widget lifecycle, state management, offline sync architecture, and API integration before your Pod Coordinator & Principal Engineer. |
