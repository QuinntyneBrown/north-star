import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ChildProfile, CreateChildRequest } from '../models/child.models';

@Injectable({ providedIn: 'root' })
export class ChildrenService {
  private readonly http = inject(HttpClient);

  list(): Observable<ChildProfile[]> {
    return this.http.get<ChildProfile[]>(`${environment.apiUrl}/children`);
  }

  create(request: CreateChildRequest): Observable<ChildProfile> {
    return this.http.post<ChildProfile>(`${environment.apiUrl}/children`, request);
  }
}
