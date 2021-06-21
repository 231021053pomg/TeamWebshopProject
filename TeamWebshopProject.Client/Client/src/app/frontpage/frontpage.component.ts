import { Component, OnInit } from '@angular/core';
import { Item } from '../models';
import { FrontpageService } from '../frontpage.service';

@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styleUrls: ['./frontpage.component.css']
})
export class FrontpageComponent implements OnInit {

  newProducts: Item[] = [];
  popProducts: Item[] = [];
  constructor(
    private frontpageService: FrontpageService
  ) { }

  ngOnInit(): void {
    this.getNewProducts();
  }

  getNewProducts(): void {
    this.frontpageService.getNewItems()
    .subscribe(items => this.newProducts = items);
  }
}
