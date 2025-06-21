import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-admin-dashboard',
    templateUrl: './student.component.html',
    styleUrls: ['./student.component.scss']
})

export class StudentComponent {
    public role: 'Administrator' | 'Librarian' | 'Student' = 'Student';

    constructor(private router: Router) { }

    public sidebarOptions = [
        {
            section: 'Dashboard',
            items: [
                { label: 'Overview', icon: 'bi bi-speedometer2', route: '/dashboard/student/home' }
            ]
        },
        {
            section: 'Library',
            items: [
                { label: 'Books', icon: 'bi bi-book', route: '/dashboard/student/books' }
            ]
        },
        {
            section: 'Favorites',
            items: [
                { label: 'WishList', icon: 'bi bi-bookmark-heart', route: '/dashboard/student/wishlist' },
            ]
        },
        {
            section: 'Transactions',
            items: [
                { label: 'History', icon: 'bi bi-clock-history', route: '/dashboard/student/history' },
                { label: 'Borrow List', icon: 'bi bi-arrow-up-circle', route: '/dashboard/student/borrow-list' },
            ]
        },
        {
            section: 'Account',
            items: [
                { label: 'Profile', icon: 'bi bi-person-circle', route: '/dashboard/student/profile' }
            ]
        }
    ];

    public logout(): void {
        sessionStorage.clear();
        this.router.navigate(['/auth/login']);
    }
}