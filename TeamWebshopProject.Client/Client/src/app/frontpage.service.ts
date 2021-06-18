import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { Item } from './models';
import { ThrowStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class FrontpageService {
  apiUrl: string = 'https://localhost:44365/apiItem'

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  }
  constructor( private http: HttpClient) {}

  getNewItems(): Observable<Item[]>{
    return this.http.get<Item[]>(`${this.apiUrl}`, this.httpOptions);
  }
}
