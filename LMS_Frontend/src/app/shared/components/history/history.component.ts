import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { TransactionService } from 'src/app/core/services/transaction.service';
import { ITransactionHistory } from 'src/app/data/models/transaction/transactionHistory';
import { TokenService } from '../../services/token.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})

export class HistoryComponent implements OnInit {
  public transactions: ITransactionHistory[] = [];
  public filteredTransactions: ITransactionHistory[] = [];
  public isLoading = true;
  public viewMode: 'table' | 'grid' = 'table';
  public searchTerm = '';
  public statusFilter = 'all';

  constructor(
    private transactionService: TransactionService,
    private messageService: MessageService,
    private tokenService: TokenService
  ) { }

  public ngOnInit(): void {
    this.loadTransactions();
  }

  public loadTransactions(): void {
    this.isLoading = true;
    var userId = Number(this.tokenService.getUserId());
    console.log(userId);

    this.transactionService.getTransactionByUserId(userId).subscribe({
      next: (transactions) => {
        this.transactions = transactions;
        this.applyFilters();
        this.isLoading = false;
      },
      error: (err) => {
        let errorMessage = 'Failed to transaction';

        if (typeof err === 'string') {
          errorMessage = err;
        } else if (err.error && typeof err.error === 'string') {
          errorMessage = err.error;
        } else if (err.message) {
          errorMessage = err.message;
        }

        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: errorMessage,
          life: 5000
        });
        this.isLoading = false;
      }
    });
  }

  public applyFilters(): void {
    let filtered = this.transactions;

    if (this.searchTerm) {
      const term = this.searchTerm.toLowerCase();
      filtered = filtered.filter(t =>
        t.title.toLowerCase().includes(term) ||
        t.status.toLowerCase().includes(term)
      );
    }

    if (this.statusFilter !== 'all') {
      filtered = filtered.filter(t => t.status === this.statusFilter);
    }

    this.filteredTransactions = filtered;
  }
}