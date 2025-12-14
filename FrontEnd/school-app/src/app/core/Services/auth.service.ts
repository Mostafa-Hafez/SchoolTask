import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'https://localhost:7154/api/Auth/login';
  private registerUrl = 'https://localhost:7154/api/Auth/StudentRegister'; 
  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
    return this.http.post<any>(this.apiUrl, { username, password }).pipe(
      
      tap(response => {
        console.log(response)
        if (response?.data?.token) {
          localStorage.setItem('token', response.data.token);
          console.log(localStorage.getItem('token'));
        }
      })
    );
  }
register(username: string, password: string): Observable<any> {
    return this.http.post(
      `${this.registerUrl}?username=${username}&password=${password}`,
      {},
      { responseType: 'text' }
    );
  }
  logout() {
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
}
