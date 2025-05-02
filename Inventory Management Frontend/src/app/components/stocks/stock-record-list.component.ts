import { Component, OnInit } from '@angular/core';
import { ProductDto, ProductService } from '../../services/product.service';
import { SharedModule } from '../../shared/shared.module';
import { StockRecordDto, StockRecordService } from '../../services/stock-record.service';
import { CreateOrEditStockRecordComponent } from './create-or-edit-stock-record/create-or-edit-stock-record.component';

@Component({
  standalone: true,
  selector: 'stock-record-list',
  imports: [SharedModule, CreateOrEditStockRecordComponent],
  templateUrl: './stock-record-list.component.html',
})
export class StockRecordListComponent implements OnInit {
  stockRecords: StockRecordDto[] = [];
  allProducts: ProductDto[] = [];

  drawerVisible = false;
  selectedRecord: StockRecordDto | null = null;

  constructor(
    private stockRecordService: StockRecordService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.productService.getProducts().subscribe(products => {
      this.allProducts = products;

      this.stockRecordService.getStockRecords().subscribe(records => {
        this.stockRecords = records;
      });
    });
  }

  addPrice() {
    this.selectedRecord = null;
    this.drawerVisible = true;
  }

  editPrice(price: StockRecordDto) {
    this.selectedRecord = price;
    this.drawerVisible = true;
  }

  deletePrice(stockRecord: StockRecordDto) {
    if (stockRecord.id !== undefined) {
      this.stockRecordService.deleteStockRecord(stockRecord.id).subscribe(() => {
        this.loadAll();
      });
    }
  }

  handleSave() {
    this.drawerVisible = false;
    this.loadAll();
  }
}
