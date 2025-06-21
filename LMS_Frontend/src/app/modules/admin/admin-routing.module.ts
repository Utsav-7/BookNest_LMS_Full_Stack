import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from 'src/app/shared/components/page-not-found/page-not-found.component';
import { AdminComponent } from './admin.component';
import { AdminBooksListComponent } from './pages/admin-books-list/admin-books-list.component';
import { BorrowRecordsComponent } from './pages/borrow-records/borrow-records.component';
import { GenreComponent } from './pages/genre/genre.component';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { SettingsComponent } from './pages/settings/settings.component';
import { UserComponent } from './pages/user/user.component';
import { ReturnRecordsComponent } from './pages/return-records/return-records.component';

const routes: Routes = [
    {
        path: '', component: AdminComponent,
        children: [
            { path: 'home', component: HomeComponent },
            { path: 'books', component: AdminBooksListComponent },
            { path: 'librarians', component: UserComponent },
            { path: 'students', component: UserComponent },
            { path: 'genres', component: GenreComponent },
            { path: 'profile', component: ProfileComponent },
            { path: 'settings', component: SettingsComponent },
            { path: 'borrow', component: BorrowRecordsComponent },
            { path: 'return', component: ReturnRecordsComponent },
            { path: '**', component: PageNotFoundComponent }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminRoutingModule { }