import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDashboardStat } from 'src/app/data/models/dashboard/dashboardStat';
import { IUser } from 'src/app/data/models/user/user';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class DashboardService {
  private baseUrl = `${environment.apiBaseUrl}/dashboard`;

  constructor(private http: HttpClient) { }

  public getProfile(): Observable<IUser> {
    return this.http.get<IUser>(`${this.baseUrl}/profile`);
  }

  public getDashboardStat(): Observable<IDashboardStat> {
    return this.http.get<IDashboardStat>(`${this.baseUrl}/stats`);
  }
}