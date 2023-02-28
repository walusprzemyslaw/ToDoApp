import { Component, OnInit } from '@angular/core';
import { UserDto } from './Dto/login.dto';
import { UserService } from './users/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  constructor(private userService: UserService){}

  ngOnInit(): void {
    if(this.userService.isAuthenticated())
      this.setCurrentUser();
  }

  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if(!userString) return;
    const user: UserDto  = JSON.parse(userString);
    this.userService.setCurrentUser(user);
  }
}
