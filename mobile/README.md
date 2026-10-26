# Track 06 Workspace: Mobile & Cross-Platform Engineering (`mobile/`)

Welcome to the **Track 06 (`SD-MB-101..104`: Mobile & Cross-Platform Engineering)** workspace inside the unified **Sputnik Devs Residence Sandbox** polyglot monorepo.

Students enrolled in Track 06 build the **Student Residence & Field Technician Mobile Companion App** consuming the `.NET 10` Residence Sandbox API (`http://localhost:5035/api/v1/...`):

| Sub-Track | Folder | Primary Tech Stack |
| :--- | :--- | :--- |
| **Track 06A: Flutter & Dart Mobile App** | [`mobile/mobile-flutter/`](mobile-flutter/README.md) | **Flutter 3.x & Dart 3**, Adaptive Material 3 UI, `http`/`dio` REST Client, `FlutterSecureStorage`, Offline Queue Sync & `flutter test` |
| **Track 06B: .NET MAUI Cross-Platform App** | [`mobile/mobile-maui/`](mobile-maui/README.md) | **.NET 10 MAUI (C# / XAML)**, MVVM (`CommunityToolkit.Mvvm`), `HttpClient`, `SecureStorage`, SQLite Local Sync |

---

## 💻 Low-RAM / 4GB Laptop Compatibility
You do **not** need a heavy 8GB+ Android Studio Emulator to complete Track 06:
* **Flutter Web / Mobile Viewport Mode:** Run `flutter run -d chrome` or `flutter run -d web-server` (`<400MB` RAM) and inspect in Chrome DevTools Mobile Viewport (`375x812`).
* **Physical Phone over USB:** Plug in any Android device with **USB Debugging** enabled so the app runs on your phone's CPU/RAM.
* **Cloud CI Verification:** Every Pull Request is automatically analyzed and tested in GitHub Actions!

👉 Full 19-Day Mobile Syllabus: **[`../docs/tracks/TRACK_06_MOBILE_FLUTTER_MAUI.md`](../docs/tracks/TRACK_06_MOBILE_FLUTTER_MAUI.md)**
