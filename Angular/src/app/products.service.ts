import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginationDTO } from './models/pagination.interface';
import { Observable } from 'rxjs';
import { ProductDTO } from './models/product.interface';
@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  changeActiveState(stan: boolean) {
    return this.httpClient.get<ProductDTO[]>('https://localhost:7016/api/Products/active?isActive=${stan}');
  }
  delete(id: number) {
    return false;
  }
  getProductById(id: number) {
    return this.httpClient.get<ProductDTO[]>('https://localhost:7016/api/Products/${id}');
  }

  constructor(private httpClient: HttpClient) { }

  public get(pagination: PaginationDTO): Observable<ProductDTO[]>{
    const params = new HttpParams()
      .set('page', pagination.page?.toString() ?? '1')
      .set('size', pagination.count?.toString() ?? '10'); // Użyj 'size' zamiast 'count'

    console.log('/paged', { params: params.toString() }); // Console log z poprawioną konwersją na string

    return this.httpClient.get<ProductDTO[]>('https://localhost:7016/api/Products/paged', { params });
  }

  public post(body: ProductDTO) : Observable<void>{
    return this.httpClient.post<void>('https://localhost:7016/api/Products', body);
  }
}
