import { Component, OnInit } from '@angular/core';
import { Tag } from '../models';
import { TagService } from '../tag.service';
import { Item } from '../models';

@Component({
  selector: 'app-categorypage',
  templateUrl: './categorypage.component.html',
  styleUrls: ['./categorypage.component.css']
})
export class CategorypageComponent implements OnInit {
  tags: Tag[] = [];

  constructor(private tagService: TagService) { }

  ngOnInit(): void {
    this.getAllTags();

  }

  getAllTags(): void {
    this.tagService.getAllTags().subscribe(tag => this.tags = tag);
  }
}
