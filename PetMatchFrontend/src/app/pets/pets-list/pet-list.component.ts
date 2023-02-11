import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pets-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css']
})
export class PetListComponent {
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
