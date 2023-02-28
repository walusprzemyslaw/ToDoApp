import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CreateTodolistCommand } from 'src/app/Dto/create-todolist-command';
import { UserDto } from 'src/app/Dto/login.dto';
import { UpdateToDoListCommand } from 'src/app/Dto/update-todolist-command';
import { GlobalService } from 'src/app/global.service';
import { List } from 'src/app/models/api-models/list.model';
import { UserService } from 'src/app/users/user.service';
import { ListService } from '../list.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-view-list',
  templateUrl: './view-list.component.html',
  styleUrls: ['./view-list.component.scss']
})
export class ViewListComponent implements OnInit, OnDestroy {
  listId: string | null | undefined;
  userId: string = '';
  newList: boolean = false;
  list: List = {
    toDoListId: '',
    name: '',
    hiddenFinishedItems: false,
    visibility: false,
    items: [],
    userId: '',
    username: '',
  }
  private subscriptions: Subscription[] = [];

  @ViewChild('listDetailForm') listDetailForm?: NgForm;

  constructor(private readonly listService: ListService,
    private readonly route: ActivatedRoute,
    private globalService: GlobalService,
    private router: Router,
    private userServce: UserService) {
    this.listId = '';
  }
  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }
  ngOnInit(): void {
    this.newList = this.route.snapshot.url[this.route.snapshot.url.length - 1].path === 'add';

    if (!this.newList) {
      let parSub = this.route.paramMap.subscribe(
        (params : any) => {
          this.listId = params.get('id');
          if (this.listId) {

            let listSub = this.listService.getList(this.listId)
              .subscribe(
                (successResponse : any) => {
                  this.list = successResponse;
                }
              );
              this.subscriptions.push(listSub);
          }
        }
      );
      this.subscriptions.push(parSub)
    }

    let userSub = this.userServce.currentUser$.subscribe((user: UserDto | null) => {
      this.userId = user?.userId!
      console.log(this.userId)
    })
    this.subscriptions.push(userSub);

  }

  onSave(): void {
    if (this.newList) {
      this.onAdd();
    }
    else {
      this.onUpdate();
    }
  }

  onAdd(): void {
    if (this.listDetailForm?.form.valid) {

      const createCommand: CreateTodolistCommand = {
        name: this.list.name,
        userId: this.userId!
      };

      this.listService.addList(createCommand)
        .subscribe(
          (successResponse : any) => {
            this.router.navigateByUrl(`/lists`);
          },
          (err :any) => console.log(err)
        );
    }
  }

  onUpdate(): void {
    if (this.listDetailForm?.form.valid) {
      const updatedList: UpdateToDoListCommand = {
        name: this.list.name,
        toDoListId: this.listId!
      };
      
      this.listService.updateList(updatedList)
        .subscribe(
          () => {
            this.router.navigateByUrl(`/lists`);
          },
          (err : any) => console.log(err))
    }
  }
}
