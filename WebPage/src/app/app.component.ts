import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { LoginModalComponent } from '../app/login-modal/login-modal.component'
import { MatDialog } from '@angular/material/dialog';
import { BookListComponent } from '../app/book-list/book-list.component'
import { SharedService } from './SharedService';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive, MatTabsModule, MatDialogModule, FormsModule, MatInputModule, MatFormFieldModule, MatIconModule, BookListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  title = 'WebPage';
  links = [
    {
      label: 'Książki',
      link: '/book-list',
    }, {
      label: 'Recenzje',
      link: '/reviews',
    },
    {
      label: 'Aktualności',
      link: '/news',
    }];
  value = '';

  constructor(public dialog: MatDialog, private sharedService: SharedService) { }
  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(LoginModalComponent, {
      width: '500px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }
  updateSearch() {
    this.sharedService.updateSearchTerm(this.value);
  }
}
