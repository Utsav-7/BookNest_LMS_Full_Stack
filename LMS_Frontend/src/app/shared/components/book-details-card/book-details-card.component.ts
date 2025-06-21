import { Component, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { IBook } from 'src/app/data/models/book/book';

@Component({
  selector: 'app-book-details-card',
  templateUrl: './book-details-card.component.html',
  styleUrls: ['./book-details-card.component.scss']
})

export class BookDetailsCardComponent {
  @Input() book: IBook | null = null;
  @Input() showModal: boolean = false;
  @Output() closeModal = new EventEmitter<void>();

  public onModalClick(event: MouseEvent): void {
    if ((event.target as HTMLElement).classList.contains('modal')) {
      this.closeModal.emit();
    }
  }
}