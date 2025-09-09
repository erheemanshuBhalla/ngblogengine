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
import { UsersComponent } from './components/users/users.component';
import { AdminComponent } from './components/users/admin/admin.component';
import { RegisterComponent } from './components/account/register/register.component';
import { LoginComponent } from './components/account/login/login.component';
import { ForgotpasswordComponent } from './components/account/forgotpassword/forgotpassword.component';
import { ChangepasswordComponent } from './components/account/changepassword/changepassword.component';
import { GetComponent } from './components/comments/get/get.component';
import { TagsComponent } from './components/tags/tags.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ArticlesComponent,
    AddComponent,
    EditComponent,
    ListComponent,
    DetailsComponent,
    UsersComponent,
    AdminComponent,
    RegisterComponent,
    LoginComponent,
    ForgotpasswordComponent,
    ChangepasswordComponent,
    GetComponent,
    TagsComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
