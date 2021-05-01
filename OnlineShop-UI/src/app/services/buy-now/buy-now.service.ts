import { EventEmitter, Injectable } from '@angular/core';
import { BuyNowItem } from 'src/app/models/shopping-cart-item/buy-now-item.model';

@Injectable({
    providedIn: 'root'
})
export class BuyNowItemService {
    buyNowItem!:BuyNowItem;

    constructor() { }

}
