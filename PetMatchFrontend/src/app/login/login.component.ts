import { Component } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(public userService: UsersService, private router: Router) {}

  email!: string;
  password!: string;

  login() {
    const user = {email: this.email, password: this.password};
    this.userService.login(user).subscribe( data => {
      localStorage.setItem("token", data.token);
      this.router.navigate(['/pets'])
    });
  }
}
