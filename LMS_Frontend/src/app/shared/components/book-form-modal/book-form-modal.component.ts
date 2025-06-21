import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { GenreService } from 'src/app/core/services/genre.service';
import { IBook } from 'src/app/data/models/book/book';
import { IGenre } from 'src/app/data/models/genre/genre';
import { ValidationService } from '../../services/validation.service';
import { CanComponentDeactivate } from '../../guards/deactivate.guard';

@Component({
  selector: 'app-book-form-modal',
  templateUrl: './book-form-modal.component.html',
  styleUrls: ['./book-form-modal.component.scss']
})

export class BookFormModalComponent implements CanComponentDeactivate, OnInit, OnChanges {
  public bookForm!: FormGroup;
  public selectedImage: File | null = null;
  public imageBase64: string | null = null;
  public genres: IGenre[] = [];
  public isLoading: boolean = false;
  public isSubmitted: boolean = false;

  @Input() book!: IBook | null;
  @Input() showModal: boolean = false;
  @Input() role!: string;
  @Output() closeModal = new EventEmitter<void>();
  @Output() submitForm = new EventEmitter<IBook>();

  constructor(private fb: FormBuilder, private genreService: GenreService) { }

  public ngOnChanges(changes: SimpleChanges): void {
    if (changes['book'] && changes['book'].currentValue) {
      this.initializeForm();
    }
  }

  public ngOnInit(): void {
    if (this.role !== 'Student') {
      this.initializeForm();
      this.loadGenres();
    }
  }

  public canDeactivate(): boolean {
    if (this.bookForm.dirty && !this.isSubmitted) {
      return confirm('You have unsaved changes. Do you really want to leave?');
    }
    return true;
  }

  public loadGenres(): void {
    this.genreService.getAllGenres().subscribe({
      next: (response) => {
        if (response.success && response.data) {
          this.genres = response.data;
          if (this.book?.genreId) {
            this.bookForm.patchValue({ genreId: this.book.genreId });
          }
        }
      }
    });
  }

  public initializeForm(): void {
    this.bookForm = this.fb.group({
      Title: [this.book?.title || '', [Validators.required, ValidationService.noWhitespaceValidator]],
      Author: [this.book?.author || '', [Validators.required, ValidationService.noWhitespaceValidator, ValidationService.nameValidator]],
      GenreId: [this.book?.genreId ? Number(this.book.genreId) : null, Validators.required],
      TotalCopies: [this.book?.totalCopies || 1, [Validators.required, Validators.min(1)]],
      AvailableCopies: [this.book?.availableCopies || 1, [Validators.required, Validators.min(0)]],
      PublicationYear: [
        this.book?.publicationYear ? new Date(this.book.publicationYear).getFullYear() : null,
        [Validators.required, Validators.min(1000), Validators.max(2100)]
      ],
      Publisher: [this.book?.publisher || '', [ValidationService.noWhitespaceValidator]],
      Description: [this.book?.description || ''],
      ISBN: [this.book?.isbn || '', [Validators.minLength(10), Validators.maxLength(13)]],
      CoverImageUrl: [this.book?.coverImageUrl || '']
    }, { validators: this.copiesValidator });

    if (this.book?.coverImageUrl) {
      this.imageBase64 = this.book.coverImageUrl;
    }

    if (!this.book) {
      this.bookForm.get('TotalCopies')?.valueChanges.subscribe(val => {
        this.bookForm.patchValue({ AvailableCopies: val }, { emitEvent: false });
      });
    }

    this.bookForm.get('TotalCopies')?.valueChanges.subscribe(() => {
      this.bookForm.updateValueAndValidity();
    });
    this.bookForm.get('AvailableCopies')?.valueChanges.subscribe(() => {
      this.bookForm.updateValueAndValidity();
    });
  }

  private copiesValidator(form: FormGroup): ValidationErrors | null {
    const total = form.get('TotalCopies')?.value;
    const available = form.get('AvailableCopies')?.value;

    if (total !== null && available !== null && available > total) {
      return { invalidCopies: true };
    }
    return null;
  }

  public onFileChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedImage = input.files[0];
      const reader = new FileReader();
      reader.onload = () => {
        this.imageBase64 = reader.result as string;
        this.bookForm.patchValue({ CoverImageUrl: this.imageBase64 });
      };
      reader.readAsDataURL(this.selectedImage);
    }
  }

  public onSubmit(): void {
    this.isLoading = true;
    if (this.bookForm.valid) {
      const formValue = this.bookForm.value;
      const bookData = {
        ...formValue,
        id: this.book?.id || 0,
        GenreId: Number(formValue.GenreId),
        PublicationYear: formValue.PublicationYear,
        CoverImageUrl: this.imageBase64 || this.book?.coverImageUrl || ''
      };
      this.isSubmitted = true;
      this.submitForm.emit(bookData);
      this.isLoading = false;
      this.onReset();
    }
  }

  public onReset(): void {
    this.bookForm.reset();
    this.imageBase64 = null;

    const fileInput = document.getElementById('bookImage') as HTMLInputElement;
    if (fileInput) fileInput.value = '';
  }

  public onClose(): void {
    this.onReset();
    this.closeModal.emit();
  }
}