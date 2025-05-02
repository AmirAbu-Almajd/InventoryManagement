import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDto } from './product.service';

export interface SalesRecord {
  id: number;
  productId: string;
  quantity: number;
  amount: number;
}

export interface SalesRecordDto {
  id?: number;
  productDto?: ProductDto;
  quantity: number;
  amount: number;
}

@Injectable({
  providedIn: 'root'
})
export class SalesRecordService {
  private apiUrl = 'https://localhost:44373/api/salesRecord'; 

  constructor(private http: HttpClient) {}

  getSalesRecords(): Observable<SalesRecordDto[]> {
    return this.http.get<SalesRecordDto[]>(this.apiUrl);
  }

  getSalesRecord(id: number): Observable<SalesRecordDto> {
    return this.http.get<SalesRecordDto>(`${this.apiUrl}/${id}`);
  }

  createSalesRecord(dto: SalesRecordDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/create/`, dto);
  }

  updateSalesRecord(dto: SalesRecordDto): Observable<any> {
    return this.http.put(`${this.apiUrl}/update/`, dto);
  }

  deleteSalesRecord(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
