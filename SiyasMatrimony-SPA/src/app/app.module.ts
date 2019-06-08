import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule , BsDatepickerModule  } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { AppRoutes } from './routes';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { AuthGuard } from './_guard/auth.guard';
import { HelperService } from './_services/helper.service';
import { SelectDropDownModule } from 'ngx-select-dropdown';
import { InternationalPhoneNumberModule } from 'ngx-international-phone-number';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RegistermodalComponent } from './register/register_modal/register_modal.component';
import { SearchComponent } from './search/search.component';
import { ManageComponent } from './manage/manage.component';

export function TokenGetter() {
   return localStorage.getItem('token');
}
@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      FooterComponent,
      HomeComponent,
      RegisterComponent,
      RegistermodalComponent,
      SearchComponent,
      ManageComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(AppRoutes),
      BsDropdownModule.forRoot(),
      ReactiveFormsModule,
      SelectDropDownModule,
      BsDatepickerModule.forRoot(),
      InternationalPhoneNumberModule,
      NgbModule,
      JwtModule.forRoot({
         config: {
            tokenGetter: TokenGetter,
            whitelistedDomains:['localhost:5000'],
            blacklistedRoutes:['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      AlertifyService,
      AuthGuard,
      HelperService
   ],
   bootstrap: [
      AppComponent
   ],
   entryComponents: [
      RegistermodalComponent
   ]
})
export class AppModule { }
