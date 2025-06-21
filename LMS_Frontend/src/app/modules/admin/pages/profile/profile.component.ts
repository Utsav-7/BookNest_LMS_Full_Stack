import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { UserService } from 'src/app/core/services/user.service';
import { IUser } from 'src/app/data/models/user/user';
import { TokenService } from 'src/app/shared/services/token.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})

export class ProfileComponent implements OnInit {
  public userData!: IUser;
  public userId: number = 0;

  constructor(
    private userService: UserService,
    private tokenService: TokenService,
    private messageService: MessageService
  ) { }

  public ngOnInit(): void {
    this.userId = Number(this.tokenService.getUserId());
    if (this.userId > 0) {
      this.loadProfile();
    } else {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'User not found',
      })
    }
  }

  public loadProfile(): void {
    this.userService.getUserById(this.userId).subscribe({
      next: (res) => {
        this.userData = res?.data;
      },
      error: (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Error loading user data',
        })
      }
    });
  }
}
