import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { IResetPwd } from 'src/app/data/models/authentication/resetPwd';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})

export class ResetPasswordComponent {
  public otp: string[] = ['', '', '', '', '', ''];
  public password: string = '';
  public confirmPassword: string = '';
  public passwordError: string = '';
  public confirmPasswordError: string = '';
  public isResetModalVisible: boolean = true;

  @Input() email: string = '';
  @Output() close = new EventEmitter<void>();

  constructor(private authService: AuthService, private router: Router, private messageService: MessageService) { }

  public onOtpInput(index: number, event: Event): void {
    const input = event.target as HTMLInputElement;
    const value = input.value;

    if (/^\d$/.test(value)) {
      this.otp[index] = value;
      if (index < 5) {
        setTimeout(() => {
          const nextInput = document.getElementById(`otp-${index + 1}`) as HTMLInputElement;
          nextInput?.focus();
        }, 10);
      }
    } else {
      this.otp[index] = '';
    }
  }

  public onOtpKeyDown(index: number, event: KeyboardEvent): void {
    const input = event.target as HTMLInputElement;

    if (event.key === 'Backspace' && !input.value && index > 0) {
      const prevInput = document.getElementById(`otp-${index - 1}`) as HTMLInputElement;
      prevInput?.focus();
      prevInput?.select();
      event.preventDefault();
    }

    if (event.key === 'ArrowLeft' && index > 0) {
      const prevInput = document.getElementById(`otp-${index - 1}`) as HTMLInputElement;
      prevInput?.focus();
      event.preventDefault();
    } else if (event.key === 'ArrowRight' && index < 5) {
      const nextInput = document.getElementById(`otp-${index + 1}`) as HTMLInputElement;
      nextInput?.focus();
      event.preventDefault();
    }
  }

  public onSubmit(): void {
    this.passwordError = '';
    this.confirmPasswordError = '';

    const isPasswordEmpty = !this.password.trim();
    const isConfirmEmpty = !this.confirmPassword.trim();
    const isMismatch = this.password !== this.confirmPassword;

    if (isPasswordEmpty) {
      this.passwordError = 'Password is required and cannot be blank.';
    } else if (this.password.length < 6) {
      this.passwordError = 'Password must be at least 6 characters.';
    }

    if (isConfirmEmpty) {
      this.confirmPasswordError = 'Confirm Password is required.';
    } else if (!isPasswordEmpty && isMismatch) {
      this.confirmPasswordError = 'Passwords do not match';
    }

    if (this.passwordError || this.confirmPasswordError) {
      return;
    }

    const otpCode = parseInt(this.otp.join(''), 10);
    const resetRequest: IResetPwd = {
      email: this.email,
      otp: otpCode,
      newPassword: this.password,
      confirmPassword: this.confirmPassword
    };

    this.authService.resetPassword(resetRequest).subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Password Reset',
          detail: 'Your password has been successfully reset.',
          life: 3000
        });
        setTimeout(() => {
          this.router.navigate(['/auth/login']);
        }, 3000);
      },
      error: (error) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Reset Failed',
          detail: error?.error?.message || 'Something went wrong. Please try again.',
          life: 3000
        });
      }
    });

    this.closeModal();
  }

  public closeModal(): void {
    this.isResetModalVisible = false;
    this.close.emit();
  }
} 