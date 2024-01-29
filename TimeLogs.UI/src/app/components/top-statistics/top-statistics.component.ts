import { Component, OnInit } from '@angular/core';
import { TimeLogsService } from '../../services/time-logs.service';
import { GoogleChartComponent } from 'angular-google-charts';
// import { TopStatistic } from '../../models/topStatistic';

@Component({
  selector: 'app-top-statistics',
  templateUrl: './top-statistics.component.html',
  styleUrls: ['./top-statistics.component.scss']
})
  export class TopStatisticsComponent implements OnInit {
    // public topStatistics: TopStatistic[] = [];
    public fromDate: string = '';
    public toDate: string = '';
    public selectedType: string = 'users'; // Default to users

    constructor(private timeLogsService: TimeLogsService) { }

    ngOnInit(): void {
      this.loadGoogleCharts();
      // this.fromDate = this.getDefaultFromDate();
      // this.toDate = this.getDefaultToDate();
      // this.updateTopStatistics();
    }

    loadGoogleCharts(): void {
      google.charts.load('current', { packages: ['corechart'] });
      google.charts.setOnLoadCallback(() => {
        // Chart initialization logic goes here
      });
    }

    // Other methods...
  }
