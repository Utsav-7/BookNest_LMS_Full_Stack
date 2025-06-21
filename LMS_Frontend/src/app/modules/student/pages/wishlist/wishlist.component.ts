import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { WishlistAndNotificationService } from 'src/app/core/services/wishlist-and-notification.service';
import { IWishlistResponse } from 'src/app/data/models/wishlist-notification/wishlistResponse';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.scss']
})

export class WishlistComponent implements OnInit {
  public wishlistItems: IWishlistResponse[] = [];
  public isLoading = true;

  constructor(
    private wishlistService: WishlistAndNotificationService,
    private messageService: MessageService
  ) { }

  public ngOnInit(): void {
    this.loadWishlist();
  }

  public loadWishlist(): void {
    this.isLoading = true;
    this.wishlistService.getWishList().subscribe({
      next: (response) => {
        this.wishlistItems = response.data;
        this.isLoading = false;
      },
      error: (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to load wishlist'
        })
        this.isLoading = false;
      }
    });
  }

  public removeFromWishlist(wishlistId: number): void {
    if (confirm('Are you sure you want to remove this item from your wishlist?')) {
      this.wishlistService.removeFromWishList(wishlistId).subscribe({
        next: (res) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Book removed from wishlist',
            detail: 'The Book has been successfully removed from your wishlist.'
          })
          this.loadWishlist();
        },
        error: (err) => {
          this.messageService.add({
            severity: 'Error',
            summary: 'Error removing book from wishlist',
            detail: 'There was an error removing the book from your wishlist.'
          })
        }
      })
    }
  }
}