import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
import { Customer } from '../models';

@Component({
  selector: 'app-all-customers',
  templateUrl: './all-customers.component.html',
  styleUrls: ['./all-customers.component.css']
})
export class AllCustomersComponent implements OnInit {

  customers: Customer[] = [];

  constructor(
    private customerService: CustomerService
  ) { }

  ngOnInit(): void {
    this.getAllCustomers();
  }

  getAllCustomers() : void {
    this.customerService.getAllCustomer()
    .subscribe(c => this.customers = c);
  }

  deleteCustomer(customer: Customer): void {
    if(confirm(`Er du sikker på at du vil slætte: ${customer.firstName} ${customer.lastName}`)) {
      this.customers = this.customers.filter(c => c !== customer);
      this.customerService.deleteCustomer(customer).subscribe();
    }
  }

}
