import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { Observable } from 'rxjs';
import { Item } from '../models';
import { NewitemService } from '../newitem.service';

@Component({
  selector: 'app-edititem',
  templateUrl: './edititem.component.html',
  styleUrls: ['./edititem.component.css']
})
export class EdititemComponent implements OnInit {
  apiUrl: string = 'https://localhost:44365/apiItem';
  id: number = 0;


  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(
    private edititemservice: NewitemService,
    private http: HttpClient, private route: ActivatedRoute,
  ) {  }

  item: Item = { id: 0, itemType: "", price: 100, discount: 0, discription: "", image: "" };

  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get("id") || 0) as number;
    this.getItem(this.id);
  }
  getItem(id: number):void{
    this.edititemservice.getItem(id)
    .subscribe(i => this.item = i);
  }

  updateItem() : void{
    this.edititemservice.updateItem(this.item)
    .subscribe();
  }
}








