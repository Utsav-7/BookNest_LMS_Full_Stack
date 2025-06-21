import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-admin-dashboard',
    templateUrl: './admin.component.html',
    styleUrls: ['./admin.component.scss']
})

export class AdminComponent {
    public role: 'Administrator' | 'Librarian' | 'Student' = 'Administrator';

    constructor(private router: Router) { }

    public sidebarOptions = [
        {
            section: 'Dashboard',
            items: [
                { label: 'Overview', icon: 'bi bi-speedometer2', route: '/dashboard/administrator/home' }
            ]
        },
        {
            section: 'Library',
            items: [
                { label: 'Books', icon: 'bi bi-book', route: '/dashboard/administrator/books' },
                { label: 'Genres', icon: 'bi bi-tags', route: '/dashboard/administrator/genres' },
            ]
        },
        {
            section: 'Users',
            items: [
                { label: 'Students', icon: 'bi bi-people', route: '/dashboard/administrator/students' },
                { label: 'Librarians', icon: 'bi bi-person-workspace', route: '/dashboard/administrator/librarians' }
            ]
        },
        {
            section: 'Transactions',
            items: [
                { label: 'Borrow', icon: 'bi bi-arrow-up-circle', route: '/dashboard/administrator/borrow' },
                { label: 'Returns', icon: 'bi bi-arrow-down-circle', route: '/dashboard/administrator/return' }
            ]
        },
        {
            section: 'Account',
            items: [
                { label: 'Profile', icon: 'bi bi-person-circle', route: '/dashboard/administrator/profile' },
                { label: 'Settings', icon: 'bi bi-gear', route: '/dashboard/administrator/settings' },
            ]
        }
    ];

    public logout(): void {
        sessionStorage.clear();
        this.router.navigate(['/auth/login']);
    }
}