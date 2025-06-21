import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { NotificationService } from 'src/app/core/services/notification.service';

@Component({
  selector: 'app-dashboard-navbar',
  templateUrl: './dashboard-navbar.component.html',
  styleUrls: ['./dashboard-navbar.component.scss'],
})

export class DashboardNavbarComponent implements OnInit {
  public showNotifications = false;
  public notificationCount = 0;
  @Input() role!: 'Administrator' | 'Librarian' | 'Student';

  constructor(
    private router: Router,
    private messageService: MessageService,
    private notificationService: NotificationService
  ) { }

  public ngOnInit(): void {
    if (this.role === 'Student') {
      this.getNotificationCount();
    }
  }

  public getNotificationCount(): void {
    this.notificationService.unreadNotificationCount().subscribe({
      next: (count) => {
        this.notificationCount = count.data;
      },
      error: (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to get notification count.',
        })
      }
    });
  }

  public logout(): void {
    sessionStorage.clear();
    this.router.navigate(['/auth/login']);
    this.messageService.add({
      severity: 'success',
      summary: 'Logged Out',
      detail: 'You have been successfully logged out.',
      life: 3000
    });
  }

  public toggleNotifications(): void {
    this.showNotifications = !this.showNotifications;
    if (!this.showNotifications) {
      this.getNotificationCount();
    }
  }
}