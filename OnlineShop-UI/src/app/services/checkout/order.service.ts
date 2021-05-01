import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { Observable } from 'rxjs';
import { Brand } from 'src/app/models/product/brand.model';
import { environment } from 'src/environments/environment';
import { Order } from 'src/app/models/shopping-cart-item/order-model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.baseUrl;
  orderUrl = "api/Order";

  constructor(private http: HttpClient) { }

  getByCount(userId:string){
    return this.http.get<number>("https://localhost:44351/count/"+userId);
  }

  post(order: Order): Observable<Order> {
    return this.http.post<Order>(`${this.baseUrl}/${this.orderUrl}`, order);
  }

  get(userId: string, currentPage: number, numberOfItems: number): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.baseUrl}/${this.orderUrl}/${userId},${currentPage},${numberOfItems}`);
  }

}
