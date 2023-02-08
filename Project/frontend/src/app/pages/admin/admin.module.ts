import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Components
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AdminComponentComponent } from './admin-component/admin-component.component';
import { AdminComponent } from './admin.component';


//Modules
import { AdminRoutingModule } from './admin-routing.module';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [
    AdminComponent,
    AdminPageComponent,
    AdminComponentComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatCardModule
  ]
})
export class AdminModule { }
