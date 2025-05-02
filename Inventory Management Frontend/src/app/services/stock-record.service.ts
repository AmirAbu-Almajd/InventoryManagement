import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDto } from './product.service';

export interface StockRecord {
  id: number;
  productId: string;
  quantity: number;
}

export interface StockRecordDto {
  id?: number;
  productDto?: ProductDto;
  quantity: number;
}

@Injectable({
  providedIn: 'root'
})
export class StockRecordService {
  private apiUrl = 'https://localhost:44373/api/stockRecord'; 

  constructor(private http: HttpClient) {}

  getStockRecords(): Observable<StockRecordDto[]> {
    return this.http.get<StockRecordDto[]>(this.apiUrl);
  }

  getStockRecord(id: number): Observable<StockRecordDto> {
    return this.http.get<StockRecordDto>(`${this.apiUrl}/${id}`);
  }

  createStockRecord(dto: StockRecordDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/create/`, dto);
  }

  updateStockRecord(dto: StockRecordDto): Observable<any> {
    return this.http.put(`${this.apiUrl}/update/`, dto);
  }

  deleteStockRecord(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
