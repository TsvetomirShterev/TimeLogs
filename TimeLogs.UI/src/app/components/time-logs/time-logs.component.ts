import { Component, OnInit } from '@angular/core';
import { TimeLogsService } from '../../services/time-logs.service';
import { user } from '../../models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-time-logs',
  templateUrl: './time-logs.component.html',
  styleUrls: ['./time-logs.component.scss']
})
export class TimeLogsComponent implements OnInit {
  public users: user[] = [];

  constructor(private timeLogsService: TimeLogsService, private router: Router) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.timeLogsService.getUsers().subscribe({
      next: (res: any) => {
        if (res) {
          this.users = res;
        }
      },
      error: (err) => {
        console.error('Error fetching users:', err);
      },
      complete: () => {}
    });
  }
}
