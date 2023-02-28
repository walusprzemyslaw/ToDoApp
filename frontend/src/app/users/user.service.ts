import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserDto } from '../Dto/login.dto';
import { GlobalService } from '../global.service';
import { LoginCommand } from '../models/api-models/login-command';
import { RegisterCommand } from '../models/api-models/register-command';
import { BehaviorSubject , map} from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseApiUrl = '';

  private currentUserSource = new BehaviorSubject<UserDto | null>(null)
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private jwtHelper: JwtHelperService, private httpClient: HttpClient, private globalService: GlobalService) { 
    this.baseApiUrl = this.globalService.baseApiUrl;
  }

  register(user: RegisterCommand) {
    return this.httpClient.post<any>(`${this.baseApiUrl}/user/register`, {username : user.username,
       password: user.password, confirmPassword: user.confirmPassword});
  }

  login(user: LoginCommand) {
    return this.httpClient.post<UserDto>(`${this.baseApiUrl}/user/login`, {username : user.username,
       password: user.password}).pipe(
         map((response: UserDto) => {
           const user = response;
           if(user){
            localStorage.setItem('user', JSON.stringify(user));
            this.currentUserSource.next(user);
           }
         })
       );
  }

  logout() {
    localStorage.removeItem('user');
    this.setCurrentUser(null);
  }

  setCurrentUser(user: UserDto | null){
    this.currentUserSource.next(user);
  }

  public isAuthenticated(): boolean {
    const userString = localStorage.getItem('user');
    if(!userString) return false;
    const user: UserDto  = JSON.parse(userString);
    let expired =  this.jwtHelper.isTokenExpired(user.token);
    return !expired;
  }

}
