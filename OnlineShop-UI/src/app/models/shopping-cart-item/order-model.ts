import { OrderProduct } from "../checkout/order-product.model";

export class Order{
    orderId:number = 0;
    orderDate:Date = new Date();
    totalPrice!:number;
    userId!:string;
    shippingId!:number;
    shippingName!: string;
    products!:OrderProduct[];

    constructor(totalPrice:number,userId:string,shippingId:number){
        this.totalPrice = totalPrice;
        this.userId = userId;
        this.shippingId = shippingId;
    }

}