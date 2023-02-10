import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "./AuthGuards/authGuards";
import { LoginComponent } from "./login/login.component";
import { PetsCreateUpdatePages } from "./pets/pets-create-update/pets-create-update.pages";
import { PetsDetailPages } from "./pets/pets-detail/pets-detail.pages";
import { PetsComponent } from "./pets/pets.component";
import { RegisterComponent } from "./register/register.component";

const routes: Routes = [
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  { path: 'register', component: RegisterComponent, pathMatch: 'full' },
  { path: 'pets', component: PetsComponent, pathMatch: 'full', canActivate: [AuthGuard] },
  { path: 'pets/create', component: PetsCreateUpdatePages, pathMatch: 'full', canActivate: [AuthGuard] },
  { path: 'pets/edit/:id', component: PetsCreateUpdatePages, canActivate: [AuthGuard] },
  { path: 'pets/:id', component: PetsDetailPages, canActivate: [AuthGuard] },
  { path: '', component: RegisterComponent, pathMatch: 'full' },
  // { path: '**', component: RegisterComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}