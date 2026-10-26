// ============================================================================
// Sputnik Devs Academy — Track 06A (SD-MB-101..104): Dart Domain DTO Models
// Mirrors canonical JSON contracts from SputnikDevs.Residence.SandboxApi
// ============================================================================

class RoomDto {
  final int id;
  final String roomNumber;
  final String buildingBlock;
  final int floor;
  final int capacity;
  final int currentOccupancy;
  final double monthlyRentZar;

  const RoomDto({
    required this.id,
    required this.roomNumber,
    required this.buildingBlock,
    required this.floor,
    required this.capacity,
    required this.currentOccupancy,
    required this.monthlyRentZar,
  });

  bool get isAvailable => currentOccupancy < capacity;

  factory RoomDto.fromJson(Map<String, dynamic> json) {
    return RoomDto(
      id: (json['id'] as num?)?.toInt() ?? 0,
      roomNumber: (json['roomNumber'] as String?) ?? '',
      buildingBlock: (json['buildingBlock'] as String?) ?? 'Block A',
      floor: (json['floor'] as num?)?.toInt() ?? 1,
      capacity: (json['capacity'] as num?)?.toInt() ?? 2,
      currentOccupancy: (json['currentOccupancy'] as num?)?.toInt() ?? 0,
      monthlyRentZar: (json['monthlyRentZar'] as num?)?.toDouble() ?? 4500.0,
    );
  }
}

class MaintenanceTicketDto {
  final int id;
  final String title;
  final String description;
  final String category;
  final String priority;
  final String status;
  final int roomId;
  final String roomNumber;
  final String? assignedTechnician;
  final bool isSlaBreached;

  const MaintenanceTicketDto({
    required this.id,
    required this.title,
    required this.description,
    required this.category,
    required this.priority,
    required this.status,
    required this.roomId,
    required this.roomNumber,
    this.assignedTechnician,
    this.isSlaBreached = false,
  });

  factory MaintenanceTicketDto.fromJson(Map<String, dynamic> json) {
    return MaintenanceTicketDto(
      id: (json['id'] as num?)?.toInt() ?? 0,
      title: (json['title'] as String?) ?? '',
      description: (json['description'] as String?) ?? '',
      category: (json['category'] as String?) ?? 'General',
      priority: (json['priority'] as String?) ?? 'Medium',
      status: (json['status'] as String?) ?? 'Open',
      roomId: (json['roomId'] as num?)?.toInt() ?? 0,
      roomNumber: (json['roomNumber'] as String?) ?? '',
      assignedTechnician: json['assignedTechnician'] as String?,
      isSlaBreached: (json['isSlaBreached'] as bool?) ?? false,
    );
  }
}
