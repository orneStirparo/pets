import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs";
import { PetService } from "src/app/services";

@Component({
  selector: "app-pets-form",
  templateUrl: "./pets-form.component.html",
  styleUrls: ["./pets-form.component.css"]
})

export class PetFormComponent {
    form!: FormGroup;
    isAddMode!: boolean;
    id!: string;
    name!: string;
    description!: string;
    url!: string;
    loading = false;

    constructor(private route: ActivatedRoute, private router: Router, 
      private petService: PetService, private formBuilder: FormBuilder,){}

    ngOnInit() {
      this.id = this.route.snapshot.params['id'];
      this.isAddMode = !this.id;

      this.form = this.formBuilder.group({
          name: ['', Validators.required],
          description: ['', Validators.required],
          url: ['', Validators.required],
      }, );

      if (!this.isAddMode) {
          this.petService.getById(this.id)
              .pipe(first())
              .subscribe(x => this.form.patchValue(x));
      }
  }

  onSubmit(){
    this.loading = true;
    if (this.isAddMode) {
      this.createPet();
    } else {
      this.updatePet();
    }
    }
    goBack(): void{
      this.router.navigate(['/pets']);
    }

    private createPet() {
      this.petService.create(this.form.value)
          .pipe(first())
          .subscribe(() => {
              //this.alertService.success('User added', { keepAfterRouteChange: true });
              this.router.navigate(['pets']);
          })
          .add(() => this.loading = false);
  }

  private updatePet() {
      this.petService.update(this.id, this.form.value)
          .pipe(first())
          .subscribe(() => {
              //this.alertService.success('User updated', { keepAfterRouteChange: true });
              this.router.navigate(['pets']);
          })
          .add(() => this.loading = false);
  }
}
