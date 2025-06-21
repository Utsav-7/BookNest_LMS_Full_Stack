import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { IForgotPwd } from 'src/app/data/models/authentication/forgotPwd';
import { ILoginResponse } from 'src/app/data/models/authentication/loginResponse';
import { AuthService } from 'src/app/shared/services/auth.service';
import { TokenService } from 'src/app/shared/services/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  public isLoading: boolean = false;
  public loginData = {
    email: '',
    password: ''
  };

  public showForgotModal: boolean = false;
  public submittedEmail: IForgotPwd = { email: '' };
  public showResetModal: boolean = false;

  constructor(
    private authService: AuthService,
    private messageService: MessageService,
    private router: Router,
    private tokenService: TokenService
  ) { }

  public onLogin(): void {
    this.isLoading = true;

    this.authService.login(this.loginData).subscribe({
      next: (response: ILoginResponse) => {
        const isLoginSuccessful = this.tokenService.processLoginResponse(response);

        if (isLoginSuccessful) {
          this.messageService.add({
            severity: 'success',
            summary: 'Login Success',
            detail: response.message || 'Login successful',
            life: 3000
          });
        } else {
          this.messageService.add({
            severity: 'error',
            summary: 'Login Error',
            detail: response.message || 'Authentication failed',
            life: 3000
          });
        }
        this.isLoading = false;
      },
      error: (error) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Login Failed',
          detail: error?.error?.message || 'Something went wrong',
          life: 3000
        });
        this.isLoading = false;
      }
    });
  }

  public onReset(): void {
    this.loginData = {
      email: '',
      password: ''
    };
  }

  public openForgotModal(): void {
    this.showForgotModal = false;

    setTimeout(() => {
      this.showForgotModal = true;
    }, 0);
  }

  public handleEmail(email: string): void {
    this.submittedEmail.email = email;

    this.authService.forgotPassword(this.submittedEmail).subscribe({
      next: (response) => {
        this.messageService.add({
          severity: 'success',
          summary: 'OTP Sent',
          detail: 'OTP has been sent successfully to your email.',
          life: 3000
        });

        this.showForgotModal = false;
        this.showResetModal = true;
      },
      error: (error) => {
        this.messageService.add({
          severity: 'error',
          summary: 'OTP Send Failed',
          detail: error?.error?.message || 'Failed to send OTP. Please try again.',
          life: 4000
        });
      }
    });
  }
}