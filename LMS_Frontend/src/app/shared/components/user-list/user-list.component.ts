import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessageService } from 'primeng/api';
import { UserService } from 'src/app/core/services/user.service';
import { IPatchOperation } from 'src/app/data/models/patchOperation';
import { IUser } from 'src/app/data/models/user/user';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})

export class UserListComponent implements OnInit {
  public users: IUser[] = [];
  public filteredUsers: IUser[] = [];
  public viewMode: 'table' | 'grid' = 'table';
  public searchTerm: string = '';
  public userType: 'students' | 'librarians' = 'students';
  public isLibrariansView: boolean = false;
  public isLoading: boolean = false;
  public loadingUserId: number | null = null;
  public showFormModal = false;
  public selectedUser: IUser | null = null;
  public isEditMode = false;

  @Input() role!: 'Administrator' | 'Librarian';

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private messageService: MessageService,
  ) { }

  public ngOnInit(): void {
    this.route.url.subscribe(urlSegments => {
      this.userType = (urlSegments[0]?.path === 'librarians' && this.role === 'Administrator') ?
        'librarians' : 'students';
      this.isLibrariansView = this.userType === 'librarians';
      this.loadUsers();
    });
  }

  public loadUsers(): void {
    this.isLoading = true;
    const serviceMethod = this.isLibrariansView ?
      this.userService.getUsersByRole('Librarian') :
      this.userService.getUsersByRole('Student');

    serviceMethod.subscribe({
      next: (response: any) => {
        this.users = response?.data || [];
        this.filteredUsers = [...this.users];
        this.isLoading = false;
      },
      error: (error) => {
        this.users = [];
        this.filteredUsers = [];
        this.messageService.add({
          severity: 'error',
          summary: 'Fetch Failed',
          detail: 'An error occurred while retrieving user data.',
          life: 4000
        });
        this.isLoading = false;
      }
    });
  }

  public applyFilters(): void {
    const term = this.searchTerm.toLowerCase().trim();

    if (term) {
      this.filteredUsers = this.users.filter(user => {
        return (
          user.firstName.toLowerCase().includes(term) ||
          user.lastName.toLowerCase().includes(term) ||
          user.email.toLowerCase().includes(term) ||
          (user.mobileNo && user.mobileNo.toLowerCase().includes(term))
        );
      });
    } else {
      this.filteredUsers = [...this.users];
    }
  }

  public getFullName(user: IUser): string {
    return `${user.firstName} ${user.lastName}`;
  }

  public deleteUser(userId: number): void {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(userId).subscribe({
        next: () => {
          this.loadUsers();
        },
        error: (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: error.message
          })
        }
      });
    }
  }

  public toggleStatus(user: IUser): void {
    const newStatus = !user.isActive;
    const patch: IPatchOperation[] = [
      {
        op: 'replace',
        path: '/isActive',
        value: newStatus
      }
    ];

    this.loadingUserId = user.id!;

    this.userService.patchUser(user.id!, patch).subscribe({
      next: () => {
        user.isActive = newStatus;
        this.loadingUserId = null;
      },
      error: () => {
        this.loadingUserId = null;
        user.isActive = !newStatus;
      }
    });
  }

  public handleUserSubmit(user: IUser): void {
    if (this.isEditMode) {
      this.userService.updateUser(user.id, user).subscribe({
        next: () => {
          this.closeFormModal();
          this.loadUsers();
        },
        error: (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: error.message
          });
        }
      });
    } else {
      this.userService.addUser(user).subscribe({
        next: () => {
          this.loadUsers();
          this.closeFormModal();
          this.messageService.add({
            severity: 'success',
            summary: 'Librarian Register',
            detail: 'Credentials sent to register Email-Id.'
          })
        },
        error: (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: error.message
          });
        }
      });
    }
  }

  public openAddUserForm(): void {
    this.isEditMode = false;
    this.selectedUser = null;
    this.showFormModal = true;
  }

  public openEditUserForm(user: IUser): void {
    this.isEditMode = true;
    this.selectedUser = JSON.parse(JSON.stringify(user));
    this.showFormModal = true;
  }

  public closeFormModal(): void {
    this.showFormModal = false;
    this.selectedUser = null;
  }
}