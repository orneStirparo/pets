import { Component } from "@angular/core";
import { UsersService } from "../services/users.service";
import { Router } from "@angular/router";

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

  constructor(public userService: UsersService, private router: Router) {}

  register() {
    const user = { firstName: this.firstName, lastName: this.lastName, email: this.email, password: this.password, confirmPassword: this.confirmPassword };
    this.userService.register(user).subscribe(data => {
      localStorage.setItem("token", data.token)
      this.router.navigate(['/pets'])
    });
  }
}
