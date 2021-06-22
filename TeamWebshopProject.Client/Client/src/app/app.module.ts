import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { ProductpageComponent } from './productpage/productpage.component';
import { CategorypageComponent } from './categorypage/categorypage.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NewitemComponent } from './newitem/newitem.component';
import { LoginFormComponent } from './login-form/login-form.component';

import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
  declarations: [
    AppComponent,
    FrontpageComponent,
    ProductpageComponent,
    CategorypageComponent,
    AdminpageComponent,
    NewitemComponent,
    LoginFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatListModule,
    MatGridListModule,
    MatFormFieldModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
