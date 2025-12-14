import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClassService } from '../../../core/Services/class.service';

import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-add-course',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './add.component.html',
  styleUrl :'./add.component.scss'
})
export class AddComponent {

  courseForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private classServices: ClassService,
    private router: Router
  ) {
    this.courseForm = this.fb.group({
      name: ['', Validators.required],
      teacherName: ['', Validators.required]
    });
  }

  submit() {
    if (this.courseForm.invalid) return;

    this.classServices.addClass(this.courseForm.value).subscribe({
      next: (res) => {
        console.log(res);
        alert('class added successfully!');
        this.courseForm.reset();
      },
      error: err => console.error(err)
    });
  }

  cancel() {
    this.router.navigate(['/classes']);
  }
}
