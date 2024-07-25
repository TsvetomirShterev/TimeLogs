import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { timeLog } from '../models/timeLog';

@Injectable({
  providedIn: 'root'
})
export class TopStatisticsService {
  private apiUrl = environment.baseUrl;

  constructor(private httpClient: HttpClient) { }

  getTopTimeLogs(): Observable<timeLog[]> {
    return this.httpClient.get<timeLog[]>(`${this.apiUrl}/TimeLogs/Top}`);
  }
}
