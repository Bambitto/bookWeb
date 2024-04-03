import { Component } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MatDialogActions,
  MatDialogClose,
  MatDialogTitle,
  MatDialogContent,
} from '@angular/material/dialog';
import { FormControl, Validators, FormsModule, ReactiveFormsModule, FormGroup, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common'

@Component({
  selector: 'app-login-modal',
  standalone: true,
  imports: [MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, MatInputModule, MatFormFieldModule, FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './login-modal.component.html',
  styleUrl: './login-modal.component.css'
})
export class LoginModalComponent {
  constructor(public dialogRef: MatDialogRef<LoginModalComponent>) { }
  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });

  signupForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    retypepassword: new FormControl('', [Validators.required])
  });

  signup : boolean = false;

  toggleSignup(): void {
    this.signup = !this.signup;
  }

  onSubmit(signup : boolean) {
    // Here you can access the email and password
    var signInValues = this.loginForm.value;
    var signUpValues = this.signupForm.value;
    var isSuccess = true;
    if (signup) {
      console.log(`Email: ${signUpValues.email}, Password: ${signUpValues.password}, Retype Password: ${signUpValues.retypepassword}`);
    }
    else {
      localStorage.setItem("isLoggedIn", "true");
    }

    if (isSuccess) {
      this.dialogRef.close();
    }
  }
}
