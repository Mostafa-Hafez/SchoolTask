import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import  {MatSidenav}  from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-main-layout',
  imports: [MatSidenav,CommonModule,MatToolbarModule,MatSidenavModule
    ,MatListModule,MatIconModule,
    RouterModule
  ],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss'
})
export class MainLayoutComponent {


  isSidebarOpened: boolean = true;

  toggleSidebar() {
    this.isSidebarOpened = !this.isSidebarOpened;
  }

}
