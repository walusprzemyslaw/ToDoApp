import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from '../models/api-models/item.model';
import { GlobalService } from '../global.service';
import { StickyDirection } from '@angular/cdk/table';
import { StatusTodoitemCommand } from '../Dto/status-todoitem-command';
import { CreateTodoitemCommand } from '../Dto/create-todoitem-command';
import { UpdateTodoitemCommand } from '../Dto/update-todoitem-command';
import { DeleteTodoitemCommand } from '../Dto/delete-todoitem-command';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private baseApiUrl = '';

  constructor(private httpClient: HttpClient, private globalService: GlobalService) {
    this.baseApiUrl = this.globalService.baseApiUrl;
  }

  getAllItems(listId: string): Observable<Item[]> {
    return this.httpClient.get<Item[]>(this.baseApiUrl + `/ToDoItems/${listId}`);
  }

  getTodayItems(userid: string): Observable<Item[]> {
    return this.httpClient.get<Item[]>(this.baseApiUrl + `/ToDoItems/${userid}/today`)
  }

  anyTodayItems(userid: string): Observable<boolean> {
    return this.httpClient.get<boolean>(this.baseApiUrl + `/ToDoItems/${userid}/AnyDueDatesToday`)
  }

  getItem(itemId: string): Observable<Item> {
    return this.httpClient.get<Item>(this.baseApiUrl + `/ToDoItems/item/${itemId}`)
  }

  addItem(createTodoitemCommand : CreateTodoitemCommand): Observable<Item> {
    return this.httpClient.post<Item>(this.baseApiUrl + '/ToDoItems', createTodoitemCommand);  
  }

  updateItem(command: UpdateTodoitemCommand) {

    return this.httpClient.put(this.baseApiUrl +  `/ToDoItems`, command, httpOptions); 
  }

  deleteItem(deleteCommand: DeleteTodoitemCommand) {
    return this.httpClient.delete(this.baseApiUrl  + `/ToDoItems/${deleteCommand.toDoItemId}`); 
  }

  changeStatus(statusTodoitemCommand: StatusTodoitemCommand) {
    return this.httpClient.put(this.baseApiUrl + `/ToDoItems/status`, statusTodoitemCommand, httpOptions);
  }

}