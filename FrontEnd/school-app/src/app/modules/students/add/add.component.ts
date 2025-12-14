import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { matSelectAnimations, MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';
import { Router } from '@angular/router';
import { StudentsService } from '../../../core/Services/student.service';

@Component({
  selector: 'app-add-student',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule
  ],
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss'],
})
export class AddComponent {

  form: any;
  classes: any[] = [];

  constructor(
    private fb: FormBuilder,
    private studentService: StudentsService,
    private router: Router
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      classId: [null, Validators.required],
    });
  }
  ngOnInit() {
  this.loadClasses()
}
  submit() {
    if (this.form.invalid) return;

    this.studentService.createStudent(this.form.value.name, this.form.value.email, this.form.value.classId).subscribe({
      next: () => {
        alert('Student added successfully!');
        this.form.reset();
      },
      error: (err) => {
        console.error(err);
        alert('Error occurred!');
      }
    });
  }
    

   loadClasses() {
    this.studentService.getClasses().subscribe(res => {
      this.classes = res.data;
    });
  }
  cancel(){
    this.router.navigate(['/students'])
  }
}
