import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { StudentComponent } from './student.component';
import { PageNotFoundComponent } from 'src/app/shared/components/page-not-found/page-not-found.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { StudentBookListComponent } from './pages/student-book-list/student-book-list.component';
import { BorrowListComponent } from './pages/borrow-list/borrow-list.component';
import { UserHistoryComponent } from './pages/user-history/user-history.component';
import { WishlistComponent } from './pages/wishlist/wishlist.component';

const routes: Routes = [
    {
        path: '', component: StudentComponent,
        children: [
            { path: 'home', component: HomeComponent },
            { path: 'books', component: StudentBookListComponent },
            { path: 'profile', component: ProfileComponent },
            { path: 'history', component: UserHistoryComponent },
            { path: 'wishlist', component: WishlistComponent },
            { path: 'borrow-list', component: BorrowListComponent },
            { path: '**', component: PageNotFoundComponent }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class StudentRoutingModule { }