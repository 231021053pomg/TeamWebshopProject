import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ObservableLike } from 'rxjs';
import { Tag } from './models';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  apiUrl: string = "https://localhost:44365/api/Tag";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(
    private http: HttpClient
  ) { }

  newTag(tag: Tag): Observable<Tag> {
    return this.http.post<Tag>(`${this.apiUrl}`, tag, this.httpOptions);
  }

  getAllTags(): Observable<Tag[]> {
    return this.http.get<Tag[]>(`${this.apiUrl}`, this.httpOptions);
  }

  deleteTag(tag: Tag) : Observable<Tag>{
    return this.http.delete<Tag>(`${this.apiUrl}/${tag.id}`, this.httpOptions);
  };
}
