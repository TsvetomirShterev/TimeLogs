import { project } from "./project";
import { user } from "./user";

export interface timeLog{
  id: number,
  logDate: Date,
  hoursWorked: number,
  project: project,
  user: user
}
