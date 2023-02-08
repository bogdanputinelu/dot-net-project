import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Components
import { MatCardModule } from '@angular/material/card';
import { InfoComponent } from './info/info.component';

let componentsArray = [InfoComponent]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatCardModule
  ]
})
export class ComponentsModule { }
