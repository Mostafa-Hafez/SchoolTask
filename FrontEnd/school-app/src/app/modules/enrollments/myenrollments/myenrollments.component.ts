import { Component } from '@angular/core';
import { StudentsService } from '../../../core/Services/student.service';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-myenrollments',
  imports: [CommonModule],
  templateUrl: './myenrollments.component.html',
  styleUrl: './myenrollments.component.scss'
})
export class MyenrollmentsComponent {
  enrollments: any[] = [];

  constructor(private studentService: StudentsService) {}

  ngOnInit(): void {
    this.studentService.getStudentEnrollments().subscribe(
      (res) => {
        this.enrollments = res.data;
      },
      (error) => {
        console.error('Error fetching enrollments:', error);
      }
    );
  }
}
