import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LibrarianComponent } from './librarian.component';
import { HomeComponent } from './pages/home/home.component';
import { LibrarianBookListComponent } from './pages/librarian-book-list/librarian-book-list.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { StudentListComponent } from './pages/student-list/student-list.component';
import { BorrowRecordsComponent } from './pages/borrow-records/borrow-records.component';
import { ReturnRecordsComponent } from './pages/return-records/return-records.component';

const routes: Routes = [
    {
        path: '', component: LibrarianComponent,
        children: [
            { path: 'home', component: HomeComponent },
            { path: 'books', component: LibrarianBookListComponent },
            { path: 'profile', component: ProfileComponent },
            { path: 'students', component: StudentListComponent },
            { path: 'borrow', component: BorrowRecordsComponent },
            { path: 'return', component: ReturnRecordsComponent }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class LibrarianRoutingModule { }