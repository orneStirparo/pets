import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-pets-form",
  templateUrl: "./pets-form.component.html",
  styleUrls: ["./pets-form.component.css"]
})

export class PetFormComponent {
    isAddMode!: boolean;
    id!: string;
    name!: string;
    description!: string;
    url!: string;
    constructor(private route: ActivatedRoute){}

    ngOnInit(){
      this.id = this.route.snapshot.params['id'];
      this.isAddMode = !this.id;
      console.log(this.isAddMode);
    }
    onClick(){
        console.log("clicked")
    }
}