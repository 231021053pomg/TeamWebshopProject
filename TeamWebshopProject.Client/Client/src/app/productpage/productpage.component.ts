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

    /**
    * Handle Http operation that failed.
    * Let the app continue.
    * @param operation - name of the operation that failed
    * @param result - optional value to return as the observable result
    */
     private handleError<T>(operation = 'operation', result?: T) {
      return (error: any): Observable<T> => {
         // TODO: send the error to remote logging infrastructure
         console.error(error); // log to console instead
  
         // TODO: better job of transforming error for user consumption
         console.log(`${operation} failed: ${error.message}`);
  
         // Let the app keep running by returning an empty result.
         return of(result as T);
      };
    }
}
