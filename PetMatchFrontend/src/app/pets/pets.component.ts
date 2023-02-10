import { Component } from '@angular/core';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent {
  constructor(){}

  signOut(): void{
    localStorage.removeItem('token')
    window.location.replace("/login");
  } 

}
