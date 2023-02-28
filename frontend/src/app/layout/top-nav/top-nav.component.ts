import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { OnSameUrlNavigation, Router } from '@angular/router';
import { filter, interval, Subscription, switchMap, tap } from 'rxjs';
import { UserDto } from '../../Dto/login.dto';
import { ItemService } from '../../items/item.service';
import { Item } from '../../models/api-models/item.model';
import { UserService } from '../../users/user.service';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.scss']
})
export class TopNavComponent implements OnInit, OnDestroy {
  anyTodayItems: boolean = false;
  isLoggedIn: boolean = false;
  private subscriptions: Subscription[] = [];
  constructor(private itemsService: ItemService,
    private userService: UserService,
    private router: Router) {
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  ngOnInit(): void {
  let initSub = this.userService.currentUser$.pipe(
      filter(user => user != null),
      tap(user => {
        this.isLoggedIn = true;
      }),
      switchMap(user => interval(1000).pipe(
        tap(() => {
          if (user && this.isLoggedIn) {
          this.getTodayItem(user)
          }
        })
      ))
    ).subscribe();
  }


  private getTodayItem(user: UserDto) {
    this.itemsService.anyTodayItems(user.userId)
      .subscribe(
        (successResponse: any) => {
          this.anyTodayItems = successResponse;
        },
        (errorResponse: any) => {
          console.log(errorResponse);
        }
      );
  }

  onLogOut() {
    this.userService.logout();
    this.isLoggedIn = false;
    this.router.navigateByUrl(`/today`);
  }
}
