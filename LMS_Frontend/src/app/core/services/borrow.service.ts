import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmptyResponse } from 'src/app/data/models/api-response/emptyResponse';
import { IPatchOperation } from 'src/app/data/models/patchOperation';
import { IBorrowRequest } from 'src/app/data/models/transaction/borrowRequest';
import { IBorrowResponse } from 'src/app/data/models/transaction/borrowResponse';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class BorrowService {
  private baseUrl = `${environment.apiBaseUrl}/transactions`;

  constructor(private http: HttpClient) { }

  public getAllBorrowRequests(): Observable<IBorrowResponse[]> {
    return this.http.get<IBorrowResponse[]>(`${this.baseUrl}/borrow-requests`);
  }

  public getBorrowRequestByUserId(id: number): Observable<IBorrowResponse[]> {
    return this.http.get<IBorrowResponse[]>(`${this.baseUrl}/borrow-requests-by-userId?id=${id}`);
  }

  public getBorrowRequestById(id: number): Observable<IBorrowResponse> {
    return this.http.get<IBorrowResponse>(`${this.baseUrl}/borrow-requests-by-id?id=${id}`);
  }

  public addBorrowRequest(request: IBorrowRequest): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.baseUrl}/borrow-requests`, request);
  }

  public patchBorrowRequest(id: number, patchDoc: IPatchOperation[]): Observable<EmptyResponse> {
    const params = new HttpParams().set('id', id);
    return this.http.patch<EmptyResponse>(`${this.baseUrl}/borrow-requests`, patchDoc, { params });
  }

  public deleteBorrowRequest(id: number): Observable<EmptyResponse> {
    return this.http.delete<EmptyResponse>(`${this.baseUrl}/borrow-requests?id=${id}`);
  }
}