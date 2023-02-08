import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ApartmentsComponent } from './pages/apartments/apartments.component';

const routes: Routes = [
  {
    path: "apartments",
    component: ApartmentsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
