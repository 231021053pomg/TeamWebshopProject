import { TOUCH_BUFFER_MS } from '@angular/cdk/a11y';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Basket, BasketItem, Item } from './models';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  url = {
    basket: 'https://localhost:44365/api/Basket',
    basketItem: 'https://localhost:44365/apiBasketItem',
  };
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  basket: Basket = { customer: {
    login: {
      id: 1,
      accessType: "Customer",
      email: "email@email.email",
      password: "password",
    },
    credit: {
      "creditAmount": 100,
      "id": 4
    },
    userName: "Username",
    firstName: "FirstName",
    lastName: "LastName",
    birthDay: new Date,
    addressStreet: "Streetname",
    addressNumber: 420,
    addressPostCode: 1337,
  }, quantity: 0, price: 0, created: new Date};

  constructor(private http: HttpClient) {
    this.getBasket();
   }

  getBasket(): Observable<Basket> {
    // var basket = localStorage.getItem("basket") as Basket;
    // if(basket != null) {
    //   this.basket = basket;
    // }
    // else {
      // localStorage.setItem("basket", JSON.stringify(basket));
    // }
    return this.basket as Observable<Basket>;
  }

  addBasketItem(item: Item, quantity: number): Observable<BasketItem> {
    var basketItem: BasketItem = { basket: this.basket, item: item, quantity: quantity};

    console.log("Item:");
    console.log(basketItem);

    return this.http.post<BasketItem>(`${this.url.basketItem}`, basketItem, this.httpOptions)
      .pipe(catchError(this.handleError<any>("addBasketItem")));
  }

  removeBasketItem(item: BasketItem): Observable<BasketItem> {
    return this.http.delete<BasketItem>(`${this.url.basketItem}/${item.id}`, this.httpOptions)
    .pipe(catchError(this.handleError<any>("removeBasketItem")));
  }

  initializeBasket(): Observable<Basket> {
    return this.http.post<Basket>(`${this.url.basket}`, this.basket, this.httpOptions)
    .pipe(catchError(this.handleError<any>("initializeBasket")));
  }

  getBasketItems(basket: number): Observable<BasketItem[]> {
    return this.http.get<BasketItem[]>(`${this.url.basketItem}/byBasket/${basket}`)
    .pipe(catchError(this.handleError<any>("getBasketItems")));
  }

  finalizeBasket() {

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
