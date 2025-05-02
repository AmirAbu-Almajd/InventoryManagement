import { Component, OnInit } from '@angular/core';
import { ProductDto, ProductService } from '../../services/product.service';
import { SharedModule } from '../../shared/shared.module';
import { CreateOrEditProductComponent } from './create-or-edit-product/create-or-edit-product.component';

@Component({
  standalone: true,
  selector: 'product-list',
  imports: [SharedModule, CreateOrEditProductComponent],
  templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit {

  products: ProductDto[] = [];
  drawerVisible = false;
  selectedProduct: ProductDto | null = null;
  
  openCreate() {
    this.selectedProduct = null;
    this.drawerVisible = true;
  }
  

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(data => {
      this.products = data;
    });
  }

  getProducts() {
    this.productService.getProducts().subscribe(data => {
      this.products = data;
    });
  }

  deleteProduct(product: any) {
    this.productService.deleteProduct(product.id).subscribe(() => {
      this.getProducts();
    });
  }

  editProduct(product: ProductDto) {
    this.selectedProduct = product;
    this.drawerVisible = true;
  }

  addProduct() {
    this.selectedProduct = null;
    this.drawerVisible = true;
  }
  
  handleSave() {
    this.drawerVisible = false;
    this.getProducts();
  }
}

