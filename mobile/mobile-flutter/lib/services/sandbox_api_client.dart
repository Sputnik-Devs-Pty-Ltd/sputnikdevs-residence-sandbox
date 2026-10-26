import 'dart:convert';
import 'package:http/http.dart' as http;
import '../models/residence_models.dart';

/// Sputnik Devs Academy — Track 06A (SD-MB-102)
/// Typed Dart HTTP client connecting to SputnikDevs.Residence.SandboxApi
class SandboxApiClient {
  final String baseUrl;
  final http.Client _httpClient;

  SandboxApiClient({
    this.baseUrl = 'http://localhost:5035/api/v1',
    http.Client? httpClient,
  }) : _httpClient = httpClient ?? http.Client();

  Future<List<RoomDto>> fetchRooms({bool? availableOnly}) async {
    final uri = Uri.parse('$baseUrl/rooms').replace(
      queryParameters: availableOnly != null
          ? {'availableOnly': availableOnly.toString()}
          : null,
    );
    final response = await _httpClient.get(uri);
    if (response.statusCode != 200) {
      throw Exception('Failed to load rooms (HTTP ${response.statusCode})');
    }
    final List<dynamic> list = jsonDecode(response.body) as List<dynamic>;
    return list
        .map((item) => RoomDto.fromJson(item as Map<String, dynamic>))
        .toList();
  }

  Future<List<MaintenanceTicketDto>> fetchTickets({String? status}) async {
    final uri = Uri.parse('$baseUrl/tickets').replace(
      queryParameters: status != null ? {'status': status} : null,
    );
    final response = await _httpClient.get(uri);
    if (response.statusCode != 200) {
      throw Exception('Failed to load tickets (HTTP ${response.statusCode})');
    }
    final List<dynamic> list = jsonDecode(response.body) as List<dynamic>;
    return list
        .map((item) => MaintenanceTicketDto.fromJson(item as Map<String, dynamic>))
        .toList();
  }

  Future<void> updateTicketStatus(int ticketId, String newStatus) async {
    final uri = Uri.parse('$baseUrl/tickets/$ticketId/status');
    final response = await _httpClient.patch(
      uri,
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({'status': newStatus}),
    );
    if (response.statusCode < 200 || response.statusCode >= 300) {
      throw Exception('Failed to update ticket status (HTTP ${response.statusCode})');
    }
  }
}
