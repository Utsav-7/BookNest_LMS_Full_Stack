import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { IRegister } from 'src/app/data/models/authentication/register';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ValidationService } from 'src/app/shared/services/validation.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class RegisterComponent implements OnInit {
  public registerForm!: FormGroup;
  public selectedImage: File | null = null;
  public imageBase64: string = '';
  public isLoading: boolean = false;
  public formSubmitted = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private messageService: MessageService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    this.registerForm = this.fb.group({
      firstName: this.fb.control('', {
        validators: [
          Validators.required,
          ValidationService.noWhitespaceValidator,
          ValidationService.nameValidator
        ],
        updateOn: 'blur'
      }),
      lastName: this.fb.control('', {
        validators: [
          Validators.required,
          ValidationService.noWhitespaceValidator,
          ValidationService.nameValidator
        ],
        updateOn: 'blur'
      }),
      email: this.fb.control('', {
        validators: [
          Validators.required,
          Validators.email,
          ValidationService.noWhitespaceValidator,
          ValidationService.emailValidator
        ],
        updateOn: 'blur'
      }),
      mobile: this.fb.control('', {
        validators: [
          Validators.required,
          Validators.pattern(/^[6-9]\d{9}$/)
        ],
        updateOn: 'blur'
      }),
      password: this.fb.control('', {
        validators: [
          Validators.required,
          Validators.minLength(6),
          ValidationService.noWhitespaceValidator,
          ValidationService.passwordValidator
        ],
        updateOn: 'blur'
      }),
      confirmPassword: this.fb.control('', {
        validators: [Validators.required],
        updateOn: 'blur'
      })
    }, { validators: this.passwordMatchValidator });
  }

  public getControl(name: string): AbstractControl | null {
    return this.registerForm.get(name);
  }

  public passwordMatchValidator(form: AbstractControl) {
    const password = form.get('password')?.value;
    const confirm = form.get('confirmPassword')?.value;
    return password === confirm ? null : { mismatch: true };
  }

  get passwordMismatch(): boolean | undefined {
    return this.registerForm.hasError('mismatch') &&
      this.registerForm.get('confirmPassword')?.touched;
  }

  public isInvalid(controlName: string): boolean {
    const control = this.registerForm.get(controlName);
    return !!(control && control.invalid && control.touched);
  }

  public onFileChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedImage = input.files[0];
      const reader = new FileReader();
      reader.onload = () => {
        this.imageBase64 = reader.result as string;
      };
      reader.readAsDataURL(this.selectedImage);
    }
  }

  public canDeactivate(): boolean {
    if (this.registerForm.dirty && !this.formSubmitted) {
      return confirm('You have unsaved changes. Close without saving?');
    }
    return true;
  }

  public onRegister(): void {
    if (this.registerForm.valid) {
      const formValue = this.registerForm.value;
      this.isLoading = true;

      const registerData: IRegister = {
        firstName: formValue.firstName,
        lastName: formValue.lastName,
        email: formValue.email,
        mobileNo: formValue.mobile,
        password: formValue.password,
        profileImageUrl: this.imageBase64 || null
      };
      this.formSubmitted = true;
      this.authService.register(registerData).subscribe({
        next: (response) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Registration Success',
            detail: response.message,
            life: 3000
          });
          this.router.navigateByUrl('/auth/login');
        },
        error: (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Registration Failed',
            detail: error?.error?.message || 'Something went wrong',
            life: 3000
          });
        }
      });
      this.onReset();
    }
  }

  public onReset(): void {
    this.registerForm.reset();
    this.selectedImage = null;

    const fileInput = document.getElementById('bookImage') as HTMLInputElement;
    if (fileInput) fileInput.value = '';
  }
}