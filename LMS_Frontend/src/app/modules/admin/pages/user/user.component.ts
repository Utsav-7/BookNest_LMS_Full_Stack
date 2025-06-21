import { Component } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})

export class UserComponent {
  public role: 'Administrator' | 'Librarian' = 'Administrator';
}