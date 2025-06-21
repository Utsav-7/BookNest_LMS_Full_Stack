import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { jwtDecode, JwtPayload } from 'jwt-decode';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ILoginResponse } from 'src/app/data/models/authentication/loginResponse';

interface CustomJwtPayload extends JwtPayload {
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'?: string;
  role?: string;
  userId?: string;
  email?: string;
}

@Injectable({
  providedIn: 'root'
})

export class TokenService {
  private jwtHelper = new JwtHelperService();

  constructor(private router: Router, private messageService: MessageService) { }

  public processLoginResponse(loginResponse: ILoginResponse): boolean {
    if (!loginResponse?.data?.token) {
      this.messageService.add({
        severity: 'error',
        summary: 'Login Failed',
        detail: 'Invalid login response',
        life: 3000
      });
      return false;
    }

    const token = loginResponse.data.token;
    const decoded = this.decodeToken(token);

    if (!decoded || !this.isTokenValid(token)) {
      this.messageService.add({
        severity: 'error',
        summary: 'Login Failed',
        detail: 'Invalid or expired token',
        life: 3000
      });
      return false;
    }

    this.setToken(token);
    this.storeUserData(loginResponse.data.user);

    const role = this.extractRole(decoded);
    if (role) {
      this.redirectToDashboard(role);
    }

    return true;
  }

  public setToken(token: string): void {
    sessionStorage.setItem('token', token);
    const decoded = this.decodeToken(token);
    if (decoded) {
      const role = this.extractRole(decoded);
      if (role) {
        sessionStorage.setItem('role', role);
      }
      if (decoded.userId) {
        sessionStorage.setItem('userId', decoded.userId);
      }
    }
  }

  private storeUserData(user: ILoginResponse['data']['user']): void {
    sessionStorage.setItem('userId', user.id);
    sessionStorage.setItem('email', user.email);
    sessionStorage.setItem('firstName', user.firstName);
    sessionStorage.setItem('lastName', user.lastName);
    if (user.profileImageUrl) {
      sessionStorage.setItem('profileImageUrl', user.profileImageUrl);
    }
  }

  public getRole(): string | null {
    const storedRole = sessionStorage.getItem('role');
    if (storedRole) return storedRole;

    const token = this.getValidToken();
    if (!token) return null;

    const decoded = this.decodeToken(token);
    return decoded ? this.extractRole(decoded) : null;
  }

  public getUserId(): string | null {
    const storedUserId = sessionStorage.getItem('userId');
    if (storedUserId) return storedUserId;

    const token = this.getValidToken();
    if (!token) return null;

    const decoded = this.decodeToken(token);
    return decoded?.userId || null;
  }

  private redirectToDashboard(role: string): void {
    switch (role.toLowerCase()) {
      case 'administrator':
        this.router.navigate(['/dashboard/administrator/home']);
        break;
      case 'librarian':
        this.router.navigate(['/dashboard/librarian/home']);
        break;
      case 'student':
        this.router.navigate(['/dashboard/student/home']);
        break;
      default:
        this.router.navigate(['/auth/login']);
        break;
    }
  }

  public decodeToken(token: string): CustomJwtPayload | null {
    try {
      return jwtDecode<CustomJwtPayload>(token);
    } catch (error) {
      console.error('Error decoding token:', error);
      return null;
    }
  }

  public isTokenValid(token: string): boolean {
    if (!token) return false;

    try {
      return !this.jwtHelper.isTokenExpired(token);
    } catch (error) {
      console.error('Token validation error:', error);
      return false;
    }
  }

  public getValidToken(): string | null {
    const token = sessionStorage.getItem('token');
    return token && this.isTokenValid(token) ? token : null;
  }

  public extractRole(decoded: CustomJwtPayload): string | null {
    if (decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']) {
      return this.normalizeRole(decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
    }
    if (decoded.role) {
      return this.normalizeRole(decoded.role);
    }
    return null;
  }

  private normalizeRole(role: string): string {
    return role.toLocaleLowerCase();
  }

  public clearAuthData(): void {
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('role');
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('firstName');
    sessionStorage.removeItem('lastName');
    sessionStorage.removeItem('profileImageUrl');
  }
}