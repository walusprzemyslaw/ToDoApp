import { Component, OnDestroy, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { RegisterCommand } from '../../models/api-models/register-command';
import { UserService } from '../user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnDestroy{
  username: string = '';
  password: string = '';
  confirmedPassword: string = '';
  private subscriptions: Subscription[] = [];

  constructor(
    private userService: UserService, 
    private router: Router,
    private toastr: ToastrService) { }

    @ViewChild('userDetailForm') userDetailForm?: NgForm;

    onSubmit(): void {
      if (this.userDetailForm?.form.valid){
        const command = {username : this.username, password: this.password, confirmPassword: this.confirmedPassword} as RegisterCommand;
        let sub = this.userService.register(command).subscribe(
          () => {
            this.router.navigate(['/']);
          },
          (error : any) => {
            this.toastr.error(error);
            console.log(error);
          }
        );
        this.subscriptions.push(sub)
      }
    }

    ngOnDestroy(): void {
      this.subscriptions.forEach(s => s.unsubscribe());
    }
}
