import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService:AuthService, private router:Router, private alertify: AlertifyService) {}

  canActivate():boolean {

    if(this.authService.LoggedIn()){
      return true;
    }
    this.router.navigate(['/home']);
    this.alertify.error('You are not authorized!!!');
    return false;
  }
}
