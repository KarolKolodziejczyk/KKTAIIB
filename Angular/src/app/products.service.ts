import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginationDTO } from './models/pagination.interface';
import { Products } from './products/products.component';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(private httpClient: HttpClient) { }

  public get(pagination: PaginationDTO): Observable<Products[]>{
    /*const params = new HttpParams();
    params.set('page', pagination.page ?? 0);
    params.set('count', pagination.count ?? 10);*/

    return this.httpClient.get<Products[]>('https://localhost:7016/api/Products    ',{params:{
      page: pagination.page ?? 0,
      count: pagination.count ?? 10
    }});
  }

  public post(body: Products) : Observable<void>{
    return this.httpClient.post<void>('https://localhost:7016/api/Products', body);
  }
}
