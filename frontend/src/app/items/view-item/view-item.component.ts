import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Item } from 'src/app/models/api-models/item.model';
import { ItemService } from '../item.service';
import { CreateTodoitemCommand } from 'src/app/Dto/create-todoitem-command';
import { UpdateTodoitemCommand } from 'src/app/Dto/update-todoitem-command';

@Component({
  selector: 'app-view-item',
  templateUrl: './view-item.component.html',
  styleUrls: ['./view-item.component.scss']
})
export class ViewItemComponent implements OnInit {
  itemId: string | null | undefined;
  listId: string | null | undefined;;
  newItem: boolean = false;
  item: Item = {
    toDoItemId: '',
    name: '',
    description: '',
    notes: '',
    dueDate: new Date(),
    createdDate: new Date(),
    status: 0,
    toDoListId: ''
  };

  @ViewChild('itemDetailForm') itemDetailForm?: NgForm;


  constructor(private readonly itemService: ItemService,
    private readonly route: ActivatedRoute,
    private router: Router,
    private location: Location) {
    this.listId = '';
    this.itemId = '';
  }

  ngOnInit(): void {
    this.newItem = this.route.snapshot.url[this.route.snapshot.url.length - 1].path === 'add';

    if (!this.newItem) {
      this.route.paramMap.subscribe(
        (params: any) => {
          this.itemId = params.get('id');

          if (this.itemId) {
            this.itemService.getItem(this.itemId)
              .subscribe(
                (successResponse : any) => {
                  this.item = successResponse;
                }
              );
          }
        }
      );
    }
    else {
      this.route.paramMap.subscribe(
        (params: any) => {
          this.listId = params.get('id');
        })
    }
  }

  onSave(): void {
    if (this.newItem) {
      this.onAdd();
    }
    else {
      this.onUpdate();
    }
  }

  onAdd(): void {
    if (this.itemDetailForm?.form.valid) {
      const createCommand: CreateTodoitemCommand = {
        name: this.item.name,
        description: this.item.description!,
        dueDate: this.item.dueDate.toLocaleDateString(),
        notes: this.item.notes!,
        toDoListId: this.listId!
      };
      this.itemService.addItem(createCommand)
        .subscribe(
          (successResponse: any) => {
            this.goBack();
          }
        );
    }
  }

  onUpdate(): void {
    if (this.itemDetailForm?.form.valid) {
      const command: UpdateTodoitemCommand = {
        name: this.item.name,
        description: this.item.description!,
        dueDate: new Date(this.item.dueDate).toLocaleDateString(),
        notes: this.item.notes!,
        toDoItemId: this.itemId!};
      this.itemService.updateItem(command)
        .subscribe(
          (successResponse :any) => {
            this.goBack();
          }
        );
    }
  }

  goBack() {
    this.location.back();
  }
}
