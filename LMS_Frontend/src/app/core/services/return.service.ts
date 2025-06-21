import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmptyResponse } from 'src/app/data/models/api-response/emptyResponse';
import { IPatchOperation } from 'src/app/data/models/patchOperation';
import { IReturnRequest } from 'src/app/data/models/transaction/returnRequest';
import { IReturnResponse } from 'src/app/data/models/transaction/returnResponse';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class ReturnService {
  private baseUrl = `${environment.apiBaseUrl}/transactions`;

  constructor(private http: HttpClient) { }

  public getAllReturnRequests(): Observable<IReturnResponse[]> {
    return this.http.get<IReturnResponse[]>(`${this.baseUrl}/return-requests`);
  }

  public getReturnRequestById(id: number): Observable<IReturnResponse> {
    return this.http.get<IReturnResponse>(`${this.baseUrl}/return-requests-by-id?id=${id}`);
  }

  public getReturnRequestByUserId(id: number): Observable<IReturnResponse> {
    return this.http.get<IReturnResponse>(`${this.baseUrl}/borrow-requests?id=${id}`);
  }

  public addReturnRequest(request: IReturnRequest): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.baseUrl}/return-requests`, request);
  }

  public patchReturnRequest(id: number, patchDoc: IPatchOperation[]): Observable<EmptyResponse> {
    const params = new HttpParams().set('id', id);
    return this.http.patch<EmptyResponse>(`${this.baseUrl}/return-requests`, patchDoc, { params });
  }

  public deleteReturnRequest(id: number): Observable<EmptyResponse> {
    return this.http.delete<EmptyResponse>(`${this.baseUrl}/return-requests?id=${id}`);
  }
}