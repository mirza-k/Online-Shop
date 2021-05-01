import { ThisReceiver } from '@angular/compiler';
import { Guid } from 'guid-typescript';

export class BuyNowItem {
    buyNowItemId!: Guid;
    productId!: string;
    productName!: string;
    quantity!: number;
    productPrice!: number;
    totalPrice!: number;
    userId!: string;
    imageUrl!: string;
    sizeId!: number;
    categoryId!: number;
    sizeName!:string;

    constructor(quantity: number, productName: string, imageUrl: string, productPrice: number, productId: string, userId: string,
        sizeId: number,categoryId:number) {
        this.buyNowItemId = Guid.create();
        this.quantity = quantity;
        this.productPrice = productPrice;
        this.totalPrice = this.quantity * this.productPrice;
        this.productId = productId;
        this.userId = userId;
        this.productName = productName;
        this.imageUrl = imageUrl;
        this.sizeId = sizeId;
        this.categoryId = categoryId;
    }
}