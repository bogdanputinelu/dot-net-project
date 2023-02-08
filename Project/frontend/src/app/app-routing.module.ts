import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ApartmentContentComponent } from './pages/apartment-content/apartment-content.component';
import { ContentComponent } from './pages/content/content.component';
import { MainComponent } from './pages/main/main.component';

const routes: Routes = [
  {
    path: "main",
    component: MainComponent
  },
  {
    path: "content/:id",
    component: ApartmentContentComponent
  },
  {
    path: "content",
    component: ContentComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
