import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Credit, Customer, Login } from './models';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  url =  {
    customer: "https://localhost:44365/api/Customer",
    credit: "https://localhost:44365/api/Credit",
    login: "https://localhost:44365/api/login",

  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(
    private http: HttpClient
  ) { }

  newCustomer(customer: Customer) : Observable<Customer> {
    return this.http.post<Customer>(`${this.url.customer}`, customer, this.httpOptions);
  }

  getAllCustomer(): Observable<Array<Customer>> {
    return this.http.get<Array<Customer>>(`${this.url.customer}`, this.httpOptions);
  }

  deleteCustomer(customer: Customer): Observable<Customer> {
    return this.http.delete<Customer>(`${this.url.customer}/${customer.id}`, this.httpOptions);
  }

  updateCustomer(customer: Customer): Observable<Customer> {
    return this.http.put<Customer>(`${this.url.customer}`, customer, this.httpOptions);
  }

  newCredit(): Observable<Credit> {
    return this.http.post<Credit>(`${this.url.credit}`, { creditAmount: 0 }, this.httpOptions);
  }

  newLogin(login: Login): Observable<Login> {
    return this.http.post<Login>(`${this.url.login}`, login, this.httpOptions);
  }
}
