import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { Pet } from 'src/app/models';
import { PetService } from 'src/app/services';

@Component({
  selector: 'app-pets-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css']
})
export class PetListComponent {
  pets!: any;
  constructor(private router: Router, private petService: PetService){}
  ngOnInit(){
    this.petService.getAll()
            .pipe(first())
            .subscribe(pets => this.pets = pets);
  }

  signOut(): void{
    localStorage.removeItem('token');
    window.location.replace("/login");
  };

  createPet(){
    this.router.navigate(['pets/create']);
  };

  getDetails(id: string){
    this.router.navigate([`pets/${id}`]);
  };

  updatePet(id: string){
    this.router.navigate([`pets/edit/${id}`]);
  };

  deletePet(id: string){}
}
