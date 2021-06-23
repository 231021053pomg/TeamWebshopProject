import { Component, OnInit } from '@angular/core';
import { Tag } from '../models';
import { TagService } from '../tag.service';

@Component({
  selector: 'app-all-tags',
  templateUrl: './all-tags.component.html',
  styleUrls: ['./all-tags.component.css']
})
export class AllTagsComponent implements OnInit {

  tags: Tag[] = [];

  constructor(
    private tagService: TagService
  ) { }

  ngOnInit(): void {
    this.getAllTags();
  }

  getAllTags(): void {
    this.tagService.getAllTags()
    .subscribe(tag => this.tags = tag);
  }

  deleteTag(tag: Tag): void {
    if(confirm(`Er du sikker på at du vil slætte: ${tag.name}`)) {
      this.tags = this.tags.filter(t => t !== tag);
      this.tagService.deleteTag(tag).subscribe();
    }
  }
}
