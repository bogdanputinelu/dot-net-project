import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { AdminModule } from './pages/admin/admin.module';
import { ApartmentContentComponent } from './pages/apartment-content/apartment-content.component';
import { ContentComponent } from './pages/content/content.component';
import { LoginComponent } from './pages/login/login.component';
import { MainComponent } from './pages/main/main.component';


const routes: Routes = [
  {
    path: "main",
    canActivate: [AuthGuard],
    component: MainComponent
  },
  {
    path: "content/:id",
    canActivate: [AuthGuard],
    component: ApartmentContentComponent
  },
  {
    path: "content",
    canActivate: [AuthGuard],
    component: ContentComponent
  },
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "admin",
    canActivate: [AuthGuard],
    loadChildren: () => import('./pages/admin/admin.module').then(m => AdminModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
