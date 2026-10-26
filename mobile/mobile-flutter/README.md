# Track 06A: Flutter & Dart Mobile Companion App (`mobile/mobile-flutter/`)

Welcome to **Track 06A (`SD-MB-101..104`) — Flutter & Dart Cross-Platform Mobile Engineering** for the **Sputnik Devs Residence Sandbox**.

## What You Will Build
You are building the **Varsnik / Resnik Student & Field Technician Mobile Companion App**, featuring:
1. **`SD-MB-101`:** Adaptive 4-Tab Mobile Shell (`Dashboard`, `Rooms`, `Tickets`, `QR Gate Pass`) with Dark/Light theme tokens and virtualized `ListView.builder` cards.
2. **`SD-MB-102`:** Typed Dart REST API Client (`SandboxApiClient`), `FlutterSecureStorage` JWT auth, and Offline-First SQLite/Hive queue sync.
3. **`SD-MB-103`:** Student Visitor QR Gate Pass Generator (with 22:00 SAST curfew countdown) & Field Technician 1-Tap Ticket Status Triage (`PATCH /api/v1/tickets/{id}/status`).
4. **`SD-MB-104`:** Automated `flutter test` Widget Tests, `48x48dp` ergonomics audit, and Release Build verification.

## Quick Start (Zero Android Emulator Needed!)
1. Start the `.NET 10` Sandbox API in Terminal 1:
   ```bash
   dotnet run --project ../../SputnikDevs.Residence.SandboxApi
   ```
2. Run the Flutter companion app in Terminal 2 (Chrome Mobile Viewport or Physical USB Device):
   ```bash
   cd mobile/mobile-flutter
   flutter pub get
   flutter run -d chrome --web-port 8080
   ```
3. Run static analysis and widget tests before opening your Pull Request:
   ```bash
   flutter analyze
   flutter test
   ```
