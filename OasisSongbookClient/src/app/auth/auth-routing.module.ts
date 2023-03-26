import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  imports: [RouterModule.forChild([
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {
      path: '',
      component: AuthComponent,
      children: [
        { path: 'login', component: LoginComponent, data: { title: "Logowanie"} },
        { path: 'register', component: RegisterComponent, data: { title: "Rejestracja"}  },
        //   { path: 'change-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard], data: { title: "Zmiana hasła"}  }
      ]
    },
    {path: '**', redirectTo: 'login'}
  ])],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
