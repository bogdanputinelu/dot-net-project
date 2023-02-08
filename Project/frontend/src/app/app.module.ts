import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ContentComponent } from './pages/content/content.component';
import { MainComponent } from './pages/main/main.component';
import { InfoComponent } from './shared/components/info/info.component';
import { ApartmentContentComponent } from './pages/apartment-content/apartment-content.component';

@NgModule({
  declarations: [
    AppComponent,
    ContentComponent,
    MainComponent,
    InfoComponent,
    ApartmentContentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatToolbarModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
