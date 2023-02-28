import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserDto } from '../Dto/login.dto';
import { List } from '../models/api-models/list.model';
import { UserService } from '../users/user.service';
import { ListService } from './list.service';
import { CloneToDoListCommand } from '../Dto/clone-todolist-command';
import { VisibilityToDoListCommand } from '../Dto/visibility-todolist-command';
import { DeleteTodolistCommand } from '../Dto/delete-todolist-command';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.scss']
})
export class ListsComponent implements OnInit, OnDestroy {
  isLoggedIn: boolean = false;
  lists: List[] = [];
  displayedColumns: string[] = ['name', 'options'];
  showHidenLists: boolean = false;
  dataSource: MatTableDataSource<List> = new MatTableDataSource<List>([]);
  
  private subscriptions: Subscription[] = [];

  constructor(
    private listService: ListService,
    private router: Router,
    private userService: UserService) {
     }

  ngOnInit(): void {
    let sub = this.userService.currentUser$.subscribe(
      (res: UserDto | null) =>{
        if(res){
          this.isLoggedIn = true;
          this.getLists(res);        }
      },
      (err: any) => console.log(err)
    );
    this.subscriptions.push(sub);
  }


  private getLists(res: UserDto) {
    let sub = this.listService.getAllLists(res.userId)
      .subscribe((successResponse: List[]) => {
            this.lists = successResponse;
            this.dataSource = new MatTableDataSource(this.lists);
          },
          (errorResponse: any) => {
            console.log(errorResponse);
          }
      );
      this.subscriptions.push(sub);
  }

  onDelete(listId: string): void {
    const deleteCommand: DeleteTodolistCommand = {
      toDoListId: listId
    };
    this.listService.deleteList(deleteCommand)
      .subscribe(
        (successResponse: any) => {
          let index = this.lists.findIndex(item => item.toDoListId === deleteCommand.toDoListId);
          if (index !== -1) {
            this.lists.splice(index, 1);
          }          
          this.updateDataSource();
          this.router.navigateByUrl(`/lists`);
        },
        (err : any) => console.log(err)
      );
  }


  onChangeVisibility(listId: string): void {
    const listVisibility: VisibilityToDoListCommand = {
      listId: listId
    };
    let visSub = this.listService.changeVisibilityOfToDoList(listVisibility)
      .subscribe(
        (successResponse : boolean) => {
          let list = this.lists.find(x => x.toDoListId === listId);
          if(list){
            list.visibility = successResponse
            this.updateDataSource();
          }
          this.router.navigateByUrl(`/lists`);
        }
      );
      this.subscriptions.push(visSub)
  }

  onClone(listId: string): void {
    const cloneCommand: CloneToDoListCommand = {
      listId: listId
    };

    this.listService.cloneList(cloneCommand)
      .subscribe(
        (successResponse : List) => {
          this.lists.push(successResponse);
          this.updateDataSource();
          this.router.navigateByUrl(`/lists`);
        },
        (err: any) => console.log(err)
      );
  }
  
  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }
  updateDataSource(){
    this.dataSource.data = this.lists;
    this.dataSource._updateChangeSubscription();
  }
}
