  import { Component, OnInit } from '@angular/core';
import { Item } from '../models';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProductPageService } from '../product-page.service';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from '../basket.service';

@Component({
  selector: 'app-productpage',
  templateUrl: './productpage.component.html',
  styleUrls: ['./productpage.component.css']
})
export class ProductpageComponent implements OnInit {
  apiUrl: string = 'https://localhost:44365/apiItem';
  id: number = 0;

  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor( 
    private productpageservice: ProductPageService,
    private basketService: BasketService,
    private route: ActivatedRoute
    ) {}


    
    item: Item = { id: 0, itemType: "", price: 0, discount: 0, discription: "", image: "" };
    quantity: number = 1;
  
  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get("id") || 0) as number;
    this.getItem(this.id);
  }

  getItem(id: number): void {
    this.productpageservice.getItem(id)
    .subscribe(i => this.item = i);
  }

  addToBasket(item: Item, quantity: number) : void{
    console.log("item:");
    console.log(item);
    console.log(quantity);
    this.basketService.addBasketItem(item, quantity)
    .subscribe();

    console.log("localstorage(basket): " + localStorage.getItem("basket"));
  }

}
