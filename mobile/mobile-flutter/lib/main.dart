import 'package:flutter/material.dart';

void main() {
  runApp(const SputnikResidenceCompanionApp());
}

/// Sputnik Devs Academy — Track 06A (SD-MB-101)
/// Root Flutter Shell for the Student Residence & Field Technician Companion App
class SputnikResidenceCompanionApp extends StatelessWidget {
  const SputnikResidenceCompanionApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Sputnik Residence Mobile',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
          seedColor: const Color(0xFF6366F1),
          brightness: Brightness.dark,
        ),
        useMaterial3: true,
      ),
      home: const ResidenceHomeShell(),
    );
  }
}

class ResidenceHomeShell extends StatefulWidget {
  const ResidenceHomeShell({super.key});

  @override
  State<ResidenceHomeShell> createState() => _ResidenceHomeShellState();
}

class _ResidenceHomeShellState extends State<ResidenceHomeShell> {
  int _selectedIndex = 0;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Sputnik Residence • WIL Sandbox'),
      ),
      body: IndexedStack(
        index: _selectedIndex,
        children: const [
          Center(child: Text('Tab 1: Residence KPI Overview (SD-MB-101)')),
          Center(child: Text('Tab 2: Room Occupancy Matrix (SD-MB-101)')),
          Center(child: Text('Tab 3: Field Technician Tickets (SD-MB-102)')),
          Center(child: Text('Tab 4: Student QR Gate Pass (SD-MB-103)')),
        ],
      ),
      bottomNavigationBar: NavigationBar(
        selectedIndex: _selectedIndex,
        onDestinationSelected: (idx) => setState(() => _selectedIndex = idx),
        destinations: const [
          NavigationDestination(icon: Icon(Icons.dashboard_outlined), label: 'Overview'),
          NavigationDestination(icon: Icon(Icons.meeting_room_outlined), label: 'Rooms'),
          NavigationDestination(icon: Icon(Icons.build_circle_outlined), label: 'Tickets'),
          NavigationDestination(icon: Icon(Icons.qr_code_2_outlined), label: 'Gate Pass'),
        ],
      ),
    );
  }
}
