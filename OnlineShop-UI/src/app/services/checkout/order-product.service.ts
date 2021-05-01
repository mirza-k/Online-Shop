import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { environment } from 'src/environments/environment';
import { OrderProduct } from 'src/app/models/checkout/order-product.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class OrderProductService {
    baseUrl = environment.baseUrl;
    orderProductUrl = "api/OrderProduct";

    constructor(private http: HttpClient) { }

    post(orderProduct: OrderProduct) {
        return this.http.post<OrderProduct>(`${this.baseUrl}/${this.orderProductUrl}`, orderProduct);
    }

    get(orderId:number):Observable<OrderProduct[]>{
        return this.http.get<OrderProduct[]>(`${this.baseUrl}/${this.orderProductUrl}/${orderId}`);
    }
}
