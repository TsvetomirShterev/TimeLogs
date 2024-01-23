import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { user } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class TimeLogsService {
  private apiUrl = environment.baseUrl;

  constructor(private httpClient: HttpClient) {}

  getUsers(queryParams: string): Observable<user[]> {
    return this.httpClient.get<user[]>(`${this.apiUrl}/Users${queryParams}`);
  }
}
