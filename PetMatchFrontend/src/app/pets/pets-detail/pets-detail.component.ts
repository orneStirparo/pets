import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pets-detail',
  templateUrl: './pets-detail.component.html',
  styleUrls: ['./pets-detail.component.css']
})
export class PetsDetailComponent {
  constructor(private router: Router){}
  signOut(): void{
    localStorage.removeItem('token')
    window.location.replace("/login");
  };
  goBack(): void{
    this.router.navigate(['/pets']);
  }
  updatePet(){}
  deletePet(){}
}
