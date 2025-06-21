import { Component, OnInit } from '@angular/core';
import { GenreService } from 'src/app/core/services/genre.service';
import { IGenre } from 'src/app/data/models/genre/genre';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.scss']
})

export class GenreComponent implements OnInit {
  public isLoading: boolean = false;
  public genres: IGenre[] = [];
  public filteredGenres: IGenre[] = [];
  public searchTerm: string = '';
  public editGenreId: number | null = null;
  public editedGenre: IGenre = { genreId: 0, genreName: '', description: '' };
  public showAddForm: boolean = false;
  public newGenre: IGenre = { genreId: 0, genreName: '', description: '' };

  constructor(private genreService: GenreService, private messageService: MessageService) { }

  public ngOnInit(): void {
    this.loadGenres();
  }

  public loadGenres(): void {
    this.isLoading = true;
    this.genreService.getAllGenres().subscribe({
      next: (response) => {
        this.genres = response.data ?? [];
        this.filteredGenres = [...this.genres];
        this.isLoading = false;
      },
      error: (error) => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to load genres.' });
      }
    });
  }

  public applyFilters(): void {
    const search = this.searchTerm.trim().toLowerCase();

    this.filteredGenres = this.genres.filter(genre =>
      genre.genreName.toLowerCase().includes(search) ||
      (genre.description && genre.description.toLowerCase().includes(search))
    );
    this.messageService.add({ severity: 'info', summary: 'Info', detail: 'Filter Applied.' });
  }

  public onAddGenre(): void {
    this.showAddForm = true;
    this.newGenre = { genreId: 0, genreName: '', description: '' };
  }

  public cancelAddGenre(): void {
    this.showAddForm = false;
    this.newGenre = { genreId: 0, genreName: '', description: '' };
  }

  public onSaveNewGenre(): void {
    if (!this.newGenre.genreName.trim()) {
      this.messageService.add({ severity: 'warn', summary: 'Validation', detail: 'Genre name is required.' });
      return;
    }

    this.genreService.createGenre(this.newGenre).subscribe({
      next: () => {
        this.messageService.add({ severity: 'success', summary: 'Genre Added', detail: 'New genre has been created.' });
        this.showAddForm = false;
        this.loadGenres();
      },
      error: () => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to add genre.' });
      }
    });
  }

  public onEditGenre(genre: IGenre): void {
    this.editGenreId = genre.genreId;
    this.editedGenre = { ...genre };
  }

  public onSaveGenre(): void {
    this.genreService.updateGenre(this.editedGenre).subscribe({
      next: () => {
        this.messageService.add({ severity: 'success', summary: 'Updated', detail: 'Genre updated successfully.' });
        this.editGenreId = null;
        this.loadGenres();
      },
      error: () => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to update genre.' });
      }
    });
  }

  public onCancelEdit(): void {
    this.editGenreId = null;
  }

  public onDeleteGenre(id: number): void {
    if (confirm('Are you sure you want to delete this genre?')) {
      this.genreService.deleteGenre(id).subscribe({
        next: () => {
          this.messageService.add({ severity: 'success', summary: 'Deleted', detail: 'Genre deleted successfully.' });
          this.loadGenres();
        },
        error: () => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to delete genre.' });
        }
      });
    }
  }
}