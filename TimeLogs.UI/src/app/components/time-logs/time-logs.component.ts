import { Component, OnInit } from '@angular/core';
import { TimeLogsService } from '../../services/time-logs.service';
import { user } from '../../models/user';

@Component({
  selector: 'app-time-logs',
  templateUrl: './time-logs.component.html',
  styleUrls: ['./time-logs.component.scss']
})
export class TimeLogsComponent implements OnInit {
  public users: user[] = [];
  public currentPage: number = 1;
  public itemsPerPage: number = 10;
  public usersCount: number = 0;
  public fromDate: string = '';
  public toDate: string = '';
  public sortedByDate: boolean = false;

  constructor(private timeLogsService: TimeLogsService) { }

  ngOnInit(): void {
    this.updatePage();
  }

  getUsers() {
    let queryParams = `?page=${this.currentPage}&itemsPerPage=${this.itemsPerPage}`;

    if (this.fromDate && this.toDate) {
      queryParams += `&fromDate=${this.fromDate}&toDate=${this.toDate}`;
    }

    this.timeLogsService
      .getUsers(queryParams)
      .subscribe({
        next: (res: any) => {
          if (res) {
            this.users = res;
          }
        },
        error: (err) => {
          console.error('Error fetching users:', err);
        }
      });
  }

  getUsersCount() {
    let queryParams = `?fromDate=${this.fromDate}&toDate=${this.toDate}`;

    this.timeLogsService
      .getUsersCount(queryParams)
      .subscribe({
        next: (res: any) => {
          if (res) {
            this.usersCount = res;
            console.log(`this is how many we have: ${this.usersCount}`);
          }
        },
        error: (err) => {
          console.error('Error fetching users:', err);
        },
        complete: () => { }
      });
  }

  public updatePage() {
    this.getUsers();
    this.getUsersCount();
  }
}
