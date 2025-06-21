import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { BookService } from 'src/app/core/services/book.service';
import { BorrowService } from 'src/app/core/services/borrow.service';
import { WishlistAndNotificationService } from 'src/app/core/services/wishlist-and-notification.service';
import { IBook } from 'src/app/data/models/book/book';
import { TokenService } from '../../services/token.service';
import { PaginatorState } from 'primeng/paginator';

type UserRole = 'Administrator' | 'Librarian' | 'Student';
type ViewMode = 'table' | 'grid';
type AvailabilityFilter = 'all' | 'available';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})

export class BookListComponent implements OnInit {
  public books: IBook[] = [];
  public filteredBooks: IBook[] = [];
  public viewMode: ViewMode = 'table';
  public searchTerm: string = '';
  public availabilityFilter: AvailabilityFilter = 'all';
  public isLoading: Boolean = false;
  public isLoadingRequest: Boolean = false;
  public showModal = false;
  public currentBook: IBook | null = null;
  public isEditMode = false;
  public showDetailsModal = false;
  public selectedBook: IBook | null = null;
  public userId!: number;
  public first: number = 0;
  public rows: number = 10;
  public totalRecords: number = 0;
  @Input() role: UserRole = 'Student';

  constructor(
    private bookService: BookService,
    private borrowService: BorrowService,
    private messageService: MessageService,
    private tokenService: TokenService,
    private wishlistService: WishlistAndNotificationService
  ) { }

  public ngOnInit(): void {
    this.loadBooks(this.first, this.rows);
    const userId = Number(this.tokenService.getUserId());
    this.userId = userId || 0;
  }

  public loadBooks(first: number = 0, rows: number = 10): void {
    this.isLoading = true;
    const pageNo = Math.floor(first / rows) + 1;

    this.bookService.getAllBooks().subscribe({
      next: (res) => {
        this.totalRecords = res.length;
      }
    })

    this.bookService.getBookByPage(rows, pageNo).subscribe({
      next: (response) => {
        if (response.success) {
          this.books = response.data;
          this.filteredBooks = [...this.books];
          this.applyFilters();
        } else {
          this.messageService.add({
            severity: 'warn',
            summary: 'Warning',
            detail: response.message || 'Failed to load books'
          });
        }
        this.isLoading = false;
      },
      error: (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to load books.'
        });
        this.books = [];
        this.filteredBooks = [];
        this.isLoading = false;
      }
    });
  }

  public onPageChange(event: PaginatorState): void {
    this.first = event.first ?? 0;
    this.rows = event.rows ?? 10;
    this.loadBooks(this.first, this.rows);
  }

  public applyFilters(): void {
    const term = this.searchTerm.toLowerCase().trim();

    this.filteredBooks = this.books.filter(book => {
      const matchesSearch =
        term === '' ||
        (book.title?.toLowerCase().includes(term) ||
          book.author?.toLowerCase().includes(term) ||
          book.genreName?.toLowerCase().includes(term));

      const matchesAvailability =
        this.availabilityFilter === 'all' ||
        (book.availableCopies && book.availableCopies > 0);

      return matchesSearch && matchesAvailability;
    });
  }

  public openAddBookModal(): void {
    this.currentBook = null;
    this.isEditMode = false;
    this.showModal = true;
  }

  public openEditBookModal(book: IBook): void {
    this.currentBook = JSON.parse(JSON.stringify(book));
    this.isEditMode = true;
    this.showModal = true;
  }

  public closeModal(): void {
    this.showModal = false;
    this.currentBook = null;
  }

  public openBookDetails(book: IBook): void {
    this.selectedBook = { ...book };
    this.showDetailsModal = true;
  }

  public handleSubmit(bookData: IBook): void {
    if (this.isEditMode && this.currentBook?.id) {
      this.bookService.updateBook(this.currentBook.id, bookData).subscribe({
        next: () => {
          this.loadBooks();
          this.closeModal();
          this.messageService.add({
            severity: 'success',
            summary: 'Book updated',
            detail: 'Book updated successfully',
          })
        },
        error: (err) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Failed to update book',
          })
        }
      });
    } else {
      this.bookService.addBook(bookData).subscribe({
        next: () => {
          this.loadBooks();
          this.closeModal();
          this.messageService.add({
            severity: 'success',
            summary: 'Book added',
            detail: 'Book added successfully',
          })
        },
        error: (err) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Failed to add book',
          })
        }
      });
    }
  }

  public deleteBook(bookId: number): void {
    if (confirm('Are you sure you want to delete this book?')) {
      this.bookService.deleteBook(bookId).subscribe({
        next: () => {
          this.loadBooks();
          this.messageService.add({
            severity: 'success',
            summary: 'Book deleted',
            detail: 'Book has been successfully deleted',
          })
        },
        error: (err) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Failed to delete book',
          })
        }
      });
    }
  }

  public addToWishlist(book: IBook): void {
    this.isLoadingRequest = true;
    this.wishlistService.addToWishList(book.id).subscribe({
      next: (res) => {
        if (res) {
          this.isLoadingRequest = false;
          this.messageService.add({
            severity: 'success',
            summary: 'Book Added',
            detail: 'Book has been added to your wishlist',
          });
        }
      },
      error: (err) => {
        const errorMessage = err.error?.message || 'Failed to add book to wishlist';
        this.isLoadingRequest = false;
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: errorMessage,
          life: 3000
        });
      }
    })
  }

  public borrowBook(bookId: number): void {
    this.isLoadingRequest = true;
    this.borrowService.addBorrowRequest({ bookId: bookId, userId: this.userId }).subscribe({
      next: (res) => {
        this.isLoadingRequest = false;
        this.messageService.add({
          severity: 'success',
          summary: 'Request Sent',
          detail: 'Borrow request sent to the librarian.',
          life: 3000
        });
      },
      error: (err) => {
        this.isLoadingRequest = false;
        this.messageService.add({
          severity: 'error',
          summary: 'Request Failed',
          detail: err.error,
          life: 3000
        });
      }
    });
  }

  public returnBook(book: IBook): void {
    alert(`Returned "${book.title}"`);
  }

  public canAddBooks(): boolean {
    return this.role === 'Administrator' || this.role === 'Librarian';
  }
}