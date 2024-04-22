import { Component, Inject } from '@angular/core';
import { Book } from '../models'
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-book-modal',
  standalone: true,
  imports: [],
  templateUrl: './book-modal.component.html',
  styleUrl: './book-modal.component.css'
})
export class BookModalComponent {
  constructor(public dialogRef: MatDialogRef<BookModalComponent>, @Inject(MAT_DIALOG_DATA) public data: { book: Book }) { }

}
