import { Component, OnInit, inject, PLATFORM_ID } from '@angular/core';
import { DashboardService } from 'src/app/core/services/dashboard.service';
import { isPlatformBrowser } from '@angular/common';
import { INavOptions } from 'src/app/data/models/navOption';
import { IRecentIssuesBook } from 'src/app/data/models/dashboard/recentIssuesBook';

@Component({
  selector: 'app-admin-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})

export class HomeComponent implements OnInit {
  public dashboardCards: INavOptions[] = [];
  public recentIssues: IRecentIssuesBook[] = [];
  public loadingIssues = true;
  public loadingStats = true;
  public data: any;
  public options: any;

  private platformId = inject(PLATFORM_ID);
  private dashboardService = inject(DashboardService);

  public ngOnInit(): void {
    this.initializeDashboardCards();
    this.fetchDashboardStats();
    this.initChart();
  }

  public initializeDashboardCards(): void {
    this.dashboardCards = [
      { title: 'Total Books', value: '--', subtext: 'Loading...', icon: 'bi bi-book', subtextClass: 'text-muted' },
      { title: 'Total Book Copies', value: '--', subtext: 'Loading...', icon: 'bi bi-book', subtextClass: 'text-muted' },
      { title: 'Issued Books', value: '--', subtext: 'Loading...', icon: 'bi bi-journal-arrow-up', subtextClass: 'text-muted' },
      { title: 'Returned Books', value: '--', subtext: 'Loading...', icon: 'bi bi-journal-arrow-down', subtextClass: 'text-muted' },
      { title: 'Total Students', value: '--', subtext: 'Loading...', icon: 'bi bi-people', subtextClass: 'text-muted' },
      { title: 'Total Librarians', value: '--', subtext: 'Loading...', icon: 'bi bi-person-workspace', subtextClass: 'text-muted' },
      { title: 'Book Reviews', value: '--', subtext: 'Loading...', icon: 'bi bi-chat-left-text', subtextClass: 'text-muted' },
      { title: 'Total Categories', value: '--', subtext: 'Loading...', icon: 'bi bi-tags', subtextClass: 'text-muted' }
    ];
  }

  public initChart(): void {
    if (isPlatformBrowser(this.platformId)) {
      const documentStyle = getComputedStyle(document.documentElement);
      const textColor = documentStyle.getPropertyValue('--text-color');

      this.data = {
        labels: ['Total Copies', 'Borrowed Books', 'Returned Books'],
        datasets: [
          {
            data: [0, 0, 0],
            backgroundColor: [
              documentStyle.getPropertyValue('--blue-500'),
              documentStyle.getPropertyValue('--orange-500'),
              documentStyle.getPropertyValue('--green-500')
            ],
            hoverBackgroundColor: [
              documentStyle.getPropertyValue('--blue-400'),
              documentStyle.getPropertyValue('--orange-400'),
              documentStyle.getPropertyValue('--green-400')
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
              data: [stats.totalCopies, stats.borrowedBooks, stats.returnedBooks]
            }]
          };
        }

        this.dashboardCards = [
          {
            title: 'Total Books',
            value: stats.books,
            subtext: '',
            icon: 'bi bi-book',
            subtextClass: 'text-success'
          },
          {
            title: 'Total Book Copies',
            value: stats.totalCopies,
            subtext: '',
            icon: 'bi bi-bookshelf',
            subtextClass: 'text-success'
          },
          {
            title: 'Issued Books',
            value: stats.borrowedBooks,
            subtext: '',
            icon: 'bi bi-journal-arrow-up',
            subtextClass: 'text-success'
          },
          {
            title: 'Returned Books',
            value: stats.returnedBooks,
            subtext: '',
            icon: 'bi bi-journal-arrow-down',
            subtextClass: 'text-info'
          },
          {
            title: 'Total Students',
            value: stats.students,
            subtext: '',
            icon: 'bi bi-people',
            subtextClass: 'text-success'
          },
          {
            title: 'Total Librarians',
            value: stats.librarians,
            subtext: '',
            icon: 'bi bi-person-workspace',
            subtextClass: 'text-info'
          },
          {
            title: 'Book Reviews',
            value: stats.reviews,
            subtext: '',
            icon: 'bi bi-chat-left-text',
            subtextClass: 'text-primary'
          },
          {
            title: 'Total Categories',
            value: stats.genres,
            subtext: '',
            icon: 'bi bi-tags',
            subtextClass: 'text-warning'
          }
        ];

        this.recentIssues = stats.recentIssuedBooks.map((book: IRecentIssuesBook) => ({
          title: book.title,
          studentName: book.studentName,
          issueDate: book.issueDate,
          dueDate: new Date(book.dueDate)
        }));

        this.loadingStats = false;
        this.loadingIssues = false;
      },
      error: (error) => {
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