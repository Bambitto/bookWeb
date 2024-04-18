import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models';

@Injectable({
  providedIn: 'root',
})
export class BookService {

  constructor(private http: HttpClient) { }

  apiUrl = 'http://localhost:5135/api';


  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.apiUrl}/books`)
  }
}
