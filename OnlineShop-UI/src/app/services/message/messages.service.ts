import { EventEmitter, Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class MessageService {
    orderSuccessMessage: string = '';
    nowtAllowedToCheckoutAfterBuyNow="Please log in to order product."
    nowtAllowedToAddToShopCart="Please log in to add product in shopping cart."

    setOrderSuccessMessage(data: string) {
        this.orderSuccessMessage = data;
    }

    getOrderSuccessMessage() {
        return this.orderSuccessMessage;
    }
}
