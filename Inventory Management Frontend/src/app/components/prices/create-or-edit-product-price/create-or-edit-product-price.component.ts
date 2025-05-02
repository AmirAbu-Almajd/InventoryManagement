import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { ProductDto } from '../../../services/product.service';
import { ProductPriceDto, ProductPriceService } from '../../../services/product-price.service';

@Component({
  selector: 'app-create-or-edit-product-price',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './create-or-edit-product-price.component.html',
  styleUrl: './create-or-edit-product-price.component.css'
})
export class CreateOrEditProductPriceComponent implements OnInit {
  @Input() visible: boolean = false;
  @Input() productPrice: ProductPriceDto | null = null;
  @Input() allProducts: ProductDto[] = [];
  @Input() existingPrices: ProductPriceDto[] = [];

  @Output() close = new EventEmitter<void>();
  @Output() save = new EventEmitter<ProductPriceDto>();

  formData = {
    productId: '',
    price: 0
  };

  availableProducts: ProductDto[] = [];

  constructor(private productPriceService: ProductPriceService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  ngOnChanges(): void {
    this.initializeForm();
  }

  initializeForm() {
    const usedIds = this.existingPrices.map(p => p.productDto?.id);
    this.availableProducts = this.allProducts.filter(p =>
      this.productPrice?.productDto?.id === p.id || !usedIds.includes(p.id)
    );

    this.formData = this.productPrice
      ? {
        productId: this.productPrice.productDto?.id || '',
        price: this.productPrice.price
      }
      : {
        productId: '',
        price: 0
      };
  }

  onSave(): void {
    const productPriceDto: ProductPriceDto = {
      id: this.productPrice?.id,
      productDto: {
        id: this.formData.productId,
        code: '',
        name: '',
        description: ''
      } as ProductDto,
      price: this.formData.price
    };

    const req$ = this.productPrice?.id
      ? this.productPriceService.updateProductPrice(productPriceDto)
      : this.productPriceService.createProductPrice(productPriceDto);

    req$.subscribe(() => {
      this.save.emit(productPriceDto);
    });
  }

  onClose(): void {
    this.close.emit();
  }
}
