import { Component } from '@angular/core';
import { AuthService } from '../../../core/Services/auth.service';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-student-dashboard',
  imports: [RouterOutlet],
  templateUrl: './student-dashboard.component.html',
  styleUrl: './student-dashboard.component.scss'
})
export class StudentDashboardComponent {
currentUserName: any = '';

  constructor(private auth: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.currentUserName = this.GetUserName();
    console.log(this.currentUserName);
  }
 GetUserName(): string {
  const user = JSON.parse(localStorage.getItem('user') || '{}');
  return user.userName;
 }
  logout() {
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}
