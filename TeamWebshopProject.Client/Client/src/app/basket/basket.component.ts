import { Component, OnInit } from '@angular/core';
import { Basket, BasketItem, Item } from '../models';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from '../basket.service';
import { ProductpageComponent } from '../productpage/productpage.component';


@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  id: number = 0;
  basket: Basket = {};
  basketItems: BasketItem[] = [];

  constructor(
    private route: ActivatedRoute,
    private basketService: BasketService,
    // Login Service
  ) { }

  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get("id") || 0) as number;
    this.getBasket(this.id);
    this.getBasketItems(this.id);
    }

  getBasket(id: number): void {
      this.basket = this.basketService.getBasket(id) as Basket; 
  }

  getBasketItems(id: number): void {
    this.basketService.getBasketItems(id)
    .subscribe(items => this.basketItems = items);
  }
}
