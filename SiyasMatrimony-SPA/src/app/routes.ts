import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guard/auth.guard';
import { SearchComponent } from './search/search.component';
import { ManageComponent } from './manage/manage.component';

export const AppRoutes: Routes = [
  {path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'search', component: SearchComponent },
      {path: 'manage', component: ManageComponent },
      {path: 'register', component: RegisterComponent }
    ]
  },
  {path: '**', redirectTo: '' , pathMatch : 'full'}
];
