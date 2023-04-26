  import { NgModule } from '@angular/core';
  import { BrowserModule } from '@angular/platform-browser';

  import { AppRoutingModule } from './app-routing.module';
  import { AppComponent } from './app.component';
  import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
  import { HomeComponent } from './home/home.component';
  import { CatalogComponent } from './catalog/catalog.component';
  import { MatToolbarModule } from '@angular/material/toolbar';
  import {MatGridListModule} from '@angular/material/grid-list';
  import {MatFormFieldModule} from '@angular/material/form-field';
  import {MatCardModule} from '@angular/material/card';

  import { HttpClientModule } from '@angular/common/http';


  @NgModule({
    declarations: [
      AppComponent,
      HomeComponent,
      CatalogComponent
    ],
    imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      MatToolbarModule,
      MatGridListModule,
      MatFormFieldModule,
      MatCardModule,
      HttpClientModule
    ],
    providers: [],
    bootstrap: [AppComponent]
  })
  export class AppModule { }
