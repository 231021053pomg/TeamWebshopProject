import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Category } from 'src/app/models/domain';

@Injectable({
  providedIn: 'root'
})

export class CategoryPageService {
  apiUrl: string = 'https://localhost:44365/api/Item';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  getCategory(id: number): Observable<Category> {
    return this.http.get<Category>('${this.apiUrl}/${id}').pipe(catchError(
      this.handleError<any>("getCategory")));
  }

  addCategory(category: Category): Observable<Category> {
    return this.http.post<Category>(this.apiUrl, category, this.httpOptions).pipe(
      catchError(this.handleError<Category>('addCategory')));
  }

  updateCategory(id: number, category: Category): Observable<Category> {
    return this.http.put<Category>('${this.apiUrl}/${id}', category, this.httpOptions).pipe(
      catchError(this.handleError<any>("udpateCategory")));
  }

  deleteCategory(id: number): Observable<Category> {
    return this.http.delete<Category>('${this.apiUrl}/${id}', this.httpOptions).pipe(
      catchError(this.handleError<any>('deleteCategory')));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}
