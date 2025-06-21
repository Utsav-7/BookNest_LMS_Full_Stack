import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { LibrarianRoutingModule } from './librarian-routing.module';
import { LibrarianComponent } from './librarian.component';
import { HomeComponent } from './pages/home/home.component';
import { LibrarianBookListComponent } from './pages/librarian-book-list/librarian-book-list.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { StudentListComponent } from './pages/student-list/student-list.component';
import { BorrowRecordsComponent } from './pages/borrow-records/borrow-records.component';
import { ReturnRecordsComponent } from './pages/return-records/return-records.component';
import { ChartModule } from 'primeng/chart';

@NgModule({
  declarations: [
    LibrarianComponent,
    HomeComponent,
    LibrarianBookListComponent,
    ProfileComponent,
    StudentListComponent,
    BorrowRecordsComponent,
    ReturnRecordsComponent
  ],
  imports: [
    CommonModule,
    LibrarianRoutingModule,
    SharedModule,
    RouterModule,
    ChartModule
  ]
})

export class LibrarianModule { }