import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IBook } from 'src/app/data/models/book/book';

@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.scss']
})

export class BookCardComponent {
  @Input() book!: IBook;
  @Input() displayMode: 'compact' | 'detailed' = 'compact';
  @Input() showActions: boolean = false;
  @Input() userRole: 'Administrator' | 'Librarian' | 'Student' = 'Student';
  @Input() showDeleteButton: boolean = false;
  @Output() viewBook = new EventEmitter<IBook>();
  @Output() editBook = new EventEmitter<IBook>();
  @Output() borrowBook = new EventEmitter<number>();
  @Output() deleteBook = new EventEmitter<number>();
}