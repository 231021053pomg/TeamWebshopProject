import { Component, OnInit } from '@angular/core';
import { Basket } from '../models';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from '../basket.service';


@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  id: number = 0;
  basket: Basket = {};

  constructor(
    private route: ActivatedRoute,
    private basketService: BasketService
  ) { }

  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get("id") || 0) as number;
    this.getBasket(this.id);
    }

  getBasket(id: number): void {
      this.basket = this.basketService.getBasket(id) as Basket; 
  }
}
