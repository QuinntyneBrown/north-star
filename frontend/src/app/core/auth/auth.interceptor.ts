import { inject } from '@angular/core';
import { HttpInterceptorFn } from '@angular/common/http';
import { TokenStorageService } from './token-storage.service';

/** Attaches the bearer token to outgoing API requests. */
export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = inject(TokenStorageService).getToken();
  if (token) {
    req = req.clone({ setHeaders: { Authorization: `Bearer ${token}` } });
  }
  return next(req);
};
