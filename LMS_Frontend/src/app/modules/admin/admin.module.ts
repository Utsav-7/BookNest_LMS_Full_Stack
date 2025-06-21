import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ChartModule } from 'primeng/chart';
import { SharedModule } from 'src/app/shared/shared.module';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { AdminBooksListComponent } from './pages/admin-books-list/admin-books-list.component';
import { BorrowRecordsComponent } from './pages/borrow-records/borrow-records.component';
import { GenreComponent } from './pages/genre/genre.component';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { ReturnRecordsComponent } from './pages/return-records/return-records.component';
import { SettingsComponent } from './pages/settings/settings.component';
import { UserComponent } from './pages/user/user.component';

@NgModule({
  declarations: [
    AdminComponent,
    HomeComponent,
    AdminBooksListComponent,
    UserComponent,
    GenreComponent,
    ProfileComponent,
    SettingsComponent,
    BorrowRecordsComponent,
    ReturnRecordsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AdminRoutingModule,
    RouterModule,
    SharedModule,
    ChartModule
  ]
})

export class AdminModule { }