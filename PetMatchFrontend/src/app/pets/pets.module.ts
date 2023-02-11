import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { PetsRoutingModule } from './pets-routing.module';
import { PetsDetailComponent } from './pets-detail/pets-detail.component';
import { PetListComponent } from './pets-list/pet-list.component';
import { PetFormComponent } from './pets-create-update/pets-form.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatCardModule} from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';
import { PetsComponent } from './pets.component'

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        PetsRoutingModule,
        FormsModule,
        HttpClientModule,
        MatCardModule,
        MatToolbarModule,
        MatButtonModule,
        FlexLayoutModule,
    ],
    declarations: [
        PetsDetailComponent,
        PetListComponent,
        PetFormComponent,
        PetsComponent
    ]
})
export class PetsModule { }