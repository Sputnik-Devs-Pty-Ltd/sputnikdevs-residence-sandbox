import { Injectable, inject, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import {
  CreateTicketRequest,
  DashboardSummaryDto,
  MaintenanceTicketDto,
  RoomDto,
  StudentResidentDto,
  TicketStatus
} from '../models/residence.models';

/**
 * Sputnik Devs Academy — Track 02A (SD-FE-102)
 * Centralized Angular HttpClient service connecting to SputnikDevs.Residence.SandboxApi
 */
@Injectable({ providedIn: 'root' })
export class ResidenceApiService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = 'http://localhost:5035/api/v1';

  // Reactive Signals for UI state (SD-FE-101 / SD-FE-102)
  readonly rooms = signal<RoomDto[]>([]);
  readonly tickets = signal<MaintenanceTicketDto[]>([]);
  readonly isLoading = signal<boolean>(false);

  getRooms(floor?: number, availableOnly?: boolean): Observable<RoomDto[]> {
    let params = new HttpParams();
    if (floor !== undefined) params = params.set('floor', floor);
    if (availableOnly !== undefined) params = params.set('availableOnly', availableOnly);

    this.isLoading.set(true);
    return this.http.get<RoomDto[]>(`${this.baseUrl}/rooms`, { params }).pipe(
      tap({
        next: (data) => {
          this.rooms.set(data);
          this.isLoading.set(false);
        },
        error: () => this.isLoading.set(false)
      })
    );
  }

  getStudents(search?: string): Observable<StudentResidentDto[]> {
    let params = new HttpParams();
    if (search?.trim()) params = params.set('search', search.trim());
    return this.http.get<StudentResidentDto[]>(`${this.baseUrl}/students`, { params });
  }

  getTickets(status?: TicketStatus): Observable<MaintenanceTicketDto[]> {
    let params = new HttpParams();
    if (status) params = params.set('status', status);
    return this.http.get<MaintenanceTicketDto[]>(`${this.baseUrl}/tickets`, { params }).pipe(
      tap((data) => this.tickets.set(data))
    );
  }

  createTicket(payload: CreateTicketRequest): Observable<MaintenanceTicketDto> {
    return this.http.post<MaintenanceTicketDto>(`${this.baseUrl}/tickets`, payload);
  }

  updateTicketStatus(ticketId: number, status: TicketStatus): Observable<MaintenanceTicketDto> {
    return this.http.patch<MaintenanceTicketDto>(`${this.baseUrl}/tickets/${ticketId}/status`, { status });
  }

  getDashboardSummary(): Observable<DashboardSummaryDto> {
    return this.http.get<DashboardSummaryDto>(`${this.baseUrl}/dashboard/summary`);
  }
}
