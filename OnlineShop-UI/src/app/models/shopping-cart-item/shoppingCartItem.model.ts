export class shoppingCartItem {
    quantity!: number;
    productPrice!: number;
    addedInCartDate!: Date;
    totalPrice!: number;
    productId!: string;
    userId!: string;
    productName: string = "";
    username: string = "";
    shoeSize!: string;
    clothesSize!: string;
    imageUrl!:string;
    subCategory!:string;
    color!:string;
    shoesSizeId!:number;
    clothesSizeId!:number;
    categoryId!:number;


    constructor(quantity: number, productPrice: number, productId: string, userId: string,shoesizeId:number,clothesSizeId:number) {
        this.quantity = quantity;
        this.productPrice = productPrice;
        this.addedInCartDate = new Date();
        this.totalPrice = this.quantity * this.productPrice;
        this.productId = productId;
        this.userId = userId;
        this.shoesSizeId = shoesizeId;
        this.clothesSizeId = clothesSizeId;
    }
}