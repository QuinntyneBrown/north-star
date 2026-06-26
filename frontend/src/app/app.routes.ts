import { Routes } from '@angular/router';
import { authGuard } from './core/auth/auth.guard';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
  {
    path: 'login',
    loadComponent: () =>
      import('./features/auth/login/login.component').then((m) => m.LoginComponent),
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./features/auth/register/register.component').then((m) => m.RegisterComponent),
  },
  {
    path: 'child-login',
    loadComponent: () =>
      import('./features/auth/child-login/child-login.component').then((m) => m.ChildLoginComponent),
  },
  {
    path: 'dashboard',
    canActivate: [authGuard],
    loadComponent: () =>
      import('./features/dashboard/parent-dashboard/parent-dashboard.component').then(
        (m) => m.ParentDashboardComponent,
      ),
  },
  {
    path: 'children/:childId/today',
    canActivate: [authGuard],
    loadComponent: () => import('./features/today/today.component').then((m) => m.TodayComponent),
  },
  { path: '**', redirectTo: 'dashboard' },
];
