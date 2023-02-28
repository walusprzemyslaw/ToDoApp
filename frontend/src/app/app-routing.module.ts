import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListsComponent } from './lists/lists.component';
import { ItemsComponent } from './items/items.component';
import { ViewListComponent } from './lists/view-list/view-list.component';
import { ViewItemComponent } from './items/view-item/view-item.component';
import { LoginComponent } from './users/login/login.component';
import { RegisterComponent } from './users/register/register.component';
import { AuthGuard } from './users/auth.guard';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  {
    path:'',
    component: ListsComponent
  },
  {
    path: 'lists',
    component: ListsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'lists/edit/:id',
    component: ViewListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'lists/add',
    component: ViewListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'today',
    component: ItemsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'list/:id',
    component: ItemsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'list/:id/add',
    component: ViewItemComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'item/:id',
    component: ViewItemComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'not-found',
    component: NotFoundComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
    pathMatch: 'full'
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
