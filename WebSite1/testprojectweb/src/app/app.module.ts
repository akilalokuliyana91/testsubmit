import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';


import { AppComponent } from '../app/component/app/app.component';
import { CustomersComponent } from './component/customers/customers.component';
import { AppRoutingModule } from './app-routing.module';

import { CustomerService } from './services/customer.service';


@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent
  ],
  imports: [
    BrowserModule, FormsModule, HttpModule, AppRoutingModule
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
