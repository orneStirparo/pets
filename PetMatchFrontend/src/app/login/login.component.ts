import { Component } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  form: any;
  errorMessage: any;
  email!: string;
  password!: string;

  constructor(public userService: UsersService, private router: Router, private fb: FormBuilder) {}
  ngOnInit(){
    this.form = this.fb.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.minLength(8), Validators.required]]
    });
  }

  login() {
    this.userService.login(this.form.value)
    .pipe(
      catchError(error => {
        this.errorMessage = error.error;
        return throwError(error);
      })
    ).subscribe( data => {
      localStorage.setItem("token", data.token);
      this.router.navigate(['/pets']);
    });
  }
}
