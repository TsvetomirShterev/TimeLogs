import { Component, OnInit } from '@angular/core';
import { TopStatisticsService } from '../../services/top-statistics.service';
import { timeLog } from '../../models/timeLog';

declare const google: any;

@Component({
  selector: 'app-top-statistics',
  templateUrl: './top-statistics.component.html',
  styleUrls: ['./top-statistics.component.scss']
})
export class TopStatisticsComponent implements OnInit {
  public fromDate: string = '';
  public toDate: string = '';
  public timeLogs: timeLog[] = [];

  constructor(private topStatisticsService: TopStatisticsService) { }

  ngOnInit(): void {
    this.loadGoogleCharts();
    this.getTopTimeLogs();
  }

  loadGoogleCharts(): void {
    google.charts.load('current', { packages: ['corechart'] });
    google.charts.setOnLoadCallback(() => {
      this.drawChart();
    });
  }

  drawChart(): void {
    console.log('Drawing chart...');

    const dataArray: any[] = [];
    console.log(dataArray);
    this.timeLogs.forEach((log) => {
      dataArray.push([log.user.firstName + ' ' + log.user.lastName, log.hoursWorked]);
    });

    const data = new google.visualization.DataTable();
    data.addColumn('string', 'User');
    data.addColumn('number', 'Hours Worked');
    data.addRows(dataArray);


    const options = {
      title: 'Top 10 Users by Hours Worked',
      bars: 'vertical',
      height: 600,
      legend: { position: 'none' },
    };

    const chartComponent = new google.visualization.ChartWrapper({
      chartType: 'BarChart',
      dataTable: data,
      options: options,
      containerId: 'chart_div',
    });

    chartComponent.draw();
  }

  getTopTimeLogs(): void {
    console.log('Fetching time logs...');
    this.topStatisticsService.getTopTimeLogs().subscribe({
      next: (res: timeLog[]) => {
        console.log('Time logs received:', res);
        this.timeLogs = res;
      },
      error: (err) => {
        console.error('Error fetching timeLogs', err);
      }
    });
  }
}
