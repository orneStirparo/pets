import { Component } from "@angular/core";
import { UsersService } from "../services/users.service";
import { Router } from "@angular/router";
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { catchError, throwError } from "rxjs";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent {
  firstName!: string;
  lastName!: string;
  email!: string;
  password!: string;
  confirmPassword!: string;
  validationErrors!: any;
  form!: FormGroup<{firstName: FormControl<string | null>; lastName: FormControl<string | null>; email: FormControl<string | null>; password: FormControl<string | null>; confirmPassword: FormControl<string | null>; }>;
  errorMessage: any;

  constructor(public userService: UsersService, private router: Router, 
    private fb: FormBuilder) {}

    ngOnInit(){
      this.form = this.fb.group({
          firstName: ['', Validators.required],
          lastName: ['', Validators.required],
          email: ['', [Validators.required, Validators.email]],
          password: ['', [Validators.minLength(8), Validators.required]],
          confirmPassword: ['', Validators.required]
      });
    }
  register() {
    this.userService.register(this.form.value)
    .pipe(
      catchError(error => {
        this.errorMessage = error.error;
        return throwError(error);
      })
    ).subscribe(
      data => {
      localStorage.setItem("token", data.token)
      this.router.navigate(['/pets'])
    })
    ;
  }
}

