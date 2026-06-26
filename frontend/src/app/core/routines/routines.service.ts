import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { RoutineCompletion, TodayPlan } from '../models/today.models';

@Injectable({ providedIn: 'root' })
export class RoutinesService {
  private readonly http = inject(HttpClient);

  getToday(childId: string): Observable<TodayPlan> {
    return this.http.get<TodayPlan>(`${environment.apiUrl}/children/${childId}/today`);
  }

  complete(routineId: string): Observable<RoutineCompletion> {
    return this.http.post<RoutineCompletion>(`${environment.apiUrl}/routines/${routineId}/complete`, {});
  }
}
