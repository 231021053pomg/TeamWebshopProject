import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { Observable } from 'rxjs';
import { Item } from '../models';
import { NewitemService } from '../newitem.service';

@Component({
  selector: 'app-newitem',
  templateUrl: './newitem.component.html',
  styleUrls: ['./newitem.component.css']
})
export class NewitemComponent implements OnInit {
  apiUrl: string = 'https://localhost:44365/apiItem';
  id: number = 0;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private newitemservice: NewitemService,
    private http: HttpClient, private route: ActivatedRoute,

  ) { }

  
  item: Item = { itemType: "", price: 100, discount: 0, discription: "", image: "", tags: [] };

  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get("id") || 0) as number;
    this.getItem(this.id);
    
  }

  getItem(id: number):void{
    this.newitemservice.getItem(id)
    .subscribe(i => this.item = i);
  }

  postItem() : void{
    console.log(this.item);
    this.newitemservice.postItem(this.item)
    .subscribe(i => this.item = i);
  }



    
}
