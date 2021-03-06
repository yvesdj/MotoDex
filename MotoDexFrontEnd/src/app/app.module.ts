import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule  } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';


import { MaterialModule } from './material/material.module';


import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './navigation/header/header.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { MotorcyclesComponent } from './motorcycles/motorcycles.component';
import { OverviewComponent } from './motorcycles/overview/overview.component';
import { DeleteComponent } from './motorcycles/delete/delete.component';
import { AddMotoComponent } from './motorcycles/add-moto/add-moto.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    SidenavListComponent,
    MotorcyclesComponent,
    OverviewComponent,
    DeleteComponent,
    AddMotoComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule ,
    MaterialModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
