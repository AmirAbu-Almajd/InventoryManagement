import { Component, OnInit } from '@angular/core';
import { ProductDto, ProductService } from '../../services/product.service';
import { ProductPriceDto, ProductPriceService } from '../../services/product-price.service';
import { SharedModule } from '../../shared/shared.module';
import { CreateOrEditProductPriceComponent } from './create-or-edit-product-price/create-or-edit-product-price.component';

@Component({
  standalone: true,
  selector: 'product-price-list',
  imports: [SharedModule, CreateOrEditProductPriceComponent],
  templateUrl: './product-price-list.component.html',
})
export class ProductPriceListComponent implements OnInit {
  productPrices: ProductPriceDto[] = [];
  allProducts: ProductDto[] = [];

  drawerVisible = false;
  selectedPrice: ProductPriceDto | null = null;

  constructor(
    private productPriceService: ProductPriceService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.productService.getProducts().subscribe(products => {
      this.allProducts = products;

      this.productPriceService.getProductPrices().subscribe(prices => {
        this.productPrices = prices;
      });
    });
  }

  addPrice() {
    this.selectedPrice = null;
    this.drawerVisible = true;
  }

  editPrice(price: ProductPriceDto) {
    this.selectedPrice = price;
    this.drawerVisible = true;
  }

  deletePrice(productPrice: ProductPriceDto) {
    if (productPrice.id !== undefined) {
      this.productPriceService.deleteProductPrice(productPrice.id).subscribe(() => {
        this.loadAll();
      });
    }
  }

  handleSave() {
    this.drawerVisible = false;
    this.loadAll();
  }
}
