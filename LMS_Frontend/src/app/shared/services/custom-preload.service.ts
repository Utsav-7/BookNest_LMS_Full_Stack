import { Injectable } from '@angular/core';
import { PreloadingStrategy } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CustomPreloadService implements PreloadingStrategy {
  public preload(route: any, load: () => Observable<any>): Observable<any> {
    return route.data && route.data.preload ? load() : of(null);
  }
}