import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ApiResponse } from 'src/app/data/models/api-response/apiResponse';
import { EmptyResponse } from 'src/app/data/models/api-response/emptyResponse';
import { IBook } from 'src/app/data/models/book/book';
import { IPatchOperation } from 'src/app/data/models/patchOperation';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class BookService {
  private baseUrl = `${environment.apiBaseUrl}/books`;

  constructor(private http: HttpClient) { }

  public addBook(book: IBook): Observable<ApiResponse<IBook>> {
    return this.http.post<ApiResponse<IBook>>(`${this.baseUrl}`, book);
  }

  public getAllBooks(): Observable<IBook[]> {
    return this.http.get<{ data: IBook[] }>(`${this.baseUrl}`).pipe(
      map(response => response.data)
    );
  }

  public getBookById(id: number): Observable<IBook> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.get<IBook>(`${this.baseUrl}/get-by-id`, { params });
  }

  public getBookByPage(bookPerPage: number, pageNo: number): Observable<ApiResponse<IBook[]>> {
    const params = new HttpParams({
      fromObject: {
        bookPerPage: bookPerPage.toString(),
        pageNo: pageNo.toString()
      }
    });
    return this.http.get<ApiResponse<IBook[]>>(`${this.baseUrl}/book-page`, { params });
  }

  public deleteBook(id: number): Observable<EmptyResponse> {
    if (!id || isNaN(id)) {
      throw new Error('Invalid book ID');
    }
    const params = new HttpParams().set('id', id);
    return this.http.delete(`${this.baseUrl}`, { params });
  }

  public patchBook(id: number, patchDoc: IPatchOperation[]): Observable<EmptyResponse> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.patch<EmptyResponse>(`${this.baseUrl}`, patchDoc, { params });
  }

  public updateBook(id: number, book: IBook): Observable<EmptyResponse> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.put<EmptyResponse>(`${this.baseUrl}`, book, { params });
  }
}
