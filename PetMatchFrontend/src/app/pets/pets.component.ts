import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent {
  constructor(private router: Router){}

  signOut(): void{
    localStorage.removeItem('token')
    window.location.replace("/login");
  };

  createPet(){
    this.router.navigate(['pets/create']);
  };

  getDetails(){
    this.router.navigate(['pets/9']);
  };

  updatePet(){
    this.router.navigate(['pets/edit/9']);
  };

  deletePet(){}
}
