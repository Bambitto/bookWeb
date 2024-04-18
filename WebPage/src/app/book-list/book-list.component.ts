import { Component, OnInit, OnDestroy } from '@angular/core';
import { Book } from '../models';
import { CommonModule, NgOptimizedImage } from '@angular/common'
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipListboxChange, MatChipsModule } from '@angular/material/chips';
import { Subscription } from 'rxjs';
import { SharedService } from '../services/SharedService';
import { BookService } from '../services/book.service';


@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, NgOptimizedImage, MatIconModule, MatButtonModule, MatChipsModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit, OnDestroy {
  books: any[];
  displayedBooks: any[];

  booksTest: any[]
    = [
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    }

  ];
  constructor(private sharedService: SharedService, private bookService: BookService) {
    this.books = [];
    this.displayedBooks = this.books;
  }
  public genres: string[] = ['Komedia', 'Kryminał', 'Powieść', 'Sci-finction', 'Kryminał', 'Powieść', 'Sci-finction', 'Kryminał', 'Powieść', 'Sci-finction']
  selectedGenre = "";
  private searchSubscription: Subscription = new Subscription;



  ngOnInit() {
    this.bookService.getPosts().subscribe((data: any) => {
      this.books = data.books;
      this.displayedBooks = data.books;
      console.log(data);
      console.log(this.books);
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
      this.displayedBooks = this.books.filter(book => book.genre === this.selectedGenre);
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
}
