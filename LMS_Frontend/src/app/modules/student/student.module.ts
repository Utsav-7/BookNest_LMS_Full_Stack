import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ChartModule } from 'primeng/chart';
import { SharedModule } from 'src/app/shared/shared.module';
import { BorrowListComponent } from './pages/borrow-list/borrow-list.component';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { StudentBookListComponent } from './pages/student-book-list/student-book-list.component';
import { UserHistoryComponent } from './pages/user-history/user-history.component';
import { WishlistComponent } from './pages/wishlist/wishlist.component';
import { StudentRoutingModule } from './student-routing.module';
import { StudentComponent } from './student.component';

@NgModule({
  declarations: [
    StudentComponent,
    HomeComponent,
    ProfileComponent,
    StudentBookListComponent,
    BorrowListComponent,
    UserHistoryComponent,
    WishlistComponent
  ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    SharedModule,
    ChartModule,
    RouterModule
  ]
})

export class StudentModule { }