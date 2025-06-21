import { isPlatformBrowser } from '@angular/common';
import { Component, inject, PLATFORM_ID } from '@angular/core';
import { StudentDashboardStatService } from 'src/app/core/services/student-dashboard-stat.service';
import { IRecentIssuesBook } from 'src/app/data/models/dashboard/recentIssuesBook';
import { INavOptions } from 'src/app/data/models/navOption';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {
  public dashboardCards: INavOptions[] = [];
  public recentIssues: IRecentIssuesBook[] = [];
  public loadingIssues = true;
  public loadingStats = true;
  public data: any;
  public options: any;

  private platformId = inject(PLATFORM_ID);
  private dashboardService = inject(StudentDashboardStatService);

  public ngOnInit(): void {
    this.initializeDashboardCards();
    this.fetchDashboardStats();
    this.initChart();
  }

  public initializeDashboardCards(): void {
    this.dashboardCards = [
      { title: 'Total Borrowed Books', value: '--', subtext: 'Loading...', icon: 'bi bi-journal-arrow-up', subtextClass: 'text-muted' },
      { title: 'Total Returned Books', value: '--', subtext: 'Loading...', icon: 'bi bi-journal-arrow-down', subtextClass: 'text-muted' },
      { title: 'Wishlisted Books', value: '--', subtext: 'Loading...', icon: 'bi bi-heart', subtextClass: 'text-muted' },
      { title: 'Book Reviews', value: '--', subtext: 'Loading...', icon: 'bi bi-chat-left-text', subtextClass: 'text-muted' }
    ];
  }

  public initChart(): void {
    if (isPlatformBrowser(this.platformId)) {
      const documentStyle = getComputedStyle(document.documentElement);
      const textColor = documentStyle.getPropertyValue('--text-color');

      this.data = {
        labels: ['Returned Books', 'Borrowed Books'],
        datasets: [
          {
            data: [0, 0, 0],
            backgroundColor: [
              documentStyle.getPropertyValue('--green-500'),
              documentStyle.getPropertyValue('--orange-500')
            ],
            hoverBackgroundColor: [
              documentStyle.getPropertyValue('--green-400'),
              documentStyle.getPropertyValue('--orange-400')
            ]
          }
        ]
      };

      this.options = {
        plugins: {
          legend: {
            labels: {
              usePointStyle: true,
              color: textColor
            }
          },
          tooltip: {
            callbacks: {
              label: (context: any) => {
                const label = context.label || '';
                const value = context.raw || 0;
                return `${label}: ${value}`;
              }
            }
          }
        }
      };
    }
  }

  public fetchDashboardStats(): void {
    this.loadingStats = true;
    this.loadingIssues = true;

    this.dashboardService.getDashboardStat().subscribe({
      next: (response: any) => {
        const stats = response.data;

        if (isPlatformBrowser(this.platformId)) {
          this.data = {
            ...this.data,
            datasets: [{
              ...this.data.datasets[0],
              data: [
                stats.totalBooks || 0,
                stats.borrowedBook || 0,
                stats.returnedBook || 0
              ]
            }]
          };
        }

        this.dashboardCards = [
          {
            title: 'Total Borrowed Books',
            value: (stats.borrowedBook || 0).toString(),
            subtext: '',
            icon: 'bi bi-journal-arrow-up',
            subtextClass: 'text-warning'
          },
          {
            title: 'Total Returned Books',
            value: (stats.returnedBook || 0).toString(),
            subtext: '',
            icon: 'bi bi-journal-arrow-down',
            subtextClass: 'text-success'
          },
          {
            title: 'Wishlisted Books',
            value: (stats.wishlistedBook || 0).toString(),
            subtext: '',
            icon: 'bi bi-heart',
            subtextClass: 'text-danger'
          },
          {
            title: 'Book Reviews',
            value: (stats.totalReview || 0).toString(),
            subtext: '',
            icon: 'bi bi-chat-left-text',
            subtextClass: 'text-info'
          }
        ];

        this.recentIssues = (stats.recentIssuedBooks || []).map((book: IRecentIssuesBook) => ({
          title: book?.title || 'Unknown Book',
          studentName: book?.studentName || 'Unknown Student',
          issueDate: book?.issueDate || 'Unknown Student',
          dueDate: book?.dueDate ? new Date(book.dueDate) : null
        }));

        this.loadingStats = false;
        this.loadingIssues = false;
      },
      error: (error) => {
        console.error('Error fetching dashboard stats:', error);
        this.loadingStats = false;
        this.loadingIssues = false;

        this.dashboardCards.forEach(card => {
          card.value = 'Error';
          card.subtext = 'Failed to load data';
          card.subtextClass = 'text-danger';
        });
      }
    });
  }
}