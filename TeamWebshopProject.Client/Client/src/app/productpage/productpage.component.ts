import { Component, OnInit } from '@angular/core';
import { Item } from '../models';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProductPageService } from '../product-page.service';

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

  constructor( private http: HttpClient) { }

    id: number = 0;
    item: Item = {itemType: "", price: 0, discount: 0, discription: "", image: "" };
  
  
      
     

  ngOnInit(): void {
  }

  getItem(id: number): Observable<Item> {
    return this.http.get<Item>(`${this.apiUrl}/${id}`, this.httpOptions)
    .pipe(catchError(this.handleError<any>("getItem")));


    
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
