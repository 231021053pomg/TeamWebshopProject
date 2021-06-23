import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
import { Credit, Customer, Login } from '../models';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  login: Login = {email: "", password: "", accessType: "customer"}
  customer: Customer = { login: this.login };
  

  constructor(
    private customerService: CustomerService
  ) { }

  ngOnInit(): void {
  }

  newCustomer(): void {
    this.customerService.newCredit()
    .subscribe(s => this.customer.credit = s);

    this.customerService.newLogin(this.login as Login)
    .subscribe(l => this.login = l);

    this.customer.login = this.login;

    console.log(this.customer);

    this.customerService.newCustomer(this.customer)
    .subscribe();
  }

}
