import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  private hubConnection!: signalR.HubConnection;
  private messageSource = new Subject<any>();
  message$ = this.messageSource.asObservable();


  startConnection() {
  if (this.hubConnection?.state === signalR.HubConnectionState.Connected) {
    return;
  }

  this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:7154/chatHub', {
      accessTokenFactory: () => localStorage.getItem('token') || '',
    })
    .withAutomaticReconnect()
    .build();

  this.hubConnection
    .start()
    .then(() => console.log('SignalR Connected'))
    .catch(err => console.error(err));

  this.hubConnection.on('ReceiveMessage', (message) => {
    this.messageSource.next(message);
  });
}

  sendMessage(receiverId: number, message: string) {
    return this.hubConnection.invoke('SendMessage', receiverId, message);
  }
}
