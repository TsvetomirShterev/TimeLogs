import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { user } from '../models/user';
import { timeLog } from '../models/timeLog';

@Injectable({
  providedIn: 'root'
})
export class TimeLogsService {
  private apiUrl = environment.baseUrl;

  constructor(private httpClient: HttpClient) { }

  getTimeLogs(): Observable<timeLog[]> {
    return this.httpClient.get<timeLog[]>(`${this.apiUrl}/TimeLogs`);
  }

  getTimeLogsCount() {
    return this.httpClient.get<number>(`${this.apiUrl}/TimeLogs/Count`);
  }
}
