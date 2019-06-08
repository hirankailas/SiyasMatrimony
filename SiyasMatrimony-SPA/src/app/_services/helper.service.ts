import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from './alertify.service';
import { environment } from 'src/environments/environment';
import { Religion } from '../_models/Religion';
import { Star } from '../_models/Star';
import { Observable, BehaviorSubject } from 'rxjs';
import { Country } from '../_models/Country';
import { City } from '../_models/City';

@Injectable({
  providedIn: 'root'
})
export class HelperService {
relegionUrl = environment.apiUrl + 'religion/';
GenderConfig =  environment.genderConfig;
MaritalConfig =  environment.maritalConfig;
ReligionConfig = environment.religionConfig;
CasteConfig = environment.casteConfig;
ProfileForConfig = environment.ProfileforConfig;
MotherTongueConfig = environment.MotherTongueConfig;
StarConfig = environment.StarConfig;
HeightConfig = environment.HeightConfig;
RashiConfig = environment.RashiConfig;
DoshamConfig = environment.DoshamConfig;
FamilystatusConfig = environment.FamilystatusConfig;
FamilytypeConfig = environment.FamilytypeConfig;
FamilyValueConfig = environment.FamilyValueConfig;
CountryConfig = environment.CountryConfig;
StateConfig = environment.StateConfig;
CityConfig = environment.CityConfig;
Relegions: Religion[];

constructor(private http: HttpClient, private alertify: AlertifyService) { }
GetAllRelegions(): Observable<Religion[]> {
  return this.http.get<Religion[]>(this.relegionUrl + 'GetAllReligions/');
}

GetAllStars(): Observable<Star[]>{
  return this.http.get<Star[]>(this.relegionUrl + 'GetAllStars/');
}

GetAllCountries(): Observable<Country[]>{
  return this.http.get<Country[]>(this.relegionUrl + 'GetAllCountries/');
}
GetAllCities(stateId: number): Observable<City[]>{
  return this.http.get<City[]>(this.relegionUrl + 'GetAllCities/' + stateId);
}
PasswordGenerator():Observable<string>{
  let dictionary: Array<String>;
  const library = 'abcdefghijklmnopqrstuvwxyz';
  dictionary = library.split('');
  let newPassword: BehaviorSubject<string> ;
  let password = '';
  for (let i = 0; i < 5; i++) {
    password += dictionary[Math.floor(Math.random() * dictionary.length)];
  }
  newPassword = new BehaviorSubject(password);
  return newPassword.asObservable();
}
}

