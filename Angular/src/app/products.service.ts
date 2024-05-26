import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginationDTO } from './models/pagination.interface';
import { Observable } from 'rxjs';
import { ProductDTO } from './models/product.interface';
@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClient: HttpClient) { }

  public get(pagination: PaginationDTO): Observable<ProductDTO[]>{
    /*const params = new HttpParams();
    params.set('page', pagination.page ?? 0);
    params.set('count', pagination.count ?? 10);*/

    return this.httpClient.get<ProductDTO[]>('https://localhost:7016/api/Products',{params:{
      page: pagination.page ?? 0,
      count: pagination.count ?? 10
    }});
  }

  public post(body: ProductDTO) : Observable<void>{
    return this.httpClient.post<void>('https://localhost:7016/api/Products', body);
  }
}
