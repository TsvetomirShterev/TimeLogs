import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TimeLogsComponent } from './components/time-logs/time-logs.component';

const routes: Routes = [
  // {
  //   path: '',
  //   redirectTo: 'time-logs'
  // },
  {
    path: 'time-logs',
    component: TimeLogsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
