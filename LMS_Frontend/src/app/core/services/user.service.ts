import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/data/models/api-response/apiResponse';
import { EmptyResponse } from 'src/app/data/models/api-response/emptyResponse';
import { IPatchOperation } from 'src/app/data/models/patchOperation';
import { IUser } from 'src/app/data/models/user/user';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  private baseUrl = `${environment.apiBaseUrl}/users`;

  constructor(private http: HttpClient) { }

  public addUser(user: IUser): Observable<ApiResponse<number>> {
    return this.http.post<ApiResponse<number>>(`${this.baseUrl}`, user);
  }

  public getAllUsers(): Observable<ApiResponse<IUser>> {
    return this.http.get<ApiResponse<IUser>>(`${this.baseUrl}`);
  }

  public getUserById(id: number): Observable<ApiResponse<IUser>> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.get<ApiResponse<IUser>>(`${this.baseUrl}/get-by-id`, { params });
  }

  public getUsersByRole(role: string): Observable<ApiResponse<IUser>> {
    const params = new HttpParams().set('role', role);
    return this.http.get<ApiResponse<IUser>>(`${this.baseUrl}/get-by-role`, { params });
  }

  public updateUser(id: number | undefined, user: IUser): Observable<EmptyResponse> {
    if (id === undefined) {
      throw new Error('User ID is required to update user.');
    }

    const params = new HttpParams().set('id', id.toString());
    return this.http.put<EmptyResponse>(`${this.baseUrl}`, user, { params });
  }

  public patchUser(id: number, patchDoc: IPatchOperation[]): Observable<EmptyResponse> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.patch<EmptyResponse>(`${this.baseUrl}`, patchDoc, { params },
    );
  }

  public deleteUser(id: number): Observable<EmptyResponse> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.delete<EmptyResponse>(`${this.baseUrl}`, { params });
  }
}