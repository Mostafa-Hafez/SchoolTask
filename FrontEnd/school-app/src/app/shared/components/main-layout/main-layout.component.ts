import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSidenav } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../core/Services/auth.service';

@Component({
  selector: 'app-main-layout',
  imports: [
    MatSidenav,
    CommonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    RouterModule,
  ],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss',
})
export class MainLayoutComponent {
  constructor(
    private auth: AuthService,
    private router: Router,
  ) {}
  isSidebarOpened: boolean = true;

  toggleSidebar() {
    this.isSidebarOpened = !this.isSidebarOpened;
  }
  logout() {
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}
