import { Component, OnInit } from '@angular/core';
import { ProductDto, ProductService } from '../../services/product.service';
import { SharedModule } from '../../shared/shared.module';

@Component({
  standalone: true,
  selector: 'product-list',
  imports: [SharedModule],
  templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit {
  products: ProductDto[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getProducts().subscribe(data => {
      this.products = data;
    });
  }
}
