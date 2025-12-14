import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { CourseService } from '../../../core/Services/course.service';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule,
    MatButtonModule
  ],
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'description', 'actions'];
  dataSource = new MatTableDataSource<any>([]);
  filterValue = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private courseService: CourseService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadCourses();
  }

  loadCourses(filter: string = this.filterValue): void {
    this.courseService.getCourses(this.filterValue).subscribe(res => {
      this.dataSource.data = res.data;
      this.dataSource.paginator = this.paginator;

    });
  }

  applyFilter() {
    this.loadCourses()
  }
 create(){
    this.router.navigate(['/courses/add']);
 }
  edit(id: number) {
    this.router.navigate(['/courses/edit', id]);
  }

  delete(id: number) {
    if (!confirm('Are you sure you want to delete this course?')) return;

    this.courseService.deleteCourse(id).subscribe({
      next: () => {
        this.loadCourses();
      },
      error: err => console.error(err)
    });
  }
}
