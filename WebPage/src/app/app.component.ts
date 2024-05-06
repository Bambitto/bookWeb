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
import { AddBookModalComponent } from '../app/add-book-modal/add-book-modal.component'
import { SharedService } from './services/SharedService';
import { UserService } from './services/user.service';
import { HttpResponse } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive, MatTabsModule, MatDialogModule, FormsModule, MatInputModule, MatFormFieldModule, MatIconModule, BookListComponent, CommonModule],
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
  loggedIn: boolean = localStorage.getItem('jwt') != null;
  isAdmin: boolean = false;
  constructor(public dialog: MatDialog, private sharedService: SharedService, private userService: UserService) { }

  ngOnInit() {
    this.userService.isAdmin().subscribe((response: HttpResponse<any>) => {
      console.log("test");
      console.log(response);
      if (response.status === 200) {
        this.isAdmin = true;
      }
      else {
        this.isAdmin = false;
      }
    })
  }

  accountClick(): void {

    this.loggedIn = localStorage.getItem('jwt') != null;
    if (!this.loggedIn) {
      this.openLoginDialog()
    }
    else {

    }
  }

  openLoginDialog(): void {
    const dialogRef = this.dialog.open(LoginModalComponent, {
      width: '500px',
      enterAnimationDuration: "300ms",
      exitAnimationDuration: "300ms",
    });

    dialogRef.afterClosed().subscribe(_ => {
      console.log("closed");
      window.location.reload();
    });

  }

  openAddBookDialog(): void {
    this.dialog.open(AddBookModalComponent, {
      width: '500px',
      enterAnimationDuration: "300ms",
      exitAnimationDuration: "300ms",
    });
  }

  updateSearch() {
    this.sharedService.updateSearchTerm(this.value);
  }
}
