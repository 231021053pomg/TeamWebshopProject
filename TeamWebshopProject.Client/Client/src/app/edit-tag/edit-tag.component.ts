import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Tag } from '../models';
import { TagService } from '../tag.service';

@Component({
  selector: 'app-edit-tag',
  templateUrl: './edit-tag.component.html',
  styleUrls: ['./edit-tag.component.css']
})
export class EditTagComponent implements OnInit {

  id: number = 0;
  tag: Tag = { name: "" };

  constructor(
    private tagService: TagService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.id = (this.route.snapshot.paramMap.get("id") || 0) as number;
    this.getTag(this.id);
  }

  getTag(id: number) {
    this.tagService.getTag(id)
    .subscribe(t => this.tag = t);
  }

  updateTag(): void {
    this.tagService.updateTag(this.tag)
    .subscribe();
  }

}
