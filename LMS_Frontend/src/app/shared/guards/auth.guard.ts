import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { TokenService } from '../services/token.service';

export const authGuard: CanActivateFn = (route, state) => {
  const tokenService = inject(TokenService);
  const router = inject(Router);
  const messageService = inject(MessageService);

  const token = tokenService.getValidToken();

  if (!token) {
    messageService.add({
      severity: 'warn',
      summary: 'Unauthorized',
      detail: 'Please login to access this page',
      life: 3000
    });
    tokenService.clearAuthData();
    return router.parseUrl('/auth/login');
  }

  const decoded = tokenService.decodeToken(token);
  const currentRole = decoded ? tokenService.extractRole(decoded) : null;
  const allowedRoles = route.data?.['roles'] as string[];

  if (allowedRoles && currentRole && !allowedRoles.includes(currentRole)) {
    messageService.add({
      severity: 'error',
      summary: 'Access Denied',
      detail: 'You do not have permission to view this page',
      life: 3000
    });
    return router.parseUrl('/auth/login');
  }

  return true;
};