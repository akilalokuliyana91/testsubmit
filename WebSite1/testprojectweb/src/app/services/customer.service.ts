import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Customer } from "../models/customer.model";
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
@Injectable()
export class CustomerService {

  constructor(private http: Http) { }

  getCustomers(): Observable<Customer[]> {
    let statusUrl= "http://localhost:5400/api/Customers";
    return this.http.get(statusUrl).map(res => {
      let stsRslt = res.json();
      return stsRslt || {};
    });

  }

}
