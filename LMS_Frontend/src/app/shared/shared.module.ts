import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BookCardComponent } from './components/book-card/book-card.component';
import { BookDetailsCardComponent } from './components/book-details-card/book-details-card.component';
import { BookFormModalComponent } from './components/book-form-modal/book-form-modal.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { DashboardNavbarComponent } from './components/dashboard-navbar/dashboard-navbar.component';
import { IndexComponent } from './components/index/index.component';
import { ProfileCardComponent } from './components/profile-card/profile-card.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TransactionListComponent } from './components/transaction-list/transaction-list.component';
import { UserFormComponent } from './components/user-form/user-form.component';
import { AuthModule } from './modules/auth/auth.module';
import { UserListComponent } from './components/user-list/user-list.component';
import { ReturnBookModalComponent } from './components/return-book-modal/return-book-modal.component';
import { HistoryComponent } from './components/history/history.component';
import { NotificationComponent } from './components/notification/notification.component';
import { RatingModule } from 'primeng/rating';
import { PaginatorModule } from 'primeng/paginator';
import { LoaderComponent } from '../layout/loader/loader.component';

@NgModule({
    declarations: [
        IndexComponent,
        SidebarComponent,
        BookCardComponent,
        DashboardNavbarComponent,
        ProfileCardComponent,
        BookFormModalComponent,
        BookDetailsCardComponent,
        UserFormComponent,
        BookListComponent,
        TransactionListComponent,
        UserListComponent,
        ReturnBookModalComponent,
        HistoryComponent,
        NotificationComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AuthModule,
        RatingModule,
        PaginatorModule,
        RouterModule,
        LoaderComponent
    ],
    exports: [
        IndexComponent,
        SidebarComponent,
        BookCardComponent,
        DashboardNavbarComponent,
        ProfileCardComponent,
        BookFormModalComponent,
        BookDetailsCardComponent,
        BookListComponent,
        UserFormComponent,
        TransactionListComponent,
        UserListComponent,
        HistoryComponent,
        NotificationComponent
    ]
})

export class SharedModule { }