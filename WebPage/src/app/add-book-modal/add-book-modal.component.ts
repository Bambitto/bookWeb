import { Component, OnInit, OnDestroy } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BookService } from '../services/book.service'
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-book-modal',
  standalone: true,
  imports: [],
  templateUrl: './add-book-modal.component.html',
  styleUrl: './add-book-modal.component.css'
})
export class AddBookModalComponent {
  constructor(public dialogRef: MatDialogRef<AddBookModalComponent>, public bookService: BookService) {
  }


  addBookForm = new FormGroup({
    title: new FormControl('', [Validators.required, Validators.maxLength(64)]),
    author: new FormControl('', [Validators.required, Validators.maxLength(64)]),
    description: new FormControl('', [Validators.required, Validators.maxLength(512)]),
    genreId: new FormControl('', Validators.required)
  });



  ngOnInit() {
    
  }


  onSubmit() {
    this.bookService.addBook(this.addBookForm).subscribe((response: HttpResponse<any>) => {
      console.log(response);
    });
  }
}
