import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, catchError, of, tap } from 'rxjs';
import { FormGroup } from '@angular/forms';
import { Signup } from '../models';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  apiUrl = 'http://localhost:5135/api';
  token = localStorage.getItem('jwt');

  login(creds: FormGroup): Observable<HttpResponse<any>> {
    return this.http.post<any>(`${this.apiUrl}/account/login`, creds.value, { observe: 'response', headers: new HttpHeaders({ 'Content-Type': 'application/json' }) })
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

  signUp(request: Signup): Observable<HttpResponse<any>> {
    return this.http.post<any>(`${this.apiUrl}/account/signup`, request, { observe: 'response', headers: new HttpHeaders({ 'Content-Type': 'application/json' }) })
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

  isAdmin(): Observable<HttpResponse<any>> {
    return this.http.get<any>(`${this.apiUrl}/admin`, { observe: 'response', headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${this.token}` }) })
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
}
