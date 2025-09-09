import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { ArticlesComponent } from './components/articles/articles.component';
import { AddComponent } from './components/articles/add/add.component';
import { EditComponent } from './components/articles/edit/edit.component';
import { ListComponent } from './components/articles/list/list.component';
import { DetailsComponent } from './components/articles/details/details.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ArticlesComponent,
    AddComponent,
    EditComponent,
    ListComponent,
    DetailsComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
