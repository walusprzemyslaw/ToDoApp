import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserDto } from '../Dto/login.dto';
import { ListService } from '../lists/list.service';
import { Item } from '../models/api-models/item.model'
import { UserService } from '../users/user.service';
import { ItemService } from './item.service';
import { MatTableDataSource } from '@angular/material/table';
import { StatusTodoitemCommand } from '../Dto/status-todoitem-command';
import { DeleteTodoitemCommand } from '../Dto/delete-todoitem-command';
import { VisibilityOfFinishedItemsCommand } from '../Dto/visibility-of-finished-items-command';
import { List } from '../models/api-models/list.model';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.scss']
})
export class ItemsComponent implements OnDestroy {
  dataSource: MatTableDataSource<Item> = new MatTableDataSource<Item>([]);

  listId: string;
  items: Item[] = [];
  displayedColumns: string[] = ['status', 'name', 'options'];
  todayMode: boolean = false;
  visibilityOfFinishedItems: boolean | null | undefined;
  private subscriptions: Subscription[] = [];

  constructor(private itemsService: ItemService, 
    private listService: ListService,
    private readonly route: ActivatedRoute,
    private router: Router,
    private userService: UserService
    ) {
    this.listId = '';
  }

  ngOnInit(): void {
    this.todayMode = this.route.snapshot.url[this.route.snapshot.url.length - 1].path === 'today';

    if (this.todayMode) {
      this.todayInitialize();
    }
    else {
      this.normalInitialize();
    }
 }

  private todayInitialize() {
    let userSub = this.userService.currentUser$.subscribe((userDto: UserDto | null) => {
      let itemsSub = this.itemsService.getTodayItems(userDto?.userId ?? '')
        .subscribe(
          (successResponse: Item[]) => {
            this.items = successResponse;
            this.dataSource = new MatTableDataSource(this.items);
          },
          (errorResponse: Item[]) => {
            console.log(errorResponse);
          }
        );
      this.subscriptions.push(itemsSub);
    },
      (err: any) => console.log(err));
    this.subscriptions.push(userSub);
  }
  private normalInitialize() {
    let paramSub = this.route.paramMap.subscribe(
      (params: any) => {
        this.listId = params.get('id') ?? '';
        if (this.listId) {
          let itemSub = this.itemsService.getAllItems(this.listId)
            .subscribe(
              (succsessResponse: Item[]) => {
                this.items = succsessResponse;
                this.dataSource = new MatTableDataSource(this.items);
              },
              (errorResponse: Item[]) => {
                console.log(errorResponse);
              });
          this.subscriptions.push(itemSub);

          let listSub = this.listService.getList(this.listId)
              .subscribe(
              (successResponse: List) => {
                this.visibilityOfFinishedItems = successResponse.hiddenFinishedItems;
              },
              (errorResponse: List) => {
                console.log(errorResponse);
              });
          this.subscriptions.push(listSub);
        }
      }
    );
    this.subscriptions.push(paramSub);
  }

  onChangeStatus(itemId: string, status: number): void {
    const statusTodoitemCommand: StatusTodoitemCommand = {
      statusDto: status,
      toDoItemId: itemId
    };
    let statusSub = this.itemsService.changeStatus(statusTodoitemCommand)
    .subscribe(
      (successResponse: any) => {
        let item = this.items.find(i => i.toDoItemId === itemId);
        if(item){
          item.status = status;
          this.updateDataSource();
        }
        if (this.todayMode){
          this.router.navigateByUrl(`/today`);
        }
        else{
          this.router.navigateByUrl(`/list/${this.listId}`);
        }
      }
    );
    this.subscriptions.push(statusSub)
  }

  onDelete(itemId: string): void {
    const deleteCommand: DeleteTodoitemCommand = {
      toDoItemId: itemId
    };
    let deleteSub = this.itemsService.deleteItem(deleteCommand)
    .subscribe(
      (successResponse :any) => {
        let index = this.items.findIndex(item => item.toDoItemId === deleteCommand.toDoItemId);
        if (index !== -1) {
          this.items.splice(index, 1);
        }          
        this.updateDataSource();
        if (this.todayMode){
          this.router.navigateByUrl(`/today`);
        }
        else{
          this.router.navigateByUrl(`/list/${successResponse.toDoListId}`);
        }
      },
      (err : any) => console.log(err)
    )
    this.subscriptions.push(deleteSub)
  }

  onChangeVisibilityOfFinishedItems(visibility: boolean): void {
    const listVisibilityCommand: VisibilityOfFinishedItemsCommand = {
      listId: this.listId
    };
    let visSub = this.listService.changeVisibilityOfFinishedItems(listVisibilityCommand)
    .subscribe(
      (successResponse: boolean) => {
        this.visibilityOfFinishedItems = successResponse;
      }
    );
    this.subscriptions.push(visSub);
  }
  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }
  updateDataSource(){
    this.dataSource.data = this.items;
    this.dataSource._updateChangeSubscription();
  }
}
