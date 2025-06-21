import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/data/models/api-response/apiResponse';
import { IWishlistResponse } from 'src/app/data/models/wishlist-notification/wishlistResponse';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class WishlistAndNotificationService {
  private baseUrl = `${environment.apiBaseUrl}/wishlist`;

  constructor(private http: HttpClient) { }

  public getWishList(): Observable<ApiResponse<IWishlistResponse[]>> {
    return this.http.get<ApiResponse<IWishlistResponse[]>>(`${this.baseUrl}/my-list`);
  }

  public addToWishList(bookId: number): Observable<ApiResponse<boolean>> {
    return this.http.post<ApiResponse<boolean>>(`${this.baseUrl}/add-to-wishlist?bookid=${bookId}`, {});
  }

  public removeFromWishList(wishlistId: number): Observable<ApiResponse<boolean>> {
    return this.http.post<ApiResponse<boolean>>(`${this.baseUrl}/remove?wishlistId=${wishlistId}`, {});
  }
}