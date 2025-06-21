import { Component, inject } from '@angular/core';
import { TokenService } from 'src/app/shared/services/token.service';

@Component({
  selector: 'app-borrow-records',
  templateUrl: './borrow-records.component.html',
  styleUrls: ['./borrow-records.component.scss']
})

export class BorrowRecordsComponent {
  public currentUserRole: string = 'Administrator';
  public listTypes: "Borrow" | "Return" = 'Borrow'
}