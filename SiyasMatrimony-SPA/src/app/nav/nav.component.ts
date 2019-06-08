import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FormGroup } from '@angular/forms';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { analyzeAndValidateNgModules } from '@angular/compiler';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  loginForm: FormGroup;

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  Login() {
    //let test: any = false;
    this.authService.Login(this.model).subscribe(response => {
    }, error => {
      console.log(error);
    }, () => {
      this.alertify.success('Logged in successfully');
      this.router.navigate(['/search']);
    });

    // if ( loggin === true)
    // {
    //   this.router.navigate(['/register']);
    // }
  }

  IsLoggedIn() {
    return this.authService.LoggedIn();
  }

  LoggedOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authService.decodedToken = null;
    this.authService.currentUser = null;
    this.alertify.message('Logged Out');
    this.router.navigate(['/home']);
  }

}
