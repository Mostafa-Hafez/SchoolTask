import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { StudentsService } from '../../../core/Services/student.service';
import { ClassService } from '../../../core/Services/class.service';

@Component({
  selector: 'app-edit-student',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule
  ],
  templateUrl: './edit.component.html',
})
export class EditComponent implements OnInit {

  form!: FormGroup;
  studentId!: number;
  classes: any[] = [];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private studentsService: StudentsService,
    private classservce: ClassService
  ) {}

  ngOnInit(): void {
    this.studentId = Number(this.route.snapshot.paramMap.get('id'));

    this.form = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      classId: [null, Validators.required]
    });

    this.loadStudent();
    this.loadClasses();
  }

  loadStudent() {
    this.studentsService.getStudent(this.studentId).subscribe(res => {
      this.form.patchValue({
        name: res.data.name,
        email: res.data.email,
        classId: res.data.classId
      });
    });
  }

  loadClasses() {
    this.studentsService.getClasses().subscribe(res => {
      this.classes = res.data;
    });
  }

  submit() {
    if (this.form.invalid) return;

    this.studentsService.updateStudent(this.studentId, this.form.value)
      .subscribe({
        next: () => {
          alert('Student updated successfully');
          this.router.navigate(['/students']);
        }
      });
  }
}
