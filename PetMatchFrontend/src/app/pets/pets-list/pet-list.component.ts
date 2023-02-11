import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { Pet } from 'src/app/models';
import { PetService } from 'src/app/services';
import Swal from 'sweetalert2';

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

  deletePet(id: string){
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if(result.value){
    this.petService.delete(id)
        .pipe(first())
        .subscribe(
          () => this.pets = this.pets.filter((x: { id: {value: string}; }) => x.id.value !== id)
        );
      }
    });
  }
}
