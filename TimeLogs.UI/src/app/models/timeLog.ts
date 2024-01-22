import { project } from "./project";

export interface timeLog{
  id: number,
  logDate: Date,
  hoursWorked: number,
  project: project
}
