import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderProduct } from 'src/app/models/checkout/order-product.model';
import { Transaction } from 'src/app/models/checkout/transaction.model';
import { ClothesSize } from 'src/app/models/product/clothes-size.model';
import { ShoeSize } from 'src/app/models/product/shoe-size.model';
import { BuyNowItem } from 'src/app/models/shopping-cart-item/buy-now-item.model';
import { Order } from 'src/app/models/shopping-cart-item/order-model';
import { shoppingCartItem } from 'src/app/models/shopping-cart-item/shoppingCartItem.model';
import { BuyNowItemService } from 'src/app/services/buy-now/buy-now.service';
import { OrderProductService } from 'src/app/services/checkout/order-product.service';
import { OrderService } from 'src/app/services/checkout/order.service';
import { TransactionService } from 'src/app/services/checkout/transaction.service';
import { JwtService } from 'src/app/services/jwt/jwt.service';
import { MessageService } from 'src/app/services/message/messages.service';
import { ClothesSizeService } from 'src/app/services/product/clothes-size.service';
import { ProductService } from 'src/app/services/product/product.service';
import { ShoppingCartItemsService } from 'src/app/services/shopping-cart-items/shopping-cart-items.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  buyNowItem!: BuyNowItem;
  shoppingCartItems!: shoppingCartItem[];
  activeUrl!: string;
  totalPrice!: number;
  successMessage!: string;
  totalWithoutCheckout:number=0;

  constructor(private buyNowService: BuyNowItemService, private productService: ProductService, private clothesSizeService: ClothesSizeService,
    private orderService: OrderService, private orderProductService: OrderProductService, private transactionService: TransactionService,
    private shoppingCartService: ShoppingCartItemsService, private router: Router, private messageService: MessageService, private jwtService: JwtService) { }

  shippingFree() {
    if (this.totalPrice > 100)
      return true;
    else
      return false;
  }

  ngOnInit(): void {
    let jwtToken: any = this.jwtService.getJwtTokenEncrypted();
    let userId = jwtToken.UserId;

    this.activeUrl = window.location.href;
    let searchResult = this.activeUrl.search('shopping-cart');

    if (searchResult == -1) {
      this.buyNowItem = this.buyNowService.buyNowItem;
      this.totalPrice = this.buyNowItem.totalPrice;
      if (this.totalPrice < 100){
        this.totalWithoutCheckout = this.totalPrice;  
        this.totalPrice += 5;
      }

      //set size property
      if (this.buyNowItem.categoryId == 1)
        this.productService.getShoeSizesById(this.buyNowItem.sizeId).subscribe((res: ShoeSize) => {
          this.buyNowItem.sizeName = res.name;
        })
      else
        this.clothesSizeService.getById(this.buyNowItem.sizeId).subscribe((res: ClothesSize) => {
          this.buyNowItem.sizeName = res.name;
        })
    }
    else
      this.shoppingCartService.get(userId).subscribe((res: shoppingCartItem[]) => {
        this.shoppingCartItems = res;
        this.totalPrice = this.shoppingCartItemsTotalPrice();

        //set size property
        this.shoppingCartItems.forEach(x => {
          if (x.categoryId == 1)
            this.productService.getShoeSizesById(x.shoesSizeId).subscribe((res: ShoeSize) => {
              x.shoeSize = res.name;
            })
          else
            this.clothesSizeService.getById(x.clothesSizeId).subscribe((res: ClothesSize) => {
              x.clothesSize = res.name;
            })
        })
      })
  }

  buyNowCheckout() {
    let jwtToken: any = this.jwtService.getJwtTokenEncrypted();
    let userId = jwtToken.UserId;

    let shippingId = 4;
    if (this.totalPrice < 100) {
      shippingId = 1;
    }


    //creating order
    let order = this.newOrderObject(this.totalPrice, userId, shippingId);
    this.orderService.post(order).subscribe((order: Order) => {

      //creating order-product
      let orderProduct = this.newOrderProductObject(this.buyNowItem.productPrice, this.buyNowItem.quantity, order.orderId, this.buyNowItem.productId);
      this.orderProductService.post(orderProduct).subscribe(orderProduct => {

        //creating transaction
        let transaction = this.newTransactionObject(this.totalPrice, userId, order.orderId);
        this.transactionService.post(transaction).subscribe(() => {

          this.successMessage = "Order successfully created!"
        })
      })
    })
  }

  shoppingCartItemsTotalPrice() {
    let total = 0;
    this.shoppingCartItems.forEach((x) => {
      total += x.totalPrice;
    });

    this.totalWithoutCheckout = total;

    if (total < 100)
      total += 5;

    return total;
  }

  newOrderProductObject(productPrice: number, qty: number, orderId: number, productId: string) {
    return new OrderProduct(productPrice, qty, orderId, productId);
  }

  newOrderObject(totalPrice: number, userId: string, shippingId: number) {
    return new Order(totalPrice, userId, shippingId);
  }

  newTransactionObject(totalPrice: number, userId: string, orderId: number) {
    return new Transaction(totalPrice, userId, orderId);
  }

  shoppingCartCheckout() {
    let jwtToken: any = this.jwtService.getJwtTokenEncrypted();
    let userId = jwtToken.UserId;

    //creating order
    let shippingId = 4;
    if (this.totalPrice < 100) {
      shippingId = 1;
    }


    let newOrder = this.newOrderObject(this.totalPrice, userId, shippingId);
    this.orderService.post(newOrder).subscribe((order: Order) => {

      //creating orderProduct
      this.shoppingCartItems.forEach(x => {
        let orderProduct = this.newOrderProductObject(x.productPrice, x.quantity, order.orderId, x.productId);
        this.orderProductService.post(orderProduct).subscribe();
      })

      //creating transaction
      let transaction = this.newTransactionObject(this.totalPrice, userId, order.orderId);
      this.transactionService.post(transaction).subscribe(() => {

        //deleting items from shopping cart
        this.shoppingCartItems.forEach(x => {
          this.shoppingCartService.delete(x.productId, x.userId).subscribe();
        })
        this.shoppingCartService.newShoppingCartItemNotification.emit(0)

        this.messageService.setOrderSuccessMessage("Order created successfully");
        this.router.navigate(['']);
      })
    })
  }

  onCheckout() {
    let searchResult = this.activeUrl.search('shopping-cart');

    if (searchResult == -1)
      this.buyNowCheckout();
    else
      this.shoppingCartCheckout();
  }
}
