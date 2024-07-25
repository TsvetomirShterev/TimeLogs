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
    const dataArray: any[] = [['User', 'Hours Worked']];

    this.timeLogs.forEach((log) => {
      dataArray.push([log.user, log.hoursWorked]);
    });

    const data = google.visualization.arrayToDataTable(dataArray);

    const options = {
      title: 'Top 10 Users by Hours Worked',
      bars: 'vertical',
      height: 400,
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
    this.topStatisticsService.getTopTimeLogs().subscribe({
      next: (res: timeLog[]) => {
        this.timeLogs = res;
      },
      error: (err) => {
        console.error('Error fetching timeLogs', err);
      }
    });
  }
}
