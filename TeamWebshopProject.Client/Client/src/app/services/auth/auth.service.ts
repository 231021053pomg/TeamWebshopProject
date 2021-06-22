import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const apiUrl = '';

const httpOptions = {
  headers: new HttpHeaders({ 'Contnet-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    return this.http.post(apiUrl + 'signin', {
       username,
       password
    }, httpOptions);
  }

  reqister(username: string, email: string, password: string): Observable<any> {
    return this.http.post(apiUrl + 'signup', {
      username,
      email,
      password
    }, httpOptions);
  }
}
