import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';
import { Book, Genre } from '../models';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class BookService {

  constructor(private http: HttpClient) { }

  apiUrl = 'http://localhost:5135/api';
  token = localStorage.getItem('jwt');

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.apiUrl}/books`)
  }

  addBook(book: FormGroup): Observable<HttpResponse<any>> {
    return this.http.post<any>(`${this.apiUrl}/book/create`, book.value, { observe: 'response', headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${this.token}` }) })
      .pipe(
        catchError((error) => {
          const errorResponse = {
            error: error.error
          }
          return of(new HttpResponse({
            body: errorResponse,
            status: error.status
          }));
        })
      )
  }

  getGenres(): Observable<Genre[]> {
    return this.http.get<Genre[]>(`${this.apiUrl}/genres`)
  }
}
