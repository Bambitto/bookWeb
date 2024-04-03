import { Routes } from '@angular/router';
import { ReviewsComponent } from './reviews/reviews.component';
import { BookListComponent } from './book-list/book-list.component';
import { NewsComponent } from './news/news.component'

export const routes: Routes = [
  { path: 'book-list', component: BookListComponent },
  { path: 'reviews', component: ReviewsComponent },
  { path: 'news', component: NewsComponent },
  { path: '', redirectTo:'book-list', pathMatch: 'full' }
];
