import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, EMPTY } from 'rxjs';
// import { LoginCommand } from 'src/app/shared/models';

@Component({
  selector: 'auth-login',
  templateUrl: './login.component.html',
  styleUrls: ['../form.scss']
})
export class LoginComponent {
  hide: boolean = true;
  loginForm!: FormGroup;
  submitDisabled: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder) {
    this.loginForm = fb.group(
      {
        login: this.fb.control('', [Validators.required, Validators.email]),
        password: this.fb.control('', [Validators.required])
      }
    )
  }

  login(): void {
    const rawForm = this.loginForm.getRawValue();
    // this.submitDisabled = true;
    // const command = {
    //   email: rawForm.login,
    //   password: rawForm.password
    // } as LoginCommand;

    // console.log("Test")

    // this.service.login(command)
    //   .pipe(
    //     catchError((err, caught) => {
    //     this.submitDisabled = false;
    //     return EMPTY;
    //   }))
    //   .subscribe(token => {
    //     console.log(token.token)
    //     this.authService.setUserToken(token.token);
    //     this.router.navigate(['/user/dashboard']);
    //   });
  }

  getErrorMessage(control: string): string {
    const required: string = 'To pole jest wymagane';

    if (control === 'login') {
      if (this.loginForm.controls[control].hasError('required')) {
        return required;
      }
      return this.loginForm.controls[control].hasError('email') ? 'Niepoprawny format email' : '';
    }
    else if (control === 'password') {
      return this.loginForm.controls[control].hasError('required') ? required : '';
    }
    return '';
  }
}
