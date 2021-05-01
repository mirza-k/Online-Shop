import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderProduct } from 'src/app/models/checkout/order-product.model';
import { Order } from 'src/app/models/shopping-cart-item/order-model';
import { OrderProductService } from 'src/app/services/checkout/order-product.service';
import { OrderService } from 'src/app/services/checkout/order.service';

@Component({
  selector: 'app-purchase-history',
  templateUrl: './purchase-history.component.html',
  styleUrls: ['./purchase-history.component.css']
})
export class PurchaseHistoryComponent implements OnInit {
  orders!: Order[];
  orderProducts!: OrderProduct[];
  currentPage = 1;
  numberOfItems = 5;
  userId = this.activatedRoute.snapshot.params['id'];
  numOfCollection=20;


  constructor(private orderService: OrderService, private OrderProductService: OrderProductService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {

    //get orders
    this.orderService.get(this.userId,this.currentPage,this.numberOfItems).subscribe((res: Order[]) => {
      this.orders = res;

      this.orderService.getByCount(this.userId).subscribe((res:number)=>{
        this.numOfCollection = res;
      })

      //get order-products
      this.orders.forEach(x => {
        this.OrderProductService.get(x.orderId).subscribe((res: OrderProduct[]) => {
          x.products = res;
        })
      })
    })
  }

  onPageNumberChange() {
    this.orderService.get(this.userId,this.currentPage,this.numberOfItems).subscribe((res:Order[])=>{
      this.orders = res;

      this.orders.forEach(x => {
        this.OrderProductService.get(x.orderId).subscribe((res: OrderProduct[]) => {
          x.products = res;
        })
      })
    })
    window.scroll(0,0);
  }

}
