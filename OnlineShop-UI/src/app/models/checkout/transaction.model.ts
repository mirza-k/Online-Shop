export class Transaction{
    transactionId:number=0;
    totalPrice!:number;
    transactionDate:Date = new Date();
    userId!:string;
    orderId!:number;

    constructor(totalPrice:number,userId:string,orderId:number){
        this.totalPrice = totalPrice;
        this.userId = userId;
        this.orderId = orderId;
    }
}