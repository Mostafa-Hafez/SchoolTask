import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../core/Services/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule
  ]
})
export class RegisterComponent {

  form: FormGroup;
  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(5)]]
    });
  }

  register() {
    if (this.form.invalid) return;

    const { username, password } = this.form.value;

    this.auth.register(username, password).subscribe({
      next: (res) => {
        console.log(res);
        this.successMessage = "User registered successfully!";
        this.errorMessage = null;
        this.form.reset();
        this.router.navigate(['/auth/login']);
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = err.error?.errors?.[0] || "Registration failed.";
        this.successMessage = null;
      }
    });
  }

}
