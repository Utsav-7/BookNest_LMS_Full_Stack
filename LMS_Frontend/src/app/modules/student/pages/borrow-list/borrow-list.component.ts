import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-borrow-list',
  templateUrl: './borrow-list.component.html',
  styleUrls: ['./borrow-list.component.scss']
})

export class BorrowListComponent implements OnInit {
  public currentUserRole: string = 'Student';
  public listTypes: "Borrow" | "Return" = 'Borrow'
  public userId!: number;

  public ngOnInit() {
    const id = sessionStorage.getItem('userId');
    this.userId = parseInt(id!);
  }
}