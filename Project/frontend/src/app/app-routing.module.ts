import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminModule } from './pages/admin/admin.module';
import { ApartmentContentComponent } from './pages/apartment-content/apartment-content.component';
import { ContentComponent } from './pages/content/content.component';
import { MainComponent } from './pages/main/main.component';
import { RegisterComponent } from './register/register.component';


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
  },
  {
    path: "register",
    component: RegisterComponent
  },
  {
    path: "admin",
    loadChildren: () => import('./pages/admin/admin.module').then(m => AdminModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
