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
import { UserService } from '../services/user.service';
import { HttpResponse } from '@angular/common/http';
import { Signup } from '../models';

@Component({
  selector: 'app-login-modal',
  standalone: true,
  imports: [MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, MatInputModule, MatFormFieldModule, FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './login-modal.component.html',
  styleUrl: './login-modal.component.css'
})
export class LoginModalComponent {
  constructor(public dialogRef: MatDialogRef<LoginModalComponent>, private userService: UserService) { }

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });
  signupForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl(''),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    retypepassword: new FormControl('', [Validators.required])
  });

  signup: boolean = false;
  apiResponse: string[] = ['', ''];

  toggleSignup(): void {
    this.signup = !this.signup;
    this.apiResponse = ['','']
  }

  onSubmit(signup: boolean) {
    // Here you can access the email and password
    const signUpValues = this.signupForm.value;
    if (signup) {

      const request: Signup = {
        email: signUpValues.email,
        firstName: signUpValues.firstName,
        lastName: signUpValues.lastName,
        password: signUpValues.password
      }

      this.userService.signUp(request).subscribe((response: HttpResponse<any>) => {
        if (response.status === 200) {
          this.toggleSignup();
          this.signupForm.reset();
          this.apiResponse[0] = 'Konto założone pomyślnie, możesz się teraz zalogować!';
          this.apiResponse[1] = 'success'  
        }
        else {
          this.displayError(response);
        }
      })
    }
    else {
      this.userService.login(this.loginForm).subscribe((response: HttpResponse<any>) => {
        console.log(response);
        if (response.status === 200) {
          localStorage.setItem("isLoggedIn", "true");
          localStorage.setItem("jwt", response.body);
          this.dialogRef.close();
        }
        else {  
          this.displayError(response);
        }
      });
    }
  }


  displayError(response: HttpResponse<any>) {
    this.apiResponse[0] = response.body.error.errors.generalErrors[0];
    this.apiResponse[1] = 'error'
  }
}
