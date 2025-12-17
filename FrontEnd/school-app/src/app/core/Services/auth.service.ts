import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { getMessaging, getToken } from 'firebase/messaging';

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
      
      tap(async  response => {
        console.log(response)
        if (response?.data?.token) {
          const tok: any = await this.getFcmToken();
          console.log("FCM Token:", tok);
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

  getTokenfromlocalstorage(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  async getFcmToken(): Promise<string | null> {
    const messaging = getMessaging();
    return await getToken(messaging, {
      vapidKey: 'BOdc1GMx3zczYbSMxvyTJPzOafdMNnkWcbW_s54LQoDWSt_JRFX8y2a4z-j6ryDCI7czhoIO79zW663K4bpnv4E'
      
    });
  }
}
