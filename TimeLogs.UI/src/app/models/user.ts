import { timeLog } from "./timeLog";

export interface user{
  id: number,
  firstName: string,
  lastName: string,
  email: string,
  timeLogs: timeLog[]
}
