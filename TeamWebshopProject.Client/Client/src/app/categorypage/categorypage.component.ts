import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-categorypage',
  templateUrl: './categorypage.component.html',
  styleUrls: ['./categorypage.component.css']
})
export class CategorypageComponent implements OnInit {

  typeOfCategories: string[] = ['Normal Pepe', 'Rare Pepe', 'Exotic Pepe', 'Peepo'];



  constructor() { }

  ngOnInit(): void {
  }

}
