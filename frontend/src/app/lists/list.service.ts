import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { List } from '../models/api-models/list.model';
import { GlobalService } from '../global.service';
import { UpdateToDoListCommand } from '../Dto/update-todolist-command';
import { CreateTodolistCommand } from '../Dto/create-todolist-command';
import { VisibilityToDoListCommand } from '../Dto/visibility-todolist-command';
import { CloneToDoListCommand } from '../Dto/clone-todolist-command';
import { DeleteTodolistCommand } from '../Dto/delete-todolist-command';
import { VisibilityOfFinishedItemsCommand } from '../Dto/visibility-of-finished-items-command';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class ListService {

  private baseApiUrl = '';

  
  constructor(private httpClient: HttpClient, private globalService: GlobalService) {
    this.baseApiUrl = this.globalService.baseApiUrl;
  }

  addList(command : CreateTodolistCommand) {
    return this.httpClient.post<List>(this.baseApiUrl + '/ToDoList', command); 
  }

  getAllLists(userId: string): Observable<List[]> {
    return this.httpClient.get<List[]>(this.baseApiUrl + `/ToDoList/${userId}/lists`);
  }

  getList(listId: string): Observable<List> {
    return this.httpClient.get<List>(this.baseApiUrl + `/ToDoList/${listId}/list`); 
  }

  changeVisibilityOfToDoList(listId: VisibilityToDoListCommand) : Observable<boolean>{
    return this.httpClient.put<boolean>(this.baseApiUrl + `/ToDoList/visibilityOfList`, {ListId: listId.listId}, httpOptions);
  }

  changeVisibilityOfFinishedItems(listId: VisibilityOfFinishedItemsCommand) : Observable<boolean>{
    return this.httpClient.put<boolean>(this.baseApiUrl + `/ToDoList/visibilityOfFinishedItems`, {ListId: listId.listId}, httpOptions);
  }

  updateList(list: UpdateToDoListCommand) {
    return this.httpClient.put<UpdateToDoListCommand>(this.baseApiUrl + `/ToDoList`, list, httpOptions); 
  }

  deleteList(command: DeleteTodolistCommand) {
    return this.httpClient.delete(this.baseApiUrl + `/ToDoList/${command.toDoListId}`);
  }

  cloneList(cloneCommand: CloneToDoListCommand): Observable<List> {
    return this.httpClient.put<List>(this.baseApiUrl + '/ToDoList/clone',{ListId: cloneCommand.listId}, httpOptions );
  }
}
