import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "./AuthGuards/authGuards";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";

const petsComponent = () => import('./pets/pets.module').then(x => x.PetsModule);

const routes: Routes = [
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  { path: 'register', component: RegisterComponent, pathMatch: 'full' },
  { path: 'pets', loadChildren: petsComponent, canActivate: [AuthGuard] },
   { path: '**', component: RegisterComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}