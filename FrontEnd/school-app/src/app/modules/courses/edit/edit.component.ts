import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../../core/Services/course.service';

import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-edit-course',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './edit.component.html',
})
export class EditComponent implements OnInit {

  courseForm!: FormGroup;
  courseId!: number;
  loading = true;

  constructor(
    private fb: FormBuilder,
    private courseService: CourseService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.courseId = Number(this.route.snapshot.paramMap.get('id'));

    this.courseForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required]
    });

    this.loadCourse();
  }

  loadCourse() {
    this.courseService.getById(this.courseId).subscribe({
      next: (res) => {
        this.courseForm.patchValue({
          name: res.data.name,
          description: res.data.description
        });
        this.loading = false;
      },
      error: err => console.error(err)
    });
  }

  submit() {
    if (this.courseForm.invalid) return;
     const body = {
    id: this.courseId,
    name: this.courseForm.value.name,
    discription: this.courseForm.value.description  // API متوقع discription
  };
    this.courseService.updateCourse(this.courseId, body).subscribe({
      next: () => {
        this.router.navigate(['/courses']);
      },
      error: err => console.error(err)
    });
  }

  cancel() {
    this.router.navigate(['/courses']);
  }
}
