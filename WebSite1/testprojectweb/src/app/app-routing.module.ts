import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './component/customers/customers.component';

const routes: Routes = [
  { path: '', redirectTo: '/customers', pathMatch: 'full'},
  { path: 'customers',component: CustomersComponent },

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

