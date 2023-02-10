import { Component } from "@angular/core";

@Component({
  selector: "app-pets-form",
  templateUrl: "./pets-form.pages.html",
  styleUrls: ["./pets-form.pages.css"]
})
export class PetFormPages {
    name!: string;
    description!: string;
    url!: string;
    constructor(){}
    onClick(){
        console.log("clicked")
    }
}
