import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IStudentDashboardStats } from 'src/app/data/models/dashboard/studentDashboardStats';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class StudentDashboardStatService {
  private baseUrl = `${environment.apiBaseUrl}/dashboard`;

  constructor(private http: HttpClient) { }

  public getDashboardStat(): Observable<IStudentDashboardStats> {
    return this.http.get<IStudentDashboardStats>(`${this.baseUrl}/student-stats`);
  }
}