  import { Component, OnInit } from '@angular/core';
import { Item } from '../models';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProductPageService } from '../product-page.service';
import { ActivatedRoute } from '@angular/router';

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
    private http: HttpClient,   private route: ActivatedRoute,) {

   }


    id: number = 0;
    item: Item = { id: 0, itemType: "", price: 0, discount: 0, discription: "", image: "" };
  
  
      
     

  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get("id") || 0) as number;
    this.getItem(this.id);
    
  }

  getItem(id: number): void {
    this.productpageservice.getItem(id)
    .subscribe(i => this.item = i);


    
  }

}
