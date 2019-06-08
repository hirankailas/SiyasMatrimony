import { State } from './State';
import { City } from './City';

export interface Country {

     id: number;
     name: string;
     iso3: string;
     iso2: string;
     phone_code: string;
     capital: string;
     currency: string;
     States: State[];
     Cities: City[];
}
