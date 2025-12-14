import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { StudentsService } from './../../../core/Services/student.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Router } from '@angular/router';
import { A11yModule } from '@angular/cdk/a11y';
@Component({
  selector: 'app-student-list',
  standalone: true,
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    A11yModule,
  ],
})
export class ListComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['id', 'name', 'email', 'Classname', 'actions'];
  dataSource = new MatTableDataSource<any>();
  filterNameValue = '';
  classFiltervlaue = '';
  pageSize = 10;
  pageIndex = 1;
  totalItems = 0;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private studentsService: StudentsService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.loadStudents();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  loadStudents(page: number = this.pageIndex, pageSize: number = this.pageSize): void {
    this.studentsService
      .getStudents(page, pageSize, this.filterNameValue, this.classFiltervlaue)
      .subscribe({
        next: (res) => {
          const students = res.data.items;
          this.dataSource.data = students;
          this.totalItems = res.data.totalCount;
          this.dataSource.paginator = this.paginator;

          return students;
        },
        error: (err) => console.error(err),
      });
  }
  create() {
    this.router.navigate(['/students/add']);
  }
  classFilter() {
    this.loadStudents();
  }
  applyFilter() {
    this.loadStudents();
  }
  reset() {
    this.filterNameValue = '';
    this.classFiltervlaue = '';
    this.loadStudents();
  }
  edit(id: number) {
    console.log('Edit student', id);
    this.router.navigate(['/students/edit', id]);

  }
  delete(id: number) {
    const result: Boolean = confirm('Are you sure you want to delete this student?');
    if (result) {
      this.studentsService.deleteStudent(id).subscribe({
        next: (res) => {
          console.log(res);
          if (res.success){
            this.loadStudents();
          console.log(res);
          alert('Student deleted successfully');
          }
          
        },
        error: (err) => {console.error(err)
        alert('Failed to delete student,Please try again later.');
        },
      });
    }
  }

  onPageChange($event: PageEvent) {
    this.pageIndex = $event.pageIndex;
    this.pageSize = $event.pageSize;
    this.loadStudents(this.pageIndex + 1, this.pageSize);
  }
}
