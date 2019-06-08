import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../_models/User';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

decodedToken: any;
currentUser: User;
jwtHelper = new JwtHelperService();
baseUrl = environment.apiUrl + 'auth/';
constructor(private http: HttpClient) { }

Register(user: User) {
 return this.http.post(this.baseUrl + 'register', user);
}

Login(model: any) {
  return this.http.post(this.baseUrl + 'login', model)
    .pipe(
      map((response: any) => {
        const user = response;
        if (user)
        {
          localStorage.setItem('token', user.token.result);
          localStorage.setItem('user', user.user);
          this.decodedToken = this.jwtHelper.decodeToken(user.token.result);
          console.log(this.decodedToken);
          this.currentUser = user.user;
        }
      })
    );
  }

  LoggedIn() {
    const token = localStorage.getItem('token');
    if (this.jwtHelper.isTokenExpired(token)) {
      return false;
    }

    this.decodedToken = this.jwtHelper.decodeToken(token);
    return true;
  }

}
