import { Component, OnInit, OnDestroy } from '@angular/core';
import { Book, Genre } from '../models';
import { CommonModule, NgOptimizedImage } from '@angular/common'
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipListboxChange, MatChipsModule } from '@angular/material/chips';
import { Subscription } from 'rxjs';
import { SharedService } from '../services/SharedService';
import { BookService } from '../services/book.service';
import { MatDialog } from '@angular/material/dialog';
import { BookModalComponent } from '../book-modal/book-modal.component'


@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, NgOptimizedImage, MatIconModule, MatButtonModule, MatChipsModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit, OnDestroy {
  books: Book[] = [];
  displayedBooks: Book[] = [];

  constructor(private sharedService: SharedService, private bookService: BookService, private dialog: MatDialog) {
  }
  public genres: Genre[] = [];
  selectedGenre: Genre | null = null;
  private searchSubscription: Subscription = new Subscription;



  ngOnInit() {
    this.bookService.getBooks().subscribe((data: any) => {
      this.books = data.books;
      this.displayedBooks = data.books;
    });

    this.bookService.getGenres().subscribe((data: any) => {
      this.genres = data.genres;
    });

    this.searchSubscription = this.sharedService.currentSearchTerm.subscribe(term => {
      this.filterBooks(term);
    });
  }

  ngOnDestroy() {
    this.searchSubscription.unsubscribe();
  }

  onSelection(event: MatChipListboxChange) {
    const selected = event.value;
    if (selected !== undefined) {
      // Assuming single selection, adjust if multiple
      this.selectedGenre = selected;
      this.displayedBooks = this.books.filter(book => book.genreId === this.selectedGenre?.id);
    } else {
      this.displayedBooks = this.books;
    }
  }

  filterBooks(searchTerm: string) {
    console.log(this.displayedBooks);
    if (!searchTerm) {
      this.displayedBooks = this.books.slice(); // No search term, show all books
    } else {
      this.displayedBooks = this.books.filter(book =>
        book.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
        book.author.toLowerCase().includes(searchTerm.toLowerCase())
      );
    }
  }
  openDialog(book: any): void {
    console.log(book);
    this.openBookDialog(book, '300ms', '300ms')
  }

  openBookDialog(book: any, enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(BookModalComponent, {
      width: '500px',
      data: book,
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }
}
