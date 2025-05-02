import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { ProductDto } from '../../../services/product.service';
import { StockRecordDto, StockRecordService } from '../../../services/stock-record.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-create-or-edit-stock-record',
  standalone: true,
  providers: [MessageService],
  imports: [SharedModule],
  templateUrl: './create-or-edit-stock-record.component.html',
  styleUrl: './create-or-edit-stock-record.component.css'
})
export class CreateOrEditStockRecordComponent implements OnInit {
  @Input() visible: boolean = false;
  @Input() stockRecord: StockRecordDto | null = null;
  @Input() allProducts: ProductDto[] = [];
  @Input() existingStocks: StockRecordDto[] = [];

  @Output() close = new EventEmitter<void>();
  @Output() save = new EventEmitter<StockRecordDto>();

  formData = {
    productId: '',
    quantity: 0
  };

  availableProducts: ProductDto[] = [];

  constructor(private stockRecordService: StockRecordService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  ngOnChanges(): void {
    this.initializeForm();
  }

  initializeForm() {
    const usedIds = this.existingStocks.map(p => p.productDto?.id);
    this.availableProducts = this.allProducts.filter(p =>
      this.stockRecord?.productDto?.id === p.id || !usedIds.includes(p.id)
    );

    this.formData = this.stockRecord
      ? {
        productId: this.stockRecord.productDto?.id || '',
        quantity: this.stockRecord.quantity
      }
      : {
        productId: '',
        quantity: 0
      };
  }

  onSave(): void {
    const stockRecordDto: StockRecordDto = {
      id: this.stockRecord?.id,
      productDto: {
        id: this.formData.productId,
        code: '',
        name: '',
        description: ''
      } as ProductDto,
      quantity: this.formData.quantity
    };

    const req$ = this.stockRecord?.id
      ? this.stockRecordService.updateStockRecord(stockRecordDto)
      : this.stockRecordService.createStockRecord(stockRecordDto);

    req$.subscribe(
      (e) => this.save.emit()
      , (err) => {
        const message =
          err?.error?.title || err?.error || 'An unexpected error occurred.';
        this.messageService.add({
          severity: 'error',
          summary: 'Stock Error',
          detail: message,
          life: 5000
        });
        console.error('My Error:', err);
      })
  }

  onClose(): void {
    this.close.emit();
  }
}
