import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PetListComponent } from './pets-list/pet-list.component';
import { PetsDetailComponent } from './pets-detail/pets-detail.component';
import { PetFormComponent } from './pets-create-update/pets-form.component';
import { PetsComponent } from './pets.component';

const routes: Routes = [
    {
        path: '', component: PetsComponent,
        children: [
            {path: '', component: PetListComponent, pathMatch: 'full' },
            {path: 'create', component: PetFormComponent, pathMatch: 'full' },
            {path: 'edit/:id', component: PetFormComponent, pathMatch: 'full' },
            {path: ':id', component: PetsDetailComponent, pathMatch: 'full'}
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PetsRoutingModule { }