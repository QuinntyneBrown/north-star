import { computed, inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AuthResponse, ChildLoginRequest, CurrentUser, LoginRequest, RegisterRequest } from '../models/auth.models';
import { TokenStorageService } from './token-storage.service';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly http = inject(HttpClient);
  private readonly storage = inject(TokenStorageService);
  private readonly router = inject(Router);

  private readonly _user = signal<CurrentUser | null>(this.storage.getUser());
  readonly user = this._user.asReadonly();
  readonly isAuthenticated = computed(() => this._user() !== null);

  login(request: LoginRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${environment.apiUrl}/auth/login`, request)
      .pipe(tap((response) => this.applySession(response)));
  }

  register(request: RegisterRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${environment.apiUrl}/auth/register`, request)
      .pipe(tap((response) => this.applySession(response)));
  }

  childLogin(request: ChildLoginRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${environment.apiUrl}/auth/child-login`, request)
      .pipe(tap((response) => this.applySession(response)));
  }

  logout(): void {
    this.storage.clear();
    this._user.set(null);
    void this.router.navigateByUrl('/login');
  }

  private applySession(response: AuthResponse): void {
    const user: CurrentUser = {
      email: response.email,
      displayName: response.displayName,
      role: response.role,
      familyId: response.familyId,
      childId: response.childId ?? null,
    };
    this.storage.setSession(response.accessToken, user);
    this._user.set(user);
  }
}
