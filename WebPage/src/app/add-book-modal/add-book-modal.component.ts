import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MatDialogActions,
  MatDialogClose,
  MatDialogTitle,
  MatDialogContent,
  
} from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { FormControl, Validators, FormsModule, ReactiveFormsModule, FormGroup, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { BookService } from '../services/book.service'
import { HttpResponse } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { Genre } from '../models';

@Component({
  selector: 'app-add-book-modal',
  standalone: true,
  imports: [MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, MatInputModule, MatFormFieldModule, FormsModule, ReactiveFormsModule, CommonModule, MatSelectModule],
  templateUrl: './add-book-modal.component.html',
  styleUrl: './add-book-modal.component.css'
})
export class AddBookModalComponent {
  constructor(public dialogRef: MatDialogRef<AddBookModalComponent>, public bookService: BookService) {
  }

  apiResponse: string[] = ['', ''];
  genres: Genre[] = [];

  addBookForm = new FormGroup({
    title: new FormControl('', [Validators.required, Validators.maxLength(64)]),
    author: new FormControl('', [Validators.required, Validators.maxLength(64)]),
    description: new FormControl('', [Validators.required, Validators.maxLength(512)]),
    genreId: new FormControl('', Validators.required)
  });



  ngOnInit() {
    this.bookService.getGenres().subscribe((response: any) => {
      this.genres = response.genres;
    })
  }


  onSubmit() {
    this.bookService.addBook(this.addBookForm).subscribe((response: HttpResponse<any>) => {
      console.log(response);
      if (response.status === 200) {
        this.addBookForm.reset();
        this.addBookForm.clearValidators();
        this.addBookForm.clearAsyncValidators();
      }
      else {
        this.displayError(response);
      }
    });
  }


  displayError(response: HttpResponse<any>) {
    try {
      this.apiResponse[0] = response.body.error.errors.generalErrors[0];
    }
    catch (error) {
      this.apiResponse[0] = "Coś poszło nie tak";
    }
    this.apiResponse[1] = 'error'
  }
}
