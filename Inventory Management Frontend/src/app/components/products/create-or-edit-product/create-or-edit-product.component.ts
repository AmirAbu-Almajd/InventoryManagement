import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { ProductDto, ProductService } from '../../../services/product.service';
import { SharedModule } from '../../../shared/shared.module';

@Component({
  selector: 'app-create-or-edit-product',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './create-or-edit-product.component.html',
  styleUrl: './create-or-edit-product.component.css'
})

export class CreateOrEditProductComponent implements OnChanges, OnInit {
  @Input() visible: boolean = false;
  @Input() product: ProductDto | null = null;

  @Output() close = new EventEmitter<void>();
  @Output() save = new EventEmitter<ProductDto>();

  formData: ProductDto = {
    id: undefined,
    code: '',
    name: '',
    description: ''
  };
  
  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.formData = this.product
      ? { ...this.product }
      : { id: undefined, code: '', name: '', description: '' };
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['product']) {
      this.formData = this.product
        ? { ...this.product }
        : { id: '', code: '', name: '', description: '' };
    }
  }

  onSave(): void {
    if (this.formData?.id) {
      this.productService.updateProduct(this.formData).subscribe(() => {
        this.save.emit(this.formData);
      });
    } else {
      this.productService.createProduct(this.formData).subscribe(() => {
        this.save.emit(this.formData);
      });
    }
  }

  onClose(): void {
    this.close.emit();
  }
}