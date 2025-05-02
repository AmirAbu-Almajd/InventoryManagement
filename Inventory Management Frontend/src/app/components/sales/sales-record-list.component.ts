import { Component, OnInit } from '@angular/core';
import { ProductDto, ProductService } from '../../services/product.service';
import { SharedModule } from '../../shared/shared.module';
import { SalesRecordDto, SalesRecordService } from '../../services/sales-record.service';
import { CreateOrEditSalesRecordComponent } from './create-or-edit-product-price/create-or-edit-sales-record.component';

@Component({
  standalone: true,
  selector: 'sales-record-list',
  imports: [SharedModule, CreateOrEditSalesRecordComponent],
  templateUrl: './sales-record-list.component.html',
})
export class SalesRecordListComponent implements OnInit {
  salesRecords: SalesRecordDto[] = [];
  allProducts: ProductDto[] = [];

  drawerVisible = false;
  selectedRecord: SalesRecordDto | null = null;

  constructor(
    private salesRecordService: SalesRecordService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.productService.getProducts().subscribe(products => {
      this.allProducts = products;

      this.salesRecordService.getSalesRecords().subscribe(records => {
        this.salesRecords = records;
      });
    });
  }

  addPrice() {
    this.selectedRecord = null;
    this.drawerVisible = true;
  }

  editPrice(price: SalesRecordDto) {
    this.selectedRecord = price;
    this.drawerVisible = true;
  }

  deletePrice(salesRecord: SalesRecordDto) {
    if (salesRecord.id !== undefined) {
      this.salesRecordService.deleteSalesRecord(salesRecord.id).subscribe(() => {
        this.loadAll();
      });
    }
  }

  handleSave() {
    this.drawerVisible = false;
    this.loadAll();
  }
}
