import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/data/models/api-response/apiResponse';
import { EmptyResponse } from 'src/app/data/models/api-response/emptyResponse';
import { ICreateGenre } from 'src/app/data/models/genre/createGenre';
import { IGenre } from 'src/app/data/models/genre/genre';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class GenreService {
  private baseUrl = `${environment.apiBaseUrl}/genre`;

  constructor(private http: HttpClient) { }

  public getAllGenres(): Observable<{ success: boolean; message: string; data: IGenre[] }> {
    return this.http.get<{ success: boolean; message: string; data: IGenre[] }>(`${this.baseUrl}/all`);
  }

  public getGenreById(id: number): Observable<IGenre> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.get<IGenre>(`${this.baseUrl}/get-by-id`, { params });
  }

  public createGenre(payload: ICreateGenre): Observable<ApiResponse<number>> {
    return this.http.post<ApiResponse<number>>(`${this.baseUrl}/create`, payload);
  }

  public updateGenre(payload: IGenre): Observable<ApiResponse<number>> {
    return this.http.put<ApiResponse<number>>(`${this.baseUrl}/update`, payload);
  }

  public deleteGenre(id: number): Observable<EmptyResponse> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.delete<EmptyResponse>(`${this.baseUrl}/delete`, { params });
  }
}