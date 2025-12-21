import { Component, OnInit } from '@angular/core';
import { ChatApiService } from '../../../core/Services/chat-api.service';
import { SignalrService } from '../../../core/Services/chat.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  imports: [FormsModule, CommonModule],
  standalone: true,
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  messages: any[] = [];
  receiverId = 2;
  messageText = '';
  user: any = ''; 
  currentUserId !: number ;
 chatwindow =document.getElementById('Chatwindow');

  chatList: any[] = [];
  selectedUser: any;
  chatName!: string;
  constructor(
    private chatApi: ChatApiService,
    private signalr: SignalrService,
  ) {}

  ngOnInit(): void {
    this.signalr.startConnection();
    this.signalr.message$.subscribe((msg) => {
      if (msg.senderId === this.receiverId || msg.receiverId === this.receiverId) {
        this.messages = [...this.messages, msg];
      }
    });
    this.loadChatList();
this.user=localStorage.getItem('user');
this.currentUserId=JSON.parse(this.user).studentId;

  }

  onSelectChat(event: any) {
    const selectedId = +event.target.value;
    this.receiverId = selectedId;
    this.selectedUser = this.chatList.find((u) => u.contactId === selectedId);
    this.chatName = this.selectedUser?.contextName || 'Unknown';
    this.chatApi.getConversation(this.receiverId).subscribe({
      next: (res: any) => {
        this.messages = res.data;
      },
    });
    if(this.chatwindow){
      this.chatwindow.scrollTop = this.chatwindow.scrollHeight;
    }
  }

  sendMessage() {
    if (!this.messageText.trim()) return;

    this.signalr.sendMessage(this.receiverId, this.messageText);
    this.messageText = '';
  }

  async loadChatList() {
    this.chatApi.getChatList().subscribe({
      next: (res) => {
        this.chatList = res.data;
        console.log(this.chatList);
      },
    });
  }

  selectChat(user: any) {
    this.receiverId = user.contactId;
    this.selectedUser = user;
  }

  getSenderName(senderId: any): string {
    return Number(senderId) === Number(this.currentUserId)
      ? 'You'
      : this.selectedUser?.contextName || 'Unknown';
  }
}
