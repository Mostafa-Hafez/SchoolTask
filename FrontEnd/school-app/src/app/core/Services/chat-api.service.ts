import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ChatApiService {

  private baseUrl = 'https://localhost:7154/api/Chat';

  constructor(private http: HttpClient) {}

  sendMessage(data: {
    receiverId: number;
    message: string;
  }) {
    return this.http.post(`${this.baseUrl}/send`, data);
    
  }

  getConversation(receiverId: number) {
    return this.http.get(
      `${this.baseUrl}/Getconversation?recieverid=${receiverId}`
    );
  }

  getChatList() {
  return this.http.get<any>(
    'https://localhost:7154/api/Chat/chat-list'
  );
}
}