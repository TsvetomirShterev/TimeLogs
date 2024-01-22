import { Component, OnInit } from '@angular/core';
import { TimeLogsService } from '../../services/time-logs.service';

@Component({
  selector: 'app-time-logs',
  templateUrl: './time-logs.component.html',
  styleUrl: './time-logs.component.scss'
})
export class TimeLogsComponent implements OnInit {
  timeLogs: any[] = [];

  constructor(private timeLogsService: TimeLogsService){

  }

  ngOnInit(): void {
      this.timeLogsService.getUsers()
        .subscribe(data => {
          this.timeLogs = data;
        });
  }
}
