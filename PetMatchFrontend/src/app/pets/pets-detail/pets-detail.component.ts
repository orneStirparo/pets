import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import { PetService } from 'src/app/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-pets-detail',
  templateUrl: './pets-detail.component.html',
  styleUrls: ['./pets-detail.component.css']
})
export class PetsDetailComponent {
  id!: string;
  pet!: any;
  constructor(private route: ActivatedRoute, private router: Router, private petService: PetService){}
  ngOnInit(){
    this.id = this.route.snapshot.params['id'];
    this.petService.getById(this.id)
    .pipe(first())
    .subscribe(pet => this.pet = pet);
  }
  signOut(): void{
    localStorage.removeItem('token')
    this.router.navigate([`/login`]);
  };
  goBack(): void{
    this.router.navigate(['/pets']);
  }
  updatePet(){
    this.router.navigate([`/pets/edit/${this.id}`])
  }
  deletePet(){
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
    this.petService.delete(this.id)
        .pipe(first())
        .subscribe(() => this.router.navigate(['/pets'])
        );
      }
    });
  }
}
