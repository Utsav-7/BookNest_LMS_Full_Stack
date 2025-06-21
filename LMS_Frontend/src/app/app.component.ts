import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { TokenService } from './shared/services/token.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  public showHeaderFooter = true;
  private dashboardRoutes = ['/dashboard/administrator', '/dashboard/librarian', '/dashboard/student'];

  constructor(private router: Router, private tokenService: TokenService) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.updateHeaderFooterVisibility(event.url);
      }
    });
  }

  private updateHeaderFooterVisibility(currentUrl: string): void {
    const token = this.tokenService.getValidToken();
    const isDashboardRoute = this.dashboardRoutes.some(route => currentUrl.startsWith(route));
    this.showHeaderFooter = !(isDashboardRoute || (token && !isDashboardRoute));
  }
}