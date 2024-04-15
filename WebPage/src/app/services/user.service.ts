import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, catchError, of, tap } from 'rxjs';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  apiUrl = 'http://localhost:5135/api';


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

  signUp(creds: FormGroup): Observable<HttpResponse<any>> {
    return this.http.post<any>(`${this.apiUrl}/account/signup`, creds.value, { observe: 'response', headers: new HttpHeaders({ 'Content-Type': 'application/json' }) })
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
