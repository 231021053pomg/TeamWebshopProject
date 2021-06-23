import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Item } from './models';

@Injectable({
  providedIn: 'root'
})
export class NewitemService {
  apiUrl: string = 'https://localhost:44365/apiItem'
  

  httpsOptions = {
    headers: new HttpHeaders({ 'Content-Type' : 'application/json'})
  }
  constructor(
    private http: HttpClient
  ) { }
getItem(id:number) : Observable<Item>{
  return this.http.get<Item>(`${this.apiUrl}/${id}`, this.httpsOptions)
  .pipe(catchError(this.handleError<any>("getItem")));
}

updateItem(item:Item) : Observable<Item>{
  return this.http.put<Item>(`${this.apiUrl}/${item.id}`, item, this.httpsOptions)
  .pipe(catchError(this.handleError<any>("updateItem")));
}

postItem(item:Item) : Observable<Item>{
  return this.http.post<Item>(`${this.apiUrl}`, item, this.httpsOptions)
  .pipe(catchError(this.handleError<any>("postItem")))
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
