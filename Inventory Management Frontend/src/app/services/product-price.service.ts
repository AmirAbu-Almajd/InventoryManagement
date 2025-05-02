import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDto } from './product.service';

export interface ProductPrice {
  id: number;
  productId: string;
  price: number;
}

export interface ProductPriceDto {
  id?: number;
  productDto?: ProductDto;
  price: number;
}

@Injectable({
  providedIn: 'root'
})
export class ProductPriceService {
  private apiUrl = 'https://localhost:44373/api/productprice'; 

  constructor(private http: HttpClient) {}

  getProductPrices(): Observable<ProductPriceDto[]> {
    return this.http.get<ProductPriceDto[]>(this.apiUrl);
  }

  getProductPrice(id: number): Observable<ProductPriceDto> {
    return this.http.get<ProductPriceDto>(`${this.apiUrl}/${id}`);
  }

  createProductPrice(dto: ProductPriceDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/create/`, dto);
  }

  updateProductPrice(dto: ProductPriceDto): Observable<any> {
    return this.http.put(`${this.apiUrl}/update/`, dto);
  }

  deleteProductPrice(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
