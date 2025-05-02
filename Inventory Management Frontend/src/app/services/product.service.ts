import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Product {
  id: string;
  code: string;
  name: string;
}

export interface ProductDto {
  code: string;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:44373/api/product'; 

  constructor(private http: HttpClient) {}

  getProducts(): Observable<ProductDto[]> {
    return this.http.get<ProductDto[]>(this.apiUrl);
  }

  getProduct(id: string): Observable<ProductDto> {
    return this.http.get<ProductDto>(`${this.apiUrl}/${id}`);
  }

  createProduct(product: ProductDto): Observable<any> {
    return this.http.post(this.apiUrl, product);
  }

  updateProduct(product: ProductDto): Observable<any> {
    return this.http.put(this.apiUrl, product);
  }

  deleteProduct(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
