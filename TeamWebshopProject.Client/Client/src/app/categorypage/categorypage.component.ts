import { Component, OnInit } from '@angular/core';
import { CategoryPageService } from '../services/category/categorypage.service';
import { Category } from '../models/domain';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-categorypage',
  templateUrl: './categorypage.component.html',
  styleUrls: ['./categorypage.component.css']
})
export class CategorypageComponent implements OnInit {
  categorytCat_Name: string = "Pepe";

  typeOfCategories: Category[] = [];

  constructor(
    private categoryService: CategoryPageService
  ) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(): void {
    this.categoryService.getCategories().subscribe(category => this.typeOfCategories = category);
  }

  addCategory(category_Name: string): void {
    this.categoryService.addCategory({ category_Name } as Category).subscribe(category => { this.typeOfCategories.push(category) });
  }

  deleteCategory(category: Category): void {
    if (confirm('Confirm that you want to delete this category: ${category.category_Name}')) {
      this.typeOfCategories = this.typeOfCategories.filter(a => a !== category);
      this.categoryService.deleteCategory(category.id).subscribe();
    }
  }

}
