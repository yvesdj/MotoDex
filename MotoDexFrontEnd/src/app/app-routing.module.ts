import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MotorcyclesComponent } from './motorcycles/motorcycles.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'motorcycles', component: MotorcyclesComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }