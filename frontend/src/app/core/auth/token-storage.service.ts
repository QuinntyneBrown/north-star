import { Injectable } from '@angular/core';
import { CurrentUser } from '../models/auth.models';

/** Persists the access token and current user across reloads. */
@Injectable({ providedIn: 'root' })
export class TokenStorageService {
  private readonly tokenKey = 'ns.token';
  private readonly userKey = 'ns.user';

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  getUser(): CurrentUser | null {
    const raw = localStorage.getItem(this.userKey);
    return raw ? (JSON.parse(raw) as CurrentUser) : null;
  }

  setSession(token: string, user: CurrentUser): void {
    localStorage.setItem(this.tokenKey, token);
    localStorage.setItem(this.userKey, JSON.stringify(user));
  }

  clear(): void {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.userKey);
  }
}
