import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { ClassService } from '../../../core/Services/class.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
@Component({
  selector: 'app-classes-list',
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatInputModule,
  ],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'teacherName', 'actions'];
  dataSource = new MatTableDataSource<any>([]);
  filterValue = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private classesService: ClassService, private router: Router) {}

  ngOnInit(): void {
    this.loadClasses();
  }

  loadClasses(): void {
    this.classesService.getClasses(1, 10,this.filterValue).subscribe({
      next: (res: any) => {
       // console.log(res);
        this.dataSource.data = res.data; 
        this.dataSource.paginator = this.paginator;
      },
      error: (err) => console.error(err)
    });
  }

  applyFilter() {
   this.loadClasses();
       console.log("Loading.......")

  }

  create() {
    this.router.navigate(['/classes/add']);
  }

  edit(id: number) {
    this.router.navigate([`/classes/edit/${id}`]);
  }

  delete(id: number) {
    if (confirm('Are you sure you want to delete this class?')) {
      this.classesService.deleteClass(id).subscribe({
        next: () => this.loadClasses(),
        error: (err) => console.error(err)
      });
    }
  }
}
