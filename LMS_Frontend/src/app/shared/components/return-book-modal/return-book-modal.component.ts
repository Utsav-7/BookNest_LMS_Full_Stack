import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MessageService } from 'primeng/api';
import { ReturnService } from 'src/app/core/services/return.service';
import { IReturnRequest } from 'src/app/data/models/transaction/returnRequest';

@Component({
  selector: 'app-return-book-modal',
  templateUrl: './return-book-modal.component.html',
  styleUrls: ['./return-book-modal.component.scss']
})
export class ReturnBookModalComponent {
  public returnData: IReturnRequest = {
    borrowRequestId: 0,
    requestedBy: 0,
    rating: 0,
    comments: ''
  };

  @Input() showModal = false;
  @Output() closeModalEvent = new EventEmitter<void>();
  @Output() returnSubmittedEvent = new EventEmitter<void>();

  constructor(private returnService: ReturnService, private messageService: MessageService) { }

  @Input() set borrowRequestId(id: number) {
    this.returnData.borrowRequestId = id;
  }

  @Input() set requestedBy(id: number) {
    this.returnData.requestedBy = id;
  }

  public closeModal(): void {
    this.closeModalEvent.emit();
  }

  public submitForm(): void {
    this.returnService.addReturnRequest(this.returnData).subscribe({
      next: () => {
        this.returnSubmittedEvent.emit();
        this.closeModal();
      },
      error: (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to submit return request'
        })
      }
    });
  }
}