import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const redirectIfAuthenticated: CanActivateFn = () => {
  const router = inject(Router);
  const token = sessionStorage.getItem('token');
  if (token) {
    const role = sessionStorage.getItem('role');
    return router.parseUrl(`/dashboard/${role?.toLowerCase()}/home`);
  }
  return true;
};