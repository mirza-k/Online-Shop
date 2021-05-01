import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { shoppingCartItem } from 'src/app/models/shopping-cart-item/shoppingCartItem.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartItemsService {
  newShoppingCartItemNotification = new EventEmitter<number>();
  onChangeQuantityValueNotification = new EventEmitter<boolean>();
  countingQuantityErors: { productId: string, valid: boolean }[] = [];


  baseUrl = environment.baseUrl;
  shoppingItemCartUrl = 'api/ShoppingCartItem';


  constructor(private http: HttpClient) { }

  post(data: shoppingCartItem) {
    return this.http.post<shoppingCartItem>(`${this.baseUrl}/${this.shoppingItemCartUrl}`, data);
  }

  get(userId: string): Observable<shoppingCartItem[]> {
    return this.http.get<shoppingCartItem[]>('https://localhost:44351/api/ShoppingCartItem/User/' + userId);
  }

  delete(productId: string, userId: string) {
    return this.http.delete(`${this.baseUrl}/${this.shoppingItemCartUrl}/${productId},${userId}`);
  }

  update(obj: shoppingCartItem) {
    return this.http.put(`${this.baseUrl}/${this.shoppingItemCartUrl}`, obj);
  }


}
