import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TimeLogsService {
  private apiUrl = environment.baseUrl;


  constructor(private http: HttpClient) {

  }

  getUsers(): Observable<any[]> {
    return this.http.get<any[]>('${apiUrl}/Users');
  }
}
