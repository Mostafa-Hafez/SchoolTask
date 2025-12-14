9

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassService } from '../../../core/Services/class.service';

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
  classId!: number;
  loading = true;

  constructor(
    private fb: FormBuilder,
    private classservice: ClassService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.classId = Number(this.route.snapshot.paramMap.get('id'));

    this.courseForm = this.fb.group({
      name: ['', Validators.required],
      teacherName: ['', Validators.required]
    });

    this.loadCourse();
  }

  loadCourse() {
    this.classservice.getClassById(this.classId).subscribe({
      next: (res) => {
        this.courseForm.patchValue({
          name: res.data.name,
          teacherName: res.data.teacherName
        });
        this.loading = false;
      },
      error: err => console.error(err)
    });
  }

  submit() {
    if (this.courseForm.invalid) return;
     const body = {
    id: this.classId,
    name: this.courseForm.value.name,
    teacherName: this.courseForm.value.teacherName   
  };
    this.classservice.updateClass(this.classId, body).subscribe({
      next: () => {
        this.router.navigate(['/classes']);
      },
      error: err => console.error(err)
    });
  }

  cancel() {
    this.router.navigate(['/classes']);
  }
}

