// ============================================================================
// Sputnik Devs Academy — Track 02A (SD-FE-101..104): Angular TypeScript Models
// Mirrors canonical DTO contracts from SputnikDevs.Residence.SandboxApi
// ============================================================================

export type TicketPriority = 'Low' | 'Medium' | 'High' | 'Critical';
export type TicketStatus = 'Open' | 'InProgress' | 'Resolved' | 'Closed';

export interface RoomDto {
  id: number;
  roomNumber: string;
  buildingBlock: string;
  floor: number;
  capacity: number;
  currentOccupancy: number;
  monthlyRentZar: number;
  isAvailable: boolean;
}

export interface StudentResidentDto {
  id: number;
  studentNumber: string;
  fullName: string;
  email: string;
  fundingType: 'NSFAS' | 'Bursary' | 'Private';
  roomId: number | null;
  roomNumber: string | null;
  enrolledAtUtc: string;
}

export interface MaintenanceTicketDto {
  id: number;
  title: string;
  description: string;
  category: string;
  priority: TicketPriority;
  status: TicketStatus;
  roomId: number;
  roomNumber: string;
  reportedByStudentId: number;
  assignedTechnician: string | null;
  createdAtUtc: string;
  slaDueAtUtc: string;
  isSlaBreached: boolean;
}

export interface CreateTicketRequest {
  title: string;
  description: string;
  category: string;
  priority: TicketPriority;
  roomId: number;
  reportedByStudentId: number;
}

export interface DashboardSummaryDto {
  totalRooms: number;
  totalCapacity: number;
  totalOccupiedBeds: number;
  occupancyPercentage: number;
  openTicketsCount: number;
  slaBreachedCount: number;
}
