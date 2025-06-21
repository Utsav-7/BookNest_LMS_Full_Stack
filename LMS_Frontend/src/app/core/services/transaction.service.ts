import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITransactionHistory } from 'src/app/data/models/transaction/transactionHistory';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class TransactionService {
  private baseUrl = `${environment.apiBaseUrl}/transactions`;

  constructor(private http: HttpClient) { }

  public getAllTransaction(): Observable<ITransactionHistory[]> {
    return this.http.get<ITransactionHistory[]>(`${this.baseUrl}/get-all`);
  }

  public getTransactionByUserId(userId: number): Observable<ITransactionHistory[]> {
    return this.http.get<ITransactionHistory[]>(`${this.baseUrl}/get-by-userId?id=${userId}`);
  }
}
