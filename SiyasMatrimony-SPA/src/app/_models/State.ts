import { City } from "./City";

export interface State {
   id: number;
   name: string;
   country_id: number;
   Cities: City[];
}
