import { Component, OnInit } from '@angular/core';
import { Tag } from '../models';
import { TagService } from '../tag.service';

@Component({
  selector: 'app-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.css']
})
export class TagComponent implements OnInit {

  tag: Tag = { name: ""};

  constructor(
    private tagService: TagService
  ) { }

  ngOnInit(): void {
  }

  newTag(): void {
    this.tagService.newTag(this.tag)
    .subscribe();
  }
}
