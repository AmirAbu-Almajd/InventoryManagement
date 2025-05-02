import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { ProductDto } from '../../../services/product.service';
import { SalesRecordDto, SalesRecordService } from '../../../services/sales-record.service';

@Component({
  selector: 'app-create-or-edit-sales-record',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './create-or-edit-sales-record.component.html',
  styleUrl: './create-or-edit-sales-record.component.css'
})
export class CreateOrEditSalesRecordComponent implements OnInit {
  @Input() visible: boolean = false;
  @Input() salesRecord: SalesRecordDto | null = null;
  @Input() allProducts: ProductDto[] = [];

  @Output() close = new EventEmitter<void>();
  @Output() save = new EventEmitter<SalesRecordDto>();

  formData = {
    productId: '',
    quantity: 0,
    amount: 0
  };

  constructor(private salesRecordService: SalesRecordService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  ngOnChanges(): void {
    this.initializeForm();
  }

  initializeForm() {

    this.formData = this.salesRecord
      ? {
        productId: this.salesRecord.productDto?.id || '',
        quantity: this.salesRecord.quantity,
        amount: this.salesRecord.amount || 0
      }
      : {
        productId: '',
        quantity: 0,
        amount: 0
      };
  }

  onSave(): void {
    const salesRecordDto: SalesRecordDto = {
      id: this.salesRecord?.id,
      productDto: {
        id: this.formData.productId,
        code: '',
        name: '',
        description: ''
      } as ProductDto,
      amount: this.formData.amount,
      quantity: this.formData.quantity
    };

    const req$ = this.salesRecord?.id
      ? this.salesRecordService.updateSalesRecord(salesRecordDto)
      : this.salesRecordService.createSalesRecord(salesRecordDto);

    req$.subscribe(() => {
      this.save.emit(salesRecordDto);
    });
  }

  onClose(): void {
    this.close.emit();
  }
}
