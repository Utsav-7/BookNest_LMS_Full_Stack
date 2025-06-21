import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['forgot-password.component.scss']
})

export class ForgotPasswordComponent {
  public email: string = '';
  public isForgotPasswordModalVisible: boolean = true;
  public isLoading: boolean = false;

  @Output() emailSubmitted = new EventEmitter<string>();
  @Output() close = new EventEmitter<void>();

  public onSubmit(): void {
    if (this.email) {
      this.isLoading = true;
      this.emailSubmitted.emit(this.email);
    }
  }

  public closeModal(): void {
    this.close.emit();
  }
}