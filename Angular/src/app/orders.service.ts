import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderDTO } from './models/Order.interface';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(private httpClient: HttpClient) { }

  public getUserOrders(id: number): Observable<OrderDTO[]> {
    return this.httpClient.get<OrderDTO[]>(`https://localhost:7016/api/Orders/user/${id}`);
  }

  public getAllOrders(id: number): Observable<OrderDTO[]> {
    return this.httpClient.get<OrderDTO[]>(`https://localhost:7016/api/Orders`);
  }

}
