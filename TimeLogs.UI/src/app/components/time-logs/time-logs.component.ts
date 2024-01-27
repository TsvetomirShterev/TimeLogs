import { Component, OnInit } from '@angular/core';
import { TimeLogsService } from '../../services/time-logs.service';
import { user } from '../../models/user';
import { timeLog } from '../../models/timeLog';

@Component({
  selector: 'app-time-logs',
  templateUrl: './time-logs.component.html',
  styleUrls: ['./time-logs.component.scss']
})
export class TimeLogsComponent implements OnInit {
  public timeLogs: timeLog[] = [];
  public timeLogsCount: number = 0;
  public users: user[] = [];
  public currentPage: number = 1;
  public itemsPerPage: number = 10;
  public usersCount: number = 0;
  public fromDate: string = '';
  public toDate: string = '';

  constructor(private timeLogsService: TimeLogsService) { }

  ngOnInit(): void {
    this.updatePage();
  }

  getTimeLogs() {
    let queryParams = `?page=${this.currentPage}&itemsPerPage=${this.itemsPerPage}`;

    if (this.fromDate && this.toDate) {
      queryParams += `&fromDate=${this.fromDate}&toDate=${this.toDate}`;
    }

    this.timeLogsService
      .getTimeLogs(queryParams)
      .subscribe({
        next: (res: any) => {
          if (res) {
            this.timeLogs = res;
          }
        },
        error: (err) => {
          console.error('Error fetching timeLogs', err);
        }
      });
  }


  getTimeLogsCount() {
    let queryParams = ``;
    if (this.fromDate && this.toDate) {
      queryParams = `?fromDate=${this.fromDate}&toDate=${this.toDate}`;
    }
    this.timeLogsService
      .getTimeLogsCount(queryParams)
      .subscribe({
        next: (res: any) => {
          if (res) {
            this.timeLogsCount = res;
          }
        },
        error: (err) => {
          console.error('Error fetching timeLogs count', err);
        }
      });
  }

  public updatePage() {
    this.getTimeLogs();
    this.getTimeLogsCount();
  }
}
