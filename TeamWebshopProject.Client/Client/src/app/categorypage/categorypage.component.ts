import { Component, OnInit } from '@angular/core';
import { Tag } from '../models';
import { TagService } from '../tag.service';
import { FrontpageService } from '../frontpage.service';

import { Item } from '../models';

@Component({
  selector: 'app-categorypage',
  templateUrl: './categorypage.component.html',
  styleUrls: ['./categorypage.component.css']
})
export class CategorypageComponent implements OnInit {
  tags: Tag[] = [];
  products: Item[] = [];
  showedProducts: Item[] = [];

  selectedTag?: Tag;

  onSelect(tag: Tag): void {
    this.selectedTag = tag;

    this.showedProducts = this.products.filter(p => p.tags?.some(t => t.id === tag.id));
  }

  constructor(private tagService: TagService, private frontpageService: FrontpageService) { }

  ngOnInit(): void {
    this.getAllTags();
    this.getNewProducts();
  }

  getAllTags(): void {
    this.tagService.getAllTags().subscribe(tag => this.tags = tag);
  }

  getNewProducts(): void {
    this.frontpageService.getNewItems().subscribe(items => this.products = items);
  }
}
