export class OrderProduct {
    productPrice!: number;
    quantity!: number
    orderId!: number;
    productId!: string;
    productName!:string;
    imageUrl!:string;
    //will be set automatically in DB
    orderProductId: number = 0;

    constructor(productPrice:number,quantity:number,orderId:number,productId:string){
        this.productId = productId;
        this.quantity = quantity;
        this.orderId = orderId;
        this.productPrice = productPrice;
    }
}
