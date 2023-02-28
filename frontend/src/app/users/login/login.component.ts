import { Component, OnDestroy, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { LoginCommand } from '../../models/api-models/login-command';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnDestroy{

  username: string = '';
  password: string = '';
  private subscriptions: Subscription[] = [];

  constructor(
    private userService: UserService, 
    private router: Router,
    private toastr: ToastrService) { }


  @ViewChild('userDetailForm') userDetailForm?: NgForm;

  onSubmit() {
    const command = {username : this.username, password: this.password} as LoginCommand;
    let sub = this.userService.login(command).subscribe({
      next: () => { 
        this.router.navigate(['/']); 
      },
      error: (error: any) => {
        console.log(error)
        this.toastr.error(error)
      }
    });
    this.subscriptions.push(sub);
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }
}
