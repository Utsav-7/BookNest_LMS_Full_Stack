import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmptyResponse } from 'src/app/data/models/api-response/emptyResponse';
import { ISystemConfig } from 'src/app/data/models/setting';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class SystemConfigService {
  private baseUrl = `${environment.apiBaseUrl}/config`;

  constructor(private http: HttpClient) { }

  public getAllConfigs(): Observable<ISystemConfig[]> {
    return this.http.get<ISystemConfig[]>(`${this.baseUrl}`);
  }

  public updateConfigs(configs: ISystemConfig[]): Observable<EmptyResponse> {
    return this.http.patch<EmptyResponse>(`${this.baseUrl}`, configs);
  }

  public getConfigByKey(key: string): Observable<{ success: boolean, key: string, value: string }> {
    return this.http.get<{ success: boolean, key: string, value: string }>(
      `${this.baseUrl}/key?key=${key}`
    );
  }
}
