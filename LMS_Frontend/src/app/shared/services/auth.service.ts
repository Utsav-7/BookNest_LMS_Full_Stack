import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmptyResponse } from 'src/app/data/models/api-response/emptyResponse';
import { IForgotPwd } from 'src/app/data/models/authentication/forgotPwd';
import { ILogin } from 'src/app/data/models/authentication/Login';
import { ILoginResponse } from 'src/app/data/models/authentication/loginResponse';
import { IRegister } from 'src/app/data/models/authentication/register';
import { IResetPwd } from 'src/app/data/models/authentication/resetPwd';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private baseUrl = `${environment.apiBaseUrl}/auth`;

  constructor(private http: HttpClient) { }

  public register(user: IRegister): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.baseUrl}/register`, user);
  }

  public login(loginData: ILogin): Observable<ILoginResponse> {
    return this.http.post<ILoginResponse>(`${this.baseUrl}/login`, loginData);
  }

  public forgotPassword(forgotPwdData: IForgotPwd): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.baseUrl}/send-otp`, forgotPwdData);
  }

  public resetPassword(resetPwdData: IResetPwd): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.baseUrl}/ResetPassword`, resetPwdData);
  }
}